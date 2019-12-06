/*
 * Manually edited by Charles LeBlanc 
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    [NotMapped]
    public partial class SamplingPlanAndFilesLabSheetCount : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(0, -1)]
        [CSSPDisplayEN(DisplayEN = "Lab sheet history count")]
        [CSSPDisplayFR(DisplayFR = "Nombre de feuille de lab historique")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory sheet history count")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de feuille de laboratoire historique")]
        public int LabSheetHistoryCount { get; set; }
        [Range(0, -1)]
        [CSSPDisplayEN(DisplayEN = "Lab sheet transferred count")]
        [CSSPDisplayFR(DisplayFR = "Nombre de feuille de lab transférées")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory sheet transferred count")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de feuille de laboratoire transférées")]
        public int LabSheetTransferredCount { get; set; }
        [CSSPDisplayEN(DisplayEN = "Sampling plan")]
        [CSSPDisplayFR(DisplayFR = "Plan d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Samling plan")]
        [CSSPDescriptionFR(DescriptionFR = @"Plan d'échantillonnage")]
        public SamplingPlan SamplingPlan { get; set; }
        [CSSPDisplayEN(DisplayEN = "Sampling plan file (.txt)")]
        [CSSPDisplayFR(DisplayFR = "Filière du plan d'échantillonnage (.txt)")]
        [CSSPDescriptionEN(DescriptionEN = @"TVFile sampling plan file (.txt)")]
        [CSSPDescriptionFR(DescriptionFR = @"Filière du plan d'échantillonnage (.txt)")]
        public TVFile TVFileSamplingPlanFileTXT { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public SamplingPlanAndFilesLabSheetCount() : base()
        {
        }
        #endregion Constructors
    }
}
