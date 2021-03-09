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
            // -----------------------------------------------------------
            // doing PolSourceGroupingList
            // -----------------------------------------------------------
            int count = WebAllPolSourceGroupings.PolSourceGroupingList.Count;
            for (int i = 0; i < count; i++)
            {
                PolSourceGrouping PolSourceGroupingLocal = (from c in WebAllPolSourceGroupingsLocal.PolSourceGroupingList
                                        where c.PolSourceGroupingID == WebAllPolSourceGroupings.PolSourceGroupingList[i].PolSourceGroupingID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (PolSourceGroupingLocal != null)
                {
                    WebAllPolSourceGroupings.PolSourceGroupingList[i] = PolSourceGroupingLocal;
                }
            }

            List<PolSourceGrouping> PolSourceGroupingLocalNewList = (from c in WebAllPolSourceGroupingsLocal.PolSourceGroupingList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach (PolSourceGrouping PolSourceGroupingNew in PolSourceGroupingLocalNewList)
            {
                WebAllPolSourceGroupings.PolSourceGroupingList.Add(PolSourceGroupingNew);
            }

            return;
        }
    }
}
