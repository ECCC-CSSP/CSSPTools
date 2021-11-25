namespace CSSPWebModels;

[NotMapped]
public partial class WebPolSourceSites
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<PolSourceSiteModel> PolSourceSiteModelList { get; set; }

    public WebPolSourceSites()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        PolSourceSiteModelList = new List<PolSourceSiteModel>();
    }
}

