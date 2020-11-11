/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebPolSourceSiteEffectTerm
    {
        #region Properties
        public List<PolSourceSiteEffectTerm> PolSourceSiteEffectTermList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSiteEffectTerm()
        {
            PolSourceSiteEffectTermList = new List<PolSourceSiteEffectTerm>();
        }
        #endregion Constructors
    }
}
