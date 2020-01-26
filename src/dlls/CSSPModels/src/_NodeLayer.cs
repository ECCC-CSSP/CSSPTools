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
    public partial class NodeLayer : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Layer")]
        [CSSPDisplayFR(DisplayFR = "Couche")]
        [CSSPDescriptionEN(DescriptionEN = @"Layer")]
        [CSSPDescriptionFR(DescriptionFR = @"Couche")]
        public int Layer { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z")]
        [CSSPDisplayFR(DisplayFR = "Z")]
        [CSSPDescriptionEN(DescriptionEN = @"Z coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonné Z")]
        public double Z { get; set; }
        [CSSPDisplayEN(DisplayEN = "Node")]
        [CSSPDisplayFR(DisplayFR = "Noeud")]
        [CSSPDescriptionEN(DescriptionEN = @"Node")]
        [CSSPDescriptionFR(DescriptionFR = @"Noeud")]
        public Node Node { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public NodeLayer() : base()
        {
        }
        #endregion Constructors
    }
}
