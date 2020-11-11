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
    public partial class DrogueRun : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int DrogueRunID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int SubsectorTVItemID { get; set; }
        [CSSPRange(0, 100)]
        public int DrogueNumber { get; set; }
        [CSSPEnumType]
        public DrogueTypeEnum DrogueType { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime RunStartDateTime { get; set; }
        public bool IsRisingTide { get; set; }
        #endregion Properties in DB

        #region Constructors
        public DrogueRun() : base()
        {
        }
        #endregion Constructors
    }
}
