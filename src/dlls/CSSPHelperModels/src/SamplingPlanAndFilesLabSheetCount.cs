/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class SamplingPlanAndFilesLabSheetCount
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(0, -1)]
        public int LabSheetHistoryCount { get; set; }
        [CSSPRange(0, -1)]
        public int LabSheetTransferredCount { get; set; }
        public SamplingPlan SamplingPlan { get; set; }
        public TVFile TVFileSamplingPlanFileTXT { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public SamplingPlanAndFilesLabSheetCount() : base()
        {
        }
        #endregion Constructors
    }
}
