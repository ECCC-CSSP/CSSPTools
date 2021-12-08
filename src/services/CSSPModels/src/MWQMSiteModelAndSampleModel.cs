namespace CSSPModels;

[NotMapped]
public partial class MWQMSiteModelAndSampleModel
{
    public MWQMSiteModel MWQMSiteModel { get; set; }
    public MWQMSampleModel MWQMSampleModel { get; set; }

    public MWQMSiteModelAndSampleModel()
    {
        MWQMSiteModel = new MWQMSiteModel();
        MWQMSampleModel = new MWQMSampleModel();
    }
}

