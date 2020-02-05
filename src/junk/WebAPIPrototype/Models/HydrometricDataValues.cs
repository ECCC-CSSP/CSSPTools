using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class HydrometricDataValues
    {
        public int HydrometricDataValueID { get; set; }
        public int HydrometricSiteID { get; set; }
        public DateTime DateTime_Local { get; set; }
        public bool Keep { get; set; }
        public int StorageDataType { get; set; }
        public bool HasBeenRead { get; set; }
        public double? Discharge_m3_s { get; set; }
        public double? DischargeEntered_m3_s { get; set; }
        public double? Level_m { get; set; }
        public string HourlyValues { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual HydrometricSites HydrometricSite { get; set; }
    }
}
