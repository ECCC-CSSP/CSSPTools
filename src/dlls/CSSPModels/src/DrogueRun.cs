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
    public partial class DrogueRun : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Drogue run ID")]
        [CSSPDisplayFR(DisplayFR = "Drogue run ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the DrogueRuns table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table DrogueRuns")]
        public int DrogueRunID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        [CSSPDisplayEN(DisplayEN = "Subsector")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le sous-secteur")]
        public int SubsectorTVItemID { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Drogue number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de drogue")]
        [CSSPDescriptionEN(DescriptionEN = @"Drogue number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de drogue")]
        public int DrogueNumber { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Drogue type")]
        [CSSPDisplayFR(DisplayFR = "Type de drogue")]
        [CSSPDescriptionEN(DescriptionEN = @"Drogue type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de drogue")]
        public DrogueTypeEnum DrogueType { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Drogue run start date and time (local)")]
        [CSSPDisplayFR(DisplayFR = "Date et temps de départ de la run drogue (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Drogue run start date and time (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date et temps de départ de la run drogue (local)")]
        public DateTime RunStartDateTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Rising tide")]
        [CSSPDisplayFR(DisplayFR = "Marée montante")]
        [CSSPDescriptionEN(DescriptionEN = @"Is rising tide")]
        [CSSPDescriptionFR(DescriptionFR = @"Marée montante")]
        public bool IsRisingTide { get; set; }
        #endregion Properties in DB

        #region Constructors
        public DrogueRun() : base()
        {
        }
        #endregion Constructors
    }
}
