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
        private void DoMergeJsonWebMunicipality(WebMunicipality webMunicipality, WebMunicipality webMunicipalityLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemInfrastructureList
            // -----------------------------------------------------------
            int count = webMunicipality.TVItemInfrastructureList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMunicipalityLocal.TVItemInfrastructureList
                                        where c.TVItemModel.TVItem.TVItemID == webMunicipality.TVItemInfrastructureList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMunicipality.TVItemInfrastructureList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in webMunicipalityLocal.TVItemInfrastructureList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase WebBaseLocalNew in webBaseLocalNewList)
            {
                webMunicipality.TVItemInfrastructureList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemMikeScenarioList
            // -----------------------------------------------------------
            count = webMunicipality.TVItemMikeScenarioList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMunicipalityLocal.TVItemMikeScenarioList
                                        where c.TVItemModel.TVItem.TVItemID == webMunicipality.TVItemMikeScenarioList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMunicipality.TVItemMikeScenarioList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webMunicipalityLocal.TVItemMikeScenarioList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase WebBaseLocalNew in webBaseLocalNewList)
            {
                webMunicipality.TVItemMikeScenarioList.Add(WebBaseLocalNew);
            }

            // -----------------------------------------------------------
            // doing TVItemFileList
            // -----------------------------------------------------------
            count = webMunicipality.TVItemFileList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webMunicipalityLocal.TVItemFileList
                                        where c.TVItemModel.TVItem.TVItemID == webMunicipality.TVItemFileList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webMunicipality.TVItemFileList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webMunicipalityLocal.TVItemFileList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webMunicipality.TVItemFileList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing InfrastructureModelList
            // -----------------------------------------------------------

            List<InfrastructureModel> infrastructureModelLocalNewList = (from c in webMunicipalityLocal.InfrastructureModelList
                                                                         where (c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                                         || (c.Infrastructure != null
                                                                         && c.Infrastructure.DBCommand == DBCommandEnum.Created))
                                                                         select c).ToList();

            foreach (InfrastructureModel infrastructureModelLocalNew in infrastructureModelLocalNewList)
            {
                webMunicipality.InfrastructureModelList.Add(infrastructureModelLocalNew);
            }

            // -----------------------------------------------------------
            // doing InfrastructureModelList.TVItemModel
            // -----------------------------------------------------------
            count = webMunicipality.InfrastructureModelList.Count;
            for (int i = 0; i < count; i++)
            {
                InfrastructureModel infrastructureModelLocal = (from c in webMunicipalityLocal.InfrastructureModelList
                                                                where c.TVItemModel.TVItem.TVItemID == webMunicipality.InfrastructureModelList[i].TVItemModel.TVItem.TVItemID
                                                                select c).FirstOrDefault();

                if (infrastructureModelLocal != null)
                {
                    if (infrastructureModelLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                        || infrastructureModelLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                        || infrastructureModelLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                    {
                        webMunicipality.InfrastructureModelList[i].TVItemModel.TVItem = infrastructureModelLocal.TVItemModel.TVItem;
                        webMunicipality.InfrastructureModelList[i].TVItemModel.TVItemLanguageList[0] = infrastructureModelLocal.TVItemModel.TVItemLanguageList[0];
                        webMunicipality.InfrastructureModelList[i].TVItemModel.TVItemLanguageList[1] = infrastructureModelLocal.TVItemModel.TVItemLanguageList[1];
                        webMunicipality.InfrastructureModelList[i].TVItemModel.TVItemLanguageList[2] = infrastructureModelLocal.TVItemModel.TVItemLanguageList[2];
                    }

                    int count2 = webMunicipality.InfrastructureModelList[i].TVItemFileList.Count;
                    for (int j = 0; j < count2; j++)
                    {
                        WebBase webBaseTVItemFileLocal = (from c in infrastructureModelLocal.TVItemFileList
                                                          where c.TVItemModel.TVItem.TVItemID == webMunicipality.InfrastructureModelList[i].TVItemFileList[j].TVItemModel.TVItem.TVItemID
                                                          select c).FirstOrDefault();

                        if (webBaseTVItemFileLocal != null)
                        {
                            if (webBaseTVItemFileLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                || webBaseTVItemFileLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                || webBaseTVItemFileLocal.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                            {
                                webMunicipality.InfrastructureModelList[i].TVItemFileList[j] = webBaseTVItemFileLocal;
                            }
                        }
                    }

                    List<WebBase> webBaseInfTVItemFileLocalNewList = (from c in infrastructureModelLocal.TVItemFileList
                                                                      where (c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                                      || (c.TVItemModel.TVItem != null
                                                                      && c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created))
                                                                      select c).ToList();

                    foreach (WebBase webBaseInfTVItemFileLocalNew in webBaseInfTVItemFileLocalNewList)
                    {
                        webMunicipality.InfrastructureModelList[i].TVItemFileList.Add(webBaseInfTVItemFileLocalNew);
                    }
                }


            }

            return;
        }
    }
}
