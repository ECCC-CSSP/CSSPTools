using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class LabSheets
    {
        public LabSheets()
        {
            LabSheetDetails = new HashSet<LabSheetDetails>();
        }

        [Key]
        public int LabSheetID { get; set; }
        public int OtherServerLabSheetID { get; set; }
        public int SamplingPlanID { get; set; }
        [Required]
        [StringLength(250)]
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
        [Required]
        [StringLength(250)]
        public string FileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FileLastModifiedDate_Local { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string FileContent { get; set; }
        public int? AcceptedOrRejectedByContactTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AcceptedOrRejectedDateTime { get; set; }
        [StringLength(250)]
        public string RejectReason { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(AcceptedOrRejectedByContactTVItemID))]
        [InverseProperty(nameof(TVItems.LabSheetsAcceptedOrRejectedByContactTVItem))]
        public virtual TVItems AcceptedOrRejectedByContactTVItem { get; set; }
        [ForeignKey(nameof(MWQMRunTVItemID))]
        [InverseProperty(nameof(TVItems.LabSheetsMWQMRunTVItem))]
        public virtual TVItems MWQMRunTVItem { get; set; }
        [ForeignKey(nameof(SamplingPlanID))]
        [InverseProperty(nameof(SamplingPlans.LabSheets))]
        public virtual SamplingPlans SamplingPlan { get; set; }
        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.LabSheetsSubsectorTVItem))]
        public virtual TVItems SubsectorTVItem { get; set; }
        [InverseProperty("LabSheet")]
        public virtual ICollection<LabSheetDetails> LabSheetDetails { get; set; }
    }
}
