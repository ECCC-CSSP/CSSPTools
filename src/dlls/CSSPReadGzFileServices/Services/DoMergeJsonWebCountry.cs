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
        private void DoMergeJsonWebCountry(WebCountry WebCountry, WebCountry WebCountryLocal)
        {
            if (WebCountryLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebCountryLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebCountryLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebCountry.TVItemStatMapModel = WebCountryLocal.TVItemStatMapModel;
            }

            if ((from c in WebCountryLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebCountry.TVItemStatModelParentList = WebCountryLocal.TVItemStatModelParentList;
            }

            List<TVItemStatMapModel> TVItemStatMapModelList = (from c in WebCountryLocal.TVItemStatMapModelProvinceList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemStatMapModel tvItemStatMapModel in TVItemStatMapModelList)
            {
                TVItemStatMapModel tvItemStatMapModelOriginal = WebCountry.TVItemStatMapModelProvinceList.Where(c => c.TVItem.TVItemID == tvItemStatMapModel.TVItem.TVItemID).FirstOrDefault();
                if (tvItemStatMapModelOriginal == null)
                {
                    WebCountry.TVItemStatMapModelProvinceList.Add(tvItemStatMapModelOriginal);
                }
                else
                {
                    tvItemStatMapModelOriginal = tvItemStatMapModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebCountryLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebCountry.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
