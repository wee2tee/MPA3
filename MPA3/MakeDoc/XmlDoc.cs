using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MPA3.MakeDoc
{
    public class XmlDoc
    {
        private string json_source_path = null;
        private string destination_xml_path = null;

        public XmlDoc(string json_source_path = null, string destination_xml_path = null)
        {
            this.json_source_path = json_source_path;
            this.destination_xml_path = destination_xml_path;
        }

        public CreateXmlResult CreateXml()
        {
            string command = "java";
            string arguments = "-jar " + AppDomain.CurrentDomain.BaseDirectory + "GenXML.jar " + this.json_source_path + " " + this.destination_xml_path;

            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (output.ToLower().Contains("success"))
            {
                return new CreateXmlResult { createSuccess = true, message = output };
            }
            else
            {
                return new CreateXmlResult { createSuccess = false, message = output };
            }
        }

    }

    public class CreateXmlResult
    {
        public bool createSuccess { get; set; }
        public string message { get; set; }
    }
}
