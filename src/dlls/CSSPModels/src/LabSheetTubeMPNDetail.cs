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
    public partial class LabSheetTubeMPNDetail : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "LabSheetTubeMPNDetail ID")]
        [CSSPDisplayFR(DisplayFR = "LabSheetTubeMPNDetail ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the LabSheetTubeMPNDetails table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table LabSheetTubeMPNDetails")]
        public int LabSheetTubeMPNDetailID { get; set; }
        [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID")]
        [CSSPDisplayEN(DisplayEN = "Lab sheet details")]
        [CSSPDisplayFR(DisplayFR = "Détails de feuille de laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the LabSheetDetails table representing the lab sheet detail")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table LabSheetDetails représentant les détail de laboratoire")]
        public int LabSheetDetailID { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        [CSSPDisplayEN(DisplayEN = "MWQMSite TVItemID")]
        [CSSPDisplayFR(DisplayFR = "MWQMSite TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the MWQM site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site de MWQM (fr)")]
        public int MWQMSiteTVItemID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Sample date")]
        [CSSPDisplayFR(DisplayFR = "Date de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de la tournée")]
        public DateTime? SampleDateTime { get; set; }
        [Range(1, 10000000)]
        [CSSPDisplayEN(DisplayEN = "MPN (/100 mL)")]
        [CSSPDisplayFR(DisplayFR = "NPP (/100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Most probable number of fecal coliform colonies per 100 mL")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre le plus probable de colonies de coliform fécaux par 100 mL")]
        public int? MPN { get; set; }
        [Range(0, 5)]
        [CSSPDisplayEN(DisplayEN = "Tube 10")]
        [CSSPDisplayFR(DisplayFR = "Tube 10")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of positive tube for Tube 10")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tube positif pour Tube 10")]
        public int? Tube10 { get; set; }
        [Range(0, 5)]
        [CSSPDisplayEN(DisplayEN = "Tube 1")]
        [CSSPDisplayFR(DisplayFR = "Tube 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of positive tube for Tube 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tube positif pour Tube 1")]
        public int? Tube1_0 { get; set; }
        [Range(0, 5)]
        [CSSPDisplayEN(DisplayEN = "Tube .1")]
        [CSSPDisplayFR(DisplayFR = "Tube .1")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of positive tube for Tube .1")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tube positif pour Tube .1")]
        public int? Tube0_1 { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Salinity (PPT)")]
        [CSSPDisplayFR(DisplayFR = "Salinité (PPT)")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity in parts per thousand")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité en parties par millier")]
        public double? Salinity { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température en dégré Celcius")]
        public double? Temperature { get; set; }
        [StringLength(10)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Processed by")]
        [CSSPDisplayFR(DisplayFR = "Traité par")]
        [CSSPDescriptionEN(DescriptionEN = @"Processed by")]
        [CSSPDescriptionFR(DescriptionFR = @"Traité par")]
        public string ProcessedBy { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sample type")]
        [CSSPDisplayFR(DisplayFR = "Type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'échantillon")]
        public SampleTypeEnum SampleType { get; set; }
        [StringLength(250)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Site comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire relié au site")]
        [CSSPDescriptionEN(DescriptionEN = @"Site comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire relié au site")]
        public string SiteComment { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LabSheetTubeMPNDetail() : base()
        {
        }
        #endregion Constructors
    }
}
