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

namespace ETaxScanner
{
    public partial class Form1 : Form
    {
        private FORM_MODE form_mode; // FORM_MODE.EDIT = stop, FORM_MODE.READ = running
        private Timer timer = null;
        private Config config;
        private string scanned_file_name = @"\pdf\inv.dbf"; 

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
            FormConfig conf = new FormConfig();
            conf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            this.timer = new Timer();
            timer.Interval = this.config.repeatTime * 60000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
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
    }
}
