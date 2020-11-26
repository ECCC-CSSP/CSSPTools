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
    public partial class WebSamplingPlan : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public SamplingPlanModel SamplingPlanModel { get; set; }
        #endregion Properties

        #region Constructors
        public WebSamplingPlan()
        {
            TVItemParentList = new List<WebBase>();
            SamplingPlanModel = new SamplingPlanModel();
        }
        #endregion Constructors
    }
}
