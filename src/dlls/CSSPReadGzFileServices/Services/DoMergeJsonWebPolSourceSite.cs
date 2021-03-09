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
        private void DoMergeJsonWebPolSourceSite(WebPolSourceSite webPolSourceSite, WebPolSourceSite webPolSourceSiteLocal)
        {
            // -----------------------------------------------------------
            // doing PolSourceSiteModelList
            // -----------------------------------------------------------

            List<PolSourceSiteModel> polSourceSiteModelLocalNewList = (from c in webPolSourceSiteLocal.PolSourceSiteModelList
                                                             where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                             select c).ToList();

            foreach (PolSourceSiteModel polSourceSiteModel in polSourceSiteModelLocalNewList)
            {
                webPolSourceSite.PolSourceSiteModelList.Add(polSourceSiteModel);
            }

            int count = webPolSourceSite.PolSourceSiteModelList.Count;
            for (int i = 0; i < count; i++)
            {
                PolSourceSiteModel polSourceSiteModelLocal = (from c in webPolSourceSiteLocal.PolSourceSiteModelList
                                                    where c.TVItemModel.TVItem.TVItemID == webPolSourceSite.PolSourceSiteModelList[i].TVItemModel.TVItem.TVItemID
                                                    select c).FirstOrDefault();

                if (polSourceSiteModelLocal != null)
                {
                    if (polSourceSiteModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                        || polSourceSiteModelLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                        || polSourceSiteModelLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                    {
                        webPolSourceSite.PolSourceSiteModelList[i].TVItemModel = polSourceSiteModelLocal.TVItemModel;
                    }

                    // -----------------------------------------------------------
                    // doing TVItemFileList
                    // -----------------------------------------------------------
                    int count2 = webPolSourceSite.PolSourceSiteModelList[i].TVItemFileList.Count;
                    for (int j = 0; j < count2; j++)
                    {
                        WebBase webBaseLocal = (from c in polSourceSiteModelLocal.TVItemFileList
                                                where c.TVItemModel.TVItem.TVItemID == webPolSourceSite.PolSourceSiteModelList[i].TVItemFileList[j].TVItemModel.TVItem.TVItemID
                                                select c).FirstOrDefault();

                        if (webBaseLocal != null)
                        {
                            if (webBaseLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                || webBaseLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                || webBaseLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                            {
                                webPolSourceSite.PolSourceSiteModelList[i].TVItemFileList[j] = webBaseLocal;
                            }
                        }
                    }

                    List<WebBase> webBaseLocalNewList = (from c in polSourceSiteModelLocal.TVItemFileList
                                                         where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                         select c).ToList();

                    foreach (WebBase webBaseNew in webBaseLocalNewList)
                    {
                        webPolSourceSite.PolSourceSiteModelList[i].TVItemFileList.Add(webBaseNew);
                    }

                    //webPolSourceSite.PolSourceSiteModelList[i] = polSourceSiteModelLocal;
                }
            }

            return;
        }
    }
}
