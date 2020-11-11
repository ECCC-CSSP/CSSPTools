/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
