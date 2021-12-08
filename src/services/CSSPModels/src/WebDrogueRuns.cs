namespace CSSPModels;

[NotMapped]
public partial class WebDrogueRuns
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<DrogueRunModel> DrogueRunModelList { get; set; }

    public WebDrogueRuns()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        DrogueRunModelList = new List<DrogueRunModel>();
    }
}

