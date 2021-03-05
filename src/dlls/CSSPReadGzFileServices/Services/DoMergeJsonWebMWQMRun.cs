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
        private void DoMergeJsonWebMWQMRun(WebMWQMRun WebMWQMRun, WebMWQMRun WebMWQMRunLocal)
        {
            // -----------------------------------------------------------
            // doing MWQMRunModelList
            // -----------------------------------------------------------
            int count = WebMWQMRun.MWQMRunModelList.Count;
            for (int i = 0; i < count; i++)
            {
                MWQMRunModel MWQMRunModelLocal = (from c in WebMWQMRunLocal.MWQMRunModelList
                                                              where c.TVItemModel.TVItem.TVItemID == WebMWQMRun.MWQMRunModelList[i].TVItemModel.TVItem.TVItemID
                                                              && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                              || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].DBCommand != DBCommandEnum.Original
                                                              || c.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].DBCommand != DBCommandEnum.Original)
                                                              select c).FirstOrDefault();

                if (MWQMRunModelLocal != null)
                {
                    WebMWQMRun.MWQMRunModelList[i] = MWQMRunModelLocal;
                }
            }

            List<MWQMRunModel> MWQMRunModelLocalNewList = (from c in WebMWQMRunLocal.MWQMRunModelList
                                                                       where c.TVItemModel.TVItem.DBCommand == DBCommandEnum.Created
                                                                       select c).ToList();

            foreach (MWQMRunModel MWQMRunModelNew in MWQMRunModelLocalNewList)
            {
                WebMWQMRun.MWQMRunModelList.Add(MWQMRunModelNew);
            }

            return;
        }
    }
}
