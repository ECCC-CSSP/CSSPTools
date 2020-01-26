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
    public partial class VPScenarioLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "VPScenarioLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "VPScenarioLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the VPScenarioLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table VPScenarioLanguages")]
        public int VPScenarioLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
        [CSSPDisplayEN(DisplayEN = "VP scenario ID")]
        [CSSPDisplayFR(DisplayFR = "Scénario VP ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the VPScenarios table representing the visual plumes scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table VPScenarios représentant le scénario visual plumes")]
        public int VPScenarioID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "VP scenario name")]
        [CSSPDisplayFR(DisplayFR = "Nom du scénario VP")]
        [CSSPDescriptionEN(DescriptionEN = @"Visual plumes scenario name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du scénario visual plumes")]
        public string VPScenarioName { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the visual plumes scenario name")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du nom du scénario visual plumes")]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public VPScenarioLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
