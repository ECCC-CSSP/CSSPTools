using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class EmailDistributionListContacts
    {
        public EmailDistributionListContacts()
        {
            EmailDistributionListContactLanguages = new HashSet<EmailDistributionListContactLanguages>();
        }

        [Key]
        public int EmailDistributionListContactID { get; set; }
        public int EmailDistributionListID { get; set; }
        public bool IsCC { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        public bool CMPRainfallSeasonal { get; set; }
        public bool CMPWastewater { get; set; }
        public bool EmergencyWeather { get; set; }
        public bool EmergencyWastewater { get; set; }
        public bool ReopeningAllTypes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(EmailDistributionListID))]
        [InverseProperty(nameof(EmailDistributionLists.EmailDistributionListContacts))]
        public virtual EmailDistributionLists EmailDistributionList { get; set; }
        [InverseProperty("EmailDistributionListContact")]
        public virtual ICollection<EmailDistributionListContactLanguages> EmailDistributionListContactLanguages { get; set; }
    }
}
