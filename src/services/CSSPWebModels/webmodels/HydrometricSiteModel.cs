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
    public partial class HydrometricSiteModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public HydrometricSite HydrometricSite { get; set; }
        public List<HydrometricDataValue> HydrometricDataValueList { get; set; }
        public List<RatingCurveModel> RatingCurveModelList { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteModel()
        {
            TVItemModel = new TVItemModel();
            HydrometricSite = new HydrometricSite();
            HydrometricDataValueList = new List<HydrometricDataValue>();
            RatingCurveModelList = new List<RatingCurveModel>();
        }
        #endregion Constructors
    }
}
