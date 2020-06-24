/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
{
    public partial class WebSamplingPlan
    {
        #region Properties
        public SamplingPlan SamplingPlan { get; set; }
        public List<SamplingPlanSubsector> SamplingPlanSubsectorList { get; set; }
        public List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList { get; set; }
        public List<SamplingPlanEmail> SamplingPlanEmailList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSamplingPlan()
        {
            SamplingPlan = new SamplingPlan();
            SamplingPlanSubsectorList = new List<SamplingPlanSubsector>();
            SamplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
            SamplingPlanEmailList = new List<SamplingPlanEmail>();
        }
        #endregion Constructors
    }
}
