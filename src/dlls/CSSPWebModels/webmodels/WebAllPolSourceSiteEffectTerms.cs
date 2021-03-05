/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebAllPolSourceSiteEffectTerms
    {
        #region Properties
        public List<PolSourceSiteEffectTerm> PolSourceSiteEffectTermList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllPolSourceSiteEffectTerms()
        {
            PolSourceSiteEffectTermList = new List<PolSourceSiteEffectTerm>();
        }
        #endregion Constructors
    }
}
