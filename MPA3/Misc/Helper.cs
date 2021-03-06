﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPA3.Model;
using DotNetDBF;
using System.IO;
using MPA3.Model;
using static MPA3.Model.JsonModel;

namespace MPA3.Misc
{
    public static class Helper
    {
        public static List<Inv> GetInvoiceList()
        {
            if (!File.Exists("inv.dbf"))
            {
                throw new FileNotFoundException("File \"inv.dbf\" not found!");
            }

            using (Stream rs = File.Open("inv.dbf", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var rdr = new DBFReader(rs);
                rdr.CharEncoding = Encoding.GetEncoding(874);
                List<Inv> invoice_list = new List<Model.Inv>();

                for (int i = 0; i < rdr.RecordCount; i++)
                {
                    try
                    {
                        object[] obj = rdr.NextRecord();

                        invoice_list.Add(new Inv
                        {
                            docnum = (string)obj[0],
                            email = (string)obj[1],
                            status = (string)obj[2]
                        });
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                return invoice_list;
            }
        }

        public static object[] GetFields()
        {
            var fDocnum = new DBFField { Name = "docnum", DataType = NativeDbType.Char, FieldLength = 12 };
            var fEmail = new DBFField { Name = "email", DataType = NativeDbType.Char, FieldLength = 50 };
            var fStatus = new DBFField { Name = "status", DataType = NativeDbType.Char, FieldLength = 1 };
            return new[] { fDocnum, fEmail, fStatus };
        }

        public static ManageDataResult AddInvoiceRecord(Inv inv_to_add)
        {
            if (!File.Exists("inv.dbf"))
            {
                throw new FileNotFoundException("File \"inv.dbf\" not found!");
            }

            try
            {
                using (Stream stream = File.Open("inv.dbf", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    var reader = new DBFReader(stream);
                    reader.CharEncoding = Encoding.GetEncoding(874);
                    List<Inv> invoice_list = new List<Model.Inv>();

                    var writer = new DBFWriter(stream);
                    for (int i = 0; i < reader.RecordCount; i++)
                    {
                        try
                        {
                            object[] obj = reader.NextRecord();

                            // add existing record first
                            writer.AddRecord((string)obj[0], (string)obj[1], (string)obj[2]);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }

                    // add a target record
                    writer.AddRecord(inv_to_add.docnum, inv_to_add.email, inv_to_add.status);
                }
                return new ManageDataResult { success = true, message = "success" };
            }
            catch (Exception ex)
            {
                //Console.WriteLine("File is in use by another process.");
                return new ManageDataResult { success = false, message = ex.Message };
            }
        }

        public static StdDocumentName GetDocName(this ArtrnDbf artrn, DbfDataSet dataset)
        {
            //try
            //{
                IsrunDbf isrun = dataset.Isrun.Where(i => i.prefix == artrn.docnum.Substring(0, 2)).FirstOrDefault();
            //var x = dataset.Isrun.OrderBy(d => d.doctyp).Select(d => d.doctyp).ToArray<string>();
                StdDocumentName docName = null;
                if (isrun != null)
                {
                    switch (isrun.doctyp)
                    {
                        case "IV":
                            if (artrn.srv_vattyp == ((int)VAT_TYPE.ACQUISITION).ToString() && artrn.vatamt > 0)
                            {
                                docName = new StdDocumentName(StdDocumentName.TYPE._T02);
                            }
                            else
                            {
                                docName = new StdDocumentName(StdDocumentName.TYPE._380);
                            }
                            break;

                        case "HS":
                            docName = new StdDocumentName(StdDocumentName.TYPE._T03);
                            break;

                        case "CN":
                            docName = new StdDocumentName(StdDocumentName.TYPE._81);
                            break;

                        case "DR":
                            docName = new StdDocumentName(StdDocumentName.TYPE._80);
                            break;

                        default:
                            docName = new StdDocumentName(StdDocumentName.TYPE._388);
                            break;
                    }
                }

                return docName;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }
    }

    public class ManageDataResult
    {
        public bool success { get; set; }
        public string message { get; set; }

    }
}
