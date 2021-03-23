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
    public partial class SamplingPlanSubsector : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int SamplingPlanSubsectorID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
        [CSSPForeignKey(TableName = "SamplingPlans", FieldName = "SamplingPlanID")]
        public int SamplingPlanID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int SubsectorTVItemID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SamplingPlanSubsector() : base()
        {
        }
        #endregion Constructors
    }
}
