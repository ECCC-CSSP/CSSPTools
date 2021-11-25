namespace CSSPWebModels;

[NotMapped]
public partial class WebClimateSites
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<ClimateSiteModel> ClimateSiteModelList { get; set; }

    public WebClimateSites()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        ClimateSiteModelList = new List<ClimateSiteModel>();
    }
}

