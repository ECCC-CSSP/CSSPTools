using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class PolSourceSites
    {
        public PolSourceSites()
        {
            PolSourceObservations = new HashSet<PolSourceObservations>();
        }

        [Key]
        public int PolSourceSiteID { get; set; }
        public int PolSourceSiteTVItemID { get; set; }
        [StringLength(50)]
        public string Temp_Locator_CanDelete { get; set; }
        public int? Oldsiteid { get; set; }
        public int? Site { get; set; }
        public int? SiteID { get; set; }
        public bool IsPointSource { get; set; }
        public int? InactiveReason { get; set; }
        public int? CivicAddressTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(CivicAddressTVItemID))]
        [InverseProperty(nameof(TVItems.PolSourceSitesCivicAddressTVItem))]
        public virtual TVItems CivicAddressTVItem { get; set; }
        [ForeignKey(nameof(PolSourceSiteTVItemID))]
        [InverseProperty(nameof(TVItems.PolSourceSitesPolSourceSiteTVItem))]
        public virtual TVItems PolSourceSiteTVItem { get; set; }
        [InverseProperty("PolSourceSite")]
        public virtual ICollection<PolSourceObservations> PolSourceObservations { get; set; }
    }
}
