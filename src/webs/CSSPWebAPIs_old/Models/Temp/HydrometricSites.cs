using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class HydrometricSites
    {
        public HydrometricSites()
        {
            HydrometricDataValues = new HashSet<HydrometricDataValues>();
            RatingCurves = new HashSet<RatingCurves>();
        }

        public int HydrometricSiteID { get; set; }
        public int HydrometricSiteTVItemID { get; set; }
        public string FedSiteNumber { get; set; }
        public string QuebecSiteNumber { get; set; }
        public string HydrometricSiteName { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public double? Elevation_m { get; set; }
        public DateTime? StartDate_Local { get; set; }
        public DateTime? EndDate_Local { get; set; }
        public double? TimeOffset_hour { get; set; }
        public double? DrainageArea_km2 { get; set; }
        public bool? IsNatural { get; set; }
        public bool? IsActive { get; set; }
        public bool? Sediment { get; set; }
        public bool? RHBN { get; set; }
        public bool? RealTime { get; set; }
        public bool? HasDischarge { get; set; }
        public bool? HasLevel { get; set; }
        public bool? HasRatingCurve { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems HydrometricSiteTVItem { get; set; }
        public virtual ICollection<HydrometricDataValues> HydrometricDataValues { get; set; }
        public virtual ICollection<RatingCurves> RatingCurves { get; set; }
    }
}
