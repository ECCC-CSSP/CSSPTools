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
        private void DoMergeJsonWebAllMWQMLookupMPNs(WebAllMWQMLookupMPNs WebAllMWQMLookupMPNs, WebAllMWQMLookupMPNs WebAllMWQMLookupMPNsLocal)
        {
            List<MWQMLookupMPN> mwqmLookupMPNLocalList = (from c in WebAllMWQMLookupMPNsLocal.MWQMLookupMPNList
                                              where c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (MWQMLookupMPN mwqmLookupMPNLocal in mwqmLookupMPNLocalList)
            {
                MWQMLookupMPN mwqmLookupMPNOriginal = WebAllMWQMLookupMPNs.MWQMLookupMPNList.Where(c => c.MWQMLookupMPNID == mwqmLookupMPNLocal.MWQMLookupMPNID).FirstOrDefault();
                if (mwqmLookupMPNOriginal == null)
                {
                    WebAllMWQMLookupMPNs.MWQMLookupMPNList.Add(mwqmLookupMPNLocal);
                }
                else
                {
                    mwqmLookupMPNOriginal = mwqmLookupMPNLocal;
                }
            }
        }
    }
}
