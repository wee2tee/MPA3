using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ETaxScanner.Model
{
    public class SccompDbf
    {
        public string compnam { get; set; }
        public string compcod { get; set; }
        public string path { get; set; }
        public DateTime? gendat { get; set; }
        public string candel { get; set; }

        public string abs_path
        {
            get
            {
                string path_txt = string.Empty;

                if ((this.path.Length >= 3 && this.path.Substring(1, 2) == @":\") || this.path.StartsWith(@"\\"))
                {
                    path_txt = this.path;
                }
                else
                {
                    DirectoryInfo dir_info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    string absolute_path = dir_info.Parent.FullName + @"\" + this.path;
                    path_txt = absolute_path;
                }

                return path_txt.TrimEnd('\\')/* + @"\"*/;
            }
        }
    }
}
