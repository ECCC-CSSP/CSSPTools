namespace CSSPWebModels;

[NotMapped]
public partial class WebSector
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVItemModel> TVItemModelSubsectorList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }

    public WebSector()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVItemModelSubsectorList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
    }
}

