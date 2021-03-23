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
        private void DoMergeJsonWebCountry(WebCountry webCountry, WebCountry webCountryLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemProvinceList
            // -----------------------------------------------------------
            int count = webCountry.TVItemProvinceList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webCountryLocal.TVItemProvinceList
                                        where c.TVItemModel.TVItem.TVItemID == webCountry.TVItemProvinceList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webCountry.TVItemProvinceList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in webCountryLocal.TVItemProvinceList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(WebBase webBaseNew in webBaseLocalNewList)
            {
                webCountry.TVItemProvinceList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemRainExceedanceList
            // -----------------------------------------------------------
            count = webCountry.TVItemRainExceedanceList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webCountryLocal.TVItemRainExceedanceList
                                        where c.TVItemModel.TVItem.TVItemID == webCountry.TVItemRainExceedanceList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webCountry.TVItemRainExceedanceList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webCountryLocal.TVItemRainExceedanceList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webCountry.TVItemRainExceedanceList.Add(webBaseNew);
            }

            // -----------------------------------------------------------
            // doing TVItemFileList
            // -----------------------------------------------------------
            count = webCountry.TVItemFileList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in webCountryLocal.TVItemFileList
                                        where c.TVItemModel.TVItem.TVItemID == webCountry.TVItemFileList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    webCountry.TVItemFileList[i] = webBaseLocal;
                }
            }

            webBaseLocalNewList = (from c in webCountryLocal.TVItemFileList
                                   where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                   select c).ToList();

            foreach (WebBase webBaseNew in webBaseLocalNewList)
            {
                webCountry.TVItemFileList.Add(webBaseNew);
            }


            return;
        }
    }
}