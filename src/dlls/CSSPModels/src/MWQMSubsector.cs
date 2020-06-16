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
    public partial class MWQMSubsector : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MWQMSubsectorID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        public int MWQMSubsectorTVItemID { get; set; }
        [CSSPMaxLength(20)]
        public string SubsectorHistoricKey { get; set; }
        [CSSPMaxLength(20)]
        [CSSPAllowNull]
        public string TideLocationSIDText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMSubsector() : base()
        {
        }
        #endregion Constructors
    }
}
