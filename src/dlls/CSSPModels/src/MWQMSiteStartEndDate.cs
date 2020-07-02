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
    public partial class MWQMSiteStartEndDate : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MWQMSiteStartEndDateID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "16")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int MWQMSiteTVItemID { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime StartDate { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDate")]
        public DateTime? EndDate { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMSiteStartEndDate() : base()
        {
        }
        #endregion Constructors
    }
}
