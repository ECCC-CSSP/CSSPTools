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
        private static void DoMergeJsonWebSubsector(WebSubsector webSubsector, WebSubsector webSubsectorLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemMWQMSiteList
            // -----------------------------------------------------------
            int count = webSubsector.TVItemMWQMSiteList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSubsectorLocal.TVItemMWQMSiteList
                                        where c.TVItemModel.TVItem.TVItemID == webSubsector.TVItemMWQMSiteList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSubsector.TVItemMWQMSiteList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in webSubsectorLocal.TVItemMWQMSiteList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(WebBase webBaseNew in webBaseLocalNewList)
            {
                webSubsector.TVItemMWQMSiteList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMWQMRunList
            // -----------------------------------------------------------
            count = webSubsector.TVItemMWQMRunList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSubsectorLocal.TVItemMWQMRunList
                                        where c.TVItemModel.TVItem.TVItemID == webSubsector.TVItemMWQMRunList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSubsector.TVItemMWQMRunList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webSubsectorLocal.TVItemMWQMRunList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webSubsector.TVItemMWQMRunList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemPolSourceSiteList
            // -----------------------------------------------------------
            count = webSubsector.TVItemPolSourceSiteList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSubsectorLocal.TVItemPolSourceSiteList
                                        where c.TVItemModel.TVItem.TVItemID == webSubsector.TVItemPolSourceSiteList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSubsector.TVItemPolSourceSiteList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webSubsectorLocal.TVItemPolSourceSiteList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webSubsector.TVItemPolSourceSiteList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemClassificationList
            // -----------------------------------------------------------
            count = webSubsector.TVItemClassificationList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSubsectorLocal.TVItemClassificationList
                                        where c.TVItemModel.TVItem.TVItemID == webSubsector.TVItemClassificationList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSubsector.TVItemClassificationList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webSubsectorLocal.TVItemClassificationList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webSubsector.TVItemClassificationList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemFileList
            // -----------------------------------------------------------
            count = webSubsector.TVItemFileList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSubsectorLocal.TVItemFileList
                                        where c.TVItemModel.TVItem.TVItemID == webSubsector.TVItemFileList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSubsector.TVItemFileList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webSubsectorLocal.TVItemFileList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webSubsector.TVItemFileList.Add(webBaseNew);
            }

            return;
        }
    }
}
