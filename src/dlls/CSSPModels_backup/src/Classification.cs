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
    public partial class Classification : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int ClassificationID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "79")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int ClassificationTVItemID { get; set; }
        [CSSPEnumType]
        public ClassificationTypeEnum ClassificationType { get; set; }
        [CSSPRange(0, 10000)]
        public int Ordinal { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Classification() : base()
        {
        }
        #endregion Constructors
    }
}
