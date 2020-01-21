using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class PolSourceSiteEffects
    {
        [Key]
        public int PolSourceSiteEffectID { get; set; }
        public int PolSourceSiteOrInfrastructureTVItemID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        [StringLength(250)]
        public string PolSourceSiteEffectTermIDs { get; set; }
        [Column(TypeName = "text")]
        public string Comments { get; set; }
        public int? AnalysisDocumentTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(AnalysisDocumentTVItemID))]
        [InverseProperty(nameof(TVItems.PolSourceSiteEffectsAnalysisDocumentTVItem))]
        public virtual TVItems AnalysisDocumentTVItem { get; set; }
        [ForeignKey(nameof(MWQMSiteTVItemID))]
        [InverseProperty(nameof(TVItems.PolSourceSiteEffectsMWQMSiteTVItem))]
        public virtual TVItems MWQMSiteTVItem { get; set; }
        [ForeignKey(nameof(PolSourceSiteOrInfrastructureTVItemID))]
        [InverseProperty(nameof(TVItems.PolSourceSiteEffectsPolSourceSiteOrInfrastructureTVItem))]
        public virtual TVItems PolSourceSiteOrInfrastructureTVItem { get; set; }
    }
}
