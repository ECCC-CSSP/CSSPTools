using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class EmailDistributionLists
    {
        public EmailDistributionLists()
        {
            EmailDistributionListContacts = new HashSet<EmailDistributionListContacts>();
            EmailDistributionListLanguages = new HashSet<EmailDistributionListLanguages>();
            RainExceedancesOnlyStaffEmailDistributionList = new HashSet<RainExceedances>();
            RainExceedancesStakeholdersEmailDistributionList = new HashSet<RainExceedances>();
        }

        public int EmailDistributionListID { get; set; }
        public int ParentTVItemID { get; set; }
        public int Ordinal { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ParentTVItem { get; set; }
        public virtual ICollection<EmailDistributionListContacts> EmailDistributionListContacts { get; set; }
        public virtual ICollection<EmailDistributionListLanguages> EmailDistributionListLanguages { get; set; }
        public virtual ICollection<RainExceedances> RainExceedancesOnlyStaffEmailDistributionList { get; set; }
        public virtual ICollection<RainExceedances> RainExceedancesStakeholdersEmailDistributionList { get; set; }
    }
}
