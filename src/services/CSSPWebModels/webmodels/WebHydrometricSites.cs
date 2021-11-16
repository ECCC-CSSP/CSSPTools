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
    public partial class WebHydrometricSites
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<HydrometricSiteModel> HydrometricSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricSites()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            HydrometricSiteModelList = new List<HydrometricSiteModel>();
        }
        #endregion Constructors
    }
}
