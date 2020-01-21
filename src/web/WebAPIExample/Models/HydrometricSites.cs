using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class HydrometricSites
    {
        public HydrometricSites()
        {
            HydrometricDataValues = new HashSet<HydrometricDataValues>();
            RatingCurves = new HashSet<RatingCurves>();
        }

        [Key]
        public int HydrometricSiteID { get; set; }
        public int HydrometricSiteTVItemID { get; set; }
        [StringLength(7)]
        public string FedSiteNumber { get; set; }
        [StringLength(7)]
        public string QuebecSiteNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string HydrometricSiteName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(4)]
        public string Province { get; set; }
        public double? Elevation_m { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate_Local { get; set; }
        [Column(TypeName = "datetime")]
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
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(HydrometricSiteTVItemID))]
        [InverseProperty(nameof(TVItems.HydrometricSites))]
        public virtual TVItems HydrometricSiteTVItem { get; set; }
        [InverseProperty("HydrometricSite")]
        public virtual ICollection<HydrometricDataValues> HydrometricDataValues { get; set; }
        [InverseProperty("HydrometricSite")]
        public virtual ICollection<RatingCurves> RatingCurves { get; set; }
    }
}
