using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class SamplingPlanSubsectorSites
    {
        public int SamplingPlanSubsectorSiteID { get; set; }
        public int SamplingPlanSubsectorID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public bool IsDuplicate { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MWQMSiteTVItem { get; set; }
        public virtual SamplingPlanSubsectors SamplingPlanSubsector { get; set; }
    }
}
