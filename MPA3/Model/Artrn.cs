using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPA3.Model
{
    public class Artrn
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
}
