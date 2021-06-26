/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebHydrometricSites(WebHydrometricSites WebHydrometricSites, WebHydrometricSites WebHydrometricSitesLocal)
        {
            if (WebHydrometricSitesLocal.TVItemModel.TVItem.TVItemID != 0
                && (WebHydrometricSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebHydrometricSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebHydrometricSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
            {
                WebHydrometricSites.TVItemModel = WebHydrometricSitesLocal.TVItemModel;
            }

            if ((from c in WebHydrometricSitesLocal.TVItemModelParentList
                 where c.TVItem.TVItemID != 0
                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                 select c).Any())
            {
                WebHydrometricSites.TVItemModelParentList = WebHydrometricSitesLocal.TVItemModelParentList;
            }

            List<HydrometricSiteModel> HydrometricSiteModelList = (from c in WebHydrometricSitesLocal.HydrometricSiteModelList
                                                           where c.HydrometricSite.HydrometricSiteID != 0
                                                           && (c.HydrometricSite.DBCommand != DBCommandEnum.Original
                                                           || (from d in c.HydrometricDataValueList
                                                               where d.DBCommand != DBCommandEnum.Original
                                                               select d).Any())
                                                           select c).ToList();

            foreach (HydrometricSiteModel hydrometricSiteModel in HydrometricSiteModelList)
            {
                HydrometricSiteModel hydrometricSiteModelOriginal = WebHydrometricSites.HydrometricSiteModelList.Where(c => c.HydrometricSite.HydrometricSiteID == hydrometricSiteModel.HydrometricSite.HydrometricSiteID).FirstOrDefault();
                if (hydrometricSiteModelOriginal == null)
                {
                    WebHydrometricSites.HydrometricSiteModelList.Add(hydrometricSiteModelOriginal);
                }
                else
                {
                    hydrometricSiteModelOriginal = hydrometricSiteModel;
                }

                // will need to do rating curve
            }

        }
    }
}
