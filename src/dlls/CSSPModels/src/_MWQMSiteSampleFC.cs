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
    [NotMapped]
    public partial class MWQMSiteSampleFC : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Sample date")]
        [CSSPDisplayFR(DisplayFR = "Date d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date d'échantillon")]
        public DateTime SampleDate { get; set; }
        [Range(1, 100000000)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "FC")]
        [CSSPDisplayFR(DisplayFR = "CF")]
        [CSSPDescriptionEN(DescriptionEN = @"Fecal coliform")]
        [CSSPDescriptionFR(DescriptionFR = @"Coliformes fécaux")]
        public int? FC { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sal (PPT)")]
        [CSSPDisplayFR(DisplayFR = "Sal (PPT) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity parts per thousand")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité partis par millier")]
        public double? Sal { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Temp (°C)")]
        [CSSPDisplayFR(DisplayFR = "Temp (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température en dégré Celcius")]
        public double? Temp { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "pH")]
        [CSSPDisplayFR(DisplayFR = "pH")]
        [CSSPDescriptionEN(DescriptionEN = @"pH")]
        [CSSPDescriptionFR(DescriptionFR = @"pH")]
        public double? PH { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "DO")]
        [CSSPDisplayFR(DisplayFR = "DO")]
        [CSSPDescriptionEN(DescriptionEN = @"Disolved oxygen")]
        [CSSPDescriptionFR(DescriptionFR = @"Oxygène dissous")]
        public double? DO { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Depth (m)")]
        [CSSPDisplayFR(DisplayFR = "Profondeur (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Depth in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Profondeur en mètres")]
        public double? Depth { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample count")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample count")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'échantillon")]
        public int? SampCount { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Min FC")]
        [CSSPDisplayFR(DisplayFR = "CF min")]
        [CSSPDescriptionEN(DescriptionEN = @"Minimum fecal coliform")]
        [CSSPDescriptionFR(DescriptionFR = @"Coliforms fécaux minimum")]
        public int? MinFC { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Max FC")]
        [CSSPDisplayFR(DisplayFR = "CF max")]
        [CSSPDescriptionEN(DescriptionEN = @"Maximum fecal coliform")]
        [CSSPDescriptionFR(DescriptionFR = @"Coliforms fécaux maximum")]
        public int? MaxFC { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Geo mean")]
        [CSSPDisplayFR(DisplayFR = "Moyenne géométrique")]
        [CSSPDescriptionEN(DescriptionEN = @"Geometric mean")]
        [CSSPDescriptionFR(DescriptionFR = @"Moyenne géométrique")]
        public double? GeoMean { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Median")]
        [CSSPDisplayFR(DisplayFR = "Médian")]
        [CSSPDescriptionEN(DescriptionEN = @"Median")]
        [CSSPDescriptionFR(DescriptionFR = @"Médian")]
        public double? Median { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "P90")]
        [CSSPDisplayFR(DisplayFR = "P90")]
        [CSSPDescriptionEN(DescriptionEN = @"90th percentile")]
        [CSSPDescriptionFR(DescriptionFR = @"90ième poucentile")]
        public double? P90 { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "% > 43")]
        [CSSPDisplayFR(DisplayFR = "% > 43")]
        [CSSPDescriptionEN(DescriptionEN = @"Percent of samples over 43")]
        [CSSPDescriptionFR(DescriptionFR = @"Poucentage d'échantillon plus grand que 43")]
        public double? PercOver43 { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "% > 260")]
        [CSSPDisplayFR(DisplayFR = "% > 260")]
        [CSSPDescriptionEN(DescriptionEN = @"Percent of samples over 260")]
        [CSSPDescriptionFR(DescriptionFR = @"Pourcentage d'échantillon plus grand que 260")]
        public double? PercOver260 { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public MWQMSiteSampleFC() : base()
        {
        }
        #endregion Constructors
    }
}
