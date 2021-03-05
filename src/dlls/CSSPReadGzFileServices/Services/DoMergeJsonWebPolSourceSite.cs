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
        private void DoMergeJsonWebPolSourceSite(WebPolSourceSite WebPolSourceSite, WebPolSourceSite WebPolSourceSiteLocal)
        {
            // -----------------------------------------------------------
            // doing PolSourceSiteModelList
            // -----------------------------------------------------------
            int count = WebPolSourceSite.PolSourceSiteModelList.Count;
            for (int i = 0; i < count; i++)
            {
                PolSourceSiteModel PolSourceSiteModelLocal = (from c in WebPolSourceSiteLocal.PolSourceSiteModelList
                                                              where c.TVItemModel.TVItem.TVItemID == WebPolSourceSite.PolSourceSiteModelList[i].TVItemModel.TVItem.TVItemID
                                                              && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                              || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                                              || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                                              select c).FirstOrDefault();

                if (PolSourceSiteModelLocal != null)
                {
                    WebPolSourceSite.PolSourceSiteModelList[i] = PolSourceSiteModelLocal;
                }
            }

            List<PolSourceSiteModel> PolSourceSiteModelLocalNewList = (from c in WebPolSourceSiteLocal.PolSourceSiteModelList
                                                                       where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                                       select c).ToList();

            foreach (PolSourceSiteModel PolSourceSiteModelNew in PolSourceSiteModelLocalNewList)
            {
                WebPolSourceSite.PolSourceSiteModelList.Add(PolSourceSiteModelNew);
            }

            return;
        }
    }
}
