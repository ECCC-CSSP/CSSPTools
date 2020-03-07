using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class EmailDistributionListContactLanguages
    {
        public int EmailDistributionListContactLanguageID { get; set; }
        public int EmailDistributionListContactID { get; set; }
        public int Language { get; set; }
        public string Agency { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual EmailDistributionListContacts EmailDistributionListContact { get; set; }
    }
}
