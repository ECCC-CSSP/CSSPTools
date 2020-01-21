using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class PolSourceSiteEffectTerms
    {
        public PolSourceSiteEffectTerms()
        {
            InverseUnderGroup = new HashSet<PolSourceSiteEffectTerms>();
        }

        [Key]
        public int PolSourceSiteEffectTermID { get; set; }
        public bool IsGroup { get; set; }
        public int? UnderGroupID { get; set; }
        [Required]
        [StringLength(100)]
        public string EffectTermEN { get; set; }
        [Required]
        [StringLength(100)]
        public string EffectTermFR { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(UnderGroupID))]
        [InverseProperty(nameof(PolSourceSiteEffectTerms.InverseUnderGroup))]
        public virtual PolSourceSiteEffectTerms UnderGroup { get; set; }
        [InverseProperty(nameof(PolSourceSiteEffectTerms.UnderGroup))]
        public virtual ICollection<PolSourceSiteEffectTerms> InverseUnderGroup { get; set; }
    }
}
