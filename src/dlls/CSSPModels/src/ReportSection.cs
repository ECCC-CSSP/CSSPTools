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
    public partial class ReportSection : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ReportSection ID")]
        [CSSPDisplayFR(DisplayFR = "ReportSection ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ReportSections table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ReportSections")]
        public int ReportSectionID { get; set; }
        [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID")]
        [CSSPDisplayEN(DisplayEN = "Report type ID")]
        [CSSPDisplayFR(DisplayFR = "Type de raport ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the ReportTypes table representing the report type")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table ReportTypes représentant le type de raport")]
        public int ReportTypeID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID")]
        [CSSPDisplayEN(DisplayEN = "Item TVItemID")]
        [CSSPDisplayFR(DisplayFR = "L'item TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the item")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item")]
        public int? TVItemID { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is static")]
        [CSSPDisplayFR(DisplayFR = "Est statique")]
        [CSSPDescriptionEN(DescriptionEN = @"Is static --- the text will not change in time")]
        [CSSPDescriptionFR(DescriptionFR = @"Est statique --- le texte ne changera pas dans le temps")]
        public bool IsStatic { get; set; }
        [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID")]
        [CSSPDisplayEN(DisplayEN = "Parent report section ID")]
        [CSSPDisplayFR(DisplayFR = "Section du raport du parent ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Parent report section ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Section du raport du parent ID")]
        public int? ParentReportSectionID { get; set; }
        [Range(1979, 2050)]
        [CSSPDisplayEN(DisplayEN = "Year")]
        [CSSPDisplayFR(DisplayFR = "Année")]
        [CSSPDescriptionEN(DescriptionEN = @"Year for which the text is applicable")]
        [CSSPDescriptionFR(DescriptionFR = @"Année dont le texte est applicable")]
        public int? Year { get; set; }
        [CSSPDisplayEN(DisplayEN = "Locked")]
        [CSSPDisplayFR(DisplayFR = "Barré")]
        [CSSPDescriptionEN(DescriptionEN = @"Locked --- not currently used")]
        [CSSPDescriptionFR(DescriptionFR = @"Barré --- pas utilisé encore")]
        public bool Locked { get; set; }
        [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID")]
        [CSSPDisplayEN(DisplayEN = "Template report section ID")]
        [CSSPDisplayFR(DisplayFR = "Gabari de la section du raport ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Template report section ID --- not currently used")]
        [CSSPDescriptionFR(DescriptionFR = @"Gabari de la section du raport ID --- pas utilisé encore")]
        public int? TemplateReportSectionID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ReportSection() : base()
        {
        }
        #endregion Constructors
    }
}
