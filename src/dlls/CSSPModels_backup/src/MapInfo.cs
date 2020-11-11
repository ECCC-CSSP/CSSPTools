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
    public partial class MapInfo : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MapInfoID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,6,8,9,11,12,14,15,16,17,18,19,20,22,24,25,26,29,30,41,42,75,79,80,81,82,83,84")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int TVItemID { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double LatMin { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double LatMax { get; set; }
        [CSSPRange(-180.0D, 180.0D)]
        public double LngMin { get; set; }
        [CSSPRange(-180.0D, 180.0D)]
        public double LngMax { get; set; }
        [CSSPEnumType]
        public MapInfoDrawTypeEnum MapInfoDrawType { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MapInfo() : base()
        {
        }
        #endregion Constructors
    }
}
