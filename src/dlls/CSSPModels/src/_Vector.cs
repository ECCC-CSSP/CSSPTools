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
    public partial class Vector : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "Start node")]
        [CSSPDisplayFR(DisplayFR = "Node de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Start node")]
        [CSSPDescriptionFR(DescriptionFR = @"Node de départ")]
        public Node StartNode { get; set; }
        [CSSPDisplayEN(DisplayEN = "End node")]
        [CSSPDisplayFR(DisplayFR = "Node de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"End node")]
        [CSSPDescriptionFR(DescriptionFR = @"Node de fin")]
        public Node EndNode { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Vector() : base()
        {
        }
        #endregion Constructors
    }
}
