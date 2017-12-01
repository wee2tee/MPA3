using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MPA3.Model
{
    public static class DbfHelper
    {
        #region Scuser, Scacclv, Sccomp
        //public static List<ScuserDbf> ToScuserList(this DataTable scuser_dbf)
        //{
        //    List<ScuserDbf> scuser = new List<ScuserDbf>();

        //    foreach (DataRow row in scuser_dbf.Rows)
        //    {
        //        try
        //        {
        //            ScuserDbf s = new ScuserDbf
        //            {
        //                rectyp = row.Field<string>("rectyp").Trim(),
        //                reccod = row.Field<string>("reccod").Trim(),
        //                connectgrp = row.Field<string>("connectgrp").Trim(),
        //                recdes = row.Field<string>("recdes").Trim(),
        //                revokedat = !row.IsNull("revokedat") ? row.Field<DateTime?>("revokedat") : null,
        //                resumedat = !row.IsNull("resumedat") ? row.Field<DateTime?>("resumedat") : null,
        //                language = row.Field<string>("language").Trim(),
        //                userattr = !row.IsNull("userattr") ? row.Field<decimal>("userattr") : 0m,
        //                laswrk = !row.IsNull("laswrk") ? row.Field<DateTime?>("laswrk") : null,
        //                laspwd = !row.IsNull("laspwd") ? row.Field<DateTime?>("laspwd") : null,
        //                lasusedat = !row.IsNull("lasusedat") ? row.Field<DateTime?>("lasusedat") : null,
        //                lasusetim = row.Field<string>("lasusetim"),
        //                secure = row.Field<string>("secure"),
        //                authlev = !row.IsNull("authlev") ? row.Field<decimal>("authlev") : 0m,
        //                userpwd = row.Field<string>("userpwd"),
        //                status = row.Field<string>("status"),
        //                prnnum = row.Field<string>("prnnum"),
        //                rwttxt = row.Field<string>("rwttxt")
        //            };

        //            scuser.Add(s);
        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    return scuser;
        //}

        //public static List<ScacclvDbf> ToScacclvList(this DataTable scacclv_dbf)
        //{
        //    List<ScacclvDbf> scacclv = new List<ScacclvDbf>();
        //    foreach (DataRow row in scacclv_dbf.Rows)
        //    {
        //        try
        //        {
        //            ScacclvDbf s = new ScacclvDbf
        //            {
        //                compcod = row.Field<string>("compcod").Trim(),
        //                filename = row.Field<string>("filename").Trim(),
        //                accessid = row.Field<string>("accessid").Trim(),
        //                submodule = row.Field<string>("submodule").Trim(),
        //                isread = row.Field<string>("isread").Trim(),
        //                isadd = row.Field<string>("isadd").Trim(),
        //                isedit = row.Field<string>("isedit").Trim(),
        //                isdelete = row.Field<string>("isdelete").Trim(),
        //                isprint = row.Field<string>("isprint").Trim(),
        //                iscancel = row.Field<string>("iscancel").Trim(),
        //                isapprove = row.Field<string>("isapprove").Trim()
        //            };

        //            scacclv.Add(s);
        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    return scacclv;
        //}

        //public static List<SccompDbf> ToSccompList(this DataTable sccomp_dbf)
        //{
        //    List<SccompDbf> sccomp = new List<SccompDbf>();

        //    foreach (DataRow row in sccomp_dbf.Rows)
        //    {
        //        try
        //        {
        //            SccompDbf s = new SccompDbf
        //            {
        //                compnam = row.Field<string>("compnam").TrimEnd(),
        //                compcod = row.Field<string>("compcod").Trim(),
        //                path = row.Field<string>("path").Trim(),
        //                gendat = !row.IsNull("gendat") ? row.Field<DateTime?>("gendat") : null,
        //                candel = row.Field<string>("candel").Trim()
        //            };

        //            sccomp.Add(s);
        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }
        //    }

        //    return sccomp;
        //}
        #endregion Scuser, Scacclv, Sccomp

        #region Isprd, Isrun
        //public static IsprdDbf ToIsprd(this DataTable dt_isprd)
        //{
        //    IsprdDbf isprd = new IsprdDbf
        //    {
        //        beg1 = dt_isprd.Rows[0].Field<DateTime?>("beg1"),
        //        end1 = dt_isprd.Rows[0].Field<DateTime?>("end1"),
        //        lock1 = dt_isprd.Rows[0].Field<string>("lock1"),
        //        beg2 = dt_isprd.Rows[0].Field<DateTime?>("beg2"),
        //        end2 = dt_isprd.Rows[0].Field<DateTime?>("end2"),
        //        lock2 = dt_isprd.Rows[0].Field<string>("lock2"),
        //        beg3 = dt_isprd.Rows[0].Field<DateTime?>("beg3"),
        //        end3 = dt_isprd.Rows[0].Field<DateTime?>("end3"),
        //        lock3 = dt_isprd.Rows[0].Field<string>("lock3"),
        //        beg4 = dt_isprd.Rows[0].Field<DateTime?>("beg4"),
        //        end4 = dt_isprd.Rows[0].Field<DateTime?>("end4"),
        //        lock4 = dt_isprd.Rows[0].Field<string>("lock4"),
        //        beg5 = dt_isprd.Rows[0].Field<DateTime?>("beg5"),
        //        end5 = dt_isprd.Rows[0].Field<DateTime?>("end5"),
        //        lock5 = dt_isprd.Rows[0].Field<string>("lock5"),
        //        beg6 = dt_isprd.Rows[0].Field<DateTime?>("beg6"),
        //        end6 = dt_isprd.Rows[0].Field<DateTime?>("end6"),
        //        lock6 = dt_isprd.Rows[0].Field<string>("lock6"),
        //        beg7 = dt_isprd.Rows[0].Field<DateTime?>("beg7"),
        //        end7 = dt_isprd.Rows[0].Field<DateTime?>("end7"),
        //        lock7 = dt_isprd.Rows[0].Field<string>("lock7"),
        //        beg8 = dt_isprd.Rows[0].Field<DateTime?>("beg8"),
        //        end8 = dt_isprd.Rows[0].Field<DateTime?>("end8"),
        //        lock8 = dt_isprd.Rows[0].Field<string>("lock8"),
        //        beg9 = dt_isprd.Rows[0].Field<DateTime?>("beg9"),
        //        end9 = dt_isprd.Rows[0].Field<DateTime?>("end9"),
        //        lock9 = dt_isprd.Rows[0].Field<string>("lock9"),
        //        beg10 = dt_isprd.Rows[0].Field<DateTime?>("beg10"),
        //        end10 = dt_isprd.Rows[0].Field<DateTime?>("end10"),
        //        lock10 = dt_isprd.Rows[0].Field<string>("lock10"),
        //        beg11 = dt_isprd.Rows[0].Field<DateTime?>("beg11"),
        //        end11 = dt_isprd.Rows[0].Field<DateTime?>("end11"),
        //        lock11 = dt_isprd.Rows[0].Field<string>("lock11"),
        //        beg12 = dt_isprd.Rows[0].Field<DateTime?>("beg12"),
        //        end12 = dt_isprd.Rows[0].Field<DateTime?>("end12"),
        //        lock12 = dt_isprd.Rows[0].Field<string>("lock12"),

        //        beg1ny = dt_isprd.Rows[0].Field<DateTime?>("beg1ny"),
        //        end1ny = dt_isprd.Rows[0].Field<DateTime?>("end1ny"),
        //        lock1ny = dt_isprd.Rows[0].Field<string>("lock1ny"),
        //        beg2ny = dt_isprd.Rows[0].Field<DateTime?>("beg2ny"),
        //        end2ny = dt_isprd.Rows[0].Field<DateTime?>("end2ny"),
        //        lock2ny = dt_isprd.Rows[0].Field<string>("lock2ny"),
        //        beg3ny = dt_isprd.Rows[0].Field<DateTime?>("beg3ny"),
        //        end3ny = dt_isprd.Rows[0].Field<DateTime?>("end3ny"),
        //        lock3ny = dt_isprd.Rows[0].Field<string>("lock3ny"),
        //        beg4ny = dt_isprd.Rows[0].Field<DateTime?>("beg4ny"),
        //        end4ny = dt_isprd.Rows[0].Field<DateTime?>("end4ny"),
        //        lock4ny = dt_isprd.Rows[0].Field<string>("lock4ny"),
        //        beg5ny = dt_isprd.Rows[0].Field<DateTime?>("beg5ny"),
        //        end5ny = dt_isprd.Rows[0].Field<DateTime?>("end5ny"),
        //        lock5ny = dt_isprd.Rows[0].Field<string>("lock5ny"),
        //        beg6ny = dt_isprd.Rows[0].Field<DateTime?>("beg6ny"),
        //        end6ny = dt_isprd.Rows[0].Field<DateTime?>("end6ny"),
        //        lock6ny = dt_isprd.Rows[0].Field<string>("lock6ny"),
        //        beg7ny = dt_isprd.Rows[0].Field<DateTime?>("beg7ny"),
        //        end7ny = dt_isprd.Rows[0].Field<DateTime?>("end7ny"),
        //        lock7ny = dt_isprd.Rows[0].Field<string>("lock7ny"),
        //        beg8ny = dt_isprd.Rows[0].Field<DateTime?>("beg8ny"),
        //        end8ny = dt_isprd.Rows[0].Field<DateTime?>("end8ny"),
        //        lock8ny = dt_isprd.Rows[0].Field<string>("lock8ny"),
        //        beg9ny = dt_isprd.Rows[0].Field<DateTime?>("beg9ny"),
        //        end9ny = dt_isprd.Rows[0].Field<DateTime?>("end9ny"),
        //        lock9ny = dt_isprd.Rows[0].Field<string>("lock9ny"),
        //        beg10ny = dt_isprd.Rows[0].Field<DateTime?>("beg10ny"),
        //        end10ny = dt_isprd.Rows[0].Field<DateTime?>("end10ny"),
        //        lock10ny = dt_isprd.Rows[0].Field<string>("lock10ny"),
        //        beg11ny = dt_isprd.Rows[0].Field<DateTime?>("beg11ny"),
        //        end11ny = dt_isprd.Rows[0].Field<DateTime?>("end11ny"),
        //        lock11ny = dt_isprd.Rows[0].Field<string>("lock11ny"),
        //        beg12ny = dt_isprd.Rows[0].Field<DateTime?>("beg12ny"),
        //        end12ny = dt_isprd.Rows[0].Field<DateTime?>("end12ny"),
        //        lock12ny = dt_isprd.Rows[0].Field<string>("lock12ny"),

        //    };

        //    return isprd;

        //}

        //public static List<IsrunDbf> ToIsrunList(this DataTable isrun_dbf)
        //{
        //    List<IsrunDbf> isrun = new List<IsrunDbf>();

        //    foreach (DataRow row in isrun_dbf.Rows)
        //    {
        //        try
        //        {
        //            IsrunDbf i = new IsrunDbf
        //            {
        //                doctyp = !(row.IsNull("doctyp")) ? row.Field<string>("doctyp") : string.Empty,
        //                doccod = !(row.IsNull("doccod")) ? row.Field<string>("doccod") : string.Empty,
        //                shortnam = !(row.IsNull("shortnam")) ? row.Field<string>("shortnam") : string.Empty,
        //                posdes = !(row.IsNull("posdes")) ? row.Field<string>("posdes") : string.Empty,
        //                posdes2 = !(row.IsNull("posdes2")) ? row.Field<string>("posdes2") : string.Empty,
        //                prefix = !(row.IsNull("prefix")) ? row.Field<string>("prefix") : string.Empty,
        //                docnum = !(row.IsNull("docnum")) ? row.Field<string>("docnum") : string.Empty,
        //                ismodify = !(row.IsNull("ismodify")) ? row.Field<bool>("ismodify") : false,
        //                depcod = !(row.IsNull("depcod")) ? row.Field<string>("depcod") : string.Empty,
        //                jnltyp = !(row.IsNull("jnltyp")) ? row.Field<string>("jnltyp") : string.Empty,
        //                jnlexp = !(row.IsNull("jnlexp")) ? row.Field<string>("jnlexp") : string.Empty,
        //                accnum01 = !(row.IsNull("accnum01")) ? row.Field<string>("accnum01") : string.Empty,
        //                accnum02 = !(row.IsNull("accnum02")) ? row.Field<string>("accnum02") : string.Empty,
        //                accnum03 = !(row.IsNull("accnum03")) ? row.Field<string>("accnum03") : string.Empty,
        //                accnum04 = !(row.IsNull("accnum04")) ? row.Field<string>("accnum04") : string.Empty,
        //                accnum05 = !(row.IsNull("accnum05")) ? row.Field<string>("accnum05") : string.Empty,
        //                accnum06 = !(row.IsNull("accnum06")) ? row.Field<string>("accnum06") : string.Empty,
        //                accnum07 = !(row.IsNull("accnum07")) ? row.Field<string>("accnum07") : string.Empty,
        //                accnum08 = !(row.IsNull("accnum08")) ? row.Field<string>("accnum08") : string.Empty,
        //                accnum09 = !(row.IsNull("accnum09")) ? row.Field<string>("accnum09") : string.Empty,
        //                accnum10 = !(row.IsNull("accnum10")) ? row.Field<string>("accnum10") : string.Empty,
        //                accnum11 = !(row.IsNull("accnum11")) ? row.Field<string>("accnum11") : string.Empty,
        //                accnum12 = !(row.IsNull("accnum12")) ? row.Field<string>("accnum12") : string.Empty,
        //                flgvat = !(row.IsNull("flgvat")) ? row.Field<string>("flgvat") : string.Empty,
        //                vatrat = !(row.IsNull("vatrat")) ? row.Field<decimal>("vatrat") : 0m,
        //                srv_vattyp = !(row.IsNull("srv_vattyp")) ? row.Field<string>("srv_vattyp") : string.Empty,
        //                autoprn = !(row.IsNull("autoprn")) ? row.Field<string>("autoprn") : string.Empty,
        //                whichform = !(row.IsNull("whichform")) ? row.Field<string>("whichform") : string.Empty,
        //                reprn_lev = !(row.IsNull("reprn_lev")) ? row.Field<string>("reprn_lev") : string.Empty,
        //                cancel_lev = !(row.IsNull("cancel_lev")) ? row.Field<string>("cancel_lev") : string.Empty,
        //                delete_lev = !(row.IsNull("delete_lev")) ? row.Field<string>("delete_lev") : string.Empty,
        //                approv_met = !(row.IsNull("approv_met")) ? row.Field<string>("approv_met") : string.Empty,
        //                approv_lev = !(row.IsNull("approv_lev")) ? row.Field<string>("approv_lev") : string.Empty,
        //                ovrlin_lev = !(row.IsNull("ovrlin_lev")) ? row.Field<string>("ovrlin_lev") : string.Empty,
        //                vat_initem = !(row.IsNull("vat_initem")) ? row.Field<string>("vat_initem") : string.Empty,
        //                loccod = !(row.IsNull("loccod")) ? row.Field<string>("loccod") : string.Empty,
        //                usebarcod = !(row.IsNull("usebarcod")) ? row.Field<string>("usebarcod") : string.Empty,
        //                pvatprorat = !(row.IsNull("pvatprorat")) ? row.Field<string>("pvatprorat") : string.Empty,
        //                reserve1 = !(row.IsNull("reserve1")) ? row.Field<string>("reserve1") : string.Empty,
        //                reserve2 = !(row.IsNull("reserve2")) ? row.Field<string>("reserve2") : string.Empty,
        //                reserve3 = !(row.IsNull("reserve3")) ? row.Field<double>("reserve3") : 0d
        //            };

        //            isrun.Add(i);
        //        }
        //        catch (Exception ex)
        //        {
        //            continue;
        //        }
        //    }

        //    return isrun;
        //}
        #endregion Isprd, Isrun

        public static List<Inv> ToInvList(this DataTable inv_dbf)
        {
            List<Inv> inv = new List<Inv>();
            foreach (DataRow row in inv_dbf.Rows)
            {
                try
                {
                    Inv i = new Inv
                    {
                        data_path = row.Field<string>("datapath").Trim(),
                        docnum = row.Field<string>("docnum").Trim(),
                        email = row.Field<string>("email").Trim(),
                        status = row.Field<string>("status").Trim()
                    };

                    inv.Add(i);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return inv;
        }

        public static List<IstabDbf> ToIstabList(this DataTable istab_dbf)
        {
            List<IstabDbf> istab = new List<IstabDbf>();

            foreach (DataRow row in istab_dbf.Rows)
            {
                try
                {
                    IstabDbf i = new IstabDbf
                    {
                        tabtyp = row.Field<string>("tabtyp").Trim(),
                        typcod = row.Field<string>("typcod").Trim(),
                        shortnam = row.Field<string>("shortnam").Trim(),
                        shortnam2 = row.Field<string>("shortnam2").Trim(),
                        typdes = row.Field<string>("typdes").Trim(),
                        typdes2 = row.Field<string>("typdes2").Trim(),
                        fld01 = row.Field<string>("fld01").Trim(),
                        fld02 = !(row.IsNull("fld02")) ? row.Field<double>("fld02") : 0d,
                        depcod = row.Field<string>("depcod").Trim(),
                        status = row.Field<string>("status").Trim()
                    };

                    istab.Add(i);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return istab;
        }

        public static List<StmasDbf> ToStmasList(this DataTable stmas_dbf)
        {
            List<StmasDbf> stmas = new List<StmasDbf>();

            foreach (DataRow row in stmas_dbf.Rows)
            {
                try
                {
                    StmasDbf s = new StmasDbf
                    {
                        stkcod = row.Field<string>("stkcod").Trim(),
                        stkdes = row.Field<string>("stkdes").Trim(),
                        stkdes2 = row.Field<string>("stkdes2").Trim(),
                        stktyp = row.Field<string>("stktyp").Trim(),
                        stklev = row.Field<string>("stklev").Trim(),
                        stkgrp = row.Field<string>("stkgrp").Trim(),
                        barcod = row.Field<string>("barcod").Trim(),
                        stkcods = row.Field<string>("stkcods").Trim(),
                        acccod = row.Field<string>("acccod").Trim(),
                        isinv = row.Field<string>("isinv").Trim(),
                        stkclass = row.Field<string>("stkclass").Trim(),
                        negallow = row.Field<string>("negallow").Trim(),
                        qucod = row.Field<string>("qucod").Trim(),
                        cqucod = row.Field<string>("cqucod").Trim(),
                        cfactor = row.Field<double>("cfactor"),
                        stnpr = row.Field<double>("stnpr"),
                        ispur = row.Field<string>("ispur").Trim(),
                        pqucod = row.Field<string>("pqucod").Trim(),
                        pfactor = row.Field<double>("pfactor"),
                        lpurqu = row.Field<string>("lpurqu").Trim(),
                        lpurfac = row.Field<double>("lpurfac"),
                        lpurpr = row.Field<double>("lpurpr"),
                        lpdisc = row.Field<string>("lpdisc").Trim(),
                        lpurdat = row.Field<DateTime?>("lpurdat"),
                        supcod = row.Field<string>("supcod").Trim(),
                        issal = row.Field<string>("issal").Trim(),
                        squcod = row.Field<string>("squcod").Trim(),
                        sfactor = row.Field<double>("sfactor"),
                        sellpr1 = row.Field<double>("sellpr1"),
                        sellpr2 = row.Field<double>("sellpr2"),
                        sellpr3 = row.Field<double>("sellpr3"),
                        sellpr4 = row.Field<double>("sellpr4"),
                        sellpr5 = row.Field<double>("sellpr5"),
                        tracksal = row.Field<string>("tracksal").Trim(),
                        vatcod = row.Field<string>("vatcod").Trim(),
                        iscom = row.Field<string>("iscom").Trim(),
                        comrat = row.Field<string>("comrat").Trim(),
                        lsellqu = row.Field<string>("lsellqu").Trim(),
                        lsellfac = row.Field<double>("lsellfac"),
                        lsellpr = row.Field<double>("lsellpr"),
                        lsdisc = row.Field<string>("lsdisc").Trim(),
                        lseldat = row.Field<DateTime?>("lseldat"),
                        numelem = row.Field<decimal?>("numelem"),
                        totbal = row.Field<double>("totbal"),
                        totval = row.Field<double>("totval"),
                        totreo = row.Field<double>("totreo"),
                        totres = row.Field<double>("totres"),
                        opnbal = row.Field<double>("opnbal"),
                        unitpr = row.Field<double>("unitpr"),
                        opnval = row.Field<double>("opnval"),
                        lasupd = row.Field<DateTime?>("lasupd"),
                        packing = row.Field<string>("packing").Trim(),
                        mlotnum = row.Field<string>("mlotnum").Trim(),
                        mrembal = row.Field<double>("mrembal"),
                        mremval = row.Field<double>("mremval"),
                        remark = row.Field<string>("remark").Trim(),
                        dat1 = row.Field<DateTime?>("dat1"),
                        dat2 = row.Field<DateTime?>("dat2"),
                        num1 = row.Field<double>("num1"),
                        str1 = row.Field<string>("str1").Trim(),
                        str2 = row.Field<string>("str2").Trim(),
                        str3 = row.Field<string>("str3").Trim(),
                        str4 = row.Field<string>("str4").Trim(),
                        creby = row.Field<string>("creby").Trim(),
                        credat = row.Field<DateTime?>("credat"),
                        userid = row.Field<string>("userid").Trim(),
                        chgdat = row.Field<DateTime?>("chgdat"),
                        status = row.Field<string>("status").Trim(),
                        inactdat = row.Field<DateTime?>("inactdat")
                    };
                    stmas.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stmas;
        }

        public static List<StlocDbf> ToStlocList(this DataTable stloc_dbf)
        {
            List<StlocDbf> stloc = new List<StlocDbf>();

            foreach (DataRow row in stloc_dbf.Rows)
            {
                try
                {
                    StlocDbf s = new StlocDbf
                    {
                        stkcod = row.Field<string>("stkcod").Trim(),
                        loccod = row.Field<string>("loccod").Trim(),
                        area = row.Field<string>("area").Trim(),
                        stkclass = row.Field<string>("stkclass").Trim(),
                        locbal = !row.IsNull("locbal") ? row.Field<double>("locbal") : 0d,
                        unitpr = !row.IsNull("unitpr") ? row.Field<double>("unitpr") : 0d,
                        locval = !row.IsNull("locval") ? row.Field<double>("locval") : 0d,
                        locreo = !row.IsNull("locreo") ? row.Field<double>("locreo") : 0d,
                        locres = !row.IsNull("locres") ? row.Field<double>("locres") : 0d,
                        lpurdat = !row.IsNull("lpurdat") ? (DateTime?)row.Field<DateTime>("lpurdat") : null,
                        lseldat = !row.IsNull("lseldat") ? (DateTime?)row.Field<DateTime>("lseldat") : null,
                        lmovdat = !row.IsNull("lmovdat") ? (DateTime?)row.Field<DateTime>("lmovdat") : null,
                        takdat = !row.IsNull("takdat") ? (DateTime?)row.Field<DateTime>("takdat") : null,
                        mlotnum = row.Field<string>("mlotnum").Trim(),
                        mrembal = !row.IsNull("mrembal") ? row.Field<double>("mrembal") : 0d,
                        mremval = !row.IsNull("mremval") ? row.Field<double>("mremval") : 0d,
                        begbal = !row.IsNull("begbal") ? row.Field<double>("begbal") : 0d,
                        begval = !row.IsNull("begval") ? row.Field<double>("begval") : 0d,
                        qty1 = !row.IsNull("qty1") ? row.Field<double>("qty1") : 0d,
                        qty2 = !row.IsNull("qty2") ? row.Field<double>("qty2") : 0d,
                        qty3 = !row.IsNull("qty3") ? row.Field<double>("qty3") : 0d,
                        qty4 = !row.IsNull("qty4") ? row.Field<double>("qty4") : 0d,
                        qty5 = !row.IsNull("qty5") ? row.Field<double>("qty5") : 0d,
                        qty6 = !row.IsNull("qty6") ? row.Field<double>("qty6") : 0d,
                        qty7 = !row.IsNull("qty7") ? row.Field<double>("qty7") : 0d,
                        qty8 = !row.IsNull("qty8") ? row.Field<double>("qty8") : 0d,
                        qty9 = !row.IsNull("qty9") ? row.Field<double>("qty9") : 0d,
                        qty10 = !row.IsNull("qty10") ? row.Field<double>("qty10") : 0d,
                        qty11 = !row.IsNull("qty11") ? row.Field<double>("qty11") : 0d,
                        qty12 = !row.IsNull("qty12") ? row.Field<double>("qty12") : 0d,
                        qty1ny = !row.IsNull("qty1ny") ? row.Field<double>("qty1ny") : 0d,
                        qty2ny = !row.IsNull("qty2ny") ? row.Field<double>("qty2ny") : 0d,
                        qty3ny = !row.IsNull("qty3ny") ? row.Field<double>("qty3ny") : 0d,
                        qty4ny = !row.IsNull("qty4ny") ? row.Field<double>("qty4ny") : 0d,
                        qty5ny = !row.IsNull("qty5ny") ? row.Field<double>("qty5ny") : 0d,
                        qty6ny = !row.IsNull("qty6ny") ? row.Field<double>("qty6ny") : 0d,
                        qty7ny = !row.IsNull("qty7ny") ? row.Field<double>("qty7ny") : 0d,
                        qty8ny = !row.IsNull("qty8ny") ? row.Field<double>("qty8ny") : 0d,
                        qty9ny = !row.IsNull("qty9ny") ? row.Field<double>("qty9ny") : 0d,
                        qty10ny = !row.IsNull("qty10ny") ? row.Field<double>("qty10ny") : 0d,
                        qty11ny = !row.IsNull("qty11ny") ? row.Field<double>("qty11ny") : 0d,
                        qty12ny = !row.IsNull("qty12ny") ? row.Field<double>("qty12ny") : 0d,
                        val1 = !row.IsNull("val1") ? row.Field<double>("val1") : 0d,
                        val2 = !row.IsNull("val2") ? row.Field<double>("val2") : 0d,
                        val3 = !row.IsNull("val3") ? row.Field<double>("val3") : 0d,
                        val4 = !row.IsNull("val4") ? row.Field<double>("val4") : 0d,
                        val5 = !row.IsNull("val5") ? row.Field<double>("val5") : 0d,
                        val6 = !row.IsNull("val6") ? row.Field<double>("val6") : 0d,
                        val7 = !row.IsNull("val7") ? row.Field<double>("val7") : 0d,
                        val8 = !row.IsNull("val8") ? row.Field<double>("val8") : 0d,
                        val9 = !row.IsNull("val9") ? row.Field<double>("val9") : 0d,
                        val10 = !row.IsNull("val10") ? row.Field<double>("val10") : 0d,
                        val11 = !row.IsNull("val11") ? row.Field<double>("val11") : 0d,
                        val12 = !row.IsNull("val12") ? row.Field<double>("val12") : 0d,
                        val1ny = !row.IsNull("val1ny") ? row.Field<double>("val1ny") : 0d,
                        val2ny = !row.IsNull("val2ny") ? row.Field<double>("val2ny") : 0d,
                        val3ny = !row.IsNull("val3ny") ? row.Field<double>("val3ny") : 0d,
                        val4ny = !row.IsNull("val4ny") ? row.Field<double>("val4ny") : 0d,
                        val5ny = !row.IsNull("val5ny") ? row.Field<double>("val5ny") : 0d,
                        val6ny = !row.IsNull("val6ny") ? row.Field<double>("val6ny") : 0d,
                        val7ny = !row.IsNull("val7ny") ? row.Field<double>("val7ny") : 0d,
                        val8ny = !row.IsNull("val8ny") ? row.Field<double>("val8ny") : 0d,
                        val9ny = !row.IsNull("val9ny") ? row.Field<double>("val9ny") : 0d,
                        val10ny = !row.IsNull("val10ny") ? row.Field<double>("val10ny") : 0d,
                        val11ny = !row.IsNull("val11ny") ? row.Field<double>("val11ny") : 0d,
                        val12ny = !row.IsNull("val12ny") ? row.Field<double>("val12ny") : 0d,
                        status = row.Field<string>("status").Trim(),
                        inactdat = !row.IsNull("inactdat") ? (DateTime?)row.Field<DateTime>("inactdat") : null
                    };

                    stloc.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stloc;
        }

        public static List<StcrdDbf> ToStcrdList(this DataTable stcrd_dbf)
        {
            List<StcrdDbf> stcrd = new List<StcrdDbf>();

            foreach (DataRow row in stcrd_dbf.Rows)
            {
                try
                {
                    StcrdDbf s = new StcrdDbf
                    {
                        stkcod = row.Field<string>("stkcod").Trim(),
                        loccod = row.Field<string>("loccod").Trim(),
                        docnum = row.Field<string>("docnum").Trim().Trim(),
                        seqnum = row.Field<string>("seqnum").Trim(),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        rdocnum = row.Field<string>("rdocnum").Trim(),
                        refnum = row.Field<string>("refnum").Trim(),
                        depcod = row.Field<string>("depcod").Trim(),
                        posopr = row.Field<string>("posopr").Trim(),
                        free = row.Field<string>("free").Trim(),
                        vatcod = row.Field<string>("vatcod").Trim(),
                        people = row.Field<string>("people").Trim(),
                        slmcod = row.Field<string>("slmcod").Trim(),
                        flag = row.Field<string>("flag").Trim(),
                        trnqty = row.Field<double>("trnqty"),
                        tqucod = row.Field<string>("tqucod").Trim(),
                        tfactor = row.Field<double>("tfactor"),
                        unitpr = row.Field<double>("unitpr"),
                        disc = row.Field<string>("disc").Trim(),
                        discamt = row.Field<double>("discamt"),
                        trnval = row.Field<double>("trnval"),
                        phybal = row.Field<double>("phybal"),
                        retstk = row.Field<string>("retstk").Trim(),
                        xtrnqty = row.Field<double>("xtrnqty"),
                        xunitpr = row.Field<double>("xunitpr"),
                        xtrnval = row.Field<double>("xtrnval"),
                        xsalval = row.Field<double>("xsalval"),
                        netval = row.Field<double>("netval"),
                        mlotnum = row.Field<string>("mlotnum").Trim(),
                        mrembal = row.Field<double>("mrembal"),
                        mremval = row.Field<double>("mremval"),
                        balchg = row.Field<double>("balchg"),
                        valchg = row.Field<double>("valchg"),
                        lotbal = row.Field<double>("lotbal"),
                        lotval = row.Field<double>("lotval"),
                        lunitpr = row.Field<double>("lunitpr"),
                        pstkcod = row.Field<string>("pstkcod").Trim(),
                        accnumdr = row.Field<string>("accnumdr").Trim(),
                        accnumcr = row.Field<string>("accnumcr").Trim(),
                        stkdes = row.Field<string>("stkdes").Trim(),
                        packing = row.Field<string>("packing").Trim(),
                        jobcod = row.Field<string>("jobcod").Trim(),
                        phase = row.Field<string>("phase").Trim(),
                        coscod = row.Field<string>("coscod").Trim(),
                        reimburse = row.Field<string>("reimburse").Trim()
                    };

                    stcrd.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stcrd;
        }

        public static List<ApmasDbf> ToApmasList(this DataTable apmas_dbf)
        {
            List<ApmasDbf> apmas = new List<ApmasDbf>();

            foreach (DataRow row in apmas_dbf.Rows)
            {
                try
                {
                    ApmasDbf a = new ApmasDbf
                    {
                        supcod = row.Field<string>("supcod").Trim(),
                        suptyp = row.Field<string>("suptyp").Trim(),
                        onhold = row.Field<string>("onhold").Trim(),
                        prenam = row.Field<string>("prenam").Trim(),
                        supnam = row.Field<string>("supnam").Trim(),
                        addr01 = row.Field<string>("addr01").Trim(),
                        addr02 = row.Field<string>("addr02").Trim(),
                        addr03 = row.Field<string>("addr03").Trim(),
                        zipcod = row.Field<string>("zipcod").Trim(),
                        telnum = row.Field<string>("telnum").Trim(),
                        contact = row.Field<string>("contact").Trim(),
                        supnam2 = row.Field<string>("supnam2").Trim(),
                        paytrm = !row.IsNull("paytrm") ? row.Field<decimal>("paytrm") : 0m,
                        paycond = row.Field<string>("paycond").Trim(),
                        dlvby = row.Field<string>("dlvby").Trim(),
                        vatrat = !row.IsNull("vatrat") ? row.Field<decimal>("vatrat") : 0m,
                        flgvat = row.Field<string>("flgvat").Trim(),
                        disc = row.Field<string>("disc").Trim(),
                        balance = !row.IsNull("balance") ? row.Field<double>("balance") : 0d,
                        chqpay = !row.IsNull("chqpay") ? row.Field<double>("chqpay") : 0d,
                        crline = !row.IsNull("crline") ? row.Field<double>("crline") : 0d,
                        lasrcv = !row.IsNull("lasrcv") ? (DateTime?)row.Field<DateTime>("lasrcv") : null,
                        accnum = row.Field<string>("accnum").Trim(),
                        remark = row.Field<string>("remark").Trim(),
                        taxid = row.Field<string>("taxid").Trim(),
                        orgnum = !row.IsNull("orgnum") ? row.Field<decimal>("orgnum") : 0m,
                        taxdes = row.Field<string>("taxdes").Trim(),
                        taxrat = !row.IsNull("taxrat") ? row.Field<decimal>("taxrat") : 0m,
                        taxtyp = row.Field<string>("taxtyp").Trim(),
                        taxcond = row.Field<string>("taxcond").Trim(),
                        creby = row.Field<string>("creby").Trim(),
                        credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null,
                        userid = row.Field<string>("userid").Trim(),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        status = row.Field<string>("status").Trim(),
                        inactdat = !row.IsNull("inactdat") ? (DateTime?)row.Field<DateTime>("inactdat") : null
                    };

                    apmas.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return apmas;
        }

        public static List<AptrnDbf> ToAptrnList(this DataTable aptrn_dbf)
        {
            List<AptrnDbf> aptrn = new List<AptrnDbf>();

            foreach (DataRow row in aptrn_dbf.Rows)
            {
                try
                {
                    AptrnDbf a = new AptrnDbf
                    {
                        rectyp = row.Field<string>("rectyp").Trim(),
                        docnum = row.Field<string>("docnum").Trim().Trim(),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        refnum = row.Field<string>("refnum").Trim(),
                        vatprd = !row.IsNull("vatprd") ? (DateTime?)row.Field<DateTime>("vatprd") : null,
                        vatlate = row.Field<string>("vatlate").Trim(),
                        vattyp = row.Field<string>("vattyp").Trim(),
                        postgl = row.Field<string>("postgl").Trim(),
                        ponum = row.Field<string>("ponum").Trim(),
                        dntyp = row.Field<string>("dntyp").Trim(),
                        depcod = row.Field<string>("depcod").Trim(),
                        flgvat = row.Field<string>("flgvat").Trim(),
                        supcod = row.Field<string>("supcod").Trim(),
                        shipto = row.Field<string>("shipto").Trim(),
                        youref = row.Field<string>("youref").Trim(),
                        paytrm = row.Field<decimal>("paytrm"),
                        duedat = !row.IsNull("duedat") ? (DateTime?)row.Field<DateTime>("duedat") : null,
                        bilnum = row.Field<string>("bilnum").Trim(),
                        dlvby = row.Field<string>("dlvby").Trim(),
                        nxtseq = row.Field<string>("nxtseq").Trim(),
                        amount = row.Field<double>("amount"),
                        disc = row.Field<string>("disc").Trim(),
                        discamt = row.Field<double>("discamt"),
                        aftdisc = row.Field<double>("aftdisc"),
                        advnum = row.Field<string>("advnum").Trim(),
                        advamt = row.Field<double>("advamt"),
                        total = row.Field<double>("total"),
                        amtrat0 = row.Field<double>("amtrat0"),
                        vatrat = row.Field<decimal>("vatrat"),
                        vatamt = row.Field<double>("vatamt"),
                        netamt = row.Field<double>("netamt"),
                        netval = row.Field<double>("netval"),
                        payamt = row.Field<double>("payamt"),
                        remamt = row.Field<double>("remamt"),
                        cmplapp = row.Field<string>("cmplapp").Trim(),
                        cmpldat = !row.IsNull("cmpldat") ? (DateTime?)row.Field<DateTime>("cmpldat") : null,
                        docstat = row.Field<string>("docstat").Trim(),
                        cshpay = row.Field<double>("cshpay"),
                        chqpay = row.Field<double>("chqpay"),
                        intpay = row.Field<double>("intpay"),
                        tax = row.Field<double>("tax"),
                        rcvamt = row.Field<double>("rcvamt"),
                        chqpas = row.Field<double>("chqpas"),
                        vatdat = !row.IsNull("vatdat") ? (DateTime?)row.Field<DateTime>("vatdat") : null,
                        srv_vattyp = row.Field<string>("srv_vattyp").Trim(),
                        pvatprorat = row.Field<string>("pvatprorat").Trim(),
                        pvat_rf = row.Field<decimal>("pvat_rf"),
                        pvat_nrf = row.Field<decimal>("pvat_nrf"),
                        userid = row.Field<string>("userid").Trim(),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        userprn = row.Field<string>("userprn").Trim(),
                        prndat = !row.IsNull("prndat") ? (DateTime?)row.Field<DateTime>("prndat") : null,
                        prncnt = row.Field<decimal>("prncnt"),
                        authid = row.Field<string>("authid").Trim(),
                        approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
                        billbe = row.Field<string>("billbe").Trim(),
                        orgnum = row.Field<decimal>("orgnum")
                    };
                    /* only in V.1 */
                    if (aptrn_dbf.Columns.Contains("prntim"))
                        a.prntim = row.Field<string>("prntim").Trim();

                    /* only in V.2^ */
                    if (aptrn_dbf.Columns.Contains("creby"))
                        a.creby = row.Field<string>("creby").Trim();
                    if (aptrn_dbf.Columns.Contains("credat"))
                        a.credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null;
                    if (aptrn_dbf.Columns.Contains("c_type"))
                        a.c_type = row.Field<string>("c_type").Trim();
                    if (aptrn_dbf.Columns.Contains("c_date"))
                        a.c_date = !row.IsNull("c_date") ? (DateTime?)row.Field<DateTime>("c_date") : null;
                    if (aptrn_dbf.Columns.Contains("c_ref"))
                        a.c_ref = row.Field<string>("c_ref").Trim();
                    if (aptrn_dbf.Columns.Contains("c_rate"))
                        a.c_rate = row.Field<double>("c_rate");
                    if (aptrn_dbf.Columns.Contains("c_fixrate"))
                        a.c_fixrate = row.Field<string>("c_fixrate").Trim();
                    if (aptrn_dbf.Columns.Contains("c_ratio"))
                        a.c_ratio = row.Field<double>("c_ratio");
                    if (aptrn_dbf.Columns.Contains("c_amount"))
                        a.c_amount = row.Field<double>("c_amount");
                    if (aptrn_dbf.Columns.Contains("c_disc"))
                        a.c_disc = row.Field<string>("c_disc").Trim();
                    if (aptrn_dbf.Columns.Contains("c_discamt"))
                        a.c_discamt = row.Field<double>("c_discamt");
                    if (aptrn_dbf.Columns.Contains("c_aftdisc"))
                        a.c_aftdisc = row.Field<double>("c_aftdisc");
                    if (aptrn_dbf.Columns.Contains("c_advamt"))
                        a.c_advamt = row.Field<double>("c_advamt");
                    if (aptrn_dbf.Columns.Contains("c_total"))
                        a.c_total = row.Field<double>("c_total");
                    if (aptrn_dbf.Columns.Contains("c_netamt"))
                        a.c_netamt = row.Field<double>("c_netamt");
                    if (aptrn_dbf.Columns.Contains("c_netval"))
                        a.c_netval = row.Field<double>("c_netval");
                    if (aptrn_dbf.Columns.Contains("c_rcvamt"))
                        a.c_rcvamt = row.Field<double>("c_rcvamt");
                    if (aptrn_dbf.Columns.Contains("c_difamt"))
                        a.c_difamt = row.Field<double>("c_difamt");
                    if (aptrn_dbf.Columns.Contains("c_payamt"))
                        a.c_payamt = row.Field<double>("c_payamt");
                    if (aptrn_dbf.Columns.Contains("c_remamt"))
                        a.c_remamt = row.Field<double>("c_remamt");
                    if (aptrn_dbf.Columns.Contains("link1"))
                        a.link1 = row.Field<string>("link1").Trim();
                    if (aptrn_dbf.Columns.Contains("dat1"))
                        a.dat1 = !row.IsNull("dat1") ? (DateTime?)row.Field<DateTime>("dat1") : null;
                    if (aptrn_dbf.Columns.Contains("dat2"))
                        a.dat2 = !row.IsNull("dat2") ? (DateTime?)row.Field<DateTime>("dat2") : null;
                    if (aptrn_dbf.Columns.Contains("num1"))
                        a.num1 = row.Field<double>("num1");
                    if (aptrn_dbf.Columns.Contains("num2"))
                        a.num2 = row.Field<double>("num2");
                    if (aptrn_dbf.Columns.Contains("str1"))
                        a.str1 = row.Field<string>("str1").Trim();
                    if (aptrn_dbf.Columns.Contains("str2"))
                        a.str2 = row.Field<string>("str2").Trim();

                    aptrn.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return aptrn;
        }

        public static List<ArtrnDbf> ToArtrnList(this DataTable artrn_dbf)
        {
            List<ArtrnDbf> artrn = new List<ArtrnDbf>();

            foreach (DataRow row in artrn_dbf.Rows)
            {
                try
                {
                    ArtrnDbf a = new ArtrnDbf
                    {
                        rectyp = row.Field<string>("rectyp").Trim(),
                        docnum = row.Field<string>("docnum").Trim(),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        postgl = row.Field<string>("postgl").Trim(),
                        sonum = row.Field<string>("sonum").Trim(),
                        cntyp = row.Field<string>("cntyp").Trim(),
                        depcod = row.Field<string>("depcod").Trim(),
                        flgvat = row.Field<string>("flgvat").Trim(),
                        slmcod = row.Field<string>("slmcod").Trim(),
                        cuscod = row.Field<string>("cuscod").Trim(),
                        shipto = row.Field<string>("shipto").Trim(),
                        youref = row.Field<string>("youref").Trim(),
                        areacod = row.Field<string>("areacod").Trim(),
                        paytrm = row.Field<decimal>("paytrm"),
                        duedat = !row.IsNull("duedat") ? (DateTime?)row.Field<DateTime>("duedat") : null,
                        bilnum = row.Field<string>("bilnum").Trim(),
                        nxtseq = row.Field<string>("nxtseq").Trim(),
                        amount = row.Field<double>("amount"),
                        disc = row.Field<string>("disc").Trim(),
                        discamt = row.Field<double>("discamt"),
                        aftdisc = row.Field<double>("aftdisc"),
                        advnum = row.Field<string>("advnum").Trim(),
                        advamt = row.Field<double>("advamt"),
                        total = row.Field<double>("total"),
                        amtrat0 = row.Field<double>("amtrat0"),
                        vatrat = row.Field<decimal>("vatrat"),
                        vatamt = row.Field<double>("vatamt"),
                        netamt = row.Field<double>("netamt"),
                        netval = row.Field<double>("netval"),
                        rcvamt = row.Field<double>("rcvamt"),
                        remamt = row.Field<double>("remamt"),
                        comamt = row.Field<double>("comamt"),
                        cmplapp = row.Field<string>("cmplapp").Trim(),
                        cmpldat = !row.IsNull("cmpldat") ? (DateTime?)row.Field<DateTime>("cmpldat") : null,
                        docstat = row.Field<string>("docstat").Trim(),
                        cshrcv = row.Field<double>("cshrcv"),
                        chqrcv = row.Field<double>("chqrcv"),
                        intrcv = row.Field<double>("intrcv"),
                        beftax = row.Field<double>("beftax"),
                        taxrat = row.Field<decimal>("taxrat"),
                        taxcond = row.Field<string>("taxcond").Trim(),
                        tax = row.Field<double>("tax"),
                        ivcamt = row.Field<double>("ivcamt"),
                        chqpas = row.Field<double>("chqpas"),
                        vatdat = !row.IsNull("vatdat") ? (DateTime?)row.Field<DateTime>("vatdat") : null,
                        vatprd = !row.IsNull("vatprd") ? (DateTime?)row.Field<DateTime>("vatprd") : null,
                        vatlate = row.Field<string>("vatlate").Trim(),
                        srv_vattyp = row.Field<string>("srv_vattyp").Trim(),
                        dlvby = row.Field<string>("dlvby").Trim(),
                        reserve = !row.IsNull("reserve") ? (DateTime?)row.Field<DateTime>("reserve") : null,
                        userid = row.Field<string>("userid").Trim(),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        userprn = row.Field<string>("userprn").Trim(),
                        prndat = !row.IsNull("prndat") ? (DateTime?)row.Field<DateTime>("prndat") : null,
                        prncnt = row.Field<decimal>("prncnt"),
                        authid = row.Field<string>("authid").Trim(),
                        approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
                        billto = row.Field<string>("billto").Trim(),
                        orgnum = row.Field<decimal>("orgnum")
                    };

                    /* only in v.1 */
                    if (artrn_dbf.Columns.Contains("prntim"))
                        a.prntim = row.Field<string>("prntim").Trim();
                    /* only in v.2 */
                    if (artrn_dbf.Columns.Contains("creby"))
                        a.creby = row.Field<string>("creby").Trim();
                    if (artrn_dbf.Columns.Contains("credat"))
                        a.credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null;
                    if (artrn_dbf.Columns.Contains("ponum"))
                        a.ponum = row.Field<string>("ponum").Trim();
                    if (artrn_dbf.Columns.Contains("c_type"))
                        a.c_type = row.Field<string>("c_type").Trim();
                    if (artrn_dbf.Columns.Contains("c_date"))
                        a.c_date = !row.IsNull("c_date") ? (DateTime?)row.Field<DateTime>("c_date") : null;
                    if (artrn_dbf.Columns.Contains("c_ref"))
                        a.c_ref = row.Field<string>("c_ref").Trim();
                    if (artrn_dbf.Columns.Contains("c_rate"))
                        a.c_rate = row.Field<double>("c_rate");
                    if (artrn_dbf.Columns.Contains("c_fixrate"))
                        a.c_fixrate = row.Field<string>("c_fixrate").Trim();
                    if (artrn_dbf.Columns.Contains("c_ratio"))
                        a.c_ratio = row.Field<double>("c_ratio");
                    if (artrn_dbf.Columns.Contains("c_amount"))
                        a.c_amount = row.Field<double>("c_amount");
                    if (artrn_dbf.Columns.Contains("c_disc"))
                        a.c_disc = row.Field<string>("c_disc").Trim();
                    if (artrn_dbf.Columns.Contains("c_discamt"))
                        a.c_discamt = row.Field<double>("c_discamt");
                    if (artrn_dbf.Columns.Contains("c_aftdisc"))
                        a.c_aftdisc = row.Field<double>("c_aftdisc");
                    if (artrn_dbf.Columns.Contains("c_advamt"))
                        a.c_advamt = row.Field<double>("c_advamt");
                    if (artrn_dbf.Columns.Contains("c_total"))
                        a.c_total = row.Field<double>("c_total");
                    if (artrn_dbf.Columns.Contains("c_netamt"))
                        a.c_netamt = row.Field<double>("c_netamt");
                    if (artrn_dbf.Columns.Contains("c_netval"))
                        a.c_netval = row.Field<double>("c_netval");
                    if (artrn_dbf.Columns.Contains("c_ivcamt"))
                        a.c_ivcamt = row.Field<double>("c_ivcamt");
                    if (artrn_dbf.Columns.Contains("c_difamt"))
                        a.c_difamt = row.Field<double>("c_difamt");
                    if (artrn_dbf.Columns.Contains("c_rcvamt"))
                        a.c_rcvamt = row.Field<double>("c_rcvamt");
                    if (artrn_dbf.Columns.Contains("c_remamt"))
                        a.c_remamt = row.Field<double>("c_remamt");
                    if (artrn_dbf.Columns.Contains("link1"))
                        a.link1 = row.Field<string>("link1").Trim();
                    if (artrn_dbf.Columns.Contains("dat1"))
                        a.dat1 = !row.IsNull("dat1") ? (DateTime?)row.Field<DateTime>("dat1") : null;
                    if (artrn_dbf.Columns.Contains("dat2"))
                        a.dat2 = !row.IsNull("dat2") ? (DateTime?)row.Field<DateTime>("dat2") : null;
                    if (artrn_dbf.Columns.Contains("num1"))
                        a.num1 = row.Field<double>("num1");
                    if (artrn_dbf.Columns.Contains("num2"))
                        a.num2 = row.Field<double>("num2");
                    if (artrn_dbf.Columns.Contains("str1"))
                        a.str1 = row.Field<string>("str1").Trim();
                    if (artrn_dbf.Columns.Contains("str2"))
                        a.str2 = row.Field<string>("str2").Trim();

                    artrn.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return artrn;
        }

        public static List<ArmasDbf> ToArmasList(this DataTable armas_dbf)
        {
            List<ArmasDbf> armas = new List<ArmasDbf>();

            foreach (DataRow row in armas_dbf.Rows)
            {
                try
                {
                    ArmasDbf a = new ArmasDbf
                    {
                        cuscod = row.Field<string>("cuscod").Trim(),
                        custyp = row.Field<string>("custyp").Trim(),
                        prenam = row.Field<string>("prenam").Trim(),
                        cusnam = row.Field<string>("cusnam").Trim(),
                        addr01 = row.Field<string>("addr01").Trim(),
                        addr02 = row.Field<string>("addr02").Trim(),
                        addr03 = row.Field<string>("addr03").Trim(),
                        zipcod = row.Field<string>("zipcod").Trim(),
                        telnum = row.Field<string>("telnum").Trim(),
                        contact = row.Field<string>("contact").Trim(),
                        cusnam2 = row.Field<string>("cusnam2").Trim(),
                        taxid = row.Field<string>("taxid").Trim(),
                        orgnum = row.Field<decimal>("orgnum"),
                        taxtyp = row.Field<string>("taxtyp").Trim(),
                        taxrat = row.Field<decimal>("taxrat"),
                        taxgrp = row.Field<string>("taxgrp").Trim(),
                        taxcond = row.Field<string>("taxcond").Trim(),
                        shipto = row.Field<string>("shipto").Trim(),
                        slmcod = row.Field<string>("slmcod").Trim(),
                        areacod = row.Field<string>("areacod").Trim(),
                        paytrm = row.Field<decimal>("paytrm"),
                        paycond = row.Field<string>("paycond").Trim(),
                        payer = row.Field<string>("payer").Trim(),
                        tabpr = row.Field<string>("tabpr").Trim(),
                        disc = row.Field<string>("disc").Trim(),
                        balance = row.Field<double>("balance"),
                        chqrcv = row.Field<double>("chqrcv"),
                        crline = row.Field<double>("crline"),
                        lasivc = !row.IsNull("lasivc") ? (DateTime?)row.Field<DateTime>("lasivc") : null,
                        accnum = row.Field<string>("accnum").Trim(),
                        remark = row.Field<string>("remark").Trim(),
                        dlvby = row.Field<string>("dlvby").Trim(),
                        tracksal = row.Field<string>("tracksal").Trim(),
                        creby = row.Field<string>("creby").Trim(),
                        credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null,
                        userid = row.Field<string>("userid").Trim(),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        status = row.Field<string>("status").Trim(),
                        inactdat = !row.IsNull("inactdat") ? (DateTime?)row.Field<DateTime>("inactdat") : null,
                    };
                    armas.Add(a);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return armas;
        }
    }
}
