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
    public partial class MWQMLookupMPN : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MWQMLookupMPNID { get; set; }
        [CSSPRange(0, 5)]
        public int Tubes10 { get; set; }
        [CSSPRange(0, 5)]
        public int Tubes1 { get; set; }
        [CSSPRange(0, 5)]
        public int Tubes01 { get; set; }
        [CSSPRange(1, 10000)]
        public int MPN_100ml { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMLookupMPN() : base()
        {
        }
        #endregion Constructors
    }
}
