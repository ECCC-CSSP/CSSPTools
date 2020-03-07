using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class AppTasks
    {
        public AppTasks()
        {
            AppTaskLanguages = new HashSet<AppTaskLanguages>();
        }

        public int AppTaskID { get; set; }
        public int TVItemID { get; set; }
        public int TVItemID2 { get; set; }
        public int AppTaskCommand { get; set; }
        public int AppTaskStatus { get; set; }
        public int PercentCompleted { get; set; }
        public string Parameters { get; set; }
        public int Language { get; set; }
        public DateTime StartDateTime_UTC { get; set; }
        public DateTime? EndDateTime_UTC { get; set; }
        public int? EstimatedLength_second { get; set; }
        public int? RemainingTime_second { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TVItem { get; set; }
        public virtual TVItems TVItemID2Navigation { get; set; }
        public virtual ICollection<AppTaskLanguages> AppTaskLanguages { get; set; }
    }
}
