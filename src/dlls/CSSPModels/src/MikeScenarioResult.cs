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
    public partial class MikeScenarioResult : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MikeScenarioResult ID")]
        [CSSPDisplayFR(DisplayFR = "MikeScenarioResult ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MikeScenarioResults table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MikeScenarioResults")]
        public int MikeScenarioResultID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "13")]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Item du scenario MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MIKE scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le scénario MIKE")]
        public int MikeScenarioTVItemID { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario results in JSON format")]
        [CSSPDisplayFR(DisplayFR = "Résultats du scenario MIKE en format JSON")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario results in JSON format")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats du scenario MIKE en format JSON")]
        public string MikeResultsJSON { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeScenarioResult() : base()
        {
        }
        #endregion Constructors
    }
}
