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
        private void DoMergeJsonWebTideDataValue(WebTideDataValue WebTideDataValue, WebTideDataValue WebTideDataValueLocal)
        {
            // -----------------------------------------------------------
            // doing TideDataValueList
            // -----------------------------------------------------------
            int count = WebTideDataValue.TideDataValueList.Count;
            for (int i = 0; i < count; i++)
            {
                TideDataValue TideDataValueLocal = (from c in WebTideDataValueLocal.TideDataValueList
                                                          where c.TideDataValueID == WebTideDataValue.TideDataValueList[i].TideDataValueID
                                                          && c.DBCommand != DBCommandEnum.Original
                                                          select c).FirstOrDefault();

                if (TideDataValueLocal != null)
                {
                    WebTideDataValue.TideDataValueList[i] = TideDataValueLocal;
                }
            }

            List<TideDataValue> TideDataValueLocalNewList = (from c in WebTideDataValueLocal.TideDataValueList
                                                                   where c.DBCommand == DBCommandEnum.Created
                                                                   select c).ToList();

            foreach (TideDataValue TideDataValueNew in TideDataValueLocalNewList)
            {
                WebTideDataValue.TideDataValueList.Add(TideDataValueNew);
            }

            return;
        }
    }
}
