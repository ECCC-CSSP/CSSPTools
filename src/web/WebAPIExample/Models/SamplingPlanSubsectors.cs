using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class SamplingPlanSubsectors
    {
        public SamplingPlanSubsectors()
        {
            SamplingPlanSubsectorSites = new HashSet<SamplingPlanSubsectorSites>();
        }

        [Key]
        public int SamplingPlanSubsectorID { get; set; }
        public int SamplingPlanID { get; set; }
        public int SubsectorTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(SamplingPlanID))]
        [InverseProperty(nameof(SamplingPlans.SamplingPlanSubsectors))]
        public virtual SamplingPlans SamplingPlan { get; set; }
        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.SamplingPlanSubsectors))]
        public virtual TVItems SubsectorTVItem { get; set; }
        [InverseProperty("SamplingPlanSubsector")]
        public virtual ICollection<SamplingPlanSubsectorSites> SamplingPlanSubsectorSites { get; set; }
    }
}
