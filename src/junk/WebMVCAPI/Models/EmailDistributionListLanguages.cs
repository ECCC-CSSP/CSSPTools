using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class EmailDistributionListLanguages
    {
        public int EmailDistributionListLanguageID { get; set; }
        public int EmailDistributionListID { get; set; }
        public int Language { get; set; }
        public string EmailListName { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual EmailDistributionLists EmailDistributionList { get; set; }
    }
}
