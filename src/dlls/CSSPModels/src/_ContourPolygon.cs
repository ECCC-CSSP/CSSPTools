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
    public partial class ContourPolygon
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Contour value")]
        [CSSPDisplayFR(DisplayFR = "Valeur de contour")]
        [CSSPDescriptionEN(DescriptionEN = @"Contour value")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur de contour")]
        public double ContourValue { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Layer")]
        [CSSPDisplayFR(DisplayFR = "Couche")]
        [CSSPDescriptionEN(DescriptionEN = @"Layer")]
        [CSSPDescriptionFR(DescriptionFR = @"Couche")]
        public int Layer { get; set; }
        [Range(1.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Depth (m)")]
        [CSSPDisplayFR(DisplayFR = "Profondeur (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Depth in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Profondeur en mètres")]
        public double Depth_m { get; set; }
        [CSSPDisplayEN(DisplayEN = "Contour node list")]
        [CSSPDisplayFR(DisplayFR = "Liste de noeux de contour")]
        [CSSPDescriptionEN(DescriptionEN = @"Contour node list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de noeux de contour")]
        public List<Node> ContourNodeList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ContourPolygon() : base()
        {
            ContourNodeList = new List<Node>();
        }
        #endregion Constructors
    }
}
