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
    public partial class ElementLayer
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, 1000)]
        public int Layer { get; set; }
        public double ZMin { get; set; }
        public double ZMax { get; set; }
        public Element Element { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ElementLayer() : base()
        {
        }
        #endregion Constructors
    }
}
