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
    public partial class MWQMSampleLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MWQMSampleLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "MWQMSampleLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MWQMSampleLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MWQMSampleLanguages")]
        public int MWQMSampleLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "MWQMSample", ExistPlurial = "s", ExistFieldID = "MWQMSampleID")]
        [CSSPDisplayEN(DisplayEN = "MWQM sample ID")]
        [CSSPDisplayFR(DisplayFR = "Échantillon MWQM ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the MWQMSamples table representing the MWQM sample")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table MWQMSamples représentant l'échantillon MWQM")]
        public int MWQMSampleID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [CSSPDisplayEN(DisplayEN = "MWQM sample note")]
        [CSSPDisplayFR(DisplayFR = "Échantillon MWQM note")]
        [CSSPDescriptionEN(DescriptionEN = @"MWQM sample note")]
        [CSSPDescriptionFR(DescriptionFR = @"Échantillon MWQM note")]
        public string MWQMSampleNote { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du commentaire")]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMSampleLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
