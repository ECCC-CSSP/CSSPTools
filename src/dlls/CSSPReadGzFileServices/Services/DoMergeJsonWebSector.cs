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
        private void DoMergeJsonWebSector(WebSector webSector, WebSector webSectorLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemSubsectorList
            // -----------------------------------------------------------
            int count = webSector.TVItemSubsectorList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSectorLocal.TVItemSubsectorList
                                        where c.TVItemModel.TVItem.TVItemID == webSector.TVItemSubsectorList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSector.TVItemSubsectorList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in webSectorLocal.TVItemSubsectorList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(WebBase webBaseNew in webBaseLocalNewList)
            {
                webSector.TVItemSubsectorList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemFileList
            // -----------------------------------------------------------
            count = webSector.TVItemFileList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webSectorLocal.TVItemFileList
                                        where c.TVItemModel.TVItem.TVItemID == webSector.TVItemFileList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webSector.TVItemFileList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webSectorLocal.TVItemFileList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webSector.TVItemFileList.Add(webBaseNew);
            }

            return;
        }
    }
}
