namespace CSSPWebModels;

[NotMapped]
public partial class WebHydrometricSites
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<HydrometricSiteModel> HydrometricSiteModelList { get; set; }

    public WebHydrometricSites()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        HydrometricSiteModelList = new List<HydrometricSiteModel>();
    }
}

