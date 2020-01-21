using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
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

        [Key]
        public int EmailDistributionListID { get; set; }
        public int ParentTVItemID { get; set; }
        public int Ordinal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ParentTVItemID))]
        [InverseProperty(nameof(TVItems.EmailDistributionLists))]
        public virtual TVItems ParentTVItem { get; set; }
        [InverseProperty("EmailDistributionList")]
        public virtual ICollection<EmailDistributionListContacts> EmailDistributionListContacts { get; set; }
        [InverseProperty("EmailDistributionList")]
        public virtual ICollection<EmailDistributionListLanguages> EmailDistributionListLanguages { get; set; }
        [InverseProperty(nameof(RainExceedances.OnlyStaffEmailDistributionList))]
        public virtual ICollection<RainExceedances> RainExceedancesOnlyStaffEmailDistributionList { get; set; }
        [InverseProperty(nameof(RainExceedances.StakeholdersEmailDistributionList))]
        public virtual ICollection<RainExceedances> RainExceedancesStakeholdersEmailDistributionList { get; set; }
    }
}
