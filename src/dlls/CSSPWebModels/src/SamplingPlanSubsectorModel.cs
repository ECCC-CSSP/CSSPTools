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
