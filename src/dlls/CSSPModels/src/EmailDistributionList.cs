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
    public partial class EmailDistributionList : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int EmailDistributionListID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "6")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int ParentTVItemID { get; set; }
        [CSSPRange(0, 1000)]
        public int Ordinal { get; set; }
        #endregion Properties in DB

        #region Constructors
        public EmailDistributionList() : base()
        {
        }
        #endregion Constructors
    }
}
