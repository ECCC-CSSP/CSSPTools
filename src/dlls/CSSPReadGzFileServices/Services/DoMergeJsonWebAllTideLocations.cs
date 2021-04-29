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
        private void DoMergeJsonWebAllTideLocations(WebAllTideLocations WebAllTideLocations, WebAllTideLocations WebAllTideLocationsLocal)
        {
            List<TideLocation> tideLocationLocalList = (from c in WebAllTideLocationsLocal.TideLocationList
                                              where c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (TideLocation tideLocationLocal in tideLocationLocalList)
            {
                TideLocation tideLocationOriginal = WebAllTideLocations.TideLocationList.Where(c => c.TideLocationID == tideLocationLocal.TideLocationID).FirstOrDefault();
                if (tideLocationOriginal == null)
                {
                    WebAllTideLocations.TideLocationList.Add(tideLocationLocal);
                }
                else
                {
                    tideLocationOriginal = tideLocationLocal;
                }
            }
        }
    }
}
