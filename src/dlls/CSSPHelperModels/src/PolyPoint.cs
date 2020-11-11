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

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class PolyPoint
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(-180.0D, 180.0D)]
        public double XCoord { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double YCoord { get; set; }
        public double Z { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolyPoint() : base()
        {
        }
        #endregion Constructors
    }
}
