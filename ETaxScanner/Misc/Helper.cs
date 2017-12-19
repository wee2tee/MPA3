using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETaxScanner.Model;
using MPA3.Model;
using System.Globalization;
using System.Data.SQLite;

namespace ETaxScanner.Misc
{
    public enum FORM_MODE
    {
        READ,
        ADD,
        EDIT
    }


    public static class Helper
    {
        //public const string docTypeInvoice = "Invoice";
        //public const string docTypeTaxInvoice = "Tax_Invoice";
        //public const string docTypeDebitNote = "Debit_Note";
        //public const string docTypeCreditNote = "Credit_Note";
        //public const string docTypeReceipt = "Receipt";
        //public const string docTypeTaxReceipt = "Tax_Receipt";

        public enum Doctyp
        {
            Invoice,
            Tax_Invoice,
            Debit_Note,
            Credit_Note,
            Receipt,
            Tax_Receipt
        }

        public enum DoctypSubject
        {
            INV,
            DBN,
            CRN,
            CIV
        }

        public static string GetAppFolderName()
        {
            return Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        }

        public static string GetParentFolder()
        {
            return Directory.GetParent(GetAppFolderName()).FullName;
        }

        public static void SetControlState(this Component component, FORM_MODE[] form_mode_to_enable, FORM_MODE current_form_mode)
        {
            if(form_mode_to_enable.Where(m => m == current_form_mode).Count() > 0) // Enable component
            {
                if(component is Button)
                {
                    ((Button)component).Enabled = true;
                }
                if(component is TextBox)
                {
                    ((TextBox)component).Enabled = true;
                }
                if(component is DateTimePicker)
                {
                    ((DateTimePicker)component).Enabled = true;
                }
                if(component is NumericUpDown)
                {
                    ((NumericUpDown)component).Enabled = true;
                }
                if(component is CheckBox)
                {
                    ((CheckBox)component).Enabled = true;
                }
            }
            else // Disable component
            {
                if (component is Button)
                {
                    ((Button)component).Enabled = false;
                }
                if (component is TextBox)
                {
                    ((TextBox)component).Enabled = false;
                }
                if (component is DateTimePicker)
                {
                    ((DateTimePicker)component).Enabled = false;
                }
                if (component is NumericUpDown)
                {
                    ((NumericUpDown)component).Enabled = false;
                }
                if (component is CheckBox)
                {
                    ((CheckBox)component).Enabled = false;
                }
            }
        }

        public static List<SccompDbf> Sccomp()
        {
            try
            {
                string secure_path = Config.LoadConfigValue().expressPath + @"\secure\";

                if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "sccomp.dbf")))
                {
                    MessageBox.Show("ค้นหาแฟ้ม Sccomp.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;
                }

                DataTable dt = new DataTable();
                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from Sccomp";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }
                List<SccompDbf> list = new List<SccompDbf>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new SccompDbf
                    {
                        compnam = row.Field<string>("compnam").Trim(),
                        compcod = row.Field<string>("compcod").Trim(),
                        path = row.Field<string>("path").Trim(),
                        gendat = !row.IsNull("gendat") ? (DateTime?)row.Field<DateTime>("gendat") : null,
                        candel = row.Field<string>("candel").Trim()
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static string GetDocType(this ArtrnDbf artrn, DbfDataSet dataset)
        {
            var isrun = dataset.Isrun.Where(i => i.prefix == artrn.docnum.Substring(0, 2)).FirstOrDefault();
            if(isrun != null)
            {
                switch (isrun.doctyp)
                {
                    case "IV":
                        return Doctyp.Tax_Invoice.ToString();

                    case "HS":
                        return Doctyp.Tax_Invoice.ToString();

                    case "CN":
                        return Doctyp.Credit_Note.ToString();

                    case "DR":
                        return Doctyp.Debit_Note.ToString();

                    default:
                        return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetSubjectDocType(this ArtrnDbf artrn, DbfDataSet dataset)
        {
            var isrun = dataset.Isrun.Where(i => i.prefix == artrn.docnum.Substring(0, 2)).FirstOrDefault();
            if (isrun != null)
            {
                switch (isrun.doctyp)
                {
                    case "IV":
                        return DoctypSubject.INV.ToString();

                    case "HS":
                        return DoctypSubject.INV.ToString();

                    case "CN":
                        return DoctypSubject.CRN.ToString();

                    case "DR":
                        return DoctypSubject.DBN.ToString();

                    default:
                        return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SaveLog(this Log log)
        {
            // Kept log in SqLite
            if (!File.Exists("eTax.log"))
            {
                SQLiteConnection.CreateFile(Helper.GetAppFolderName() + @"\eTax.log");
            }

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + Helper.GetAppFolderName() + @"\eTax.log;Version=3"))
            {
                conn.Open();
                string sql = "Create table if not exists islog (time varchar(23), data_path varchar(150), description varchar(100))";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "Insert into islog ('time', 'data_path', 'description') Values ('" + log.Time.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.GetCultureInfo("en-US")) + "', '" + log.DataPath + "', '" + log.Description + "')";
                cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }

            // Kept log in text file
            //using (StreamWriter writer = File.AppendText("eTax.Log"))
            //{
            //    writer.WriteLine(log.Time.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) + "\t" + log.DataPath.PadRight(30) + "\t" + log.Description);
            //}
        }
    }
}
