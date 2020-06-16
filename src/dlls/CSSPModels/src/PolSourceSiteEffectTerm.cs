﻿/*
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
    public partial class PolSourceSiteEffectTerm : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int PolSourceSiteEffectTermID { get; set; }
        public bool IsGroup { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceSiteEffectTerm", ExistPlurial = "s", ExistFieldID = "PolSourceSiteEffectTermID")]
        public int? UnderGroupID { get; set; }
        [CSSPMaxLength(100)]
        public string EffectTermEN { get; set; }
        [CSSPMaxLength(100)]
        public string EffectTermFR { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceSiteEffectTerm() : base()
        {
        }
        #endregion Constructors
    }
}
