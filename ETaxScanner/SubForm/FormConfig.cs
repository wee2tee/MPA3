using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETaxScanner.Model;
using ETaxScanner.Misc;
using System.IO;

namespace ETaxScanner.SubForm
{
    public partial class FormConfig : Form
    {
        private Config config;
        private FORM_MODE form_mode;

        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.config = Config.LoadConfigValue();
            this.FillForm();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ)
            {
                if(MessageBox.Show("ข้อมูลที่ถูกแก้ไข จะไม่ถูกบันทึก, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnClosing(e);
        }

        private void FillForm()
        {
            this.txtExpressPath.Text = this.config.expressPath;
            this.chSunday.Checked = this.config.isSunday ? true : false;
            this.chMonday.Checked = this.config.isMonday ? true : false;
            this.chTuesday.Checked = this.config.isTuesday ? true : false;
            this.chWednesday.Checked = this.config.isWednesday ? true : false;
            this.chThursday.Checked = this.config.isThursday ? true : false;
            this.chFriday.Checked = this.config.isFriday ? true : false;
            this.chSaturday.Checked = this.config.isSaturday ? true : false;
            this.dtTimeFrom.Text = this.config.timeFrom.ToString();
            this.dtTimeTo.Text = this.config.timeTo.ToString();
            this.numRepeat.Value = this.config.repeatTime;
            this.txtSmtpHost.Text = this.config.smtpHost;
            this.numSmtpPort.Value = this.config.smtpPort;
            this.txtSmtpUser.Text = this.config.smtpUser;
            this.txtSmtpPassword.Text = this.config.smtpPassword;
            this.chEnableSsl.Checked = this.config.enableSsl ? true : false;
            this.txtTimeStampEmail.Text = this.config.timeStampEmail;
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;
            this.txtExpressPath.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnBrowse.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chSunday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chMonday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chTuesday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chWednesday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chThursday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chFriday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chSaturday.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.dtTimeFrom.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.dtTimeTo.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numRepeat.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtSmtpHost.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numSmtpPort.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtSmtpUser.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtSmtpPassword.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.chEnableSsl.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtTimeStampEmail.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);

            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnCancel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.config = Config.LoadConfigValue();
            this.FillForm();
            this.ResetFormState(FORM_MODE.EDIT);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.config.expressPath))
            {
                MessageBox.Show("ค้นหาที่เก็บโปรแกรมเอ็กซ์เพรสตามที่ระบุไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.config.SaveConfig();
            this.ResetFormState(FORM_MODE.READ);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ResetFormState(FORM_MODE.READ);
            this.config = Config.LoadConfigValue();
            this.FillForm();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = false;
            fb.SelectedPath = Config.GetConfigFilePath();
            if(fb.ShowDialog() == DialogResult.OK)
            {
                this.txtExpressPath.Text = fb.SelectedPath;
            }
        }

        private void txtExpressPath_TextChanged(object sender, EventArgs e)
        {
            this.config.expressPath = ((TextBox)sender).Text;
        }

        private void chSunday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isSunday = ((CheckBox)sender).Checked ? true : false;
        }

        private void chMonday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isMonday = ((CheckBox)sender).Checked ? true : false;
        }

        private void chTuesday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isTuesday = ((CheckBox)sender).Checked ? true : false;
        }

        private void chWednesday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isWednesday = ((CheckBox)sender).Checked ? true : false;
        }

        private void chThursday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isThursday = ((CheckBox)sender).Checked ? true : false;
        }

        private void chFriday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isFriday = ((CheckBox)sender).Checked ? true : false;
        }

        private void chSaturday_CheckedChanged(object sender, EventArgs e)
        {
            this.config.isSaturday = ((CheckBox)sender).Checked ? true : false;
        }

        private void dtTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            this.config.timeFrom = TimeSpan.Parse(((DateTimePicker)sender).Text);
        }

        private void dtTimeTo_ValueChanged(object sender, EventArgs e)
        {
            this.config.timeTo = TimeSpan.Parse(((DateTimePicker)sender).Text);
        }

        private void numRepeat_ValueChanged(object sender, EventArgs e)
        {
            this.config.repeatTime = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void txtSmtpHost_TextChanged(object sender, EventArgs e)
        {
            this.config.smtpHost = ((TextBox)sender).Text;
        }

        private void numSmtpPort_ValueChanged(object sender, EventArgs e)
        {
            this.config.smtpPort = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void txtSmtpUser_TextChanged(object sender, EventArgs e)
        {
            this.config.smtpUser = ((TextBox)sender).Text;
        }

        private void txtSmtpPassword_TextChanged(object sender, EventArgs e)
        {
            this.config.smtpPassword = ((TextBox)sender).Text;
        }

        private void chEnableSsl_CheckedChanged(object sender, EventArgs e)
        {
            this.config.enableSsl = ((CheckBox)sender).Checked;
        }

        private void txtTimeStampEmail_TextChanged(object sender, EventArgs e)
        {
            this.config.timeStampEmail = ((TextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if(this.form_mode == FORM_MODE.EDIT && !(this.btnSave.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
