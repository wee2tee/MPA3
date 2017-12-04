using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MPA3.MakeDoc;
using MPA3.Model;
using Newtonsoft.Json;
using System.IO;
//using MkX;
//using MkP;

namespace MPA3
{
    class Program
    {
        /**
         * args[0] = process type "XML" / "PDF"
         * 
         * XML_PROCESS
         * args[1] = path to source json file
         * args[2] = path to store xml result file
         * 
         * PDF_PROCESS
         * args[1] = path to original pdf file
         * args[2] = path to xml embeded file
         * args[3] = path to color profile file
         * args[4] = path to destination output file
         * args[5] = document type
         * args[6] = document file name (named xml file embeded)
         * args[7] = document version
         * */

        //private const string XML_PROCESS = "XML";
        //private const string PDF_PROCESS = "PDF";
        public enum PROCESS_TYPE
        {
            JSON,
            XML,
            PDF
        }

        static void Main(string[] args)
        {
            /** TEST **/
            //try
            //{
            //    List<Inv> inv_list = DbfTable.Inv();
            //    Inv inv = inv_list.Where(i => i.status == "0").First();
            //    JsonModel json = new JsonModel(inv.data_path, inv.docnum);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error : " + ex.Message);
            //}

            /* args.Length = 3 for JSON/XML, 8 for PDF */
            if (!(args != null && (/*args.Length == 2 || */args.Length == 3 || args.Length == 8)))
            {
                Console.WriteLine("Error : Arguments not specified completely!");
                return;
            }
            else
            {
                if(!(args[0].ToUpper().Trim() == PROCESS_TYPE.JSON.ToString() || args[0].ToUpper().Trim() == PROCESS_TYPE.XML.ToString() || args[0].ToUpper().Trim() == PROCESS_TYPE.PDF.ToString()))
                {
                    Console.WriteLine("Error : Process type is incorrect!");
                    return;
                }

                try
                {
                    // Create JSON file
                    if (args[0].ToUpper().Trim() == PROCESS_TYPE.JSON.ToString())
                    {
                        if (args.Length < 3)
                        {
                            Console.WriteLine("Error : Arguments not specified completely!");
                            return;
                        }

                        string data_path = args[1];
                        string docnum = args[2];
                        DbfTable dbf = new DbfTable(data_path);
                        var artrn = dbf.Artrn.Where(a => a.docnum == docnum).FirstOrDefault();
                        if (artrn != null)
                        {
                            JsonModel json = new JsonModel(data_path, docnum);
                            var result = json.WriteToFile(@"json\" + docnum + ".json");
                            if (result.createSuccess)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Error : " + result.message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error : document # " + docnum + " not found");
                        }

                        return;
                    }

                    // Create XML file
                    if (args[0].ToUpper().Trim() == PROCESS_TYPE.XML.ToString())
                    {
                        if(args.Length < 3)
                        {
                            Console.WriteLine("Error : Arguments not specified completely!");
                            return;
                        }

                        string json_path = args[1];
                        string dest_xml = args[2];

                        XmlDoc xml = new XmlDoc(json_path, dest_xml);
                        var result = xml.CreateXml();

                        if (result.createSuccess)
                        {
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Error : " + result.message);
                        }
                        return;
                    }

                    // Create PDF file
                    if(args[0].ToUpper().Trim() == PROCESS_TYPE.PDF.ToString())
                    {
                        if (args.Length < 8)
                        {
                            Console.WriteLine("Error : Arguments not specified completely!");
                            return;
                        }

                        string pdf_original_file_path = args[1];
                        string xml_embeded_file_path = args[2]; // full path of args[6]
                        string color_profile_file_path = args[3];
                        string destination_pdf_file_path = args[4];
                        string document_type = args[5];
                        string document_file_name = args[6]; // only file name of args[2]
                        string document_version = args[7];

                        PdfDoc pdf = new PdfDoc(pdf_original_file_path, xml_embeded_file_path, color_profile_file_path, destination_pdf_file_path, document_type, document_file_name, document_version);
                        var result = pdf.CreatePdf();

                        if (result.createSuccess)
                        {
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Error : " + result.message);
                        }
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                }
            }
        }
    }
}
