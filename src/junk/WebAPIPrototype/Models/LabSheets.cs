using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class LabSheets
    {
        public LabSheets()
        {
            LabSheetDetails = new HashSet<LabSheetDetails>();
        }

        public int LabSheetID { get; set; }
        public int OtherServerLabSheetID { get; set; }
        public int SamplingPlanID { get; set; }
        public string SamplingPlanName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int RunNumber { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int? MWQMRunTVItemID { get; set; }
        public int SamplingPlanType { get; set; }
        public int SampleType { get; set; }
        public int LabSheetType { get; set; }
        public int LabSheetStatus { get; set; }
        public string FileName { get; set; }
        public DateTime FileLastModifiedDate_Local { get; set; }
        public string FileContent { get; set; }
        public int? AcceptedOrRejectedByContactTVItemID { get; set; }
        public DateTime? AcceptedOrRejectedDateTime { get; set; }
        public string RejectReason { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems AcceptedOrRejectedByContactTVItem { get; set; }
        public virtual TVItems MWQMRunTVItem { get; set; }
        public virtual SamplingPlans SamplingPlan { get; set; }
        public virtual TVItems SubsectorTVItem { get; set; }
        public virtual ICollection<LabSheetDetails> LabSheetDetails { get; set; }
    }
}
