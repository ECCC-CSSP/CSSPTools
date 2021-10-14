/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
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
}
