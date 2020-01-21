using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class SamplingPlanEmails
    {
        [Key]
        public int SamplingPlanEmailID { get; set; }
        public int SamplingPlanID { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        public bool IsContractor { get; set; }
        public bool LabSheetHasValueOver500 { get; set; }
        public bool LabSheetReceived { get; set; }
        public bool LabSheetAccepted { get; set; }
        public bool LabSheetRejected { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(SamplingPlanID))]
        [InverseProperty(nameof(SamplingPlans.SamplingPlanEmails))]
        public virtual SamplingPlans SamplingPlan { get; set; }
    }
}
