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
    public partial class WebPolSourceSite : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<PolSourceSiteModel> PolSourceSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSite()
        {
            TVItemParentList = new List<WebBase>();
            PolSourceSiteModelList = new List<PolSourceSiteModel>();
        }
        #endregion Constructors
    }
}
