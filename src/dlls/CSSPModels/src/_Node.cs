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
    public partial class Node
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, 1000000)]
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int Code { get; set; }
        public double Value { get; set; }
        public List<Element> ElementList { get; set; }
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
