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
    public partial class RainExceedanceClimateSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int RainExceedanceClimateSiteID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "75")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int RainExceedanceTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "4")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int ClimateSiteTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public RainExceedanceClimateSite() : base()
        {
        }
        #endregion Constructors
    }
}
