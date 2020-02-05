using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class SamplingPlans
    {
        public SamplingPlans()
        {
            LabSheetDetails = new HashSet<LabSheetDetails>();
            LabSheets = new HashSet<LabSheets>();
            SamplingPlanEmails = new HashSet<SamplingPlanEmails>();
            SamplingPlanSubsectors = new HashSet<SamplingPlanSubsectors>();
        }

        public int SamplingPlanID { get; set; }
        public bool IsActive { get; set; }
        public string SamplingPlanName { get; set; }
        public string ForGroupName { get; set; }
        public int SampleType { get; set; }
        public int SamplingPlanType { get; set; }
        public int LabSheetType { get; set; }
        public int ProvinceTVItemID { get; set; }
        public int CreatorTVItemID { get; set; }
        public int Year { get; set; }
        public string AccessCode { get; set; }
        public double DailyDuplicatePrecisionCriteria { get; set; }
        public double IntertechDuplicatePrecisionCriteria { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        public string ApprovalCode { get; set; }
        public int? SamplingPlanFileTVItemID { get; set; }
        public int? AnalyzeMethodDefault { get; set; }
        public int? SampleMatrixDefault { get; set; }
        public int? LaboratoryDefault { get; set; }
        public string BackupDirectory { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems CreatorTVItem { get; set; }
        public virtual TVItems ProvinceTVItem { get; set; }
        public virtual TVItems SamplingPlanFileTVItem { get; set; }
        public virtual ICollection<LabSheetDetails> LabSheetDetails { get; set; }
        public virtual ICollection<LabSheets> LabSheets { get; set; }
        public virtual ICollection<SamplingPlanEmails> SamplingPlanEmails { get; set; }
        public virtual ICollection<SamplingPlanSubsectors> SamplingPlanSubsectors { get; set; }
    }
}
