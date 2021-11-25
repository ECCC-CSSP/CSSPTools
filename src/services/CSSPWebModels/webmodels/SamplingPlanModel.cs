namespace CSSPWebModels;

[NotMapped]
public partial class SamplingPlanModel
{
    public SamplingPlan SamplingPlan { get; set; }
    public List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelList { get; set; }
    public List<SamplingPlanEmail> SamplingPlanEmailList { get; set; }

    public SamplingPlanModel()
    {
        SamplingPlanSubsectorModelList = new List<SamplingPlanSubsectorModel>();
        SamplingPlanEmailList = new List<SamplingPlanEmail>();
    }
}

