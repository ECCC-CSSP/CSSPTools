using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class ClimateDataValues
    {
        public int ClimateDataValueID { get; set; }
        public int ClimateSiteID { get; set; }
        public DateTime DateTime_Local { get; set; }
        public bool Keep { get; set; }
        public int StorageDataType { get; set; }
        public bool HasBeenRead { get; set; }
        public double? Snow_cm { get; set; }
        public double? Rainfall_mm { get; set; }
        public double? RainfallEntered_mm { get; set; }
        public double? TotalPrecip_mm_cm { get; set; }
        public double? MaxTemp_C { get; set; }
        public double? MinTemp_C { get; set; }
        public double? HeatDegDays_C { get; set; }
        public double? CoolDegDays_C { get; set; }
        public double? SnowOnGround_cm { get; set; }
        public double? DirMaxGust_0North { get; set; }
        public double? SpdMaxGust_kmh { get; set; }
        public string HourlyValues { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual ClimateSites ClimateSite { get; set; }
    }
}
