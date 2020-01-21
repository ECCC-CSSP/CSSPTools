using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMSites
    {
        [Key]
        public int MWQMSiteID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        [Required]
        [StringLength(8)]
        public string MWQMSiteNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string MWQMSiteDescription { get; set; }
        public int MWQMSiteLatestClassification { get; set; }
        public int Ordinal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMSiteTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMSites))]
        public virtual TVItems MWQMSiteTVItem { get; set; }
    }
}
