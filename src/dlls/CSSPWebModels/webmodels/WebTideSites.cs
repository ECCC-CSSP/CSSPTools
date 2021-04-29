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
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TideSiteModel> TideSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebTideSites()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TideSiteModelList = new List<TideSiteModel>();
        }
        #endregion Constructors
    }
}
