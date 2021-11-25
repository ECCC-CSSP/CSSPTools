namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncRatingCurveModel(RatingCurveModel ratingCurveModelOriginal, RatingCurveModel ratingCurveModelLocal)
    {
        if (ratingCurveModelLocal != null)
        {
            if (ratingCurveModelLocal.RatingCurve != null)
            {
                ratingCurveModelOriginal.RatingCurve = ratingCurveModelLocal.RatingCurve;
            }
            foreach (RatingCurveValue ratingCurveValueLocal in ratingCurveModelLocal.RatingCurveValueList)
            {
                RatingCurveValue ratingCurveValueOriginal = ratingCurveModelOriginal.RatingCurveValueList.Where(c => c.RatingCurveValueID == ratingCurveValueLocal.RatingCurveValueID).FirstOrDefault();
                if (ratingCurveValueOriginal == null)
                {
                    ratingCurveModelOriginal.RatingCurveValueList.Add(ratingCurveValueLocal);
                }
                else
                {
                    ratingCurveValueOriginal = ratingCurveValueLocal;
                }
            }
        }
    }
}

