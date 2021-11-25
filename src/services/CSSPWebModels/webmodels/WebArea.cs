namespace CSSPWebModels;

[NotMapped]
public partial class WebArea
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVItemModel> TVItemModelSectorList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }

    public WebArea()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVItemModelSectorList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
    }
}

