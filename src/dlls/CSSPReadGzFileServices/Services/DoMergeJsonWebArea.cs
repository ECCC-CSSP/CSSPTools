﻿/*
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
        private void DoMergeJsonWebArea(WebArea webArea, WebArea webAreaLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemSectorList
            // -----------------------------------------------------------
            int count = webArea.TVItemSectorList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webAreaLocal.TVItemSectorList
                                        where c.TVItemModel.TVItem.TVItemID == webArea.TVItemSectorList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webArea.TVItemSectorList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in webAreaLocal.TVItemSectorList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(WebBase webBaseNew in webBaseLocalNewList)
            {
                webArea.TVItemSectorList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemFileList
            // -----------------------------------------------------------
            count = webArea.TVItemFileList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webAreaLocal.TVItemFileList
                                        where c.TVItemModel.TVItem.TVItemID == webArea.TVItemFileList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webArea.TVItemFileList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webAreaLocal.TVItemFileList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webArea.TVItemFileList.Add(webBaseNew);
            }

            return;
        }
    }
}
