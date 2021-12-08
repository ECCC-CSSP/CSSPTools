namespace CSSPModels;

[NotMapped]
public partial class MWQMSiteModel
{
    public TVItemModel TVItemModel { get; set; }
    public MWQMSite MWQMSite { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList { get; set; }

    public MWQMSiteModel()
    {
        TVItemModel = new TVItemModel();
        MWQMSite = new MWQMSite();
        TVFileModelList = new List<TVFileModel>();
        MWQMSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
    }
}

