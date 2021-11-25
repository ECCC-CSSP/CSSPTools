namespace CSSPWebModels;

[NotMapped]
public partial class WebRoot
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVItemModel> TVItemModelCountryList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }

    public WebRoot() : base()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVItemModelCountryList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
    }
}

