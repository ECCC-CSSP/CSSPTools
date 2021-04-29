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
        private void DoMergeJsonWebAllCountries(WebAllCountries WebAllCountries, WebAllCountries WebAllCountriesLocal)
        {
            List<CountryModel> countryModelLocalList = (from c in WebAllCountriesLocal.CountryModelList
                                                        where c.TVItem.DBCommand != DBCommandEnum.Original
                                                        || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                        || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                        select c).ToList();

            foreach (CountryModel countryModelLocal in countryModelLocalList)
            {
                CountryModel countryModelOriginal = WebAllCountries.CountryModelList.Where(c => c.TVItem.TVItemID == countryModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (countryModelOriginal == null)
                {
                    WebAllCountries.CountryModelList.Add(countryModelLocal);
                }
                else
                {
                    countryModelOriginal = countryModelLocal;
                }
            }
        }
    }
}
