using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class PolSourceSiteEffectTerms
    {
        public PolSourceSiteEffectTerms()
        {
            InverseUnderGroup = new HashSet<PolSourceSiteEffectTerms>();
        }

        public int PolSourceSiteEffectTermID { get; set; }
        public bool IsGroup { get; set; }
        public int? UnderGroupID { get; set; }
        public string EffectTermEN { get; set; }
        public string EffectTermFR { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual PolSourceSiteEffectTerms UnderGroup { get; set; }
        public virtual ICollection<PolSourceSiteEffectTerms> InverseUnderGroup { get; set; }
    }
}
