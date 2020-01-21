using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class RatingCurves
    {
        public RatingCurves()
        {
            RatingCurveValues = new HashSet<RatingCurveValues>();
        }

        [Key]
        public int RatingCurveID { get; set; }
        public int HydrometricSiteID { get; set; }
        [Required]
        [StringLength(50)]
        public string RatingCurveNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(HydrometricSiteID))]
        [InverseProperty(nameof(HydrometricSites.RatingCurves))]
        public virtual HydrometricSites HydrometricSite { get; set; }
        [InverseProperty("RatingCurve")]
        public virtual ICollection<RatingCurveValues> RatingCurveValues { get; set; }
    }
}
