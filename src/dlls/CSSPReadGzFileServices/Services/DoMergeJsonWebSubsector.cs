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
            if (WebSubsectorLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebSubsectorLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebSubsectorLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebSubsector.TVItemModel = WebSubsectorLocal.TVItemModel;
            }

            if ((from c in WebSubsectorLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebSubsector.TVItemModelParentList = WebSubsectorLocal.TVItemModelParentList;
            }

            //List<TVItemModel> TVItemModelList = (from c in WebSubsectorLocal.TVItemStatMapProvinceList
            //                                                   where c.TVItem.DBCommand != DBCommandEnum.Original
            //                                                   || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
            //                                                   || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
            //                                                   select c).ToList();

            //foreach (TVItemModel TVItemModel in TVItemModelList)
            //{
            //    TVItemModel TVItemModelOriginal = WebSubsector.TVItemStatMapProvinceList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
            //    if (TVItemModelOriginal == null)
            //    {
            //        WebSubsector.TVItemStatMapProvinceList.Add(TVItemModelOriginal);
            //    }
            //    else
            //    {
            //        TVItemModelOriginal = TVItemModel;
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
