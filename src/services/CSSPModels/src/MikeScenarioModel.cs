namespace CSSPModels;

[NotMapped]
public partial class MikeScenarioModel
{
    public MikeScenario MikeScenario { get; set; }
    public TVItemModel TVItemModel { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<MikeBoundaryConditionModel> MikeBoundaryConditionModelList { get; set; }
    public List<MikeSourceModel> MikeSourceModelList { get; set; }

    public MikeScenarioModel()
    {
        MikeScenario = new MikeScenario();
        TVItemModel = new TVItemModel();
        TVFileModelList = new List<TVFileModel>();
        MikeBoundaryConditionModelList = new List<MikeBoundaryConditionModel>();
        MikeSourceModelList = new List<MikeSourceModel>();
    }
}

