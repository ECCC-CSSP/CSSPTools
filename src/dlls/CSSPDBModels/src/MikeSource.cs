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
    public partial class MikeSource : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MikeSourceID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "14")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int MikeSourceTVItemID { get; set; }
        public bool IsContinuous { get; set; }
        public bool Include { get; set; }
        public bool IsRiver { get; set; }
        public bool UseHydrometric { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "9")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int? HydrometricTVItemID { get; set; }
        [CSSPRange(0.0D, 1000000.0D)]
        public double? DrainageArea_km2 { get; set; }
        [CSSPRange(0.0D, 1000000.0D)]
        public double? Factor { get; set; }
        [CSSPMaxLength(50)]
        public string SourceNumberString { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeSource() : base()
        {
        }
        #endregion Constructors
    }
}
