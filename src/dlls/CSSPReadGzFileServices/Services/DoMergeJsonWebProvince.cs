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
        private void DoMergeJsonWebProvince(WebProvince WebProvince, WebProvince WebProvinceLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemAreaList
            // -----------------------------------------------------------
            int count = WebProvince.TVItemAreaList.Count;
            for (int i = 0; i < count; i++)
            {
                WebBase webBaseLocal = (from c in WebProvinceLocal.TVItemAreaList
                                        where c.TVItemModel.TVItem.TVItemID == WebProvince.TVItemAreaList[i].TVItemModel.TVItem.TVItemID
                                        && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                        || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                        select c).FirstOrDefault();

                if (webBaseLocal != null)
                {
                    WebProvince.TVItemAreaList[i] = webBaseLocal;
                }
            }

            List<WebBase> webBaseLocalNewList = (from c in WebProvinceLocal.TVItemAreaList
                                                 where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(WebBase webBaseNew in webBaseLocalNewList)
            {
                WebProvince.TVItemAreaList.Add(webBaseNew);
            }

            return;
        }
    }
}
