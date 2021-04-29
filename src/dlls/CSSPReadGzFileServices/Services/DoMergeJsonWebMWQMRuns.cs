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
        private void DoMergeJsonWebMWQMRuns(WebMWQMRuns WebMWQMRuns, WebMWQMRuns WebMWQMRunsLocal)
        {
            List<MWQMRunModel> MWQMRunModelList = (from c in WebMWQMRunsLocal.MWQMRunModelList
                                                               where c.MWQMRun.DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (MWQMRunModel mwqmRunModel in MWQMRunModelList)
            {
                MWQMRunModel mwqmRunModelOriginal = WebMWQMRuns.MWQMRunModelList.Where(c => c.MWQMRun.MWQMRunID == mwqmRunModel.MWQMRun.MWQMRunID).FirstOrDefault();
                if (mwqmRunModelOriginal == null)
                {
                    WebMWQMRuns.MWQMRunModelList.Add(mwqmRunModelOriginal);
                }
                else
                {
                    mwqmRunModelOriginal = mwqmRunModel;
                }
            }
        }
    }
}
