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
    public partial class DrogueRunPosition : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "DrogueRunPosition ID")]
        [CSSPDisplayFR(DisplayFR = "DrogueRunPosition ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique identifier on each row of the DrogueRunPositions table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table DrogueRunPositions")]
        public int DrogueRunPositionID { get; set; }
        [CSSPExist(ExistTypeName = "DrogueRun", ExistPlurial = "s", ExistFieldID = "DrogueRunID")]
        [CSSPDisplayEN(DisplayEN = "Drogue run")]
        [CSSPDisplayFR(DisplayFR = "Drogue run (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the DrogueRuns table representing the drogue run")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table DrogueRuns représentant la drogue run (fr)")]
        public int DrogueRunID { get; set; }
        [Range(0, 100000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordinal (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordinal (fr)")]
        public int Ordinal { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Step Lat")]
        [CSSPDisplayFR(DisplayFR = "Step Lat")]
        [CSSPDescriptionEN(DescriptionEN = @"Step Lat")]
        [CSSPDescriptionFR(DescriptionFR = @"Step Lat")]
        public double StepLat { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Step Lng")]
        [CSSPDisplayFR(DisplayFR = "Step Lng")]
        [CSSPDescriptionEN(DescriptionEN = @"Step Lng")]
        [CSSPDescriptionFR(DescriptionFR = @"Step Lng")]
        public double StepLng { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Step date and time (local)")]
        [CSSPDisplayFR(DisplayFR = "Step date and time (local) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Step date and time (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Step date and time (local) (fr)")]
        public DateTime StepDateTime_Local { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Calculated speed (m/s)")]
        [CSSPDisplayFR(DisplayFR = "Calculated speed (m/s) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated speed (m/s)")]
        [CSSPDescriptionFR(DescriptionFR = @"Calculated speed (m/s) (fr)")]
        public double CalculatedSpeed_m_s { get; set; }
        [Range(0.0D, 360.0D)]
        [CSSPDisplayEN(DisplayEN = "Calculated direction (deg)")]
        [CSSPDisplayFR(DisplayFR = "Calculated direction (deg) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated direction (deg)")]
        [CSSPDescriptionFR(DescriptionFR = @"Calculated direction (deg) (fr)")]
        public double CalculatedDirection_deg { get; set; }
        #endregion Properties in DB

        #region Constructors
        public DrogueRunPosition() : base()
        {
        }
        #endregion Constructors
    }
}
