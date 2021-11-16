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
    public partial class WebLabSheets
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<LabSheetModel> LabSheetModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebLabSheets()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            LabSheetModelList = new List<LabSheetModel>();
        }
        #endregion Constructors
    }
}
