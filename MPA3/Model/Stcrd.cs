using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPA3.Model
{
    class Stcrd
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

        /* Additional for V.2 */
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string authid { get; set; }
        public DateTime? approve { get; set; }
        public string xcoscod { get; set; }
        public string xdepcod { get; set; }
        public string xjobcod { get; set; }
        public string xphase { get; set; }
        public string xaccnum { get; set; }
        public string accchgdr { get; set; }
        public string accchgcr { get; set; }
        public string ispi { get; set; }
        public string vatgrp { get; set; }
        public double? lot_qty { get; set; }
        public double? lot_val { get; set; }
        public string wartyp { get; set; }
        public string status { get; set; }
        public string old_status { get; set; }
        public double? c_unitpr { get; set; }
        public string c_disc { get; set; }
        public double? c_discamt { get; set; }
        public double? c_trnval { get; set; }
        public double? c_netval { get; set; }
        public string lotseq { get; set; }
        public string billxx { get; set; }
    }
}
