using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPA3.Model;
using DotNetDBF;
using System.IO;

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
    }
}
