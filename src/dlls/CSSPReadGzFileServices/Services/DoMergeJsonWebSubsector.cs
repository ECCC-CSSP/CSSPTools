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
        private static void DoMergeJsonWebSubsector(WebSubsector WebSubsector, WebSubsector WebSubsectorLocal)
        {
            if (WebSubsectorLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebSubsectorLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebSubsectorLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebSubsector.TVItemStatMapModel = WebSubsectorLocal.TVItemStatMapModel;
            }

            if ((from c in WebSubsectorLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebSubsector.TVItemStatModelParentList = WebSubsectorLocal.TVItemStatModelParentList;
            }

            //List<TVItemStatMapModel> TVItemStatMapModelList = (from c in WebSubsectorLocal.TVItemStatMapProvinceList
            //                                                   where c.TVItem.DBCommand != DBCommandEnum.Original
            //                                                   || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
            //                                                   || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
            //                                                   select c).ToList();

            //foreach (TVItemStatMapModel tvItemStatMapModel in TVItemStatMapModelList)
            //{
            //    TVItemStatMapModel tvItemStatMapModelOriginal = WebSubsector.TVItemStatMapProvinceList.Where(c => c.TVItem.TVItemID == tvItemStatMapModel.TVItem.TVItemID).FirstOrDefault();
            //    if (tvItemStatMapModelOriginal == null)
            //    {
            //        WebSubsector.TVItemStatMapProvinceList.Add(tvItemStatMapModelOriginal);
            //    }
            //    else
            //    {
            //        tvItemStatMapModelOriginal = tvItemStatMapModel;
            //    }
            //}

            List<TVFileModel> TVFileModelList = (from c in WebSubsectorLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebSubsector.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebSubsector.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
