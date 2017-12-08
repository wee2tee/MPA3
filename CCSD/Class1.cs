using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCSD
{
    //public class Province
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public string name_en { get; set; }

    //}

    //public class City
    //{

    //}

    //public class CitySubDivision
    //{

    //}
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
}
