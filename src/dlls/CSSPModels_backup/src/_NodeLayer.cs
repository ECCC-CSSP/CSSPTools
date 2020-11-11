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
    public partial class NodeLayer
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, 100)]
        public int Layer { get; set; }
        public double Z { get; set; }
        public Node Node { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public NodeLayer() : base()
        {
        }
        #endregion Constructors
    }
}
