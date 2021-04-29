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
            if (WebProvinceLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebProvinceLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebProvinceLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebProvince.TVItemStatMapModel = WebProvinceLocal.TVItemStatMapModel;
            }

            if ((from c in WebProvinceLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebProvince.TVItemStatModelParentList = WebProvinceLocal.TVItemStatModelParentList;
            }

            List<TVItemStatMapModel> TVItemStatMapModelList = (from c in WebProvinceLocal.TVItemStatMapAreaList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemStatMapModel tvItemStatMapModel in TVItemStatMapModelList)
            {
                TVItemStatMapModel tvItemStatMapModelOriginal = WebProvince.TVItemStatMapAreaList.Where(c => c.TVItem.TVItemID == tvItemStatMapModel.TVItem.TVItemID).FirstOrDefault();
                if (tvItemStatMapModelOriginal == null)
                {
                    WebProvince.TVItemStatMapAreaList.Add(tvItemStatMapModelOriginal);
                }
                else
                {
                    tvItemStatMapModelOriginal = tvItemStatMapModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebProvinceLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebProvince.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebProvince.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
