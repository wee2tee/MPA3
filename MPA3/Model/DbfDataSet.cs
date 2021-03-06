﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using MPA3.Misc;

namespace MPA3.Model
{
    public class DbfDataSet
    {
        private string data_path = null;

        public DbfDataSet(string data_path)
        {
            this.data_path = data_path.Trim();
        }

        public bool IsDataFileExist(string file_name)
        {
            if(File.Exists(this.data_path + file_name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Isprd, Scuser, Scacclv, Sccomp
        //public List<IsprdDbf>/*DataTable*/ Isprd
        //{
        //    get
        //    {
        //        if (!(Directory.Exists(this.data_path) && File.Exists(this.data_path + "isprd.dbf")))
        //        {
        //            Console.WriteLine("Cannot find the file \"Isprd.dbf\" in directory \"" + this.data_path + "\"");
        //            return null;
        //        }

        //        DataTable dt = new DataTable();

        //        OleDbConnection conn = new OleDbConnection(
        //            @"Provider=VFPOLEDB.1;Data Source=" + data_path);

        //        conn.Open();

        //        if (conn.State == ConnectionState.Open)
        //        {
        //            string mySQL = "select * from Isprd";

        //            OleDbCommand cmd = new OleDbCommand(mySQL, conn);
        //            OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

        //            DA.Fill(dt);

        //            conn.Close();
        //        }


        //    }
        //}

        //public static DataTable Scuser()
        //{
        //    string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";

        //    if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "scuser.dbf")))
        //    {
        //        XMessageBox.Show("ค้นหาแฟ้ม Scuser.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
        //        return new DataTable();
        //    }


        //    DataTable dt = new DataTable();

        //    OleDbConnection conn = new OleDbConnection(
        //        @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

        //    conn.Open();

        //    if (conn.State == ConnectionState.Open)
        //    {
        //        string mySQL = "select * from Scuser";

        //        OleDbCommand cmd = new OleDbCommand(mySQL, conn);
        //        OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

        //        DA.Fill(dt);

        //        conn.Close();
        //    }

        //    return dt;
        //}

        //public static DataTable Scacclv()
        //{
        //    string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";

        //    if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "scacclv.dbf")))
        //    {
        //        XMessageBox.Show("ค้นหาแฟ้ม Scacclv.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
        //        return new DataTable();
        //    }


        //    DataTable dt = new DataTable();

        //    OleDbConnection conn = new OleDbConnection(
        //        @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

        //    conn.Open();

        //    if (conn.State == ConnectionState.Open)
        //    {
        //        string mySQL = "select * from Scacclv";

        //        OleDbCommand cmd = new OleDbCommand(mySQL, conn);
        //        OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

        //        DA.Fill(dt);

        //        conn.Close();
        //    }

        //    return dt;
        //}

        //public static DataTable Sccomp()
        //{
        //    string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";

        //    if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "sccomp.dbf")))
        //    {
        //        XMessageBox.Show("ค้นหาแฟ้ม Sccomp.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
        //        return new DataTable();
        //    }


        //    DataTable dt = new DataTable();

        //    OleDbConnection conn = new OleDbConnection(
        //        @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

        //    conn.Open();

        //    if (conn.State == ConnectionState.Open)
        //    {
        //        string mySQL = "select * from Sccomp";

        //        OleDbCommand cmd = new OleDbCommand(mySQL, conn);
        //        OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

        //        DA.Fill(dt);

        //        conn.Close();
        //    }

        //    return dt;
        //}
        #endregion Isprd, Scuser, Scacclv, Sccomp

        public static List<Inv> Inv(string inv_dbf_file_path = "inv.dbf")
        {
            if (!File.Exists(inv_dbf_file_path))
            {
                Console.WriteLine("Cannot find the file \"" + inv_dbf_file_path + "\"");
                return null;
            }

            DataTable dt = new DataTable();

            string data_path = Directory.GetParent(inv_dbf_file_path).FullName;
            string dbf_file_name = Path.GetFileNameWithoutExtension(inv_dbf_file_path);
            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from " + dbf_file_name;

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt.ToInvList();
        }

        public IsinfoDbf Isinfo
        {
            get
            {
                if (!(Directory.Exists(this.data_path) && File.Exists(this.data_path + @"\isinfo.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"isinfo.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from Isinfo";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToList<IsinfoDbf>().FirstOrDefault();
            }
        }

        public List<IsrunDbf> Isrun
        {
            get
            {
                if (!(Directory.Exists(this.data_path) && File.Exists(this.data_path + @"\isrun.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"isrun.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from Isrun";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToIsrunList();
            }
        }

        public List<IstabDbf> Istab
        {
            get
            {
                if (!(Directory.Exists(this.data_path) && File.Exists(this.data_path + @"\istab.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"istab.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from Istab";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToIstabList();
            }
        }

        public List<StmasDbf> Stmas
        {
            get
            {
                if (!(Directory.Exists(this.data_path) && File.Exists(this.data_path + @"\stmas.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"stmas.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from Stmas";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToStmasList();
            }
        }

        public List<StlocDbf> Stloc
        {
            get
            {
                if (!(Directory.Exists(this.data_path) && File.Exists(this.data_path + @"\stloc.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"stloc.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from stloc";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToStlocList();
            }
        }

        public List<StcrdDbf> Stcrd
        {
            get
            {
                if (!(Directory.Exists(data_path) && File.Exists(data_path + @"\stcrd.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"stcrd.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from stcrd";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToStcrdList();
            }
        }

        //public static DataTable Aptrn(SccompDbf working_express_db)
        //{
        //    string data_path = working_express_db.abs_path; // GetExpressDataPath();

        //    if (!(Directory.Exists(data_path) && File.Exists(data_path + "aptrn.dbf")))
        //    {
        //        XMessageBox.Show("ค้นหาแฟ้ม Aptrn.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
        //        return new DataTable();
        //    }

        //    DataTable dt = new DataTable();

        //    OleDbConnection conn = new OleDbConnection(
        //        @"Provider=VFPOLEDB.1;Data Source=" + data_path);

        //    conn.Open();

        //    if (conn.State == ConnectionState.Open)
        //    {
        //        string mySQL = "select * from aptrn";

        //        OleDbCommand cmd = new OleDbCommand(mySQL, conn);
        //        OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

        //        DA.Fill(dt);

        //        conn.Close();
        //    }

        //    return dt;
        //}

        public List<ArtrnDbf> Artrn
        {
            get
            {
                if (!(Directory.Exists(data_path) && File.Exists(data_path + @"\artrn.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"artrn.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from artrn";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToArtrnList();
            }
        }

        public List<ArmasDbf> Armas
        {
            get
            {
                if (!(Directory.Exists(data_path) && File.Exists(data_path + @"\armas.dbf")))
                {
                    Console.WriteLine("Cannot find the file \"armas.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + this.data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from armas";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToArmasList();
            }
        }

        public List<ApmasDbf> Apmas
        {
            get
            {
                if (!(Directory.Exists(data_path) && File.Exists(data_path + @"\apmas.dbf")))
                {
                    //XMessageBox.Show("ค้นหาแฟ้ม Apmas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    Console.WriteLine("Cannot find the file \"apmas.dbf\" in directory \"" + this.data_path + "\"");
                    return null;
                }

                DataTable dt = new DataTable();

                OleDbConnection conn = new OleDbConnection(
                    @"Provider=VFPOLEDB.1;Data Source=" + data_path);

                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string mySQL = "select * from apmas";

                    OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dt);

                    conn.Close();
                }

                return dt.ToApmasList();
            }
        }
    }

    public class IsprdDbf
    {
        public DateTime? beg1 { get; set; }
        public DateTime? end1 { get; set; }
        public string lock1 { get; set; }
        public DateTime? beg2 { get; set; }
        public DateTime? end2 { get; set; }
        public string lock2 { get; set; }
        public DateTime? beg3 { get; set; }
        public DateTime? end3 { get; set; }
        public string lock3 { get; set; }
        public DateTime? beg4 { get; set; }
        public DateTime? end4 { get; set; }
        public string lock4 { get; set; }
        public DateTime? beg5 { get; set; }
        public DateTime? end5 { get; set; }
        public string lock5 { get; set; }
        public DateTime? beg6 { get; set; }
        public DateTime? end6 { get; set; }
        public string lock6 { get; set; }
        public DateTime? beg7 { get; set; }
        public DateTime? end7 { get; set; }
        public string lock7 { get; set; }
        public DateTime? beg8 { get; set; }
        public DateTime? end8 { get; set; }
        public string lock8 { get; set; }
        public DateTime? beg9 { get; set; }
        public DateTime? end9 { get; set; }
        public string lock9 { get; set; }
        public DateTime? beg10 { get; set; }
        public DateTime? end10 { get; set; }
        public string lock10 { get; set; }
        public DateTime? beg11 { get; set; }
        public DateTime? end11 { get; set; }
        public string lock11 { get; set; }
        public DateTime? beg12 { get; set; }
        public DateTime? end12 { get; set; }
        public string lock12 { get; set; }

        public DateTime? beg1ny { get; set; }
        public DateTime? end1ny { get; set; }
        public string lock1ny { get; set; }
        public DateTime? beg2ny { get; set; }
        public DateTime? end2ny { get; set; }
        public string lock2ny { get; set; }
        public DateTime? beg3ny { get; set; }
        public DateTime? end3ny { get; set; }
        public string lock3ny { get; set; }
        public DateTime? beg4ny { get; set; }
        public DateTime? end4ny { get; set; }
        public string lock4ny { get; set; }
        public DateTime? beg5ny { get; set; }
        public DateTime? end5ny { get; set; }
        public string lock5ny { get; set; }
        public DateTime? beg6ny { get; set; }
        public DateTime? end6ny { get; set; }
        public string lock6ny { get; set; }
        public DateTime? beg7ny { get; set; }
        public DateTime? end7ny { get; set; }
        public string lock7ny { get; set; }
        public DateTime? beg8ny { get; set; }
        public DateTime? end8ny { get; set; }
        public string lock8ny { get; set; }
        public DateTime? beg9ny { get; set; }
        public DateTime? end9ny { get; set; }
        public string lock9ny { get; set; }
        public DateTime? beg10ny { get; set; }
        public DateTime? end10ny { get; set; }
        public string lock10ny { get; set; }
        public DateTime? beg11ny { get; set; }
        public DateTime? end11ny { get; set; }
        public string lock11ny { get; set; }
        public DateTime? beg12ny { get; set; }
        public DateTime? end12ny { get; set; }
        public string lock12ny { get; set; }
    }

    public class StmasDbf
    {
        public string stkcod { get; set; }
        public string stkdes { get; set; }
        public string stkdes2 { get; set; }
        public string stktyp { get; set; }
        public string stklev { get; set; }
        public string stkgrp { get; set; }
        public string barcod { get; set; }
        public string stkcods { get; set; }
        public string acccod { get; set; }
        public string isinv { get; set; }
        public string stkclass { get; set; }
        public string negallow { get; set; }
        public string qucod { get; set; }
        public string cqucod { get; set; }
        public double cfactor { get; set; }
        public double stnpr { get; set; }
        public string ispur { get; set; }
        public string pqucod { get; set; }
        public double pfactor { get; set; }
        public string lpurqu { get; set; }
        public double lpurfac { get; set; }
        public double lpurpr { get; set; }
        public string lpdisc { get; set; }
        public DateTime? lpurdat { get; set; }
        public string supcod { get; set; }
        public string issal { get; set; }
        public string squcod { get; set; }
        public double sfactor { get; set; }
        public double sellpr1 { get; set; }
        public double sellpr2 { get; set; }
        public double sellpr3 { get; set; }
        public double sellpr4 { get; set; }
        public double sellpr5 { get; set; }
        public string tracksal { get; set; }
        public string vatcod { get; set; }
        public string iscom { get; set; }
        public string comrat { get; set; }
        public string lsellqu { get; set; }
        public double lsellfac { get; set; }
        public double lsellpr { get; set; }
        public string lsdisc { get; set; }
        public DateTime? lseldat { get; set; }
        public decimal? numelem { get; set; }
        public double totbal { get; set; }
        public double totval { get; set; }
        public double totreo { get; set; }
        public double totres { get; set; }
        public double opnbal { get; set; }
        public double unitpr { get; set; }
        public double opnval { get; set; }
        public DateTime? lasupd { get; set; }
        public string packing { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public string remark { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
        public string str3 { get; set; }
        public string str4 { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }

    }

    public class StlocDbf
    {
        public string stkcod { get; set; }
        public string loccod { get; set; }
        public string area { get; set; }
        public string stkclass { get; set; }
        public double locbal { get; set; }
        public double unitpr { get; set; }
        public double locval { get; set; }
        public double locreo { get; set; }
        public double locres { get; set; }
        public DateTime? lpurdat { get; set; }
        public DateTime? lseldat { get; set; }
        public DateTime? lmovdat { get; set; }
        public DateTime? takdat { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public double begbal { get; set; }
        public double begval { get; set; }
        public double qty1 { get; set; }
        public double qty2 { get; set; }
        public double qty3 { get; set; }
        public double qty4 { get; set; }
        public double qty5 { get; set; }
        public double qty6 { get; set; }
        public double qty7 { get; set; }
        public double qty8 { get; set; }
        public double qty9 { get; set; }
        public double qty10 { get; set; }
        public double qty11 { get; set; }
        public double qty12 { get; set; }
        public double qty1ny { get; set; }
        public double qty2ny { get; set; }
        public double qty3ny { get; set; }
        public double qty4ny { get; set; }
        public double qty5ny { get; set; }
        public double qty6ny { get; set; }
        public double qty7ny { get; set; }
        public double qty8ny { get; set; }
        public double qty9ny { get; set; }
        public double qty10ny { get; set; }
        public double qty11ny { get; set; }
        public double qty12ny { get; set; }
        public double val1 { get; set; }
        public double val2 { get; set; }
        public double val3 { get; set; }
        public double val4 { get; set; }
        public double val5 { get; set; }
        public double val6 { get; set; }
        public double val7 { get; set; }
        public double val8 { get; set; }
        public double val9 { get; set; }
        public double val10 { get; set; }
        public double val11 { get; set; }
        public double val12 { get; set; }
        public double val1ny { get; set; }
        public double val2ny { get; set; }
        public double val3ny { get; set; }
        public double val4ny { get; set; }
        public double val5ny { get; set; }
        public double val6ny { get; set; }
        public double val7ny { get; set; }
        public double val8ny { get; set; }
        public double val9ny { get; set; }
        public double val10ny { get; set; }
        public double val11ny { get; set; }
        public double val12ny { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }
    }

    public class StcrdDbf
    {
        public string stkcod { get; set; }
        public string loccod { get; set; }
        public string docnum { get; set; }
        public string seqnum { get; set; }
        public DateTime? docdat { get; set; }
        public string rdocnum { get; set; }
        public string refnum { get; set; }
        public string depcod { get; set; }
        public string posopr { get; set; }
        public string free { get; set; }
        public string vatcod { get; set; }
        public string people { get; set; }
        public string slmcod { get; set; }
        public string flag { get; set; }
        public double trnqty { get; set; }
        public string tqucod { get; set; }
        public double tfactor { get; set; }
        public double unitpr { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double trnval { get; set; }
        public double phybal { get; set; }
        public string retstk { get; set; }
        public double xtrnqty { get; set; }
        public double xunitpr { get; set; }
        public double xtrnval { get; set; }
        public double xsalval { get; set; }
        public double netval { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public double balchg { get; set; }
        public double valchg { get; set; }
        public double lotbal { get; set; }
        public double lotval { get; set; }
        public double lunitpr { get; set; }
        public string pstkcod { get; set; }
        public string accnumdr { get; set; }
        public string accnumcr { get; set; }
        public string stkdes { get; set; }
        public string packing { get; set; }
        public string jobcod { get; set; }
        public string phase { get; set; }
        public string coscod { get; set; }
        public string reimburse { get; set; }
    }

    public class ApmasDbf
    {
        public string supcod { get; set; }
        public string suptyp { get; set; }
        public string onhold { get; set; }
        public string prenam { get; set; }
        public string supnam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public string contact { get; set; }
        public string supnam2 { get; set; }
        public decimal paytrm { get; set; }
        public string paycond { get; set; }
        public string dlvby { get; set; }
        public decimal vatrat { get; set; }
        public string flgvat { get; set; }
        public string disc { get; set; }
        public double balance { get; set; }
        public double chqpay { get; set; }
        public double crline { get; set; }
        public DateTime? lasrcv { get; set; }
        public string accnum { get; set; }
        public string remark { get; set; }
        public string taxid { get; set; }
        public decimal orgnum { get; set; }
        public string taxdes { get; set; }
        public decimal taxrat { get; set; }
        public string taxtyp { get; set; }
        public string taxcond { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }
    }

    public class ArmasDbf
    {
        public string cuscod { get; set; }
        public string custyp { get; set; }
        public string prenam { get; set; }
        public string cusnam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public string contact { get; set; }
        public string cusnam2 { get; set; }
        public string taxid { get; set; }
        public decimal orgnum { get; set; }
        public string taxtyp { get; set; }
        public decimal taxrat { get; set; }
        public string taxgrp { get; set; }
        public string taxcond { get; set; }
        public string shipto { get; set; }
        public string slmcod { get; set; }
        public string areacod { get; set; }
        public decimal paytrm { get; set; }
        public string paycond { get; set; }
        public string payer { get; set; }
        public string tabpr { get; set; }
        public string disc { get; set; }
        public double balance { get; set; }
        public double chqrcv { get; set; }
        public double crline { get; set; }
        public DateTime? lasivc { get; set; }
        public string accnum { get; set; }
        public string remark { get; set; }
        public string dlvby { get; set; }
        public string tracksal { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }
    }

    public class AptrnDbf
    {
        public string rectyp { get; set; }
        public string docnum { get; set; }
        public DateTime? docdat { get; set; }
        public string refnum { get; set; }
        public DateTime? vatprd { get; set; }
        public string vatlate { get; set; }
        public string vattyp { get; set; }
        public string postgl { get; set; }
        public string ponum { get; set; }
        public string dntyp { get; set; }
        public string depcod { get; set; }
        public string flgvat { get; set; }
        public string supcod { get; set; }
        public string shipto { get; set; }
        public string youref { get; set; }
        public decimal paytrm { get; set; }
        public DateTime? duedat { get; set; }
        public string bilnum { get; set; }
        public string dlvby { get; set; }
        public string nxtseq { get; set; }
        public double amount { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double aftdisc { get; set; }
        public string advnum { get; set; }
        public double advamt { get; set; }
        public double total { get; set; }
        public double amtrat0 { get; set; }
        public decimal vatrat { get; set; }
        public double vatamt { get; set; }
        public double netamt { get; set; }
        public double netval { get; set; }
        public double payamt { get; set; }
        public double remamt { get; set; }
        public string cmplapp { get; set; }
        public DateTime? cmpldat { get; set; }
        public string docstat { get; set; }
        public double cshpay { get; set; }
        public double chqpay { get; set; }
        public double intpay { get; set; }
        public double tax { get; set; }
        public double rcvamt { get; set; }
        public double chqpas { get; set; }
        public DateTime? vatdat { get; set; }
        public string srv_vattyp { get; set; }
        public string pvatprorat { get; set; }
        public decimal pvat_rf { get; set; }
        public decimal pvat_nrf { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string userprn { get; set; }
        public DateTime? prndat { get; set; }
        public decimal prncnt { get; set; }
        public string prntim { get; set; }
        public string authid { get; set; }
        public DateTime? approve { get; set; }
        public string billbe { get; set; }
        public decimal orgnum { get; set; }
        public string c_type { get; set; }
        public DateTime? c_date { get; set; }
        public string c_ref { get; set; }
        public double c_rate { get; set; }
        public string c_fixrate { get; set; }
        public double c_ratio { get; set; }
        public double c_amount { get; set; }
        public string c_disc { get; set; }
        public double c_discamt { get; set; }
        public double c_aftdisc { get; set; }
        public double c_advamt { get; set; }
        public double c_total { get; set; }
        public double c_netamt { get; set; }
        public double c_netval { get; set; }
        public double c_rcvamt { get; set; }
        public double c_difamt { get; set; }
        public double c_payamt { get; set; }
        public double c_remamt { get; set; }
        public string link1 { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public double num2 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
    }

    public class ArtrnDbf
    {
        public string rectyp { get; set; }
        public string docnum { get; set; }
        public DateTime? docdat { get; set; }
        public string postgl { get; set; }
        public string sonum { get; set; }
        public string cntyp { get; set; }
        public string depcod { get; set; }
        public string flgvat { get; set; }
        public string slmcod { get; set; }
        public string cuscod { get; set; }
        public string shipto { get; set; }
        public string youref { get; set; }
        public string areacod { get; set; }
        public decimal paytrm { get; set; }
        public DateTime? duedat { get; set; }
        public string bilnum { get; set; }
        public string nxtseq { get; set; }
        public double amount { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double aftdisc { get; set; }
        public string advnum { get; set; }
        public double advamt { get; set; }
        public double total { get; set; }
        public double amtrat0 { get; set; }
        public decimal vatrat { get; set; }
        public double vatamt { get; set; }
        public double netamt { get; set; }
        public double netval { get; set; }
        public double rcvamt { get; set; }
        public double remamt { get; set; }
        public double comamt { get; set; }
        public string cmplapp { get; set; }
        public DateTime? cmpldat { get; set; }
        public string docstat { get; set; }
        public double cshrcv { get; set; }
        public double chqrcv { get; set; }
        public double intrcv { get; set; }
        public double beftax { get; set; }
        public decimal taxrat { get; set; }
        public string taxcond { get; set; }
        public double tax { get; set; }
        public double ivcamt { get; set; }
        public double chqpas { get; set; }
        public DateTime? vatdat { get; set; }
        public DateTime? vatprd { get; set; }
        public string vatlate { get; set; }
        public string srv_vattyp { get; set; }
        public string dlvby { get; set; }
        public DateTime? reserve { get; set; }

        /* V.2 + creby,credat */
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        /**********************/

        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string userprn { get; set; }
        public DateTime? prndat { get; set; }
        public decimal prncnt { get; set; }
        
        /* only in v.1 */
        public string prntim { get; set; }
        /***************/

        public string authid { get; set; }
        public DateTime? approve { get; set; }
        
        /* V.2 + ponum */
        public string ponum { get; set; }
        /***************/

        public string billto { get; set; }
        public decimal orgnum { get; set; }

        public string c_type { get; set; }
        public DateTime? c_date { get; set; }
        public string c_ref { get; set; }
        public double c_rate { get; set; }
        public string c_fixrate { get; set; }
        public double c_ratio { get; set; }
        public double c_amount { get; set; }
        public string c_disc { get; set; }
        public double c_discamt { get; set; }
        public double c_aftdisc { get; set; }
        public double c_advamt { get; set; }
        public double c_total { get; set; }
        public double c_netamt { get; set; }
        public double c_netval { get; set; }
        public double c_ivcamt { get; set; }
        public double c_difamt { get; set; }
        public double c_rcvamt { get; set; }
        public double c_remamt { get; set; }
        public string link1 { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public double num2 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
    }

    public class ScuserDbf
    {
        public string rectyp { get; set; }
        public string reccod { get; set; }
        public string connectgrp { get; set; }
        public string recdes { get; set; }
        public DateTime? revokedat { get; set; }
        public DateTime? resumedat { get; set; }
        public string language { get; set; }
        public decimal userattr { get; set; }
        public DateTime? laswrk { get; set; }
        public DateTime? laspwd { get; set; }
        public DateTime? lasusedat { get; set; }
        public string lasusetim { get; set; }
        public string secure { get; set; }
        public decimal authlev { get; set; }
        public string userpwd { get; set; }
        public string status { get; set; }
        public string prnnum { get; set; }
        public string rwttxt { get; set; }

    }

    public class ScacclvDbf
    {
        public string compcod { get; set; }
        public string filename { get; set; }
        public string accessid { get; set; }
        public string submodule { get; set; }
        public string isread { get; set; }
        public string isadd { get; set; }
        public string isedit { get; set; }
        public string isdelete { get; set; }
        public string isprint { get; set; }
        public string iscancel { get; set; }
        public string isapprove { get; set; }

    }

    //public class SccompDbf
    //{
    //    public string compnam { get; set; }
    //    public string compcod { get; set; }
    //    public string path { get; set; }
    //    public DateTime? gendat { get; set; }
    //    public string candel { get; set; }

    //    public string abs_path
    //    {
    //        get
    //        {
    //            string path_txt = string.Empty;

    //            if(this.path.Substring(1, 2) == @":\" || this.path.StartsWith(@"\\"))
    //            {
    //                path_txt = this.path;
    //            }
    //            else
    //            {
    //                DirectoryInfo dir_info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
    //                string absolute_path = dir_info.Parent.FullName + @"\" + this.path;
    //                path_txt = absolute_path;
    //            }

    //            return path_txt.TrimEnd('\\') + @"\";
    //        }
    //    }
    //}

    public class IsrunDbf
    {
        public string doctyp { get; set; }
        public string doccod { get; set; }
        public string shortnam { get; set; }
        public string posdes { get; set; }
        public string posdes2 { get; set; }
        public string prefix { get; set; }
        public string docnum { get; set; }
        public bool ismodify { get; set; }
        public string depcod { get; set; }
        public string jnltyp { get; set; }
        public string jnlexp { get; set; }
        public string accnum01 { get; set; }
        public string accnum02 { get; set; }
        public string accnum03 { get; set; }
        public string accnum04 { get; set; }
        public string accnum05 { get; set; }
        public string accnum06 { get; set; }
        public string accnum07 { get; set; }
        public string accnum08 { get; set; }
        public string accnum09 { get; set; }
        public string accnum10 { get; set; }
        public string accnum11 { get; set; }
        public string accnum12 { get; set; }
        public string flgvat { get; set; }
        public decimal vatrat { get; set; }
        public string srv_vattyp { get; set; }
        public string autoprn { get; set; }
        public string whichform { get; set; }
        public string reprn_lev { get; set; }
        public string cancel_lev { get; set; }
        public string delete_lev { get; set; }
        public string approv_met { get; set; }
        public string approv_lev { get; set; }
        public string ovrlin_lev { get; set; }
        public string vat_initem { get; set; }
        public string loccod { get; set; }
        public string usebarcod { get; set; }
        public string pvatprorat { get; set; }
        public string reserve1 { get; set; }
        public string reserve2 { get; set; }
        public double reserve3 { get; set; }

    }

    public class IstabDbf
    {
        public string tabtyp { get; set; }
        public string typcod { get; set; }
        public string shortnam { get; set; }
        public string shortnam2 { get; set; }
        public string typdes { get; set; }
        public string typdes2 { get; set; }
        public string fld01 { get; set; }
        public double? fld02 { get; set; }
        public string depcod { get; set; }
        public string status { get; set; }

    }

    public class IsinfoDbf
    {
        public string thinam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string telnum { get; set; }
        public string engnam { get; set; }
        public string addr01eng { get; set; }
        public string addr02eng { get; set; }
        public string trdreg { get; set; }
        public string taxid { get; set; }
        public string linkgl { get; set; }
        public double vatrat { get; set; }
        public string flgvat { get; set; }
        public string seditqu { get; set; }
        public string chgsalpr { get; set; }
        public string losesal { get; set; }
        public string st_lt_reop { get; set; }
        public string insertit { get; set; }
        public string cost_enc { get; set; }
        public string pvatprorat { get; set; }
        public double pvat_rf { get; set; }
        public double pvat_nrf { get; set; }
        public string arprefer { get; set; }
        public string apprefer { get; set; }
        public string stprefer { get; set; }
        public string glprefer { get; set; }
        public string cshpurjnl { get; set; }
        public string crepurjnl { get; set; }
        public string purretjnl { get; set; }
        public string othexpjnl { get; set; }
        public string aprcpjnl { get; set; }
        public string paspcqjnl { get; set; }
        public string cshsaljnl { get; set; }
        public string cresaljnl { get; set; }
        public string salretjnl { get; set; }
        public string othincjnl { get; set; }
        public string arrcpjnl { get; set; }
        public string pasrcqjnl { get; set; }
        public string intissjnl { get; set; }
        public string takadjjnl { get; set; }
        public string cosadjjnl { get; set; }
        public string baddbtjnl { get; set; }
        public string bnkmovjnl { get; set; }
        public string incchqjnl { get; set; }
        public string expchqjnl { get; set; }
        public string aradvjnl { get; set; }
        public string apadvjnl { get; set; }
        public string fadprjnl { get; set; }
        public string ardnjnl { get; set; }
        public string apcnjnl { get; set; }
        public string cosmtd { get; set; }
        public string bnkdep { get; set; }
        public string bnkpaid { get; set; }
        public string paspcqauto { get; set; }
        public string accnum00 { get; set; }
        public string accnum01 { get; set; }
        public string accnum02 { get; set; }
        public string accnum03 { get; set; }
        public string accnum04 { get; set; }
        public string accnum05 { get; set; }
        public string accnum06 { get; set; }
        public string accnum07 { get; set; }
        public string accnum08 { get; set; }
        public string accnum09 { get; set; }
        public string accnum10 { get; set; }
        public string accnum11 { get; set; }
        public string accnum12 { get; set; }
        public string accnum13 { get; set; }
        public string accnum14 { get; set; }
        public string accnum15 { get; set; }
        public string accnum16 { get; set; }
        public string accnum17 { get; set; }
        public string accnum18 { get; set; }
        public string accnum19 { get; set; }
        public string accnum20 { get; set; }
        public string accnum21 { get; set; }
        public string accnum22 { get; set; }
        public string accnum23 { get; set; }
        public string accnum24 { get; set; }
        public string accnum25 { get; set; }
        public string accnum26 { get; set; }
        public string accnum27 { get; set; }
        public string accnum28 { get; set; }
        public string accnum29 { get; set; }
        public string accnum30 { get; set; }
        public string accnum31 { get; set; }
        public string accnum32 { get; set; }
        public string accnum33 { get; set; }
        public string accnum34 { get; set; }
        public string accnum35 { get; set; }
        public string accnum36 { get; set; }
        public string accnum37 { get; set; }
        public string accnum38 { get; set; }
        public string accnum39 { get; set; }
        public string accnum40 { get; set; }
        public string accnum41 { get; set; }
        public string accnum42 { get; set; }
        public string accnum43 { get; set; }
        public string accnum44 { get; set; }
        public string accnum45 { get; set; }
        public string pt_str1 { get; set; }
        public string pt_str1eng { get; set; }
        public string petty1 { get; set; }
        public string pt_str2 { get; set; }
        public string pt_str2eng { get; set; }
        public string petty2 { get; set; }
        public string pt_str3 { get; set; }
        public string pt_str3eng { get; set; }
        public string petty3 { get; set; }
        public string pt_str4 { get; set; }
        public string pt_str4eng { get; set; }
        public string petty4 { get; set; }
        public string pt_str5 { get; set; }
        public string pt_str5end { get; set; }
        public string petty5 { get; set; }
        public string glpict { get; set; }
        public string stpict { get; set; }
        public string fapict { get; set; }
        public string mainloc { get; set; }
        public string negallow { get; set; }
        public string isperpetua { get; set; }
        public string yearthai { get; set; }
        public string peditqu { get; set; }
        public string peditfac { get; set; }
        public string teditqu { get; set; }
        public string teditfac { get; set; }
        public string e_lpursal { get; set; }
        public int ardue1 { get; set; }
        public int ardue2 { get; set; }
        public int arovr1 { get; set; }
        public int arovr2 { get; set; }
        public int arovr3 { get; set; }
        public int apdue1 { get; set; }
        public int apdue2 { get; set; }
        public int apovr1 { get; set; }
        public int apovr2 { get; set; }
        public int apovr3 { get; set; }
        public int qrdue1 { get; set; }
        public int qrdue2 { get; set; }
        public int qrovr1 { get; set; }
        public int qrovr2 { get; set; }
        public int qrovr3 { get; set; }
        public int qpdue1 { get; set; }
        public int qpdue2 { get; set; }
        public int qpovr1 { get; set; }
        public int qpovr2 { get; set; }
        public int qpovr3 { get; set; }
        public int stage1 { get; set; }
        public int stage2 { get; set; }
        public int stage3 { get; set; }
        public string glrunning { get; set; }
        public string usedep { get; set; }
        public string cndeduct { get; set; }
        public string dndeduct { get; set; }
        public int savscrtime { get; set; }
        public string ed_sstkdes { get; set; }
        public string ed_pstkdes { get; set; }
        public string fadprauto { get; set; }
        public string fadprmonly { get; set; }
        public string dprmethod { get; set; }
        public string online { get; set; }
        public string reserve1 { get; set; }
        public string reserve2 { get; set; }
        public int reserve3 { get; set; }
        public string reserve4 { get; set; }
        public string usepacking { get; set; }
        public string reprnauth { get; set; }
        public string abnormexit { get; set; }
        public string ovrcrauth { get; set; }
        public string chkneglev { get; set; }
        public string negauth { get; set; }
        public string whoami { get; set; }
        public double mintaxamt { get; set; }
        public double mintaxrat { get; set; }
        public string socialid { get; set; }
        public string povdntid { get; set; }
        public int dsimlpri { get; set; }
        public int dsimlqty { get; set; }
        public int dsimlfac { get; set; }
        public string anyloc { get; set; }
        public string loc_cost { get; set; }
        public string loc_dep { get; set; }
        public string use_cqu { get; set; }
        public string st_dat1 { get; set; }
        public string st_dat1eng { get; set; }
        public string st_dat1use { get; set; }
        public string st_dat2 { get; set; }
        public string st_dat2eng { get; set; }
        public string st_dat2use { get; set; }
        public string st_num1 { get; set; }
        public string st_num1eng { get; set; }
        public string st_num1use { get; set; }
        public string st_str1 { get; set; }
        public string st_str1eng { get; set; }
        public string st_str1use { get; set; }
        public string st_str2 { get; set; }
        public string st_str2eng { get; set; }
        public string st_str2use { get; set; }
        public string st_str3 { get; set; }
        public string st_str3eng { get; set; }
        public string st_str3use { get; set; }
        public string st_str4 { get; set; }
        public string st_str4eng { get; set; }
        public string st_str4use { get; set; }
        public string usebarcod { get; set; }
        public string so_cr_lock { get; set; }
        public string so_logloc { get; set; }
        public double crline_a { get; set; }
        public double crline_b { get; set; }
        public double crline_c { get; set; }
        public double crline_d { get; set; }
        public double crline_e { get; set; }
        public string crline_a_l { get; set; }
        public string crline_b_l { get; set; }
        public string crline_c_l { get; set; }
        public string crline_d_l { get; set; }
        public string crline_e_l { get; set; }
        public string ovrcrallow { get; set; }
        public string usejob { get; set; }
        public string jb_str1 { get; set; }
        public string jb_str1eng { get; set; }
        public string jb_str1use { get; set; }
        public string jb_str2 { get; set; }
        public string jb_str2eng { get; set; }
        public string jb_str2use { get; set; }
        public string jb_str3 { get; set; }
        public string jb_str3eng { get; set; }
        public string jb_str3use { get; set; }
        public string jb_str4 { get; set; }
        public string jb_str4eng { get; set; }
        public string jb_str4use { get; set; }
        public string jb_str5 { get; set; }
        public string jb_str5eng { get; set; }
        public string jb_str5use { get; set; }
        public int postacc { get; set; }
        public string sharefile { get; set; }
        public string srv_vattyp { get; set; }
        public string reprn_lev { get; set; }
        public string cancel_lev { get; set; }
        public string delete_lev { get; set; }
        public string approv_met { get; set; }
        public string approv_lev { get; set; }
        public string ovrlin_lev { get; set; }
        public string vat_initem { get; set; }
        public string jbpict { get; set; }
        public string vatreplev { get; set; }
        public DateTime vatrepbeg { get; set; }
        public int orgnum { get; set; }
        public string orgstr { get; set; }
    }
}
