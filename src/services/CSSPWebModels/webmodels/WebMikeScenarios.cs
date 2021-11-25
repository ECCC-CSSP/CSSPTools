namespace CSSPWebModels;

[NotMapped]
public partial class WebMikeScenarios
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<MikeScenarioModel> MikeScenarioModelList { get; set; }

    public WebMikeScenarios()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        MikeScenarioModelList = new List<MikeScenarioModel>();
    }
}

