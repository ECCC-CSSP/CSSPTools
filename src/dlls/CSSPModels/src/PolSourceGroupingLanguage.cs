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
    public partial class PolSourceGroupingLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceGroupingLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceGroupingLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceGroupingLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceGroupingLanguages")]
        public int PolSourceGroupingLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceGrouping", ExistPlurial = "s", ExistFieldID = "PolSourceGroupingID")]
        [CSSPDisplayEN(DisplayEN = "Pol Source Grouping ID")]
        [CSSPDisplayFR(DisplayFR = "Pol Source Grouping ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the PolSourceGroupings table representing the pollution source grouping")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table PolSourceGroupins représentant le groupement de source de pollution")]
        public int PolSourceGroupingID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Source Name")]
        [CSSPDisplayFR(DisplayFR = "Nom de source")]
        [CSSPDescriptionEN(DescriptionEN = @"Source Name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de source")]
        public string SourceName { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Source name ordering number")]
        [CSSPDisplayFR(DisplayFR = "Numéro d'ordre du nom de source")]
        [CSSPDescriptionEN(DescriptionEN = @"Source name ordering number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro d'ordre du nom de source")]
        public int SourceNameOrder { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status of the source name")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction du nom de source")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the source name")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du nom de source")]
        public TranslationStatusEnum TranslationStatusSourceName { get; set; }
        [StringLength(50)]
        [CSSPDisplayEN(DisplayEN = "Init")]
        [CSSPDisplayFR(DisplayFR = "Init")]
        [CSSPDescriptionEN(DescriptionEN = @"Initial")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiale")]
        public string Init { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status of Init")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction de Init")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of Init")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction de Init")]
        public TranslationStatusEnum TranslationStatusInit { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Description")]
        [CSSPDisplayFR(DisplayFR = "Description")]
        [CSSPDescriptionEN(DescriptionEN = @"Description")]
        [CSSPDescriptionFR(DescriptionFR = @"Description")]
        public string Description { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status of Description")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction de Description")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of Description")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction de Description")]
        public TranslationStatusEnum TranslationStatusDescription { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Report")]
        [CSSPDisplayFR(DisplayFR = "Report")]
        [CSSPDescriptionEN(DescriptionEN = @"Report")]
        [CSSPDescriptionFR(DescriptionFR = @"Report")]
        public string Report { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status of Report")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction de Report")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of Report")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction de Report")]
        public TranslationStatusEnum TranslationStatusReport { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Text")]
        [CSSPDisplayFR(DisplayFR = "Text")]
        [CSSPDescriptionEN(DescriptionEN = @"Text")]
        [CSSPDescriptionFR(DescriptionFR = @"Text")]
        public string Text { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status of Text")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction de Text")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of Text")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction de Text")]
        public TranslationStatusEnum TranslationStatusText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceGroupingLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
