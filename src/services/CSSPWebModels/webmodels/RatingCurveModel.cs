/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class RatingCurveModel
    {
        #region Properties
        public RatingCurve RatingCurve { get; set; }
        public List<RatingCurveValue> RatingCurveValueList { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveModel()
        {
            RatingCurve = new RatingCurve();
            RatingCurveValueList = new List<RatingCurveValue>();
        }
        #endregion Constructors
    }
}
