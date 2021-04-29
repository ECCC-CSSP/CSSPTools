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
        private void DoMergeJsonWebRoot(WebRoot WebRoot, WebRoot WebRootLocal)
        {
            if (WebRootLocal.TVItemStatMapModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebRootLocal.TVItemStatMapModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebRootLocal.TVItemStatMapModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebRoot.TVItemStatMapModel = WebRootLocal.TVItemStatMapModel;
            }

            if ((from c in WebRootLocal.TVItemStatModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebRoot.TVItemStatModelParentList = WebRootLocal.TVItemStatModelParentList;
            }

            List<TVItemStatMapModel> TVItemStatMapModelList = (from c in WebRootLocal.TVItemStatMapModelCountryList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemStatMapModel tvItemStatMapModel in TVItemStatMapModelList)
            {
                TVItemStatMapModel tvItemStatMapModelOriginal = WebRoot.TVItemStatMapModelCountryList.Where(c => c.TVItem.TVItemID == tvItemStatMapModel.TVItem.TVItemID).FirstOrDefault();
                if (tvItemStatMapModelOriginal == null)
                {
                    WebRoot.TVItemStatMapModelCountryList.Add(tvItemStatMapModelOriginal);
                }
                else
                {
                    tvItemStatMapModelOriginal = tvItemStatMapModel;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in WebRootLocal.TVFileModelList
                                                 where c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = WebRoot.TVFileModelList.Where(c => c.TVItem.TVItemID == tvFileModel.TVItem.TVItemID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    WebRoot.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}
