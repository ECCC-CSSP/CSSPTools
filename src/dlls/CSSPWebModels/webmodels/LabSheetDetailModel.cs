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
    public partial class LabSheetDetailModel
    {
        #region Properties
        public LabSheetDetail LabSheetDetail { get; set; }
        public List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailModel()
        {
            LabSheetDetail = new LabSheetDetail();
            LabSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();

        }
        #endregion Constructors
    }
}
