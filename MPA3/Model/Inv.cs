using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetDBF;
using System.IO;

namespace MPA3.Model
{
    public class Inv
    {
        public string data_path { get; set; }
        public string docnum { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }
}
