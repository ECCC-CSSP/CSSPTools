using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class SamplingPlanEmails
    {
        public int SamplingPlanEmailID { get; set; }
        public int SamplingPlanID { get; set; }
        public string Email { get; set; }
        public bool IsContractor { get; set; }
        public bool LabSheetHasValueOver500 { get; set; }
        public bool LabSheetReceived { get; set; }
        public bool LabSheetAccepted { get; set; }
        public bool LabSheetRejected { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual SamplingPlans SamplingPlan { get; set; }
    }
}
