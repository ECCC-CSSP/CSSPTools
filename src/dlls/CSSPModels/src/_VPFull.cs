/*
 * Manually edited
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
    public partial class VPFull : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "VP scenario")]
        [CSSPDisplayFR(DisplayFR = "Scénario VP")]
        [CSSPDescriptionEN(DescriptionEN = @"Visual plumes sceniaro")]
        [CSSPDescriptionFR(DescriptionFR = @"Scénario visuel plumes")]
        public VPScenario VPScenario { get; set; }
        [CSSPDisplayEN(DisplayEN = "VP ambient list")]
        [CSSPDisplayFR(DisplayFR = "Liste visuel plumes ambiant")]
        [CSSPDescriptionEN(DescriptionEN = @"Visual plumes ambient list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste visuel plumes des paramètres ambiants")]
        public List<VPAmbient> VPAmbientList { get; set; }
        [CSSPDisplayEN(DisplayEN = "VP result list")]
        [CSSPDisplayFR(DisplayFR = "Liste des résultats VP")]
        [CSSPDescriptionEN(DescriptionEN = @"Visual plumes result list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste des résultats visual plumes")]
        public List<VPResult> VPResultList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public VPFull() : base()
        {
            VPAmbientList = new List<VPAmbient>();
            VPResultList = new List<VPResult>();
        }
        #endregion Constructors
    }
}
