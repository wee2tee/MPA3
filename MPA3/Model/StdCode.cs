using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPA3.Model
{
    public class StdDocumentName
    {
        public enum TYPE
        {
            _80,
            _81,
            _380,
            _388,
            _T01,
            _T02,
            _T03,
            _T04,
            _T05,
            _T06,
            _T07
        }

        public TYPE type { get; }
        public string typeCode
        {
            get
            {
                return this.type.ToString().TrimStart('_');
            }
        }
        public string Name
        {
            get
            {
                switch (this.type)
                {
                    case TYPE._80:
                        return "ใบเพิ่มหนี้ (Debit note)";
                    case TYPE._81:
                        return "ใบลดหนี้ (Credit note)";
                    case TYPE._380:
                        return "ใบแจ้งหนี้ (Invoice)";
                    case TYPE._388:
                        return "ใบกำกับภาษี (Tax invoice)";
                    case TYPE._T01:
                        return "ใบรับ (Receipt)";
                    case TYPE._T02:
                        return "ใบแจ้งหนี้/ใบกำกับภาษี (Invoice/ Tax Invoice)";
                    case TYPE._T03:
                        return "ใบเสร็จรับเงิน/ใบกำกับภาษี (Receipt/ Tax Invoice)";
                    case TYPE._T04:
                        return "ใบส่งของ/ใบกำกับภาษี (Delivery order/ Tax Invoice)";
                    case TYPE._T05:
                        return "ใบกำกับภาษีอย่างย่อ (Abbreviated Tax Invoice)";
                    case TYPE._T06:
                        return "ใบเสร็จรับเงิน/ใบกำกับภาษีอย่างย่อ (Receipt/ Abbreviated Tax Invoice)";
                    case TYPE._T07:
                        return "ใบแจ้งยกเลิก (Cancellation note)";
                    default:
                        return "";
                }
            }
        }

        public StdDocumentName(TYPE type)
        {
            this.type = type;
        }
    }

    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CitySubDivision
    {
        public string provinceId { get; set; }
        public string provinceName { get; set; }
        public string provinceNameEng { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string CityNameEng { get; set; }
        public string SubDivisionId { get; set; }
        public string SubDivisionName { get; set; }
        public string SubDivisionNameEng { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

    }

    public class Province
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<City> cities { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<SubDivision> subDivisions { get; set; }
    }

    public class SubDivision
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
    }
}
