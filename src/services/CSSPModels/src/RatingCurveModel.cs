namespace CSSPModels;

[NotMapped]
public partial class RatingCurveModel
{
    public RatingCurve RatingCurve { get; set; }
    public List<RatingCurveValue> RatingCurveValueList { get; set; }

    public RatingCurveModel()
    {
        RatingCurve = new RatingCurve();
        RatingCurveValueList = new List<RatingCurveValue>();
    }
}

