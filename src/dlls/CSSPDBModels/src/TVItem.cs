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

namespace CSSPDBModels
{
    public partial class TVItem : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int TVItemID { get; set; }
        [CSSPRange(0, 100)]
        public int TVLevel { get; set; }
        [CSSPMaxLength(250)]
        public string TVPath { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        [CSSPAllowNull]
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,31,75,79")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int? ParentID { get; set; }
        public bool IsActive { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVItem() : base()
        {
        }
        #endregion Constructors
    }
}
