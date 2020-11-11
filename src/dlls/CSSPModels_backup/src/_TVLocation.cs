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
    [NotMapped]
    public partial class TVLocation
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int TVItemID { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string TVText { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        [CSSPEnumType]
        public TVTypeEnum SubTVType { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "TVTypeEnum", EnumType = "TVType")]
        [CSSPAllowNull]
        public string TVTypeText { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "TVTypeEnum", EnumType = "SubTVType")]
        [CSSPAllowNull]
        public string SubTVTypeText { get; set; }
        public List<MapObj> MapObjList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVLocation() : base()
        {
            MapObjList = new List<MapObj>();
        }
        #endregion Constructors
    }
}
