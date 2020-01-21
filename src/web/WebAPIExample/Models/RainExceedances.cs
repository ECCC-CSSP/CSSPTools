using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class RainExceedances
    {
        [Key]
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
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(OnlyStaffEmailDistributionListID))]
        [InverseProperty(nameof(EmailDistributionLists.RainExceedancesOnlyStaffEmailDistributionList))]
        public virtual EmailDistributionLists OnlyStaffEmailDistributionList { get; set; }
        [ForeignKey(nameof(RainExceedanceTVItemID))]
        [InverseProperty(nameof(TVItems.RainExceedances))]
        public virtual TVItems RainExceedanceTVItem { get; set; }
        [ForeignKey(nameof(StakeholdersEmailDistributionListID))]
        [InverseProperty(nameof(EmailDistributionLists.RainExceedancesStakeholdersEmailDistributionList))]
        public virtual EmailDistributionLists StakeholdersEmailDistributionList { get; set; }
    }
}
