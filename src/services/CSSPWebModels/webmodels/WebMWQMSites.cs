namespace CSSPWebModels;

[NotMapped]
public partial class WebMWQMSites
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<MWQMSiteModel> MWQMSiteModelList { get; set; }

    public WebMWQMSites()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        MWQMSiteModelList = new List<MWQMSiteModel>();
    }
}

