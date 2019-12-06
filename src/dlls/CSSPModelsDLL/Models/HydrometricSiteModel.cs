using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class HydrometricSiteModel : LastUpdateAndContactModel
    {
        public HydrometricSiteModel()
        {
        }
        public int HydrometricSiteID { get; set; }
        public int HydrometricSiteTVItemID { get; set; }
        public string HydrometricSiteTVText { get; set; }
        public string FedSiteNumber { get; set; }
        public string QuebecSiteNumber { get; set; }
        public string HydrometricSiteName { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public Nullable<double> Elevation_m { get; set; }
        public Nullable<System.DateTime> StartDate_Local { get; set; }
        public Nullable<System.DateTime> EndDate_Local { get; set; }
        public Nullable<double> TimeOffset_hour { get; set; }
        public Nullable<double> DrainageArea_km2 { get; set; }
        public Nullable<bool> IsNatural { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> Sediment { get; set; }
        public Nullable<bool> RHBN { get; set; }
        public Nullable<bool> RealTime { get; set; }
        public Nullable<bool> HasDischarge { get; set; }
        public Nullable<bool> HasLevel { get; set; }
        public Nullable<bool> HasRatingCurve { get; set; }
    }
}
