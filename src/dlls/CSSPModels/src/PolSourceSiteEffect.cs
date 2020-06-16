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
    public partial class PolSourceSiteEffect : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int PolSourceSiteEffectID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10,17")]
        public int PolSourceSiteOrInfrastructureTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        public int MWQMSiteTVItemID { get; set; }
        [CSSPMaxLength(250)]
        [CSSPAllowNull]
        public string PolSourceSiteEffectTermIDs { get; set; }
        [CSSPAllowNull]
        public string Comments { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
        public int? AnalysisDocumentTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceSiteEffect() : base()
        {
        }
        #endregion Constructors
    }
}
