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
        private void DoMergeJsonWebAllMunicipalities(WebAllMunicipalities WebAllMunicipalities, WebAllMunicipalities WebAllMunicipalitiesLocal)
        {
            List<AllMunicipalityModel> allMunicipalityModelLocalList = (from c in WebAllMunicipalitiesLocal.AllMunicipalityModelList
                                                                        where c.TVItem.DBCommand != DBCommandEnum.Original
                                                                        || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                        || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                                        select c).ToList();

            foreach (AllMunicipalityModel allMunicipalityModelLocal in allMunicipalityModelLocalList)
            {
                AllMunicipalityModel allMunicipalityModelOriginal = WebAllMunicipalities.AllMunicipalityModelList.Where(c => c.TVItem.TVItemID == allMunicipalityModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (allMunicipalityModelOriginal == null)
                {
                    WebAllMunicipalities.AllMunicipalityModelList.Add(allMunicipalityModelLocal);
                }
                else
                {
                    allMunicipalityModelOriginal = allMunicipalityModelLocal;
                }
            }
        }
    }
}
