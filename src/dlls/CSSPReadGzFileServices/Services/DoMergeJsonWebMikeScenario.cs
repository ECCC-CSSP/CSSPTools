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
        private void DoMergeJsonWebMikeScenario(WebMikeScenario webMikeScenario, WebMikeScenario webMikeScenarioLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemMikeSourceList
            // -----------------------------------------------------------
            int count = webMikeScenario.TVItemMikeSourceList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMikeScenarioLocal.TVItemMikeSourceList
                                        where c.TVItemModel.TVItem.TVItemID == webMikeScenario.TVItemMikeSourceList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMikeScenario.TVItemMikeSourceList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in webMikeScenarioLocal.TVItemMikeSourceList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase WebBaseLocalNew in webBaseLocalNewList)
            {
                webMikeScenario.TVItemMikeSourceList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMikeBoundaryConditionMeshList
            // -----------------------------------------------------------
            count = webMikeScenario.TVItemMikeBoundaryConditionMeshList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMikeScenarioLocal.TVItemMikeBoundaryConditionMeshList
                                        where c.TVItemModel.TVItem.TVItemID == webMikeScenario.TVItemMikeBoundaryConditionMeshList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMikeScenario.TVItemMikeBoundaryConditionMeshList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webMikeScenarioLocal.TVItemMikeBoundaryConditionMeshList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase WebBaseLocalNew in webBaseLocalNewList)
            {
                webMikeScenario.TVItemMikeBoundaryConditionMeshList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMikeBoundaryConditionWebTideList
            // -----------------------------------------------------------
            count = webMikeScenario.TVItemMikeBoundaryConditionWebTideList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMikeScenarioLocal.TVItemMikeBoundaryConditionWebTideList
                                        where c.TVItemModel.TVItem.TVItemID == webMikeScenario.TVItemMikeBoundaryConditionWebTideList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMikeScenario.TVItemMikeBoundaryConditionWebTideList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webMikeScenarioLocal.TVItemMikeBoundaryConditionWebTideList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase WebBaseLocalNew in webBaseLocalNewList)
            {
                webMikeScenario.TVItemMikeBoundaryConditionWebTideList.Add(WebBaseLocalNew);
            }


            // -----------------------------------------------------------
            // doing TVItemFileList
            // -----------------------------------------------------------
            count = webMikeScenario.TVItemFileList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMikeScenarioLocal.TVItemFileList
                                        where c.TVItemModel.TVItem.TVItemID == webMikeScenario.TVItemFileList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMikeScenario.TVItemFileList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webMikeScenarioLocal.TVItemFileList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webMikeScenario.TVItemFileList.Add(webBaseNew);
            }

            return;
        }
    }
}
