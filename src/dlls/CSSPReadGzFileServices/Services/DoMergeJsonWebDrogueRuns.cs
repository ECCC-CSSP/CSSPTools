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
        private void DoMergeJsonWebDrogueRuns(WebDrogueRuns WebDrogueRuns, WebDrogueRuns WebDrogueRunsLocal)
        {
            if (WebDrogueRunsLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
               || WebDrogueRunsLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
               || WebDrogueRunsLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
            {
                WebDrogueRuns.TVItemModel = WebDrogueRunsLocal.TVItemModel;
            }

            if ((from c in WebDrogueRunsLocal.TVItemModelParentList
                 where c.TVItem.DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                 select c).Any())
            {
                WebDrogueRuns.TVItemModelParentList = WebDrogueRunsLocal.TVItemModelParentList;
            }

            List<DrogueRunModel> DrogueRunModelList = (from c in WebDrogueRunsLocal.DrogueRunModelList
                                                       where c.DrogueRun.DBCommand != DBCommandEnum.Original
                                                       || (from d in c.DrogueRunPositionList
                                                           where d.DBCommand != DBCommandEnum.Original
                                                           select d).Any()
                                                       select c).ToList();

            foreach (DrogueRunModel drogueRunModel in DrogueRunModelList)
            {
                DrogueRunModel drogueRunModelOriginal = WebDrogueRuns.DrogueRunModelList.Where(c => c.DrogueRun.DrogueRunID == drogueRunModel.DrogueRun.DrogueRunID).FirstOrDefault();
                if (drogueRunModelOriginal == null)
                {
                    WebDrogueRuns.DrogueRunModelList.Add(drogueRunModelOriginal);
                }
                else
                {
                    drogueRunModelOriginal = drogueRunModel;
                }
            }
        }
    }
}
