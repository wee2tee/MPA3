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

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + GetConfigFilePath() + @"\eTax.conf;Version=3;"))
                {
                    conn.Open();
                    string sql = "Create table if not exists config (express_path varchar(200) default '', is_sunday boolean default 1, is_monday boolean default 1, is_tuesday boolean default 1, is_wednesday boolean default 1, is_thursday boolean default 1, is_friday boolean default 1, is_saturday boolean default 1, start varchar(5) default '00:00', end varchar(5) default '23:59', repeat_time int(7) default 1)";
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
                        sql = @"Insert into config (express_path, is_sunday, is_monday, is_tuesday, is_wednesday, is_thursday, is_friday, is_saturday, start, end, repeat_time) values ('', 1, 1, 1, 1, 1, 1, 1, '00:00', '23:59', 1)";
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
                            repeatTime = (int)rdr["repeat_time"]
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
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + GetConfigFilePath() + @"\eTax.conf;Version=3;"))
                {
                    conn.Open();
                    string sql = "Update config Set express_path = @expresspath, is_sunday = @sunday, is_monday = @monday, is_tuesday = @tuesday, is_wednesday = @wednesday, is_thursday = @thursday, is_friday = @friday, is_saturday = @saturday, is_sunday = @sunday, start = @start, end = @end, repeat_time = @repeat";
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
