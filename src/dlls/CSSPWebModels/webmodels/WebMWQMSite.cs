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
    public partial class WebMWQMSite : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<MWQMSiteModel> MWQMSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSite()
        {
            TVItemParentList = new List<WebBase>();
            MWQMSiteModelList = new List<MWQMSiteModel>();
        }
        #endregion Constructors
    }
}
