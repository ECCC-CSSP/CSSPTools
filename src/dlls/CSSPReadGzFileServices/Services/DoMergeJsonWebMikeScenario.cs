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
        private void DoMergeJsonWebMikeScenario(WebMikeScenario WebMikeScenario, WebMikeScenario WebMikeScenarioLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemMikeSourceList
            // -----------------------------------------------------------
            int count = WebMikeScenario.TVItemMikeSourceList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebMikeScenarioLocal.TVItemMikeSourceList
                                                                where c.TVItemModel.TVItem.TVItemID == WebMikeScenario.TVItemMikeSourceList[i].TVItemModel.TVItem.TVItemID
                                                                && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                                || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                                                || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                                                select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebMikeScenario.TVItemMikeSourceList[i] = webBaseLocal;
                }
            }

            List<WebBase> WebBaseLocalNewList = (from c in WebMikeScenarioLocal.TVItemMikeSourceList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase WebBaseLocalNew in WebBaseLocalNewList)
            {
                WebMikeScenario.TVItemMikeSourceList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMikeBoundaryConditionMeshList
            // -----------------------------------------------------------
            count = WebMikeScenario.TVItemMikeBoundaryConditionMeshList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebMikeScenarioLocal.TVItemMikeBoundaryConditionMeshList
                                        where c.TVItemModel.TVItem.TVItemID == WebMikeScenario.TVItemMikeBoundaryConditionMeshList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebMikeScenario.TVItemMikeBoundaryConditionMeshList[i] = webBaseLocal;
                }
            }

            WebBaseLocalNewList = (from c in WebMikeScenarioLocal.TVItemMikeBoundaryConditionMeshList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase WebBaseLocalNew in WebBaseLocalNewList)
            {
                WebMikeScenario.TVItemMikeBoundaryConditionMeshList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMikeBoundaryConditionWebTideList
            // -----------------------------------------------------------
            count = WebMikeScenario.TVItemMikeBoundaryConditionWebTideList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebMikeScenarioLocal.TVItemMikeBoundaryConditionWebTideList
                                        where c.TVItemModel.TVItem.TVItemID == WebMikeScenario.TVItemMikeBoundaryConditionWebTideList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebMikeScenario.TVItemMikeBoundaryConditionWebTideList[i] = webBaseLocal;
                }
            }

            WebBaseLocalNewList = (from c in WebMikeScenarioLocal.TVItemMikeBoundaryConditionWebTideList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase WebBaseLocalNew in WebBaseLocalNewList)
            {
                WebMikeScenario.TVItemMikeBoundaryConditionWebTideList.Add(WebBaseLocalNew);
            }

            return;
        }
    }
}
