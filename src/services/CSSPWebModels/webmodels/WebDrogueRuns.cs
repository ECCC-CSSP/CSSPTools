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
    public partial class WebDrogueRuns
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<DrogueRunModel> DrogueRunModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebDrogueRuns()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            DrogueRunModelList = new List<DrogueRunModel>();
        }
        #endregion Constructors
    }
}
