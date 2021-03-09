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
            // -----------------------------------------------------------
            // doing TideLocationList
            // -----------------------------------------------------------
            int count = WebAllTideLocations.TideLocationList.Count;
            for (int i = 0; i < count; i++)
            {
                TideLocation TideLocationLocal = (from c in WebAllTideLocationsLocal.TideLocationList
                                        where c.TideLocationID == WebAllTideLocations.TideLocationList[i].TideLocationID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (TideLocationLocal != null)
                {
                    WebAllTideLocations.TideLocationList[i] = TideLocationLocal;
                }
            }

            List<TideLocation> TideLocationLocalNewList = (from c in WebAllTideLocationsLocal.TideLocationList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (TideLocation TideLocationNew in TideLocationLocalNewList)
            {
                WebAllTideLocations.TideLocationList.Add(TideLocationNew);
            }

            return;
        }
    }
}
