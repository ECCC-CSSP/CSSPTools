using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class EmailDistributionListLanguages
    {
        [Key]
        public int EmailDistributionListLanguageID { get; set; }
        public int EmailDistributionListID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailListName { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(EmailDistributionListID))]
        [InverseProperty(nameof(EmailDistributionLists.EmailDistributionListLanguages))]
        public virtual EmailDistributionLists EmailDistributionList { get; set; }
    }
}
