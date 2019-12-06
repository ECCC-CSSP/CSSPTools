using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSPEnumsDLL.Enums;

namespace CSSPModelsDLL.Models
{
    public class SamplingPlanModel : LastUpdateAndContactModel
    {
        public SamplingPlanModel()
        {
            SamplingPlanSubsectorModelList = new List<SamplingPlanSubsectorModel>();
        }

        public int SamplingPlanID { get; set; }
        public string SamplingPlanName { get; set; }
        public string ForGroupName { get; set; }
        public SampleTypeEnum SampleType { get; set; }
        public SamplingPlanTypeEnum SamplingPlanType { get; set; }
        public LabSheetTypeEnum LabSheetType { get; set; }
        public int ProvinceTVItemID { get; set; }
        public string ProvinceTVText { get; set; }
        public int CreatorTVItemID { get; set; }
        public string CreatorTVText { get; set; }
        public int Year { get; set; }
        public string AccessCode { get; set; }
        public float DailyDuplicatePrecisionCriteria { get; set; }
        public float IntertechDuplicatePrecisionCriteria { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        public string ApprovalCode { get; set; }
        public int? SamplingPlanFileTVItemID { get; set; }
        public AnalyzeMethodEnum? AnalyzeMethodDefault { get; set; }
        public SampleMatrixEnum? SampleMatrixDefault { get; set; }
        public LaboratoryEnum? LaboratoryDefault { get; set; }
        public string BackupDirectory { get; set; }
        public bool IsActive { get; set; }
        public List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelList { get; set; }
    }

    
}
