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
    public partial class WebAllUseOfSites
    {
        #region Properties
        public List<UseOfSite> UseOfSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllUseOfSites()
        {
            UseOfSiteList = new List<UseOfSite>();
        }
        #endregion Constructors
    }
}
