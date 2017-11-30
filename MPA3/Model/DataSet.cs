using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DotNetDBF;
using MPA3.Misc;

namespace MPA3.Model
{
    public class DataSetInv
    {
        private string data_file_path = null;

        public DataSetInv(string data_file_path = "inv.dbf")
        {
            this.data_file_path = data_file_path;
        }

        private DBFField[] GetFields()
        {
            var fDocnum = new DBFField { Name = "docnum", DataType = NativeDbType.Char, FieldLength = 12 };
            var fEmail = new DBFField { Name = "email", DataType = NativeDbType.Char, FieldLength = 50 };
            var fStatus = new DBFField { Name = "status", DataType = NativeDbType.Char, FieldLength = 1 };
            return new DBFField[] { fDocnum, fEmail, fStatus };
        }

        public List<Inv> GetInvList()
        {
            if (!File.Exists(this.data_file_path))
            {
                throw new FileNotFoundException("File \"" + this.data_file_path + "\" not found!");
            }
            try
            {
                using (Stream rs = File.Open(this.data_file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ManageDataResult AddRecord(Inv inv_to_add)
        {
            int try_count = 0;

            if (!File.Exists(this.data_file_path))
            {
                throw new FileNotFoundException("File \"" + this.data_file_path + "\" not found!");
            }

            try
            {
                try_count++;
                using (Stream rStream = File.Open(this.data_file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var reader = new DBFReader(rStream);
                    reader.CharEncoding = Encoding.GetEncoding(874);
                    List<Inv> invoice_list = new List<Model.Inv>();

                    var writer = new DBFWriter();
                    writer.CharEncoding = Encoding.GetEncoding(874);
                    writer.Fields = this.GetFields();
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

                    using (Stream wStream = File.Open(this.data_file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                    {
                        writer.Write(wStream);
                    }
                }
                return new ManageDataResult { success = true, message = "success" };
            }
            catch (Exception ex)
            {
                //Console.WriteLine("File is in use by another process.");
                return new ManageDataResult { success = false, message = ex.Message };
            }
        }

        public ManageDataResult UpdateRecord(Inv inv_to_update)
        {
            int try_count = 0;

            if (!File.Exists(this.data_file_path))
            {
                throw new FileNotFoundException("File \"" + this.data_file_path + "\" not found!");
            }

            try
            {
                try_count++;
                using (Stream rStream = File.Open(this.data_file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var reader = new DBFReader(rStream);
                    reader.CharEncoding = Encoding.GetEncoding(874);
                    List<Inv> invoice_list = new List<Model.Inv>();

                    var writer = new DBFWriter();
                    writer.CharEncoding = Encoding.GetEncoding(874);
                    writer.Fields = this.GetFields();
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
                    writer.AddRecord(inv_to_update.docnum, inv_to_update.email, inv_to_update.status);

                    using (Stream wStream = File.Open(this.data_file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                    {
                        writer.Write(wStream);
                    }
                }
                return new ManageDataResult { success = true, message = "success" };
            }
            catch (Exception ex)
            {
                //Console.WriteLine("File is in use by another process.");
                return new ManageDataResult { success = false, message = ex.Message };
            }
        }
    }
}
