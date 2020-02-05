using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class RatingCurveValues
    {
        public int RatingCurveValueID { get; set; }
        public int RatingCurveID { get; set; }
        public double StageValue_m { get; set; }
        public double DischargeValue_m3_s { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual RatingCurves RatingCurve { get; set; }
    }
}
