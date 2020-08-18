﻿/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class GzFileService : ControllerBase, IGzFileService
    {
        public async Task<string> GetFileName(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            string fileName = "";
            int Year = 0;
            switch (webTypeYear)
            {
                case WebTypeYearEnum.Year1980:
                    Year = 1980;
                    break;
                case WebTypeYearEnum.Year1990:
                    Year = 1990;
                    break;
                case WebTypeYearEnum.Year2000:
                    Year = 2000;
                    break;
                case WebTypeYearEnum.Year2010:
                    Year = 2010;
                    break;
                case WebTypeYearEnum.Year2020:
                    Year = 2020;
                    break;
                case WebTypeYearEnum.Year2030:
                    Year = 2030;
                    break;
                case WebTypeYearEnum.Year2040:
                    Year = 2040;
                    break;
                case WebTypeYearEnum.Year2050:
                    Year = 2050;
                    break;
                default:
                    Year = 0;
                    break;
            }

            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    fileName = "WebRoot.gz";
                    break;
                case WebTypeEnum.WebCountry:
                    fileName = $"WebCountry_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebProvince:
                    fileName = $"WebProvince_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebArea:
                    fileName = $"WebArea_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipalities:
                    fileName = $"WebMunicipalities_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSector:
                    fileName = $"WebSector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSubsector:
                    fileName = $"WebSubsector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipality:
                    fileName = $"WebMunicipality_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSample:
                    fileName = $"WebMWQMSample_{ TVItemID }_{ Year }_{ Year + 9 }.gz";
                    break;
                case WebTypeEnum.WebSamplingPlan:
                    fileName = $"WebSamplingPlan_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMRun:
                    fileName = $"WebMWQMRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSite:
                    fileName = $"WebMWQMSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebContact:
                    fileName = $"WebContact.gz";
                    break;
                case WebTypeEnum.WebClimateSite:
                    fileName = $"WebClimateSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricSite:
                    fileName = $"WebHydrometricSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebDrogueRun:
                    fileName = $"WebDrogueRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMLookupMPN:
                    fileName = $"WebMWQMLookupMPN.gz";
                    break;
                case WebTypeEnum.WebMikeScenario:
                    fileName = $"WebMikeScenario_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebClimateDataValue:
                    fileName = $"WebClimateDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricDataValue:
                    fileName = $"WebHydrometricDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHelpDoc:
                    fileName = $"WebHelpDoc.gz";
                    break;
                case WebTypeEnum.WebTideLocation:
                    fileName = $"WebTideLocation.gz";
                    break;
                case WebTypeEnum.WebPolSourceSite:
                    fileName = $"WebPolSourceSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebPolSourceGrouping:
                    fileName = $"WebPolSourceGrouping.gz";
                    break;
                case WebTypeEnum.WebReportType:
                    fileName = $"WebReportType.gz";
                    break;
                default:
                    return await Task.FromResult("WebError.gz");
            }

            return await Task.FromResult(fileName);
        }
    }
}
