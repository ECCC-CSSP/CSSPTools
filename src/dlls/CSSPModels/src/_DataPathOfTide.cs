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
    public partial class DataPathOfTide : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Text")]
        [CSSPDisplayFR(DisplayFR = "Texte")]
        [CSSPDescriptionEN(DescriptionEN = @"Text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte")]
        public string Text { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Web tide dataset")]
        [CSSPDisplayFR(DisplayFR = "Données web tide")]
        [CSSPDescriptionEN(DescriptionEN = @"Web tide dataset")]
        [CSSPDescriptionFR(DescriptionFR = @"Données web tide")]
        public WebTideDataSetEnum? WebTideDataSet { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "WebTideDataSetEnum", EnumType = "WebTideDataSet")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Web tide dataset text")]
        [CSSPDisplayFR(DisplayFR = "Texte de données web tide")]
        [CSSPDescriptionEN(DescriptionEN = @"Web tide dataset text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de données web tide")]
        public string WebTideDataSetText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public DataPathOfTide() : base()
        {
            Text = "";
            WebTideDataSet = null;
        }
        #endregion Constructors
    }
}
