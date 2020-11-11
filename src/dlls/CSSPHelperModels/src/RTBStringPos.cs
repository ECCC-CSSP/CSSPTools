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
    public partial class RTBStringPos
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(0, -1)]
        public int StartPos { get; set; }
        [CSSPRange(0, -1)]
        public int EndPos { get; set; }
        public string Text { get; set; }
        public string TagText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public RTBStringPos() : base()
        {
        }
        #endregion Constructors
    }
}
