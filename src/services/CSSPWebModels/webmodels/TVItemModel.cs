namespace CSSPWebModels;

[NotMapped]
public partial class TVItemModel
{
    public TVItem TVItem { get; set; }
    public List<TVItemLanguage> TVItemLanguageList { get; set; }
    public List<TVItemStat> TVItemStatList { get; set; }
    public List<MapInfoModel> MapInfoModelList { get; set; }

    public TVItemModel()
    {
        TVItem = new TVItem();
        TVItemLanguageList = new List<TVItemLanguage>();
        TVItemStatList = new List<TVItemStat>();
        MapInfoModelList = new List<MapInfoModel>();
    }
}

