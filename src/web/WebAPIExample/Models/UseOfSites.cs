using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class UseOfSites
    {
        [Key]
        public int UseOfSiteID { get; set; }
        public int SiteTVItemID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int TVType { get; set; }
        public int Ordinal { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool? UseWeight { get; set; }
        public double? Weight_perc { get; set; }
        public bool? UseEquation { get; set; }
        public double? Param1 { get; set; }
        public double? Param2 { get; set; }
        public double? Param3 { get; set; }
        public double? Param4 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(SiteTVItemID))]
        [InverseProperty(nameof(TVItems.UseOfSitesSiteTVItem))]
        public virtual TVItems SiteTVItem { get; set; }
        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.UseOfSitesSubsectorTVItem))]
        public virtual TVItems SubsectorTVItem { get; set; }
    }
}
