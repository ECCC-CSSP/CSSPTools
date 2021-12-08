namespace CSSPModels;

[NotMapped]
public partial class MWQMRunModelSiteAndSampleModel
{
    public MWQMRunModel MWQMRunModel { get; set; }
    public List<MWQMSiteModelAndSampleModel> MWQMSiteModelAndSampleModelList { get; set; }

    public MWQMRunModelSiteAndSampleModel()
    {
        MWQMRunModel = new MWQMRunModel();
        MWQMSiteModelAndSampleModelList = new List<MWQMSiteModelAndSampleModel>();
    }
}

