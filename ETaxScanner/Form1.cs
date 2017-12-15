using System;
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

namespace ETaxScanner
{
    public partial class Form1 : Form
    {
        private FORM_MODE form_mode; // FORM_MODE.EDIT = stop, FORM_MODE.READ = running
        private System.Windows.Forms.Timer timer = null;
        private Config config;
        private string scanned_file_name = @"\eTaxInvoice\inv.dbf";
        private bool in_process = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetControlState(FORM_MODE.EDIT);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var company_list = Helper.Sccomp();


            DbfDataSet dbf = new DbfDataSet(@"d:\express\expressi\test");
            var artrn = dbf.Artrn.Where(a => a.docnum == "SR0000001").FirstOrDefault();
            string subject = string.Empty;
            if (artrn != null)
            {
                subject += artrn.docdat.Value.ToString("[ddMMyyyy]", CultureInfo.GetCultureInfo("th-TH"));
                subject += "[" + artrn.GetSubjectDocType(dbf) + "]";
                subject += "[" + artrn.docnum + "]";
            }

            Console.WriteLine(" ==> Start at " + DateTime.Now.ToString());
            if (this.CreateJson(@"d:\express\expressi\test", @"SR0000001", @"D:\Express\ExpressI\test\eTaxInvoice\json\SR0000001.json").Success)
            {
                if(this.CreateXml(@"d:\express\expressi\test\eTaxInvoice\json\SR0000001.json", @"D:\Express\ExpressI\test\eTaxInvoice\xml\SR0000001.xml").Success)
                {
                    if(this.CreatePdfA3(@"d:\express\expressi\test\eTaxInvoice\pdf\sample.pdf", @"D:\Express\ExpressI\test\eTaxInvoice\xml\SR0000001.xml", @"d:\express\expressi\test\eTaxInvoice\pdfa3\SR0000001.pdf", artrn.GetDocType(dbf)).Success)
                    {
                        Mailing m = new Mailing("weerawat.36@hotmail.com", subject, "", new string[] { @"d:\express\expressi\test\eTaxInvoice\pdfa3\SR0000001.pdf" });
                        if (m.Send())
                        {
                            Console.WriteLine(" ==> Send mail success");
                        }
                        else
                        {
                            Console.WriteLine(" ==> Send mail failed");
                        }
                        Console.WriteLine(" ==> Completed at " + DateTime.Now.ToString());
                        m = null;
                    }
                }
            }
            

            //Mailing m = new Mailing("weerawat.36@hotmail.com", "Test Email ทดสอบส่งอีเมล์", "This is a testing email นี่คืออีเมล์ทดสอบ", new string[] { @"D:\Express\ExpressI\eTaxInvoice\pdf\IV0000002.pdf" });
            //if (m.Send())
            //{
            //    Console.WriteLine("Success");
            //}
            //else
            //{
            //    Console.WriteLine("Failed");
            //}
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.config = Config.LoadConfigValue();

            this.SetControlState(FORM_MODE.READ);

            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = this.config.repeatTime * 5000 /*60000*/;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.in_process)
                return;

            //using (BackgroundWorker wrk = new BackgroundWorker())
            //{
            //    wrk.DoWork += delegate
            //}

            
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
    }

    public class CreateFileResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
