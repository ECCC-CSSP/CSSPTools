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
    public partial class WebMWQMSites
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<MWQMSiteModel> MWQMSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSites()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            MWQMSiteModelList = new List<MWQMSiteModel>();
        }
        #endregion Constructors
    }
}
