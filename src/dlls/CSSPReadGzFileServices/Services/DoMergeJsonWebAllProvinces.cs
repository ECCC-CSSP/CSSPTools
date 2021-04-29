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
        private void DoMergeJsonWebAllProvinces(WebAllProvinces WebAllProvinces, WebAllProvinces WebAllProvincesLocal)
        {
            List<ProvinceModel> provinceModelLocalList = (from c in WebAllProvincesLocal.ProvinceModelList
                                                    where c.TVItem.DBCommand != DBCommandEnum.Original
                                                    || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                    || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (ProvinceModel provinceModelLocal in provinceModelLocalList)
            {
                ProvinceModel provinceModelOriginal = WebAllProvinces.ProvinceModelList.Where(c => c.TVItem.TVItemID == provinceModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (provinceModelOriginal == null)
                {
                    WebAllProvinces.ProvinceModelList.Add(provinceModelLocal);
                }
                else
                {
                    provinceModelOriginal = provinceModelLocal;
                }
            }
        }
    }
}
