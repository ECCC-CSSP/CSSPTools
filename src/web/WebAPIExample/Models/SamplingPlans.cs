using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
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

        [Key]
        public int SamplingPlanID { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(200)]
        public string SamplingPlanName { get; set; }
        [Required]
        [StringLength(100)]
        public string ForGroupName { get; set; }
        public int SampleType { get; set; }
        public int SamplingPlanType { get; set; }
        public int LabSheetType { get; set; }
        public int ProvinceTVItemID { get; set; }
        public int CreatorTVItemID { get; set; }
        public int Year { get; set; }
        [Required]
        [StringLength(15)]
        public string AccessCode { get; set; }
        public double DailyDuplicatePrecisionCriteria { get; set; }
        public double IntertechDuplicatePrecisionCriteria { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        [Required]
        [StringLength(15)]
        public string ApprovalCode { get; set; }
        public int? SamplingPlanFileTVItemID { get; set; }
        public int? AnalyzeMethodDefault { get; set; }
        public int? SampleMatrixDefault { get; set; }
        public int? LaboratoryDefault { get; set; }
        [Required]
        [StringLength(250)]
        public string BackupDirectory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(CreatorTVItemID))]
        [InverseProperty(nameof(TVItems.SamplingPlansCreatorTVItem))]
        public virtual TVItems CreatorTVItem { get; set; }
        [ForeignKey(nameof(ProvinceTVItemID))]
        [InverseProperty(nameof(TVItems.SamplingPlansProvinceTVItem))]
        public virtual TVItems ProvinceTVItem { get; set; }
        [ForeignKey(nameof(SamplingPlanFileTVItemID))]
        [InverseProperty(nameof(TVItems.SamplingPlansSamplingPlanFileTVItem))]
        public virtual TVItems SamplingPlanFileTVItem { get; set; }
        [InverseProperty("SamplingPlan")]
        public virtual ICollection<LabSheetDetails> LabSheetDetails { get; set; }
        [InverseProperty("SamplingPlan")]
        public virtual ICollection<LabSheets> LabSheets { get; set; }
        [InverseProperty("SamplingPlan")]
        public virtual ICollection<SamplingPlanEmails> SamplingPlanEmails { get; set; }
        [InverseProperty("SamplingPlan")]
        public virtual ICollection<SamplingPlanSubsectors> SamplingPlanSubsectors { get; set; }
    }
}
