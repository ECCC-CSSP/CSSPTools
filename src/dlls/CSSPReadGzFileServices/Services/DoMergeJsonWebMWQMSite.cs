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
        private void DoMergeJsonWebMWQMSite(WebMWQMSite WebMWQMSite, WebMWQMSite WebMWQMSiteLocal)
        {
            // -----------------------------------------------------------
            // doing MWQMSiteModelList
            // -----------------------------------------------------------
            int count = WebMWQMSite.MWQMSiteModelList.Count;
            for (int i = 0; i < count; i++)
            {
                MWQMSiteModel MWQMSiteModelLocal = (from c in WebMWQMSiteLocal.MWQMSiteModelList
                                                              where c.TVItemModel.TVItem.TVItemID == WebMWQMSite.MWQMSiteModelList[i].TVItemModel.TVItem.TVItemID
                                                              && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                              || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                                              || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                                              select c).FirstOrDefault();

                if (MWQMSiteModelLocal != null)
                {
                    WebMWQMSite.MWQMSiteModelList[i] = MWQMSiteModelLocal;
                }
            }

            List<MWQMSiteModel> MWQMSiteModelLocalNewList = (from c in WebMWQMSiteLocal.MWQMSiteModelList
                                                                       where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                                       select c).ToList();

            foreach (MWQMSiteModel MWQMSiteModelNew in MWQMSiteModelLocalNewList)
            {
                WebMWQMSite.MWQMSiteModelList.Add(MWQMSiteModelNew);
            }

            return;
        }
    }
}
