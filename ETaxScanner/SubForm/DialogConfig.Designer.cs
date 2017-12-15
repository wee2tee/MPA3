namespace ETaxScanner.SubForm
{
    partial class DialogConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpressPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numRepeat = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chSaturday = new System.Windows.Forms.CheckBox();
            this.chFriday = new System.Windows.Forms.CheckBox();
            this.chThursday = new System.Windows.Forms.CheckBox();
            this.chWednesday = new System.Windows.Forms.CheckBox();
            this.chTuesday = new System.Windows.Forms.CheckBox();
            this.chMonday = new System.Windows.Forms.CheckBox();
            this.chSunday = new System.Windows.Forms.CheckBox();
            this.dtTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chEnableSsl = new System.Windows.Forms.CheckBox();
            this.txtTimeStampEmail = new System.Windows.Forms.TextBox();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.txtSmtpUser = new System.Windows.Forms.TextBox();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numSmtpPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ที่เก็บโปรแกรมเอ็กซ์เพรส";
            // 
            // txtExpressPath
            // 
            this.txtExpressPath.Enabled = false;
            this.txtExpressPath.Location = new System.Drawing.Point(155, 19);
            this.txtExpressPath.MaxLength = 200;
            this.txtExpressPath.Name = "txtExpressPath";
            this.txtExpressPath.Size = new System.Drawing.Size(270, 21);
            this.txtExpressPath.TabIndex = 1;
            this.txtExpressPath.TextChanged += new System.EventHandler(this.txtExpressPath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(426, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ทำซ้ำทุก ๆ";
            // 
            // numRepeat
            // 
            this.numRepeat.Enabled = false;
            this.numRepeat.Location = new System.Drawing.Point(119, 86);
            this.numRepeat.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRepeat.Name = "numRepeat";
            this.numRepeat.Size = new System.Drawing.Size(92, 21);
            this.numRepeat.TabIndex = 11;
            this.numRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRepeat.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRepeat.ValueChanged += new System.EventHandler(this.numRepeat_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "นาที";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chSaturday);
            this.groupBox1.Controls.Add(this.chFriday);
            this.groupBox1.Controls.Add(this.chThursday);
            this.groupBox1.Controls.Add(this.chWednesday);
            this.groupBox1.Controls.Add(this.chTuesday);
            this.groupBox1.Controls.Add(this.chMonday);
            this.groupBox1.Controls.Add(this.chSunday);
            this.groupBox1.Controls.Add(this.dtTimeTo);
            this.groupBox1.Controls.Add(this.dtTimeFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numRepeat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 126);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ช่วงเวลาที่ให้โปรแกรมทำงาน";
            // 
            // chSaturday
            // 
            this.chSaturday.AutoSize = true;
            this.chSaturday.Enabled = false;
            this.chSaturday.Location = new System.Drawing.Point(401, 27);
            this.chSaturday.Name = "chSaturday";
            this.chSaturday.Size = new System.Drawing.Size(37, 17);
            this.chSaturday.TabIndex = 8;
            this.chSaturday.Text = "ส.";
            this.chSaturday.UseVisualStyleBackColor = true;
            this.chSaturday.CheckedChanged += new System.EventHandler(this.chSaturday_CheckedChanged);
            // 
            // chFriday
            // 
            this.chFriday.AutoSize = true;
            this.chFriday.Enabled = false;
            this.chFriday.Location = new System.Drawing.Point(356, 27);
            this.chFriday.Name = "chFriday";
            this.chFriday.Size = new System.Drawing.Size(37, 17);
            this.chFriday.TabIndex = 7;
            this.chFriday.Text = "ศ.";
            this.chFriday.UseVisualStyleBackColor = true;
            this.chFriday.CheckedChanged += new System.EventHandler(this.chFriday_CheckedChanged);
            // 
            // chThursday
            // 
            this.chThursday.AutoSize = true;
            this.chThursday.Enabled = false;
            this.chThursday.Location = new System.Drawing.Point(304, 27);
            this.chThursday.Name = "chThursday";
            this.chThursday.Size = new System.Drawing.Size(43, 17);
            this.chThursday.TabIndex = 6;
            this.chThursday.Text = "พฤ.";
            this.chThursday.UseVisualStyleBackColor = true;
            this.chThursday.CheckedChanged += new System.EventHandler(this.chThursday_CheckedChanged);
            // 
            // chWednesday
            // 
            this.chWednesday.AutoSize = true;
            this.chWednesday.Enabled = false;
            this.chWednesday.Location = new System.Drawing.Point(258, 27);
            this.chWednesday.Name = "chWednesday";
            this.chWednesday.Size = new System.Drawing.Size(37, 17);
            this.chWednesday.TabIndex = 5;
            this.chWednesday.Text = "พ.";
            this.chWednesday.UseVisualStyleBackColor = true;
            this.chWednesday.CheckedChanged += new System.EventHandler(this.chWednesday_CheckedChanged);
            // 
            // chTuesday
            // 
            this.chTuesday.AutoSize = true;
            this.chTuesday.Enabled = false;
            this.chTuesday.Location = new System.Drawing.Point(213, 27);
            this.chTuesday.Name = "chTuesday";
            this.chTuesday.Size = new System.Drawing.Size(37, 17);
            this.chTuesday.TabIndex = 4;
            this.chTuesday.Text = "อ.";
            this.chTuesday.UseVisualStyleBackColor = true;
            this.chTuesday.CheckedChanged += new System.EventHandler(this.chTuesday_CheckedChanged);
            // 
            // chMonday
            // 
            this.chMonday.AutoSize = true;
            this.chMonday.Enabled = false;
            this.chMonday.Location = new System.Drawing.Point(169, 27);
            this.chMonday.Name = "chMonday";
            this.chMonday.Size = new System.Drawing.Size(36, 17);
            this.chMonday.TabIndex = 3;
            this.chMonday.Text = "จ.";
            this.chMonday.UseVisualStyleBackColor = true;
            this.chMonday.CheckedChanged += new System.EventHandler(this.chMonday_CheckedChanged);
            // 
            // chSunday
            // 
            this.chSunday.AutoSize = true;
            this.chSunday.Enabled = false;
            this.chSunday.Location = new System.Drawing.Point(119, 27);
            this.chSunday.Name = "chSunday";
            this.chSunday.Size = new System.Drawing.Size(42, 17);
            this.chSunday.TabIndex = 2;
            this.chSunday.Text = "อา.";
            this.chSunday.UseVisualStyleBackColor = true;
            this.chSunday.CheckedChanged += new System.EventHandler(this.chSunday_CheckedChanged);
            // 
            // dtTimeTo
            // 
            this.dtTimeTo.CustomFormat = "HH:mm";
            this.dtTimeTo.Enabled = false;
            this.dtTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeTo.Location = new System.Drawing.Point(195, 54);
            this.dtTimeTo.Name = "dtTimeTo";
            this.dtTimeTo.ShowUpDown = true;
            this.dtTimeTo.Size = new System.Drawing.Size(59, 21);
            this.dtTimeTo.TabIndex = 10;
            this.dtTimeTo.ValueChanged += new System.EventHandler(this.dtTimeTo_ValueChanged);
            // 
            // dtTimeFrom
            // 
            this.dtTimeFrom.CustomFormat = "HH:mm";
            this.dtTimeFrom.Enabled = false;
            this.dtTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeFrom.Location = new System.Drawing.Point(119, 54);
            this.dtTimeFrom.Name = "dtTimeFrom";
            this.dtTimeFrom.ShowUpDown = true;
            this.dtTimeFrom.Size = new System.Drawing.Size(59, 21);
            this.dtTimeFrom.TabIndex = 9;
            this.dtTimeFrom.ValueChanged += new System.EventHandler(this.dtTimeFrom_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "ช่วงเวลา";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "วัน";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Image = global::ETaxScanner.Properties.Resources.edit_16;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(119, 390);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnEdit.Size = new System.Drawing.Size(72, 30);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::ETaxScanner.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(197, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSave.Size = new System.Drawing.Size(72, 30);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "บันทึก";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(275, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel.Size = new System.Drawing.Size(72, 30);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chEnableSsl);
            this.groupBox2.Controls.Add(this.txtTimeStampEmail);
            this.groupBox2.Controls.Add(this.txtSmtpPassword);
            this.groupBox2.Controls.Add(this.txtSmtpUser);
            this.groupBox2.Controls.Add(this.txtSmtpHost);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numSmtpPort);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(12, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 196);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ตั้งค่าอีเมล์";
            // 
            // chEnableSsl
            // 
            this.chEnableSsl.AutoSize = true;
            this.chEnableSsl.Enabled = false;
            this.chEnableSsl.Location = new System.Drawing.Point(119, 121);
            this.chEnableSsl.Name = "chEnableSsl";
            this.chEnableSsl.Size = new System.Drawing.Size(78, 17);
            this.chEnableSsl.TabIndex = 16;
            this.chEnableSsl.Text = "Enable SSL";
            this.chEnableSsl.UseVisualStyleBackColor = true;
            this.chEnableSsl.CheckedChanged += new System.EventHandler(this.chEnableSsl_CheckedChanged);
            // 
            // txtTimeStampEmail
            // 
            this.txtTimeStampEmail.Enabled = false;
            this.txtTimeStampEmail.Location = new System.Drawing.Point(169, 160);
            this.txtTimeStampEmail.MaxLength = 50;
            this.txtTimeStampEmail.Name = "txtTimeStampEmail";
            this.txtTimeStampEmail.Size = new System.Drawing.Size(267, 21);
            this.txtTimeStampEmail.TabIndex = 17;
            this.txtTimeStampEmail.TextChanged += new System.EventHandler(this.txtTimeStampEmail_TextChanged);
            // 
            // txtSmtpPassword
            // 
            this.txtSmtpPassword.Enabled = false;
            this.txtSmtpPassword.Location = new System.Drawing.Point(119, 93);
            this.txtSmtpPassword.MaxLength = 50;
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.PasswordChar = '*';
            this.txtSmtpPassword.Size = new System.Drawing.Size(243, 21);
            this.txtSmtpPassword.TabIndex = 15;
            this.txtSmtpPassword.TextChanged += new System.EventHandler(this.txtSmtpPassword_TextChanged);
            // 
            // txtSmtpUser
            // 
            this.txtSmtpUser.Enabled = false;
            this.txtSmtpUser.Location = new System.Drawing.Point(119, 70);
            this.txtSmtpUser.MaxLength = 50;
            this.txtSmtpUser.Name = "txtSmtpUser";
            this.txtSmtpUser.Size = new System.Drawing.Size(243, 21);
            this.txtSmtpUser.TabIndex = 14;
            this.txtSmtpUser.TextChanged += new System.EventHandler(this.txtSmtpUser_TextChanged);
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Enabled = false;
            this.txtSmtpHost.Location = new System.Drawing.Point(119, 24);
            this.txtSmtpHost.MaxLength = 100;
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(243, 21);
            this.txtSmtpHost.TabIndex = 12;
            this.txtSmtpHost.TextChanged += new System.EventHandler(this.txtSmtpHost_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "User Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "SMTP Port No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "SMTP Host Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "อีเมล์หน่วยงานประทับรับรองเวลา";
            // 
            // numSmtpPort
            // 
            this.numSmtpPort.Enabled = false;
            this.numSmtpPort.Location = new System.Drawing.Point(119, 47);
            this.numSmtpPort.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numSmtpPort.Name = "numSmtpPort";
            this.numSmtpPort.Size = new System.Drawing.Size(92, 21);
            this.numSmtpPort.TabIndex = 13;
            this.numSmtpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSmtpPort.ValueChanged += new System.EventHandler(this.numSmtpPort_ValueChanged);
            // 
            // DialogConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 435);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtExpressPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpressPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numRepeat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTimeFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTimeTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chSaturday;
        private System.Windows.Forms.CheckBox chFriday;
        private System.Windows.Forms.CheckBox chThursday;
        private System.Windows.Forms.CheckBox chWednesday;
        private System.Windows.Forms.CheckBox chTuesday;
        private System.Windows.Forms.CheckBox chMonday;
        private System.Windows.Forms.CheckBox chSunday;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimeStampEmail;
        private System.Windows.Forms.TextBox txtSmtpPassword;
        private System.Windows.Forms.TextBox txtSmtpUser;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chEnableSsl;
        private System.Windows.Forms.NumericUpDown numSmtpPort;
    }
}