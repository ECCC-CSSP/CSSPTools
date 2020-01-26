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
    public partial class ElementLayer : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, 1000)]
        [CSSPDisplayEN(DisplayEN = "Layer")]
        [CSSPDisplayFR(DisplayFR = "Couche")]
        [CSSPDescriptionEN(DescriptionEN = @"Layer")]
        [CSSPDescriptionFR(DescriptionFR = @"Couche")]
        public int Layer { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z min")]
        [CSSPDisplayFR(DisplayFR = "Z min")]
        [CSSPDescriptionEN(DescriptionEN = @"Z minimum")]
        [CSSPDescriptionFR(DescriptionFR = @"Z minimum")]
        public double ZMin { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z max")]
        [CSSPDisplayFR(DisplayFR = "Z max")]
        [CSSPDescriptionEN(DescriptionEN = @"Z maximum")]
        [CSSPDescriptionFR(DescriptionFR = @"Z maximum")]
        public double ZMax { get; set; }
        [CSSPDisplayEN(DisplayEN = "Element")]
        [CSSPDisplayFR(DisplayFR = "Élément")]
        [CSSPDescriptionEN(DescriptionEN = @"Element")]
        [CSSPDescriptionFR(DescriptionFR = @"Élément")]
        public Element Element { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ElementLayer() : base()
        {
        }
        #endregion Constructors
    }
}
