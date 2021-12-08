namespace CSSPModels;

[NotMapped]
public partial class WebTideSites
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TideSiteModel> TideSiteModelList { get; set; }

    public WebTideSites()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TideSiteModelList = new List<TideSiteModel>();
    }
}

