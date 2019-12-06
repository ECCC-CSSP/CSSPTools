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
    public partial class Element : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "ID")]
        [CSSPDisplayFR(DisplayFR = "ID")]
        [CSSPDescriptionEN(DescriptionEN = @"ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant")]
        public int ID { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Type")]
        [CSSPDisplayFR(DisplayFR = "Type")]
        [CSSPDescriptionEN(DescriptionEN = @"Type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type")]
        public int Type { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Number of nodes")]
        [CSSPDisplayFR(DisplayFR = "Nombre de noeux")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of nodes")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de noeux")]
        public int NumbOfNodes { get; set; }
        [CSSPDisplayEN(DisplayEN = "Value")]
        [CSSPDisplayFR(DisplayFR = "Valeur")]
        [CSSPDescriptionEN(DescriptionEN = @"Value")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur")]
        public double Value { get; set; }
        [CSSPDisplayEN(DisplayEN = "X node0")]
        [CSSPDisplayFR(DisplayFR = "X noeu0")]
        [CSSPDescriptionEN(DescriptionEN = @"X node0")]
        [CSSPDescriptionFR(DescriptionFR = @"X noeu0")]
        public double XNode0 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z node0")]
        [CSSPDisplayFR(DisplayFR = "Z noeu0")]
        [CSSPDescriptionEN(DescriptionEN = @"Z node0")]
        [CSSPDescriptionFR(DescriptionFR = @"Z noeu0")]
        public double YNode0 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z node0")]
        [CSSPDisplayFR(DisplayFR = "Z noeu0")]
        [CSSPDescriptionEN(DescriptionEN = @"Z node0")]
        [CSSPDescriptionFR(DescriptionFR = @"Z noeu0")]
        public double ZNode0 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Node list")]
        [CSSPDisplayFR(DisplayFR = "Liste de noeux")]
        [CSSPDescriptionEN(DescriptionEN = @"Node list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de noeux")]
        public List<Node> NodeList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Element() : base()
        {
            NodeList = new List<Node>();
        }
        #endregion Constructors
    }
}
