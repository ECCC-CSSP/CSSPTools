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
    public partial class Node : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, 1000000)]
        [CSSPDisplayEN(DisplayEN = "ID")]
        [CSSPDisplayFR(DisplayFR = "ID")]
        [CSSPDescriptionEN(DescriptionEN = @"ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant")]
        public int ID { get; set; }
        [CSSPDisplayEN(DisplayEN = "X")]
        [CSSPDisplayFR(DisplayFR = "X")]
        [CSSPDescriptionEN(DescriptionEN = @"X coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonée X")]
        public double X { get; set; }
        [CSSPDisplayEN(DisplayEN = "Y")]
        [CSSPDisplayFR(DisplayFR = "Y")]
        [CSSPDescriptionEN(DescriptionEN = @"Y coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonée Y")]
        public double Y { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z")]
        [CSSPDisplayFR(DisplayFR = "Z")]
        [CSSPDescriptionEN(DescriptionEN = @"Z coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonée Z")]
        public double Z { get; set; }
        [CSSPDisplayEN(DisplayEN = "Code")]
        [CSSPDisplayFR(DisplayFR = "Code")]
        [CSSPDescriptionEN(DescriptionEN = @"Code")]
        [CSSPDescriptionFR(DescriptionFR = @"Code")]
        public int Code { get; set; }
        [CSSPDisplayEN(DisplayEN = "Value")]
        [CSSPDisplayFR(DisplayFR = "Valeur")]
        [CSSPDescriptionEN(DescriptionEN = @"Value")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur")]
        public double Value { get; set; }
        [CSSPDisplayEN(DisplayEN = "Element list")]
        [CSSPDisplayFR(DisplayFR = "Liste d'élément")]
        [CSSPDescriptionEN(DescriptionEN = @"Element list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste d'élément")]
        public List<Element> ElementList { get; set; }
        [CSSPDisplayEN(DisplayEN = "Connect node list")]
        [CSSPDisplayFR(DisplayFR = "Liste de noeux de connexion")]
        [CSSPDescriptionEN(DescriptionEN = @"Connect node list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de noeux de connexion")]
        public List<Node> ConnectNodeList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Node() : base()
        {
            ElementList = new List<Element>();
            ConnectNodeList = new List<Node>();
        }
        #endregion Constructors
    }
}
