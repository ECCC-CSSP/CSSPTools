using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class SamplingPlanSubsectors
    {
        public SamplingPlanSubsectors()
        {
            SamplingPlanSubsectorSites = new HashSet<SamplingPlanSubsectorSites>();
        }

        public int SamplingPlanSubsectorID { get; set; }
        public int SamplingPlanID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual SamplingPlans SamplingPlan { get; set; }
        public virtual TVItems SubsectorTVItem { get; set; }
        public virtual ICollection<SamplingPlanSubsectorSites> SamplingPlanSubsectorSites { get; set; }
    }
}
