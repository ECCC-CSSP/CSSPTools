namespace CSSPModels;

[NotMapped]
public partial class WebCountry
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVItemModel> TVItemModelProvinceList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<RainExceedanceModel> RainExceedanceModelList { get; set; }
    public List<EmailDistributionListModel> EmailDistributionListModelList { get; set; }

    public WebCountry()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVItemModelProvinceList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
        RainExceedanceModelList = new List<RainExceedanceModel>();
        EmailDistributionListModelList = new List<EmailDistributionListModel>();
    }
}

