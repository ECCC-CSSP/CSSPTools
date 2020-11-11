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
    public partial class RatingCurveValue : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int RatingCurveValueID { get; set; }
        [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID")]
        [CSSPForeignKey(TableName = "RatingCurves", FieldName = "RatingCurveID")]
        public int RatingCurveID { get; set; }
        [CSSPRange(0.0D, 1000.0D)]
        public double StageValue_m { get; set; }
        [CSSPRange(0.0D, 1000000.0D)]
        public double DischargeValue_m3_s { get; set; }
        #endregion Properties in DB

        #region Constructors
        public RatingCurveValue() : base()
        {
        }
        #endregion Constructors
    }
}
