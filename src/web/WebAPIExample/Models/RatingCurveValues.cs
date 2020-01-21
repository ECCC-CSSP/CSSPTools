using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class RatingCurveValues
    {
        [Key]
        public int RatingCurveValueID { get; set; }
        public int RatingCurveID { get; set; }
        public double StageValue_m { get; set; }
        public double DischargeValue_m3_s { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(RatingCurveID))]
        [InverseProperty(nameof(RatingCurves.RatingCurveValues))]
        public virtual RatingCurves RatingCurve { get; set; }
    }
}
