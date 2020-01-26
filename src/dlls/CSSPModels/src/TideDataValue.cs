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
    public partial class TideDataValue : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "TideDataValue ID")]
        [CSSPDisplayFR(DisplayFR = "TideDataValue ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the TideDataValues table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table TideDataValues")]
        public int TideDataValueID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "22")]
        [CSSPDisplayEN(DisplayEN = "Tide site")]
        [CSSPDisplayFR(DisplayFR = "Site de marée")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the tide site")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le site de marée")]
        public int TideSiteTVItemID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date (local)")]
        public DateTime DateTime_Local { get; set; }
        [CSSPDisplayEN(DisplayEN = "Keep")]
        [CSSPDisplayFR(DisplayFR = "Sauvegarder")]
        [CSSPDescriptionEN(DescriptionEN = @"Keep")]
        [CSSPDescriptionFR(DescriptionFR = @"Sauvegarder")]
        public bool Keep { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Tide data type")]
        [CSSPDisplayFR(DisplayFR = "Type de donnée de marée")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide data type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de donnée de marée")]
        public TideDataTypeEnum TideDataType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Storage data type")]
        [CSSPDisplayFR(DisplayFR = "Type de sauvegarde des données")]
        [CSSPDescriptionEN(DescriptionEN = @"Storage data type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de sauvegarde des données")]
        public StorageDataTypeEnum StorageDataType { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Depth (m)")]
        [CSSPDisplayFR(DisplayFR = "Profondeur (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Depth in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Profondeur en mètres")]
        public double Depth_m { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "U velocity (m/s)")]
        [CSSPDisplayFR(DisplayFR = "U vélocité (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"U velocity in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"U vélocité en mètres par second")]
        public double UVelocity_m_s { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "V velocity (m/s)")]
        [CSSPDisplayFR(DisplayFR = "V vélocité (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"V velocity in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"V vélocité en mètres par second")]
        public double VVelocity_m_s { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tide text start")]
        [CSSPDisplayFR(DisplayFR = "Tide text de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide text start")]
        [CSSPDescriptionFR(DescriptionFR = @"Tide text de départ")]
        public TideTextEnum? TideStart { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tide text end")]
        [CSSPDisplayFR(DisplayFR = "Tide text de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide text end")]
        [CSSPDescriptionFR(DescriptionFR = @"Tide text de fin")]
        public TideTextEnum? TideEnd { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TideDataValue() : base()
        {
        }
        #endregion Constructors
    }
}
