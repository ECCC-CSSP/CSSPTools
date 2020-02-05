using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class EmailDistributionListContacts
    {
        public EmailDistributionListContacts()
        {
            EmailDistributionListContactLanguages = new HashSet<EmailDistributionListContactLanguages>();
        }

        public int EmailDistributionListContactID { get; set; }
        public int EmailDistributionListID { get; set; }
        public bool IsCC { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool CMPRainfallSeasonal { get; set; }
        public bool CMPWastewater { get; set; }
        public bool EmergencyWeather { get; set; }
        public bool EmergencyWastewater { get; set; }
        public bool ReopeningAllTypes { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual EmailDistributionLists EmailDistributionList { get; set; }
        public virtual ICollection<EmailDistributionListContactLanguages> EmailDistributionListContactLanguages { get; set; }
    }
}
