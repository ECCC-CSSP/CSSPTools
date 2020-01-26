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
    public partial class SubsectorMWQMSampleYear : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Subsector TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le sous-secteur")]
        public int SubsectorTVItemID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Year")]
        [CSSPDisplayFR(DisplayFR = "Année")]
        [CSSPDescriptionEN(DescriptionEN = @"Year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année")]
        public int Year { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Earliest date")]
        [CSSPDisplayFR(DisplayFR = "Date la plus ancienne")]
        [CSSPDescriptionEN(DescriptionEN = @"Earliest date with some samples")]
        [CSSPDescriptionFR(DescriptionFR = @"Date la plus ancienne avec des échantillons")]
        public DateTime EarliestDate { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "EarliestDate")]
        [CSSPDisplayEN(DisplayEN = "Latest date")]
        [CSSPDisplayFR(DisplayFR = "Date la plus récente")]
        [CSSPDescriptionEN(DescriptionEN = @"Latest date with some samples")]
        [CSSPDescriptionFR(DescriptionFR = @"Date la plus récente avec des échantillons")]
        public DateTime LatestDate { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public SubsectorMWQMSampleYear() : base()
        {
        }
        #endregion Constructors
    }
}
