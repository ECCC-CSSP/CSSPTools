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
    public partial class MWQMRunLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MWQMRunLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "MWQMRunLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MWQMRunLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MWQMRunLanguages")]
        public int MWQMRunLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID")]
        [CSSPDisplayEN(DisplayEN = "MWQM run")]
        [CSSPDisplayFR(DisplayFR = "Tournée de MWQM (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the MWQMRuns table representing the MWQM run")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table MWQMRuns représentant la tournée MWQM (fr)")]
        public int MWQMRunID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire de la tournée")]
        public string RunComment { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the run comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du commentaire de la tournée")]
        public TranslationStatusEnum TranslationStatusRunComment { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run weather comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire de la météo de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run weather comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire de la météo de la tournée")]
        public string RunWeatherComment { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the run weather comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du commentaire de la météo de la tournée")]
        public TranslationStatusEnum TranslationStatusRunWeatherComment { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMRunLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
