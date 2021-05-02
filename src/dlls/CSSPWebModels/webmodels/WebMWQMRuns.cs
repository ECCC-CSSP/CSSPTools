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
    public partial class WebMWQMRuns
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<MWQMRunModel> MWQMRunModelList { get; set; }

        #endregion Properties

        #region Constructors
        public WebMWQMRuns()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            MWQMRunModelList = new List<MWQMRunModel>();
        }
        #endregion Constructors
    }
}
