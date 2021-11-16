/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPDBModels
{
    public partial class MapInfoPoint : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MapInfoPointID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "MapInfo", ExistPlurial = "s", ExistFieldID = "MapInfoID")]
        [CSSPForeignKey(TableName = "MapInfos", FieldName = "MapInfoID")]
        public int MapInfoID { get; set; }
        [CSSPRange(0, -1)]
        public int Ordinal { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double Lat { get; set; }
        [CSSPRange(-180.0D, 180.0D)]
        public double Lng { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MapInfoPoint() : base()
        {
        }
        #endregion Constructors
    }
}
