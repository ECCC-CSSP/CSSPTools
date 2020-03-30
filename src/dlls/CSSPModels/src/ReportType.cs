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
    public partial class ReportType : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ReportType ID")]
        [CSSPDisplayFR(DisplayFR = "ReportType ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ReportTypes table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ReportTypes")]
        public int ReportTypeID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"TV type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de l'arbre visuel")]
        public TVTypeEnum TVType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "File type")]
        [CSSPDisplayFR(DisplayFR = "Type de filière")]
        [CSSPDescriptionEN(DescriptionEN = @"File type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de filière")]
        public FileTypeEnum FileType { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Unique code")]
        [CSSPDisplayFR(DisplayFR = "Code unique")]
        [CSSPDescriptionEN(DescriptionEN = @"Unique code --- used in code for knowing which document and type of document to create")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de filière --- utilisé dans le code afin de savoir quel document et type de document à créer")]
        public string UniqueCode { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum? Language { get; set; }
        [StringLength(100)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Name")]
        [CSSPDisplayFR(DisplayFR = "Nom")]
        [CSSPDescriptionEN(DescriptionEN = @"Name of the report type")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du type de raport")]
        public string Name { get; set; }
        [StringLength(1000)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Description")]
        [CSSPDisplayFR(DisplayFR = "Description")]
        [CSSPDescriptionEN(DescriptionEN = @"Description of the report type")]
        [CSSPDescriptionFR(DescriptionFR = @"Description du type de raport")]
        public string Description { get; set; }
        [StringLength(100)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Start of file name")]
        [CSSPDisplayFR(DisplayFR = "Début du nom de la filière")]
        [CSSPDescriptionEN(DescriptionEN = @"Start of file name")]
        [CSSPDescriptionFR(DescriptionFR = @"Début du nom de la filière")]
        public string StartOfFileName { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ReportType() : base()
        {
        }
        #endregion Constructors
    }
}
