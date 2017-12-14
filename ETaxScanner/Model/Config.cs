using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace ETaxScanner.Model
{
    public class Config
    {
        public string expressPath { get; set; }
        public bool isSunday { get; set; }
        public bool isMonday { get; set; }
        public bool isTuesday { get; set; }
        public bool isWednesday { get; set; }
        public bool isThursday { get; set; }
        public bool isFriday { get; set; }
        public bool isSaturday { get; set; }
        public TimeSpan timeFrom { get; set; }
        public TimeSpan timeTo { get; set; }
        public int repeatTime { get; set; }

        public string smtpHost { get; set; }
        public int smtpPort { get; set; }
        public string smtpUser { get; set; }
        public string smtpPassword { get; set; }
        public bool enableSsl { get; set; }
        public string timeStampEmail { get; set; }


        public static string GetConfigFilePath()
        {
            return Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        }


        public static Config LoadConfigValue()
        {
            try
            {
                List<Config> config_list = new List<Config>();

                if (!File.Exists(GetConfigFilePath() + @"\eTax.conf"))
                {
                    SQLiteConnection.CreateFile(GetConfigFilePath() + @"\eTax.conf");
                }

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + GetConfigFilePath() + @"\eTax.conf;Version=3;Password=esg.co.th"))
                {
                    conn.Open();
                    conn.ChangePassword("esg.co.th");
                    string sql = "Create table if not exists config (express_path varchar(200) default '', is_sunday boolean default 1, is_monday boolean default 1, is_tuesday boolean default 1, is_wednesday boolean default 1, is_thursday boolean default 1, is_friday boolean default 1, is_saturday boolean default 1, start varchar(5) default '00:00', end varchar(5) default '23:59', repeat_time int(7) default 5, smtp_host varchar(100) default '', smtp_port int(7) default 587, smtp_user varchar(50) default '', smtp_password varchar(50) default '', enable_ssl boolean default 1, timestamp_email varchar(50) default '')";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //List<Config> config = new List<Config>();
                    sql = "Select count(*) as cnt from config";
                    cmd = new SQLiteCommand(sql, conn);
                    int rows = 0;
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        rows = rdr.GetInt32(0);
                    }

                    if (rows == 0)
                    {
                        sql = @"Insert into config (express_path, is_sunday, is_monday, is_tuesday, is_wednesday, is_thursday, is_friday, is_saturday, start, end, repeat_time, smtp_host, smtp_port, smtp_user, smtp_password, enable_ssl, timestamp_email) values ('', 1, 1, 1, 1, 1, 1, 1, '00:00', '23:59', 5, '', 587, '', '', 1, '')";
                        cmd = new SQLiteCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }

                    sql = "Select * from config";
                    cmd = new SQLiteCommand(sql, conn);
                    rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        config_list.Add(new Config
                        {
                            expressPath = Convert.ToString(rdr["express_path"]),
                            isSunday = Convert.ToBoolean(rdr["is_sunday"]),
                            isMonday = Convert.ToBoolean(rdr["is_monday"]),
                            isTuesday = Convert.ToBoolean(rdr["is_tuesday"]),
                            isWednesday = Convert.ToBoolean(rdr["is_wednesday"]),
                            isThursday = Convert.ToBoolean(rdr["is_thursday"]),
                            isFriday = Convert.ToBoolean(rdr["is_friday"]),
                            isSaturday = Convert.ToBoolean(rdr["is_saturday"]),
                            timeFrom = TimeSpan.Parse(Convert.ToString(rdr["start"])),
                            timeTo = TimeSpan.Parse(Convert.ToString(rdr["end"])),
                            repeatTime = (int)rdr["repeat_time"],
                            smtpHost = Convert.ToString(rdr["smtp_host"]),
                            smtpPort = (int)rdr["smtp_port"],
                            smtpUser = Convert.ToString(rdr["smtp_user"]),
                            smtpPassword = Convert.ToString(rdr["smtp_password"]),
                            enableSsl = Convert.ToBoolean(rdr["enable_ssl"]),
                            timeStampEmail = Convert.ToString(rdr["timestamp_email"])
                        });
                    }

                    conn.Close();
                }

                return config_list.First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public bool SaveConfig()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + GetConfigFilePath() + @"\eTax.conf;Version=3;Password=esg.co.th"))
                {
                    conn.Open();
                    conn.ChangePassword("esg.co.th");
                    string sql = "Update config Set express_path = @expresspath, is_sunday = @sunday, is_monday = @monday, is_tuesday = @tuesday, is_wednesday = @wednesday, is_thursday = @thursday, is_friday = @friday, is_saturday = @saturday, is_sunday = @sunday, start = @start, end = @end, repeat_time = @repeat, smtp_host = @smtphost, smtp_port = @smtpport, smtp_user = @smtpuser, smtp_password = @smtppassword, enable_ssl = @enablessl, timestamp_email = @timestampemail";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@expresspath", this.expressPath);
                    cmd.Parameters.AddWithValue("@sunday", this.isSunday);
                    cmd.Parameters.AddWithValue("@monday", this.isMonday);
                    cmd.Parameters.AddWithValue("@tuesday", this.isTuesday);
                    cmd.Parameters.AddWithValue("@wednesday", this.isWednesday);
                    cmd.Parameters.AddWithValue("@thursday", this.isThursday);
                    cmd.Parameters.AddWithValue("@friday", this.isFriday);
                    cmd.Parameters.AddWithValue("@saturday", this.isSaturday);
                    cmd.Parameters.AddWithValue("@start", this.timeFrom.ToString());
                    cmd.Parameters.AddWithValue("@end", this.timeTo.ToString());
                    cmd.Parameters.AddWithValue("@repeat", this.repeatTime);
                    cmd.Parameters.AddWithValue("@smtphost", this.smtpHost);
                    cmd.Parameters.AddWithValue("@smtpport", this.smtpPort);
                    cmd.Parameters.AddWithValue("@smtpuser", this.smtpUser);
                    cmd.Parameters.AddWithValue("@smtppassword", this.smtpPassword);
                    cmd.Parameters.AddWithValue("@enablessl", this.enableSsl);
                    cmd.Parameters.AddWithValue("@timestampemail", this.timeStampEmail);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
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
