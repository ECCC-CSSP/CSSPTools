/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class MapObj
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int MapInfoID { get; set; }
        [CSSPEnumType]
        public MapInfoDrawTypeEnum MapInfoDrawType { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "MapInfoDrawTypeEnum", EnumType = "MapInfoDrawType")]
        [CSSPAllowNull]
        public string MapInfoDrawTypeText { get; set; }
        public List<Coord> CoordList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public MapObj() : base()
        {
            CoordList = new List<Coord>();
        }
        #endregion Constructors
    }
}
