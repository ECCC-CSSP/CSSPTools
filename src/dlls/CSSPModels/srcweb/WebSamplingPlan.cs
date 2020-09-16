﻿/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebSamplingPlan
    {
        #region Properties
        public SamplingPlanModel SamplingPlanModel { get; set; }
        #endregion Properties

        #region Constructors
        public WebSamplingPlan()
        {
            SamplingPlanModel = new SamplingPlanModel();
        }
        #endregion Constructors
    }

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
