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
    public partial class WebTideSites
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TideSiteModel> TideSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebTideSites()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TideSiteModelList = new List<TideSiteModel>();
        }
        #endregion Constructors
    }
}
