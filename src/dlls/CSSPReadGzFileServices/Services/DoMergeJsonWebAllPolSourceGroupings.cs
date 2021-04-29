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
        private void DoMergeJsonWebAllPolSourceGroupings(WebAllPolSourceGroupings WebAllPolSourceGroupings, WebAllPolSourceGroupings WebAllPolSourceGroupingsLocal)
        {
            List<PolSourceGroupingModel> polSourceGroupingModelLocalList = (from c in WebAllPolSourceGroupingsLocal.PolSourceGroupingModelList
                                                                            where c.PolSourceGrouping.DBCommand != DBCommandEnum.Original
                                                                            || c.PolSourceGroupingLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                            || c.PolSourceGroupingLanguageList[1].DBCommand != DBCommandEnum.Original
                                                                            select c).ToList();

            foreach (PolSourceGroupingModel polSourceGroupingModelLocal in polSourceGroupingModelLocalList)
            {
                PolSourceGroupingModel polSourceGroupingModelOriginal = WebAllPolSourceGroupings.PolSourceGroupingModelList.Where(c => c.PolSourceGrouping.PolSourceGroupingID == polSourceGroupingModelLocal.PolSourceGrouping.PolSourceGroupingID).FirstOrDefault();
                if (polSourceGroupingModelOriginal == null)
                {
                    WebAllPolSourceGroupings.PolSourceGroupingModelList.Add(polSourceGroupingModelLocal);
                }
                else
                {
                    polSourceGroupingModelOriginal = polSourceGroupingModelLocal;
                }
            }
        }
    }
}
