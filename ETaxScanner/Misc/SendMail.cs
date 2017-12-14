using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ETaxScanner.Model;
using System.Windows.Forms;

namespace ETaxScanner.Misc
{
    public class Mailing
    {
        //public string smtpHost { get; set; }
        //public int smtpPort { get; set; }
        //public string smtpUser { get; set; }
        //public string smtpPassword { get; set; }
        //public string mailFrom { get; set; }
        //public string mailTo { get; set; }
        //public string subject { get; set; }
        //public string body { get; set; }
        //public List<Attachment> attachment { get; set; }

        private SmtpClient client;
        private MailMessage mailMessage;
        private Config config;

        public Mailing(string mailTo, string subject, string body, string[] attach_file_path)
        {
            try
            {
                config = Config.LoadConfigValue();

                client = new SmtpClient()
                {
                    Host = config.smtpHost,
                    Port = config.smtpPort,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(config.smtpUser, config.smtpPassword),
                    EnableSsl = config.enableSsl,
                };

                mailMessage = new MailMessage(this.config.smtpUser, mailTo, subject, body);
                mailMessage.CC.Add(config.timeStampEmail);
                if (attach_file_path.Count() > 0)
                {
                    foreach (string file_path in attach_file_path)
                    {
                        mailMessage.Attachments.Add(new Attachment(file_path));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Send()
        {
            try
            {
                this.client.Send(this.mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
