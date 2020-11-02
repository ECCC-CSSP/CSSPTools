/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ReadGzFileServices
{
    public partial class BaseGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BaseGzFileService()
        {
        }
        #endregion Constructors

        #region Functions public
        public static async Task<string> GetFileName(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
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
                case WebTypeEnum.WebArea:
                    fileName = $"WebArea_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebClimateDataValue:
                    fileName = $"WebClimateDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebClimateSite:
                    fileName = $"WebClimateSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebContact:
                    fileName = $"WebContact.gz";
                    break;
                case WebTypeEnum.WebCountry:
                    fileName = $"WebCountry_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebDrogueRun:
                    fileName = $"WebDrogueRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHelpDoc:
                    fileName = $"WebHelpDoc.gz";
                    break;
                case WebTypeEnum.WebHydrometricDataValue:
                    fileName = $"WebHydrometricDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricSite:
                    fileName = $"WebHydrometricSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMikeScenario:
                    fileName = $"WebMikeScenario_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipalities:
                    fileName = $"WebMunicipalities_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipality:
                    fileName = $"WebMunicipality_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMLookupMPN:
                    fileName = $"WebMWQMLookupMPN.gz";
                    break;
                case WebTypeEnum.WebMWQMRun:
                    fileName = $"WebMWQMRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSample:
                    fileName = $"WebMWQMSample_{ TVItemID }_{ Year }_{ Year + 9 }.gz";
                    break;
                case WebTypeEnum.WebMWQMSite:
                    fileName = $"WebMWQMSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebPolSourceGrouping:
                    fileName = $"WebPolSourceGrouping.gz";
                    break;
                case WebTypeEnum.WebPolSourceSite:
                    fileName = $"WebPolSourceSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebPolSourceSiteEffectTerm:
                    fileName = $"WebPolSourceSiteEffectTerm.gz";
                    break;
                case WebTypeEnum.WebProvince:
                    fileName = $"WebProvince_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebReportType:
                    fileName = $"WebReportType.gz";
                    break;
                case WebTypeEnum.WebRoot:
                    fileName = "WebRoot.gz";
                    break;
                case WebTypeEnum.WebSamplingPlan:
                    fileName = $"WebSamplingPlan_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSector:
                    fileName = $"WebSector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSubsector:
                    fileName = $"WebSubsector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebTideLocation:
                    fileName = $"WebTideLocation.gz";
                    break;
                case WebTypeEnum.WebAllTVItem:
                    fileName = $"WebAllTVItem.gz";
                    break;
                case WebTypeEnum.WebAllTVItemLanguage:
                    fileName = $"WebAllTVItemLanguage.gz";
                    break;
                default:
                    return await Task.FromResult("WebError.gz");
            }

            return await Task.FromResult(fileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
