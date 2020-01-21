using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class EmailDistributionListContactLanguages
    {
        [Key]
        public int EmailDistributionListContactLanguageID { get; set; }
        public int EmailDistributionListContactID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(100)]
        public string Agency { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(EmailDistributionListContactID))]
        [InverseProperty(nameof(EmailDistributionListContacts.EmailDistributionListContactLanguages))]
        public virtual EmailDistributionListContacts EmailDistributionListContact { get; set; }
    }
}
