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
    public partial class WebPolSourceSites
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<PolSourceSiteModel> PolSourceSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSites()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            PolSourceSiteModelList = new List<PolSourceSiteModel>();
        }
        #endregion Constructors
    }
}
