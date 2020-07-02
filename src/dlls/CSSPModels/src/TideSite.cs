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
    public partial class TideSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int TideSiteID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "22")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int TideSiteTVItemID { get; set; }
        [CSSPMaxLength(100)]
        public string TideSiteName { get; set; }
        [CSSPMaxLength(2)]
        [CSSPMinLength(2)]
        public string Province { get; set; }
        [CSSPRange(0, 10000)]
        public int sid { get; set; }
        [CSSPRange(0, 10000)]
        public int Zone { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TideSite() : base()
        {
        }
        #endregion Constructors
    }
}
