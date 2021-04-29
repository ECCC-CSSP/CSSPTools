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
        private void DoMergeJsonWebTideSites(WebTideSites WebTideSites, WebTideSites WebTideSitesLocal)
        {
            if (WebTideSitesLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebTideSitesLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebTideSitesLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebTideSites.TVItemStatMapModel = WebTideSitesLocal.TVItemStatMapModel;
            }

            if ((from c in WebTideSitesLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebTideSites.TVItemStatModelParentList = WebTideSitesLocal.TVItemStatModelParentList;
            }

            List<TideSiteModel> TideSiteModelList = (from c in WebTideSitesLocal.TideSiteModelList
                                                           where c.TideSite.DBCommand != DBCommandEnum.Original
                                                           || (from d in c.TideDataValueList
                                                               where d.DBCommand != DBCommandEnum.Original
                                                               select d).Any()
                                                           select c).ToList();

            foreach (TideSiteModel tideSiteModel in TideSiteModelList)
            {
                TideSiteModel tideSiteModelOriginal = WebTideSites.TideSiteModelList.Where(c => c.TideSite.TideSiteID == tideSiteModel.TideSite.TideSiteID).FirstOrDefault();
                if (tideSiteModelOriginal == null)
                {
                    WebTideSites.TideSiteModelList.Add(tideSiteModelOriginal);
                }
                else
                {
                    tideSiteModelOriginal = tideSiteModel;
                }
            }
        }
    }
}
