namespace CSSPModels;

[NotMapped]
public partial class WebMWQMRuns
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<MWQMRunModel> MWQMRunModelList { get; set; }

    public WebMWQMRuns()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        MWQMRunModelList = new List<MWQMRunModel>();
    }
}

