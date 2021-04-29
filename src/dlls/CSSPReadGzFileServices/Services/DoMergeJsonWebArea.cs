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
        private void DoMergeJsonWebArea(WebArea WebArea, WebArea WebAreaLocal)
        {
            if (WebAreaLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
                || WebAreaLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                || WebAreaLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebArea.TVItemStatMapModel = WebAreaLocal.TVItemStatMapModel;
            }

            if ((from c in WebAreaLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebArea.TVItemStatModelParentList = WebAreaLocal.TVItemStatModelParentList;
            }

            List<TVItemStatMapModel> TVItemStatMapModelList = (from c in WebAreaLocal.TVItemStatMapModelSectorList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemStatMapModel tvItemStatMapModel in TVItemStatMapModelList)
            {
                TVItemStatMapModel tvItemStatMapModelOriginal = WebArea.TVItemStatMapModelSectorList.Where(c => c.TVItem.TVItemID == tvItemStatMapModel.TVItem.TVItemID).FirstOrDefault();
                if (tvItemStatMapModelOriginal == null)
                {
                    WebArea.TVItemStatMapModelSectorList.Add(tvItemStatMapModelOriginal);
                }
                else
                {
                    tvItemStatMapModelOriginal = tvItemStatMapModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebAreaLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebArea.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebArea.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
