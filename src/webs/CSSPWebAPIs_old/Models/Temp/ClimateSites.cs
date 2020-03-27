using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class ClimateSites
    {
        public ClimateSites()
        {
            ClimateDataValues = new HashSet<ClimateDataValues>();
        }

        public int ClimateSiteID { get; set; }
        public int ClimateSiteTVItemID { get; set; }
        public int? ECDBID { get; set; }
        public string ClimateSiteName { get; set; }
        public string Province { get; set; }
        public double? Elevation_m { get; set; }
        public string ClimateID { get; set; }
        public int? WMOID { get; set; }
        public string TCID { get; set; }
        public bool? IsQuebecSite { get; set; }
        public bool? IsCoCoRaHS { get; set; }
        public double? TimeOffset_hour { get; set; }
        public string File_desc { get; set; }
        public DateTime? HourlyStartDate_Local { get; set; }
        public DateTime? HourlyEndDate_Local { get; set; }
        public bool? HourlyNow { get; set; }
        public DateTime? DailyStartDate_Local { get; set; }
        public DateTime? DailyEndDate_Local { get; set; }
        public bool? DailyNow { get; set; }
        public DateTime? MonthlyStartDate_Local { get; set; }
        public DateTime? MonthlyEndDate_Local { get; set; }
        public bool? MonthlyNow { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ClimateSiteTVItem { get; set; }
        public virtual ICollection<ClimateDataValues> ClimateDataValues { get; set; }
    }
}
