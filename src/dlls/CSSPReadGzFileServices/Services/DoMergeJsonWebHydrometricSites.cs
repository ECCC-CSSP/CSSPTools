/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebHydrometricSites(WebHydrometricSites WebHydrometricSites, WebHydrometricSites WebHydrometricSitesLocal)
        {
            if (WebHydrometricSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebHydrometricSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebHydrometricSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebHydrometricSites.TVItemModel = WebHydrometricSitesLocal.TVItemModel;
            }

            if ((from c in WebHydrometricSitesLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebHydrometricSites.TVItemModelParentList = WebHydrometricSitesLocal.TVItemModelParentList;
            }

            List<HydrometricSiteModel> HydrometricSiteModelList = (from c in WebHydrometricSitesLocal.HydrometricSiteModelList
                                                           where c.HydrometricSite.DBCommand != DBCommandEnum.Original
                                                           || (from d in c.HydrometricDataValueList
                                                               where d.DBCommand != DBCommandEnum.Original
                                                               select d).Any()
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
