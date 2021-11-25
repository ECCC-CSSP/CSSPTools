namespace CSSPWebModels;

[NotMapped]
public partial class WebProvince
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVItemModel> TVItemModelAreaList { get; set; }
    public List<TVItemModel> TVItemModelMunicipalityList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<SamplingPlanModel> SamplingPlanModelList { get; set; }
    public List<int> MunicipalityWithInfrastructureTVItemIDList { get; set; }

    public WebProvince()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVItemModelAreaList = new List<TVItemModel>();
        TVItemModelMunicipalityList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
        SamplingPlanModelList = new List<SamplingPlanModel>();
        MunicipalityWithInfrastructureTVItemIDList = new List<int>();
    }
}

