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
        private void DoMergeJsonWebClimateDataValue(WebClimateDataValue WebClimateDataValue, WebClimateDataValue WebClimateDataValueLocal)
        {
            // -----------------------------------------------------------
            // doing ClimateDataValueList
            // -----------------------------------------------------------
            int count = WebClimateDataValue.ClimateDataValueList.Count;
            for (int i = 0; i < count; i++)
            {
                ClimateDataValue climateDataValueLocal = (from c in WebClimateDataValueLocal.ClimateDataValueList
                                                          where c.ClimateDataValueID == WebClimateDataValue.ClimateDataValueList[i].ClimateDataValueID
                                                          && c.DBCommand != DBCommandEnum.Original
                                                          select c).FirstOrDefault();

                if (climateDataValueLocal != null)
                {
                    WebClimateDataValue.ClimateDataValueList[i] = climateDataValueLocal;
                }
            }

            List<ClimateDataValue> climateDataValueLocalNewList = (from c in WebClimateDataValueLocal.ClimateDataValueList
                                                                   where c.DBCommand == DBCommandEnum.Created
                                                                   select c).ToList();

            foreach (ClimateDataValue climateDataValueNew in climateDataValueLocalNewList)
            {
                WebClimateDataValue.ClimateDataValueList.Add(climateDataValueNew);
            }

            return;
        }
    }
}
