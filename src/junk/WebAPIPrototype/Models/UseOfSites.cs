using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class UseOfSites
    {
        public int UseOfSiteID { get; set; }
        public int SiteTVItemID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int TVType { get; set; }
        public int Ordinal { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool? UseWeight { get; set; }
        public double? Weight_perc { get; set; }
        public bool? UseEquation { get; set; }
        public double? Param1 { get; set; }
        public double? Param2 { get; set; }
        public double? Param3 { get; set; }
        public double? Param4 { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems SiteTVItem { get; set; }
        public virtual TVItems SubsectorTVItem { get; set; }
    }
}
