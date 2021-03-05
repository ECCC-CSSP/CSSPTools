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
    public partial class LabSheetModel
    {
        #region Properties
        public LabSheet LabSheet { get; set; }
        public List<LabSheetDetailModel> LabSheetDetailModelList { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetModel()
        {
            LabSheet = new LabSheet();
            LabSheetDetailModelList = new List<LabSheetDetailModel>();
        }
        #endregion Constructors
    }
}
