/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillChildListHydrometricSiteModelListLocal(List<HydrometricSiteModel> HydrometricSiteModelList, TVItem TVItem)
        {
            List<HydrometricSite> HydrometricSiteList = await GetHydrometricSiteListUnderProvince(TVItem);
            List<RatingCurve> RatingCurveList = await GetRatingCurveListUnderProvince(TVItem);
            List< RatingCurveValue> RatingCurveValueList = await GetRatingCurveValueListUnderProvince(TVItem);

            foreach (HydrometricSite hydrometricSite in HydrometricSiteList)
            {
                HydrometricSiteModel hydrometricSiteModel = new HydrometricSiteModel()
                {
                    HydrometricSite = hydrometricSite,
                    HydrometricDataValueList = await GetHydrometricDataValueListForHydrometricSite(hydrometricSite.HydrometricSiteTVItemID),
                    RatingCurveList = (from c in RatingCurveList
                                       where c.HydrometricSiteID == hydrometricSite.HydrometricSiteID
                                       select c).ToList(),
                    RatingCurveValueList = (from c in RatingCurveList
                                            from v in RatingCurveValueList
                                            where c.HydrometricSiteID == hydrometricSite.HydrometricSiteID
                                            && c.RatingCurveID == v.RatingCurveValueID
                                            select v).ToList(),
                };

                HydrometricSiteModelList.Add(hydrometricSiteModel);
            }
        }
    }
}