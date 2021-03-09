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
        private void DoMergeJsonWebMWQMSite(WebMWQMSite webMWQMSite, WebMWQMSite webMWQMSiteLocal)
        {
            // -----------------------------------------------------------
            // doing MWQMSiteModelList
            // -----------------------------------------------------------

            List<MWQMSiteModel> mwqmSiteModelLocalNewList = (from c in webMWQMSiteLocal.MWQMSiteModelList
                                                             where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                             select c).ToList();

            foreach (MWQMSiteModel mwqmSiteModel in mwqmSiteModelLocalNewList)
            {
                webMWQMSite.MWQMSiteModelList.Add(mwqmSiteModel);
            }

            int count = webMWQMSite.MWQMSiteModelList.Count;
            for (int i = 0; i < count; i++)
            {
                MWQMSiteModel mwqmSiteModelLocal = (from c in webMWQMSiteLocal.MWQMSiteModelList
                                                    where c.TVItemModel.TVItem.TVItemID == webMWQMSite.MWQMSiteModelList[i].TVItemModel.TVItem.TVItemID
                                                    select c).FirstOrDefault();

                if (mwqmSiteModelLocal != null)
                {
                    if (mwqmSiteModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                        || mwqmSiteModelLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                        || mwqmSiteModelLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                    {
                        webMWQMSite.MWQMSiteModelList[i].TVItemModel = mwqmSiteModelLocal.TVItemModel;
                    }

                    // -----------------------------------------------------------
                    // doing TVItemFileList
                    // -----------------------------------------------------------
                    int count2 = webMWQMSite.MWQMSiteModelList[i].TVItemFileList.Count;
                    for (int j = 0; j < count2; j++)
                    {
                        WebBase webBaseLocal = (from c in mwqmSiteModelLocal.TVItemFileList
                                                where c.TVItemModel.TVItem.TVItemID == webMWQMSite.MWQMSiteModelList[i].TVItemFileList[j].TVItemModel.TVItem.TVItemID
                                                select c).FirstOrDefault();

                        if (webBaseLocal != null)
                        {
                            if (webBaseLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                || webBaseLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                || webBaseLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                            {
                                webMWQMSite.MWQMSiteModelList[i].TVItemFileList[j] = webBaseLocal;
                            }
                        }
                    }

                    List<WebBase> webBaseLocalNewList = (from c in mwqmSiteModelLocal.TVItemFileList
                                                         where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                         select c).ToList();

                    foreach (WebBase webBaseNew in webBaseLocalNewList)
                    {
                        webMWQMSite.MWQMSiteModelList[i].TVItemFileList.Add(webBaseNew);
                    }

                    //webMWQMSite.MWQMSiteModelList[i] = mwqmSiteModelLocal;
                }
            }

            return;
        }
    }
}
