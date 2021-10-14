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
    public partial class SamplingPlanModel
    {
        #region Properties
        public SamplingPlan SamplingPlan { get; set; }
        public List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelList { get; set; }
        public List<SamplingPlanEmail> SamplingPlanEmailList { get; set; }
        public IEnumerable<object> ClimateDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanModel()
        {
            SamplingPlanSubsectorModelList = new List<SamplingPlanSubsectorModel>();
            SamplingPlanEmailList = new List<SamplingPlanEmail>();
        }
        #endregion Constructors
    }
}
