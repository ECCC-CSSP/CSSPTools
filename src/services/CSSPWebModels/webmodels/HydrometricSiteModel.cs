namespace CSSPWebModels;

[NotMapped]
public partial class HydrometricSiteModel
{
    public TVItemModel TVItemModel { get; set; }
    public HydrometricSite HydrometricSite { get; set; }
    public List<HydrometricDataValue> HydrometricDataValueList { get; set; }
    public List<RatingCurveModel> RatingCurveModelList { get; set; }

    public HydrometricSiteModel()
    {
        TVItemModel = new TVItemModel();
        HydrometricSite = new HydrometricSite();
        HydrometricDataValueList = new List<HydrometricDataValue>();
        RatingCurveModelList = new List<RatingCurveModel>();
    }
}

