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
    public partial class VPScenarioIDAndRawResults : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "VP scenario ID")]
        [CSSPDisplayFR(DisplayFR = "Scénario VP ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the VPScenarios table representing the visual plumes scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table VPScenarios représentant le scénario visual plumes")]
        public int VPScenarioID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Raw results")]
        [CSSPDisplayFR(DisplayFR = "Résultats bruts")]
        [CSSPDescriptionEN(DescriptionEN = @"Raw results")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats bruts")]
        public string RawResults { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public VPScenarioIDAndRawResults() : base()
        {
        }
        #endregion Constructors
    }
}
