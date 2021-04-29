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
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<PolSourceSiteModel> PolSourceSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSites()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            PolSourceSiteModelList = new List<PolSourceSiteModel>();
        }
        #endregion Constructors
    }
}
