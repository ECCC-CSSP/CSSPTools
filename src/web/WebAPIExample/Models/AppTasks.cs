using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class AppTasks
    {
        public AppTasks()
        {
            AppTaskLanguages = new HashSet<AppTaskLanguages>();
        }

        [Key]
        public int AppTaskID { get; set; }
        public int TVItemID { get; set; }
        public int TVItemID2 { get; set; }
        public int AppTaskCommand { get; set; }
        public int AppTaskStatus { get; set; }
        public int PercentCompleted { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Parameters { get; set; }
        public int Language { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDateTime_UTC { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDateTime_UTC { get; set; }
        public int? EstimatedLength_second { get; set; }
        public int? RemainingTime_second { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVItemID))]
        [InverseProperty(nameof(TVItems.AppTasksTVItem))]
        public virtual TVItems TVItem { get; set; }
        [ForeignKey(nameof(TVItemID2))]
        [InverseProperty(nameof(TVItems.AppTasksTVItemID2Navigation))]
        public virtual TVItems TVItemID2Navigation { get; set; }
        [InverseProperty("AppTask")]
        public virtual ICollection<AppTaskLanguages> AppTaskLanguages { get; set; }
    }
}
