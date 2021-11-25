namespace CSSPWebModels;

[NotMapped]
public partial class SamplingPlanSubsectorModel
{
    public SamplingPlanSubsector SamplingPlanSubsector { get; set; }
    public List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList { get; set; }

    public SamplingPlanSubsectorModel()
    {
        SamplingPlanSubsector = new SamplingPlanSubsector();
        SamplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
    }
}

