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
    public partial class ReportTypeLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ReportTypeLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "ReportTypeLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ReportTypeLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ReportTypeLanguages")]
        public int ReportTypeLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID")]
        [CSSPDisplayEN(DisplayEN = "Report type ID")]
        [CSSPDisplayFR(DisplayFR = "Type de raport ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the ReportTypes table representing the report type")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table ReportTypes représentant le type de raport")]
        public int ReportTypeID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Name")]
        [CSSPDisplayFR(DisplayFR = "Nom")]
        [CSSPDescriptionEN(DescriptionEN = @"Name of the report type")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du type de raport")]
        public string Name { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the report type name")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du nom du type de raport")]
        public TranslationStatusEnum TranslationStatusName { get; set; }
        [StringLength(1000)]
        [CSSPDisplayEN(DisplayEN = "Description")]
        [CSSPDisplayFR(DisplayFR = "Description")]
        [CSSPDescriptionEN(DescriptionEN = @"Description of the report type")]
        [CSSPDescriptionFR(DescriptionFR = @"Description du type de raport")]
        public string Description { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the report type description")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction de la description du type de raport")]
        public TranslationStatusEnum TranslationStatusDescription { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Start of file name")]
        [CSSPDisplayFR(DisplayFR = "Début du nom de la filière")]
        [CSSPDescriptionEN(DescriptionEN = @"Start of file name")]
        [CSSPDescriptionFR(DescriptionFR = @"Début du nom de la filière")]
        public string StartOfFileName { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the start of file name")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du début du nom de la filière")]
        public TranslationStatusEnum TranslationStatusStartOfFileName { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ReportTypeLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
