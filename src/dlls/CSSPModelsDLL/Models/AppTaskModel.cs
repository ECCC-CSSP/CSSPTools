using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class AppTaskModel : LastUpdateAndContactModel
    {
        public AppTaskModel()
        {
        }

        public int AppTaskID { get; set; }
        public int TVItemID { get; set; }
        public string TVItemIDTVText { get; set; }
        public int TVItemID2 { get; set; }
        public string TVItemID2TVText { get; set; }
        public AppTaskCommandEnum AppTaskCommand { get; set; }
        public string ErrorText { get; set; }
        public string StatusText { get; set; }
        public AppTaskStatusEnum AppTaskStatus { get; set; }
        public int PercentCompleted { get; set; }
        public string Parameters { get; set; }
        public LanguageEnum Language { get; set; }
        public System.DateTime StartDateTime_UTC { get; set; }
        public Nullable<System.DateTime> EndDateTime_UTC { get; set; }
        public Nullable<int> EstimatedLength_second { get; set; }
        public Nullable<int> RemainingTime_second { get; set; }

    }
}
