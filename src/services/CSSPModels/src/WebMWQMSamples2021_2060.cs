namespace CSSPModels;

[NotMapped]
public partial class WebMWQMSamples2021_2060
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<MWQMSampleModel> MWQMSampleModelList { get; set; }

    public WebMWQMSamples2021_2060()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        MWQMSampleModelList = new List<MWQMSampleModel>();
    }
}

