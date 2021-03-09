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
        private void DoMergeJsonWebHydrometricDataValue(WebHydrometricDataValue WebHydrometricDataValue, WebHydrometricDataValue WebHydrometricDataValueLocal)
        {
            // -----------------------------------------------------------
            // doing HydrometricDataValueList
            // -----------------------------------------------------------
            int count = WebHydrometricDataValue.HydrometricDataValueList.Count;
            for (int i = 0; i < count; i++)
            {
                HydrometricDataValue HydrometricDataValueLocal = (from c in WebHydrometricDataValueLocal.HydrometricDataValueList
                                                          where c.HydrometricDataValueID == WebHydrometricDataValue.HydrometricDataValueList[i].HydrometricDataValueID
                                                          && c.DBCommand != DBCommandEnum.Original
                                                          select c).FirstOrDefault();

                if (HydrometricDataValueLocal != null)
                {
                    WebHydrometricDataValue.HydrometricDataValueList[i] = HydrometricDataValueLocal;
                }
            }

            List<HydrometricDataValue> HydrometricDataValueLocalNewList = (from c in WebHydrometricDataValueLocal.HydrometricDataValueList
                                                                   where c.DBCommand == DBCommandEnum.Created
                                                                   select c).ToList();

            foreach (HydrometricDataValue HydrometricDataValueNew in HydrometricDataValueLocalNewList)
            {
                WebHydrometricDataValue.HydrometricDataValueList.Add(HydrometricDataValueNew);
            }

            return;
        }
    }
}
