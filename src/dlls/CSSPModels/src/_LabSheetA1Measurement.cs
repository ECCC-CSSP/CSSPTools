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
    public partial class LabSheetA1Measurement : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "Site")]
        [CSSPDisplayFR(DisplayFR = "Site")]
        [CSSPDescriptionEN(DescriptionEN = @"Site MWQM")]
        [CSSPDescriptionFR(DescriptionFR = @"Site MWQM (fr)")]
        public string Site { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "TVItemID")]
        [CSSPDisplayFR(DisplayFR = "TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int TVItemID { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Time")]
        [CSSPDisplayFR(DisplayFR = "Temps")]
        [CSSPDescriptionEN(DescriptionEN = @"Time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps")]
        public DateTime? Time { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "MPN (/100 mL)")]
        [CSSPDisplayFR(DisplayFR = "NPP (/100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Most probable number of fecal coliform colonies per 100 mL")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre le plus probable de colonies de coliform fécaux par 100 mL")]
        public int? MPN { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tube 10")]
        [CSSPDisplayFR(DisplayFR = "Tube 10")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of positive tube for Tube 10")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tube positif pour Tube 10")]
        public int? Tube10 { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tube 1")]
        [CSSPDisplayFR(DisplayFR = "Tube 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of positive tube for Tube 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tube positif pour Tube 1")]
        public int? Tube1_0 { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tube .1")]
        [CSSPDisplayFR(DisplayFR = "Tube .1")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of positive tube for Tube .1")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tube positif pour Tube .1")]
        public int? Tube0_1 { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Salinité (PSU)")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity (PSU)")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité (PSU)")]
        public double? Salinity { get; set; }
        [CSSPDisplayEN(DisplayEN = "Temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température en dégré Celcius")]
        public double Temperature { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Processed by")]
        [CSSPDisplayFR(DisplayFR = "Traité par")]
        [CSSPDescriptionEN(DescriptionEN = @"Processed by")]
        [CSSPDescriptionFR(DescriptionFR = @"Traité par")]
        public string ProcessedBy { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample type")]
        [CSSPDisplayFR(DisplayFR = "Type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'échantillon")]
        public SampleTypeEnum? SampleType { get; set; }
        [CSSPDisplayEN(DisplayEN = "Site comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire relatif au site")]
        [CSSPDescriptionEN(DescriptionEN = @"Site comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire relatif au site")]
        public string SiteComment { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SampleTypeEnum", EnumType = "SampleType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type d'échantillon")]
        public string SampleTypeText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LabSheetA1Measurement() : base()
        {
        }
        #endregion Constructors
    }
}
