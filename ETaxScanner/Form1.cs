﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETaxScanner.SubForm;
using ETaxScanner.Misc;
using ETaxScanner.Model;
using System.Diagnostics;
using System.Threading;
using System.IO;
using MPA3.Model;
using System.Globalization;
using System.Data.OleDb;
using System.Reflection;
using System.Data.SQLite;

namespace ETaxScanner
{
    public partial class Form1 : Form
    {
        private bool is_on_system_tray = false;
        private FORM_MODE form_mode; // FORM_MODE.EDIT = stop, FORM_MODE.READ = running
        private System.Windows.Forms.Timer timer = null;
        private Config config;
        private string scanned_file_name = @"\eTaxInvoice\inv.dbf";
        private bool in_process = false;
        private List<PdfJob> job_list;
        private enum JOB_STATE : int
        {
            NEW = 0,
            SENDED = 1
        }
        private BindingList<Log> logs;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetControlState(FORM_MODE.EDIT);
            this.btnShowLog.PerformClick();
        }

        private void SetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnConfig.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStart.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            DialogConfig conf = new DialogConfig();
            conf.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.config = Config.LoadConfigValue();

            this.SetControlState(FORM_MODE.READ);

            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = this.config.repeatTime * 60000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            this.Timer_Tick(sender, e);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.in_process)
            {
                //new Log { Time = DateTime.Now, DataPath = string.Empty, Description = "Skip new job because previous job is in process" }.SaveLog();
                return;
            }

            List<DateTimeDoJob> date_do_job = this.GetDateDoJob();
            TimeSpan this_time = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss", CultureInfo.GetCultureInfo("th-TH")));

            // Check if current time is in working time configured.
            if(date_do_job.Where(d => (int)d.dayOfWeek == (int)DateTime.Now.DayOfWeek && d.startTime.CompareTo(this_time) <= 0 && d.endTime.CompareTo(this_time) >= 0).FirstOrDefault() == null)
            {
                // Just skip this job
                return;
            }

            this.in_process = true;
            this.job_list = new List<PdfJob>();
            var company_list = Helper.Sccomp();
            if(company_list == null)
            {
                Console.WriteLine("Cannot find sccomp.dbf, please make sure \"Express program path\" is configure correctly");
                return;
            }

            foreach (var comp in company_list)
            {
                if(File.Exists(comp.abs_path + this.scanned_file_name))
                {
                    List<Inv> jobs = DbfDataSet.Inv(comp.abs_path + this.scanned_file_name).Where(j => j.status == ((int)JOB_STATE.NEW).ToString()).ToList();
                    foreach (var job in jobs)
                    {
                        this.job_list.Add(new PdfJob
                        {
                            DataPath = comp.abs_path,
                            Docnum = job.docnum,
                            Email = job.email,
                            SendTime = null,
                            //Success = false
                        });
                    }
                }
            }

            using (BackgroundWorker wrk = new BackgroundWorker())
            {
                wrk.DoWork += delegate
                {
                    for (int i = 0; i < this.job_list.Count; i++)
                    {
                        var send_result = this.CreateFileAndSendMail(this.job_list[i].DataPath, this.job_list[i].Docnum, this.job_list[i].Email);
                        if (send_result.Success)
                        {
                            this.job_list[i].SendTime = DateTime.Now;
                            if(this.UpdateJobState(this.job_list[i], JOB_STATE.SENDED) == true)
                            {
                                Log log = new Log { Time = this.job_list[i].SendTime.Value, DataPath = this.job_list[i].DataPath, Description = "Sending document # " + this.job_list[i].Docnum + " to email " + this.job_list[i].Email + " success." };
                                log.SaveLog();
                                this.dgvLog.Invoke(new Action(() =>
                                {
                                    ((BindingList<Log>)this.dgvLog.DataSource).Add(log);
                                    this.dgvLog.FirstDisplayedScrollingRowIndex = this.dgvLog.Rows.Count - 1;
                                }));

                                Console.WriteLine(" -> Send " + this.job_list[i].DataPath + ":" + this.job_list[i].Docnum + " success at " + DateTime.Now.ToString());
                                continue;
                            }
                        }
                        else
                        {
                            throw new Exception(send_result.Message);
                        }
                    }
                };
                wrk.RunWorkerCompleted += delegate
                {
                    this.in_process = false;
                    Console.WriteLine(" ==> Send all documents success at " + DateTime.Now.ToString());
                    Console.WriteLine("");
                };
                wrk.RunWorkerAsync();
            }
        }

        private List<DateTimeDoJob> GetDateDoJob()
        {
            List<DateTimeDoJob> d = new List<DateTimeDoJob>();
            Config conf = Config.LoadConfigValue();
            if (conf.isSunday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Sunday, startTime = conf.timeFrom, endTime = conf.timeTo });
            if (conf.isMonday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Monday, startTime = conf.timeFrom, endTime = conf.timeTo });
            if (conf.isTuesday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Tuesday, startTime = conf.timeFrom, endTime = conf.timeTo });
            if (conf.isWednesday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Wednesday, startTime = conf.timeFrom, endTime = conf.timeTo });
            if (conf.isThursday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Thursday, startTime = conf.timeFrom, endTime = conf.timeTo });
            if (conf.isFriday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Friday, startTime = conf.timeFrom, endTime = conf.timeTo });
            if (conf.isSaturday)
                d.Add(new DateTimeDoJob { dayOfWeek = DayOfWeek.Saturday, startTime = conf.timeFrom, endTime = conf.timeTo });

            return d;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            this.SetControlState(FORM_MODE.EDIT);

            if(this.timer != null)
            {
                this.timer.Stop();
                this.timer.Enabled = false;
                this.timer.Dispose();
                this.timer = null;
            }
        }

        private bool UpdateJobState(PdfJob job, JOB_STATE job_state)
        {
            try
            {
                string data_path = Directory.GetParent(job.DataPath + this.scanned_file_name).FullName;
                string dbf_file_name = Path.GetFileNameWithoutExtension(job.DataPath + this.scanned_file_name);

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "Update " + dbf_file_name + " Set Status = '" + ((int)job_state).ToString() + "', SendDate = CTOD('" + job.SendTime.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'), SendTime = '" + job.SendTime.Value.ToString("HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + "' Where docnum='" + job.Docnum + "'";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return this.UpdateJobState(job, job_state);
            }
        }

        private CreateFileResult CreateFileAndSendMail(string data_path, string docnum, string customer_email)
        {
            try
            {
                DbfDataSet dbf = new DbfDataSet(data_path);
                var artrn = dbf.Artrn.Where(a => a.docnum == docnum).FirstOrDefault();

                if (artrn == null)
                    throw new Exception("Error : Document number " + docnum + " not found in data path " + data_path);

                string subject = string.Empty;
                subject += artrn.docdat.Value.ToString("[ddMMyyyy]", CultureInfo.GetCultureInfo("th-TH"));
                subject += "[" + artrn.GetSubjectDocType(dbf) + "]";
                subject += "[" + artrn.docnum + "]";

                //Console.WriteLine(" ==> Start at " + DateTime.Now.ToString());
                var json_result = this.CreateJson(data_path, docnum, data_path + @"\eTaxInvoice\json\" + docnum + ".json");
                if (json_result.Success)
                {
                    var xml_result = this.CreateXml(data_path + @"\eTaxInvoice\json\" + docnum + ".json", data_path + @"\eTaxInvoice\xml\" + docnum + ".xml");
                    if (xml_result.Success)
                    {
                        File.Delete(data_path + @"\eTaxInvoice\json\" + docnum + ".json");

                        var pdfa3_result = this.CreatePdfA3(data_path + @"\eTaxInvoice\pdf\" + docnum + ".pdf", data_path + @"\eTaxInvoice\xml\" + docnum + ".xml", data_path + @"\eTaxInvoice\pdfa3\" + docnum + ".pdf", artrn.GetDocType(dbf));
                        if (pdfa3_result.Success)
                        {
                            File.Delete(data_path + @"\eTaxInvoice\xml\" + docnum + ".xml");

                            Mailing m = new Mailing(customer_email, subject, "", new string[] { data_path + @"\eTaxInvoice\pdfa3\" + docnum + ".pdf" });
                            var mail_result = m.Send();
                            if (mail_result.Success)
                            {
                                //Console.WriteLine(" ==> Send mail success");
                                //Console.WriteLine(" ==> Completed at " + DateTime.Now.ToString());
                                m = null;
                                return new CreateFileResult { Success = true, Message = mail_result.Message };
                            }
                            else
                            {
                                //Console.WriteLine(" ==> Send mail failed");
                                //Console.WriteLine(" ==> Corupted at " + DateTime.Now.ToString());
                                return new CreateFileResult { Success = false, Message = mail_result.Message };
                            }
                        }
                        else
                        {
                            return pdfa3_result;
                        }
                    }
                    else
                    {
                        return xml_result;
                    }
                }
                else
                {
                    return json_result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private CreateFileResult CreateJson(string data_path, string docnum, string destination_json_path)
        {
            string json_result = string.Empty;
            using (Process proc = new Process())
            {
                proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "MPA3.exe",
                    Arguments = @"json " + data_path + " " + docnum + " " + destination_json_path, 
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    json_result = proc.StandardOutput.ReadLine();
                    Console.WriteLine(" :: Json Result ==> " + json_result + " at " + DateTime.Now.ToString());
                }
            }

            if(json_result.ToLower() == "success")
            {
                return new CreateFileResult { Success = true, Message = json_result };
            }
            else
            {
                return new CreateFileResult { Success = false, Message = json_result };
            }
        }

        private CreateFileResult CreateXml(string json_file_path, string destination_xml_path)
        {
            string xml_result = string.Empty;
            using (Process proc = new Process())
            {
                proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "MPA3.exe",
                    Arguments = @"xml " + json_file_path + " " + destination_xml_path,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    xml_result = proc.StandardOutput.ReadLine();
                    Console.WriteLine(" :: Xml Result ==> " + xml_result + " at " + DateTime.Now.ToString());
                }
            }

            if(xml_result.ToLower() == "success")
            {
                return new CreateFileResult { Success = true, Message = xml_result };
            }
            else
            {
                return new CreateFileResult { Success = false, Message = xml_result };
            }
        }

        private CreateFileResult CreatePdfA3(string simple_pdf_path, string xml_embeded_path, string destination_pdf_path, string doc_type)
        {
            string pdf_result = string.Empty;
            using (Process proc = new Process())
            {
                proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "MPA3.exe",
                    Arguments = @"pdf " + simple_pdf_path + " " + xml_embeded_path + " " + Helper.GetAppFolderName() + @"\res\sRGB_Color_Space_Profile.icm" + " " + destination_pdf_path + " " + doc_type + " " + Path.GetFileName(xml_embeded_path) + " " + "2.0",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    pdf_result = proc.StandardOutput.ReadLine();
                    Console.WriteLine(" :: Pdf Result ==> " + pdf_result + " at " + DateTime.Now.ToString());
                }
            }

            if (pdf_result.ToLower() == "success")
            {
                return new CreateFileResult { Success = true, Message = pdf_result };
            }
            else
            {
                return new CreateFileResult { Success = false, Message = pdf_result };
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.is_on_system_tray)
            {
                this.is_on_system_tray = true;
                e.Cancel = true;

                Hide();
                NotifyIcon n = new NotifyIcon();
                n.Icon = ETaxScanner.Properties.Resources.tongue_16;
                n.Text = "eTax Scanner";
                n.Visible = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_show = new MenuItem("Show main window");
                mnu_show.Click += delegate
                {
                    this.Show();
                    n.Visible = false;
                    this.is_on_system_tray = false;
                };
                cm.MenuItems.Add(mnu_show);
                MenuItem mnu_exit = new MenuItem("Quit");
                mnu_exit.Click += delegate
                {
                    if(MessageBox.Show("Quit e-Tax Scanner", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        n.Visible = false;
                        this.Close();
                    }
                };
                cm.MenuItems.Add(mnu_exit);
                n.ContextMenu = cm;

                n.ShowBalloonTip(4000, "e-Tax Scanner", "e-Tax Scanner is still running, you can show main window or quit by clicking the icon on system tray.", ToolTipIcon.Info);
                n.BalloonTipIcon = ToolTipIcon.Info;
                n.BalloonTipText = "Right click to show context menu";
                n.MouseUp += delegate (object obj, MouseEventArgs ev)
                {
                    if(ev.Button == MouseButtons.Left)
                    {
                        MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                        mi.Invoke(n, null);
                    }
                };
            }
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            this.logs = new BindingList<Log>(this.GetLog());
            this.dgvLog.DataSource = logs;
        }

        private List<Log> GetLog()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + Helper.GetAppFolderName() + @"\eTax.log;Version=3"))
                {
                    conn.Open();
                    string date_string = this.dtLogDate.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US"));
                    string sql = "Select time, data_path, description From islog Where date(time) >= date('" + date_string + "')";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    List<Log> logs = new List<Log>();

                    while (rdr.Read())
                    {
                        logs.Add(new Log
                        {
                            Time = DateTime.Parse((string)rdr["time"], CultureInfo.GetCultureInfo("en-US")),
                            DataPath = (string)rdr["data_path"],
                            Description = (string)rdr["description"]
                        });
                    }
                    conn.Close();

                    return logs;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class CreateFileResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class DateTimeDoJob
    {
        public DayOfWeek dayOfWeek { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
    }
    
    public class PdfJob
    {
        public string DataPath { get; set; }
        public string Docnum { get; set; }
        public string Email { get; set; }
        //public bool Success { get; set; }
        public DateTime? SendTime { get; set; }
    }

    public class Log
    {
        public DateTime Time { get; set; }
        public string DataPath { get; set; }
        public string Description { get; set; }
    }
}
