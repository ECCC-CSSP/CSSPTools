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
    public partial class MikeSourceStartEnd : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MikeSourceStartEnd ID")]
        [CSSPDisplayFR(DisplayFR = "MikeSourceStartEnd ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MikeSourceStartEnds table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MikeSourceStartEnds")]
        public int MikeSourceStartEndID { get; set; }
        [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID")]
        [CSSPDisplayEN(DisplayEN = "MIKE source ID")]
        [CSSPDisplayFR(DisplayFR = "ID de source MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the MikeSources table representing MIKE source")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table MikeSources représentant une source MIKE")]
        public int MikeSourceID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Start date and time (local)")]
        [CSSPDisplayFR(DisplayFR = "Date et temps du début (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Start date and time (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date et temps du début (local)")]
        public DateTime StartDateAndTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDateAndTime_Local")]
        [CSSPDisplayEN(DisplayEN = "End date and time (local)")]
        [CSSPDisplayFR(DisplayFR = "Date et temps de fin (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"End date and time (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date et temps de fin (local)")]
        public DateTime EndDateAndTime_Local { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Start of source flow (m3/d)")]
        [CSSPDisplayFR(DisplayFR = "Début de débit de source (m3/j)")]
        [CSSPDescriptionEN(DescriptionEN = @"Start of source flow in cubic meters per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Début de débit de source en mètres cubes par jour")]
        public double SourceFlowStart_m3_day { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "End of source flow (m3/d)")]
        [CSSPDisplayFR(DisplayFR = "Fin de débit de source (m3/j)")]
        [CSSPDescriptionEN(DescriptionEN = @"End of source flow in cubic meters per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Fin de débit de source en mètres cubes par jour")]
        public double SourceFlowEnd_m3_day { get; set; }
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "Start of source concentration (MPN / 100 mL)")]
        [CSSPDisplayFR(DisplayFR = "Début de concentration de source (NPP / 100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Start of source concentration in most probable number of fecal coliform colonies per 100 milli-Litres")]
        [CSSPDescriptionFR(DescriptionFR = @"Début de concentration de source en nombre plus probable de colonie de coliform fécaux par 100 milli-Litres")]
        public int SourcePollutionStart_MPN_100ml { get; set; }
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "End of source concentration (MPN / 100 mL)")]
        [CSSPDisplayFR(DisplayFR = "Fin de concentration de source (NPP / 100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"End of source concentration in most probable number of fecal coliform colonies per 100 milli-Litres")]
        [CSSPDescriptionFR(DescriptionFR = @"Fin de concentration de source en nombre plus probable de colonie de coliform fécaux par 100 milli-Litres")]
        public int SourcePollutionEnd_MPN_100ml { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Start of source temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Début de température de source (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Start of source temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Début de température de source en dégré Celcius")]
        public double SourceTemperatureStart_C { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "End of source temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Fin de température de source (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"End of source temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Fin de température de source en dégré Celcius")]
        public double SourceTemperatureEnd_C { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Start of source salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Début de salinité de source (PSU) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Start of source salinity (PSU)")]
        [CSSPDescriptionFR(DescriptionFR = @"Début de salinité de source (PSU) (fr)")]
        public double SourceSalinityStart_PSU { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "End of source salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Fin de salinité de source (PSU) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"End of source salinity (PSU)")]
        [CSSPDescriptionFR(DescriptionFR = @"Fin de salinité de source (PSU) (fr)")]
        public double SourceSalinityEnd_PSU { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeSourceStartEnd() : base()
        {
        }
        #endregion Constructors
    }
}
