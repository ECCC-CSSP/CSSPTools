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
            // -----------------------------------------------------------
            // doing MWQMLookupMPNList
            // -----------------------------------------------------------
            int count = WebAllMWQMLookupMPNs.MWQMLookupMPNList.Count;
            for (int i = 0; i < count; i++)
            {
                MWQMLookupMPN MWQMLookupMPNLocal = (from c in WebAllMWQMLookupMPNsLocal.MWQMLookupMPNList
                                        where c.MWQMLookupMPNID == WebAllMWQMLookupMPNs.MWQMLookupMPNList[i].MWQMLookupMPNID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (MWQMLookupMPNLocal != null)
                {
                    WebAllMWQMLookupMPNs.MWQMLookupMPNList[i] = MWQMLookupMPNLocal;
                }
            }

            List<MWQMLookupMPN> MWQMLookupMPNLocalNewList = (from c in WebAllMWQMLookupMPNsLocal.MWQMLookupMPNList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (MWQMLookupMPN MWQMLookupMPNNew in MWQMLookupMPNLocalNewList)
            {
                WebAllMWQMLookupMPNs.MWQMLookupMPNList.Add(MWQMLookupMPNNew);
            }

            return;
        }
    }
}
