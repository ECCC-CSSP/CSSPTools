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

    [NotMapped]
    public partial class SamplingPlanModel
    {
        #region Properties
        public SamplingPlan SamplingPlan { get; set; }
        public List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelList { get; set; }
        public List<SamplingPlanEmail> SamplingPlanEmailList { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanModel()
        {
            SamplingPlanSubsectorModelList = new List<SamplingPlanSubsectorModel>();
            SamplingPlanEmailList = new List<SamplingPlanEmail>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class SamplingPlanSubsectorModel
    {
        #region Properties
        public SamplingPlanSubsector SamplingPlanSubsector { get; set; }
        public List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorModel()
        {
            SamplingPlanSubsector = new SamplingPlanSubsector();
            SamplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
        }
        #endregion Constructors
    }
}
