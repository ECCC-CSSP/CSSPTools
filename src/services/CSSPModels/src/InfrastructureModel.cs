namespace CSSPModels;

[NotMapped]
public partial class InfrastructureModel
{
    public TVItemModel TVItemModel { get; set; }
    public Infrastructure Infrastructure { get; set; }
    public List<InfrastructureLanguage> InfrastructureLanguageList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<BoxModelModel> BoxModelModelList { get; set; }
    public List<VPScenarioModel> VPScenarioModelList { get; set; }

    public InfrastructureModel()
    {
        TVItemModel = new TVItemModel();
        Infrastructure = new Infrastructure();
        InfrastructureLanguageList = new List<InfrastructureLanguage>();
        TVFileModelList = new List<TVFileModel>();
        BoxModelModelList = new List<BoxModelModel>();
        VPScenarioModelList = new List<VPScenarioModel>();
    }
}

