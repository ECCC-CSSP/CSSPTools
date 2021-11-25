namespace CSSPWebModels;

[NotMapped]
public partial class PolSourceSiteModel
{
    public TVItemModel TVItemModel { get; set; }
    public PolSourceSite PolSourceSite { get; set; }
    public List<TVFileModel> TVFileModelList { get; set; }
    public List<PolSourceObservationModel> PolSourceObservationModelList { get; set; }
    public List<PolSourceSiteEffect> PolSourceSiteEffectList { get; set; }

    public PolSourceSiteModel()
    {
        TVItemModel = new TVItemModel();
        PolSourceSite = new PolSourceSite();
        TVFileModelList = new List<TVFileModel>();
        PolSourceObservationModelList = new List<PolSourceObservationModel>();
        PolSourceSiteEffectList = new List<PolSourceSiteEffect>();
    }
}

