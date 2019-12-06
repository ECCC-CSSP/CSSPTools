using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ClimateSiteModel : LastUpdateAndContactModel
    {
        public ClimateSiteModel()
        {
        }
        public int ClimateSiteID { get; set; }
        public int ClimateSiteTVItemID { get; set; }
        public string ClimateSiteTVText { get; set; }
        public Nullable<int> ECDBID { get; set; }
        public string ClimateSiteName { get; set; }
        public string Province { get; set; }
        public Nullable<double> Elevation_m { get; set; }
        public string ClimateID { get; set; }
        public Nullable<int> WMOID { get; set; }
        public string TCID { get; set; }
        public Nullable<bool> IsQuebecSite { get; set; }
        public Nullable<bool> IsCoCoRaHS { get; set; }
        public Nullable<double> TimeOffset_hour { get; set; }
        public string File_desc { get; set; }
        public Nullable<System.DateTime> HourlyStartDate_Local { get; set; }
        public Nullable<System.DateTime> HourlyEndDate_Local { get; set; }
        public Nullable<bool> HourlyNow { get; set; }
        public Nullable<System.DateTime> DailyStartDate_Local { get; set; }
        public Nullable<System.DateTime> DailyEndDate_Local { get; set; }
        public Nullable<bool> DailyNow { get; set; }
        public Nullable<System.DateTime> MonthlyStartDate_Local { get; set; }
        public Nullable<System.DateTime> MonthlyEndDate_Local { get; set; }
        public Nullable<bool> MonthlyNow { get; set; }
    }
}
