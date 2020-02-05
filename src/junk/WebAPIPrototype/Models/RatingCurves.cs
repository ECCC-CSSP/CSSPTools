using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class RatingCurves
    {
        public RatingCurves()
        {
            RatingCurveValues = new HashSet<RatingCurveValues>();
        }

        public int RatingCurveID { get; set; }
        public int HydrometricSiteID { get; set; }
        public string RatingCurveNumber { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual HydrometricSites HydrometricSite { get; set; }
        public virtual ICollection<RatingCurveValues> RatingCurveValues { get; set; }
    }
}
