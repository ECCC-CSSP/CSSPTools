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
    public partial class Spill : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Spill ID")]
        [CSSPDisplayFR(DisplayFR = "Spill ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Spills table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Spills")]
        public int SpillID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "15")]
        [CSSPDisplayEN(DisplayEN = "Municipality TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Municipalité TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the municipality")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la municipalité")]
        public int MunicipalityTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
        [CSSPDisplayEN(DisplayEN = "Infrastructure TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Infrastructure TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'infrastructure")]
        public int? InfrastructureTVItemID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Start date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de début (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Start date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de début (local)")]
        public DateTime StartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDateTime_Local")]
        [CSSPDisplayEN(DisplayEN = "End date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de fin (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"End date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin (local)")]
        public DateTime? EndDateTime_Local { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Average flow (m3/d)")]
        [CSSPDisplayFR(DisplayFR = "Débit moyen (m3/j)")]
        [CSSPDescriptionEN(DescriptionEN = @"Average flow in cubic meters per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Débit moyer en mètres cube par jour")]
        public double AverageFlow_m3_day { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Spill() : base()
        {
        }
        #endregion Constructors
    }
}
