namespace CSSPWebModels;

[NotMapped]
public partial class WebMunicipality
{
    public TVItemModel TVItemModel { get; set; }
    public List<TVItemModel> TVItemModelParentList { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<ContactModel> MunicipalityContactModelList { get; set; }
    public List<TVItemLink> MunicipalityTVItemLinkList { get; set; }
    public List<InfrastructureModel> InfrastructureModelList { get; set; }

    public WebMunicipality()
    {
        TVItemModel = new TVItemModel();
        TVItemModelParentList = new List<TVItemModel>();
        TVFileModelList = new List<TVFileModel>();
        MunicipalityContactModelList = new List<ContactModel>();
        MunicipalityTVItemLinkList = new List<TVItemLink>();
        InfrastructureModelList = new List<InfrastructureModel>();
    }
}

