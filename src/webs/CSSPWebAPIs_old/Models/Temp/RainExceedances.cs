using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class RainExceedances
    {
        public int RainExceedanceID { get; set; }
        public int RainExceedanceTVItemID { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }
        public double RainMaximum_mm { get; set; }
        public int? StakeholdersEmailDistributionListID { get; set; }
        public int? OnlyStaffEmailDistributionListID { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual EmailDistributionLists OnlyStaffEmailDistributionList { get; set; }
        public virtual TVItems RainExceedanceTVItem { get; set; }
        public virtual EmailDistributionLists StakeholdersEmailDistributionList { get; set; }
    }
}
