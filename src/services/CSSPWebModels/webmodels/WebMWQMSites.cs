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
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<MWQMSiteModel> MWQMSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSites()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            MWQMSiteModelList = new List<MWQMSiteModel>();
        }
        #endregion Constructors
    }
}
