using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MkP
{
    public class PdfDoc
    {
        private string pdf_file_path = null;
        private string xml_file_path = null;
        private string color_profile_file_path = null;
        private string output_pdfa3_file_path = null;
        private string document_type = null; // etc. Tax_Invoice, Credit_Note, Debit_Note 
        private string document_file_name = null; // etc. ETDA-invoice.xml
        private string document_version = null; // etc. 2.0

        public PdfDoc(string pdf_file_path = null, string xml_file_path = null, string color_profile_file_path = null, string output_pdfa3_file_path = null, string document_type = null, string document_file_name = null, string document_version = null)
        {
            this.pdf_file_path = pdf_file_path;
            this.xml_file_path = xml_file_path;
            this.color_profile_file_path = color_profile_file_path;
            this.output_pdfa3_file_path = output_pdfa3_file_path;
            this.document_type = document_type;
            this.document_file_name = document_file_name;
            this.document_version = document_version;
        }

        public CreatePdfResult CreatePdf()
        {
            string command = "java";
            string arguments = "-jar " + AppDomain.CurrentDomain.BaseDirectory + "PdfAConverter.jar " + this.pdf_file_path + " " + this.xml_file_path + " " + this.color_profile_file_path + " " + this.output_pdfa3_file_path + " " + this.document_type + " " + this.document_file_name + " " + this.document_version;

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
                return new CreatePdfResult { createSuccess = true, message = output };
            }
            else
            {
                return new CreatePdfResult { createSuccess = false, message = output };
            }
        }
    }

    public class CreatePdfResult
    {
        public bool createSuccess { get; set; }
        public string message { get; set; }
    }
}
