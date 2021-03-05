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
        private void DoMergeJsonWebSubsector(WebSubsector WebSubsector, WebSubsector WebSubsectorLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemMWQMSiteList
            // -----------------------------------------------------------
            int count = WebSubsector.TVItemMWQMSiteList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebSubsectorLocal.TVItemMWQMSiteList
                                        where c.TVItemModel.TVItem.TVItemID == WebSubsector.TVItemMWQMSiteList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebSubsector.TVItemMWQMSiteList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in WebSubsectorLocal.TVItemMWQMSiteList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(WebBase webBaseNew in webBaseLocalNewList)
            {
                WebSubsector.TVItemMWQMSiteList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMWQMRunList
            // -----------------------------------------------------------
            count = WebSubsector.TVItemMWQMRunList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebSubsectorLocal.TVItemMWQMRunList
                                        where c.TVItemModel.TVItem.TVItemID == WebSubsector.TVItemMWQMRunList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebSubsector.TVItemMWQMRunList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in WebSubsectorLocal.TVItemMWQMRunList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebSubsector.TVItemMWQMRunList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemPolSourceSiteList
            // -----------------------------------------------------------
            count = WebSubsector.TVItemPolSourceSiteList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebSubsectorLocal.TVItemPolSourceSiteList
                                        where c.TVItemModel.TVItem.TVItemID == WebSubsector.TVItemPolSourceSiteList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebSubsector.TVItemPolSourceSiteList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in WebSubsectorLocal.TVItemPolSourceSiteList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebSubsector.TVItemPolSourceSiteList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemClassificationList
            // -----------------------------------------------------------
            count = WebSubsector.TVItemClassificationList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebSubsectorLocal.TVItemClassificationList
                                        where c.TVItemModel.TVItem.TVItemID == WebSubsector.TVItemClassificationList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebSubsector.TVItemClassificationList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in WebSubsectorLocal.TVItemClassificationList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                WebSubsector.TVItemClassificationList.Add(webBaseNew);
            }

            return;
        }
    }
}
