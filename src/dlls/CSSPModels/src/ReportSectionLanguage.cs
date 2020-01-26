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
    public partial class ReportSectionLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ReportSectionLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "ReportSectionLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ReportSectionLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ReportSectionLanguages")]
        public int ReportSectionLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID")]
        [CSSPDisplayEN(DisplayEN = "Report section ID")]
        [CSSPDisplayFR(DisplayFR = "Section du raport ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the ReportSections table representing the report section")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table ReportSections représentant la section du raport")]
        public int ReportSectionID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Report section name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la section du raport")]
        [CSSPDescriptionEN(DescriptionEN = @"Report section name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la section du raport")]
        public string ReportSectionName { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the report section name")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du nom de la section du raport")]
        public TranslationStatusEnum TranslationStatusReportSectionName { get; set; }
        [StringLength(10000)]
        [CSSPDisplayEN(DisplayEN = "Report section text")]
        [CSSPDisplayFR(DisplayFR = "Texte de la section du raport")]
        [CSSPDescriptionEN(DescriptionEN = @"Report section text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de la section du raport")]
        public string ReportSectionText { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the report section text")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du texte de la section du raport")]
        public TranslationStatusEnum TranslationStatusReportSectionText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ReportSectionLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
