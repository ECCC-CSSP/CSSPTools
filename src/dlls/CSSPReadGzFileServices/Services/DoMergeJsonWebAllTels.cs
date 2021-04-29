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
        private void DoMergeJsonWebAllTels(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)
        {
            List<TelModel> telModelLocalList = (from c in WebAllTelsLocal.TelModelList
                                                    where c.TVItem.DBCommand != DBCommandEnum.Original
                                                    || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                    || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (TelModel telModelLocal in telModelLocalList)
            {
                TelModel telModelOriginal = WebAllTels.TelModelList.Where(c => c.TVItem.TVItemID == telModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (telModelOriginal == null)
                {
                    WebAllTels.TelModelList.Add(telModelLocal);
                }
                else
                {
                    telModelOriginal = telModelLocal;
                }
            }
        }
    }
}
