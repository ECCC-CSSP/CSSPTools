using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class SamplingPlanSubsectorSites
    {
        [Key]
        public int SamplingPlanSubsectorSiteID { get; set; }
        public int SamplingPlanSubsectorID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public bool IsDuplicate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMSiteTVItemID))]
        [InverseProperty(nameof(TVItems.SamplingPlanSubsectorSites))]
        public virtual TVItems MWQMSiteTVItem { get; set; }
        [ForeignKey(nameof(SamplingPlanSubsectorID))]
        [InverseProperty(nameof(SamplingPlanSubsectors.SamplingPlanSubsectorSites))]
        public virtual SamplingPlanSubsectors SamplingPlanSubsector { get; set; }
    }
}
