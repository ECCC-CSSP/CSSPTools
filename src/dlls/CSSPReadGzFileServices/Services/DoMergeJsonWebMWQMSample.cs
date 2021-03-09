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
        private void DoMergeJsonWebMWQMSample(WebMWQMSample WebMWQMSample, WebMWQMSample WebMWQMSampleLocal)
        {
            // -----------------------------------------------------------
            // doing MWQMSampleModelList
            // -----------------------------------------------------------
            int count = WebMWQMSample.MWQMSampleList.Count;
            for (int i = 0; i < count; i++)
            {
                MWQMSample MWQMSampleLocal = (from c in WebMWQMSampleLocal.MWQMSampleList
                                              where c.MWQMSampleID == WebMWQMSample.MWQMSampleList[i].MWQMSampleID
                                              && c.DBCommand != DBCommandEnum.Original
                                              select c).FirstOrDefault();

                if (MWQMSampleLocal != null)
                {
                    WebMWQMSample.MWQMSampleList[i] = MWQMSampleLocal;
                }
            }

            List<MWQMSample> MWQMSampleLocalNewList = (from c in WebMWQMSampleLocal.MWQMSampleList
                                                       where c.DBCommand == DBCommandEnum.Created
                                                       select c).ToList();

            foreach (MWQMSample MWQMSampleNew in MWQMSampleLocalNewList)
            {
                WebMWQMSample.MWQMSampleList.Add(MWQMSampleNew);
            }

            return;
        }
    }
}
