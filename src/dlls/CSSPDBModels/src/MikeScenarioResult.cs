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
    public partial class MikeScenarioResult : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MikeScenarioResultID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "13")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int MikeScenarioTVItemID { get; set; }
        [CSSPAllowNull]
        public string MikeResultsJSON { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeScenarioResult() : base()
        {
        }
        #endregion Constructors
    }
}
