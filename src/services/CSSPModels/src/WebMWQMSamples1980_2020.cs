namespace CSSPModels;

[NotMapped]
public partial class WebMWQMSamples1980_2020
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<MWQMSampleModel> MWQMSampleModelList { get; set; }

    public WebMWQMSamples1980_2020()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        MWQMSampleModelList = new List<MWQMSampleModel>();
    }
}

