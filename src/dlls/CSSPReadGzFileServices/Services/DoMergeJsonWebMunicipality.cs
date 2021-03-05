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
        private void DoMergeJsonWebMunicipality(WebMunicipality WebMunicipality, WebMunicipality WebMunicipalityLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemInfrastructureList
            // -----------------------------------------------------------
            int count = WebMunicipality.TVItemInfrastructureList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebMunicipalityLocal.TVItemInfrastructureList
                                                                where c.TVItemModel.TVItem.TVItemID == WebMunicipality.TVItemInfrastructureList[i].TVItemModel.TVItem.TVItemID
                                                                && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                                || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                                                || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                                                select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebMunicipality.TVItemInfrastructureList[i] = webBaseLocal;
                }
            }

            List<WebBase> WebBaseLocalNewList = (from c in WebMunicipalityLocal.TVItemInfrastructureList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase WebBaseLocalNew in WebBaseLocalNewList)
            {
                WebMunicipality.TVItemInfrastructureList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMikeScenarioList
            // -----------------------------------------------------------
            count = WebMunicipality.TVItemMikeScenarioList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebMunicipalityLocal.TVItemMikeScenarioList
                                        where c.TVItemModel.TVItem.TVItemID == WebMunicipality.TVItemMikeScenarioList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebMunicipality.TVItemMikeScenarioList[i] = webBaseLocal;
                }
            }

            WebBaseLocalNewList = (from c in WebMunicipalityLocal.TVItemMikeScenarioList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase WebBaseLocalNew in WebBaseLocalNewList)
            {
                WebMunicipality.TVItemMikeScenarioList.Add(WebBaseLocalNew);
            }

            return;
        }
    }
}
