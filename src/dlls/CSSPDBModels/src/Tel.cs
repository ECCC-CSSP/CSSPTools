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
    public partial class Tel : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int TelID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "21")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int TelTVItemID { get; set; }
        [CSSPMaxLength(50)]
        public string TelNumber { get; set; }
        [CSSPEnumType]
        public TelTypeEnum TelType { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Tel() : base()
        {
        }
        #endregion Constructors
    }
}
