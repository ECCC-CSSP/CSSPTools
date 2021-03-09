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
        private void DoMergeJsonWebAllTVItems(WebAllTVItems WebAllTVItems, WebAllTVItems WebAllTVItemsLocal)
        {
            // -----------------------------------------------------------
            // doing TVItemList
            // -----------------------------------------------------------
            
            int count = WebAllTVItems.TVItemList.Count;
            for (int i = 0; i < count; i++)
            {
                TVItem TVItemLocal = (from c in WebAllTVItemsLocal.TVItemList
                                        where c.TVItemID == WebAllTVItems.TVItemList[i].TVItemID
                                        && c.DBCommand != DBCommandEnum.Original
                                        select c).FirstOrDefault();

                if (TVItemLocal != null)
                {
                    WebAllTVItems.TVItemList[i] = TVItemLocal;
                }
            }

            List<TVItem> TVItemLocalNewList = (from c in WebAllTVItemsLocal.TVItemList
                                                 where c.DBCommand == DBCommandEnum.Created
                                                 select c).ToList();

            foreach(TVItem TVItemNew in TVItemLocalNewList)
            {
                WebAllTVItems.TVItemList.Add(TVItemNew);
            }

            return;
        }
    }
}
