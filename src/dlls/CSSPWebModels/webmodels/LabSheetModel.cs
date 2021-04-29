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
        public LabSheetDetail LabSheetDetail { get; set; }
        public List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList { get; set; }

        #endregion Properties

        #region Constructors
        public LabSheetModel()
        {
            LabSheet = new LabSheet();
            LabSheetDetail = new LabSheetDetail();
            LabSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
        }
        #endregion Constructors
    }
}
