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
        private void DoMergeJsonWebMWQMSamples1980_2020(WebMWQMSamples WebMWQMSamples, WebMWQMSamples WebMWQMSamplesLocal)
        {
            List<MWQMSampleModel> MWQMSampleModelList = (from c in WebMWQMSamplesLocal.MWQMSampleModelList
                                                               where c.MWQMSample.DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (MWQMSampleModel mwqmSampleModel in MWQMSampleModelList)
            {
                MWQMSampleModel mwqmSampleModelOriginal = WebMWQMSamples.MWQMSampleModelList.Where(c => c.MWQMSample.MWQMSampleID == mwqmSampleModel.MWQMSample.MWQMSampleID).FirstOrDefault();
                if (mwqmSampleModelOriginal == null)
                {
                    WebMWQMSamples.MWQMSampleModelList.Add(mwqmSampleModelOriginal);
                }
                else
                {
                    mwqmSampleModelOriginal = mwqmSampleModel;
                }
            }
        }
    }
}
