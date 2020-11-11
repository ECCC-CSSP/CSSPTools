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
    public partial class CSSPMPNTable
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(0, 5)]
        public int Tube10 { get; set; }
        [CSSPRange(0, 5)]
        public int Tube1_0 { get; set; }
        [CSSPRange(0, 5)]
        public int Tube0_1 { get; set; }
        [CSSPRange(0, 100000000)]
        public int MPN { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CSSPMPNTable() : base()
        {
        }
        #endregion Constructors
    }
}
