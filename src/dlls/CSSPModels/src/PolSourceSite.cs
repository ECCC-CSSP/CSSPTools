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
    public partial class PolSourceSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int PolSourceSiteID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "17")]
        public int PolSourceSiteTVItemID { get; set; }
        [CSSPMaxLength(50)]
        [CSSPAllowNull]
        public string Temp_Locator_CanDelete { get; set; }
        [CSSPRange(0, 1000)]
        public int? Oldsiteid { get; set; }
        [CSSPRange(0, 1000)]
        public int? Site { get; set; }
        [CSSPRange(0, 1000)]
        public int? SiteID { get; set; }
        public bool IsPointSource { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public PolSourceInactiveReasonEnum? InactiveReason { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "2")]
        public int? CivicAddressTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceSite() : base()
        {
        }
        #endregion Constructors
    }
}
