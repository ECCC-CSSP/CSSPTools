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
        private void SyncHydrometricSiteModel(HydrometricSiteModel hydrometricSiteModelOriginal, HydrometricSiteModel hydrometricSiteModelLocal)
        {
            if (hydrometricSiteModelLocal != null)
            {
                if (hydrometricSiteModelLocal.TVItemModel != null)
                {
                    SyncTVItemModel(hydrometricSiteModelOriginal.TVItemModel, hydrometricSiteModelLocal.TVItemModel);
                }
                if (hydrometricSiteModelLocal.HydrometricSite != null)
                {
                    hydrometricSiteModelOriginal.HydrometricSite = hydrometricSiteModelLocal.HydrometricSite;
                }
                foreach (HydrometricDataValue hydrometricDataValueLocal in hydrometricSiteModelLocal.HydrometricDataValueList)
                {
                    HydrometricDataValue hydrometricDataValueOriginal = hydrometricSiteModelOriginal.HydrometricDataValueList.Where(c => c.HydrometricDataValueID == hydrometricDataValueLocal.HydrometricDataValueID).FirstOrDefault();
                    if (hydrometricDataValueOriginal == null)
                    {
                        hydrometricSiteModelOriginal.HydrometricDataValueList.Add(hydrometricDataValueLocal);
                    }
                    else
                    {
                        hydrometricDataValueOriginal = hydrometricDataValueLocal;
                    }
                }
                foreach (RatingCurveModel ratingCurveModelLocal in hydrometricSiteModelLocal.RatingCurveModelList)
                {
                    RatingCurveModel ratingCurveModelOriginal = hydrometricSiteModelOriginal.RatingCurveModelList.Where(c => c.RatingCurve.RatingCurveID == ratingCurveModelLocal.RatingCurve.RatingCurveID).FirstOrDefault();
                    if (ratingCurveModelOriginal == null)
                    {
                        hydrometricSiteModelOriginal.RatingCurveModelList.Add(ratingCurveModelLocal);
                    }
                    else
                    {
                        SyncRatingCurveModel(ratingCurveModelOriginal, ratingCurveModelLocal);
                    }
                }
            }
        }
    }
}
