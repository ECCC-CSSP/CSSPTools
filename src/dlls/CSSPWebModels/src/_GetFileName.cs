/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSSPWebModels
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
                case WebTypeYearEnum.Year1980: Year = 1980; break;
                case WebTypeYearEnum.Year1990: Year = 1990; break;
                case WebTypeYearEnum.Year2000: Year = 2000; break;
                case WebTypeYearEnum.Year2010: Year = 2010; break;
                case WebTypeYearEnum.Year2020: Year = 2020; break;
                case WebTypeYearEnum.Year2030: Year = 2030; break;
                case WebTypeYearEnum.Year2040: Year = 2040; break;
                case WebTypeYearEnum.Year2050: Year = 2050; break;
                default: Year = 0; break;
            }

            switch (webType)
            {
                case WebTypeEnum.WebAllContacts: fileName = $"{ WebTypeEnum.WebAllContacts }.gz"; break;
                case WebTypeEnum.WebAllCountries: fileName = $"{ WebTypeEnum.WebAllCountries }.gz"; break;
                case WebTypeEnum.WebAllHelpDocs: fileName = $"{ WebTypeEnum.WebAllHelpDocs }.gz"; break;
                case WebTypeEnum.WebAllMWQMLookupMPNs: fileName = $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz"; break;
                case WebTypeEnum.WebAllMunicipalities: fileName = $"{ WebTypeEnum.WebAllMunicipalities }.gz"; break;
                case WebTypeEnum.WebAllPolSourceGroupings: fileName = $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz"; break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms: fileName = $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz"; break;
                case WebTypeEnum.WebAllProvinces: fileName = $"{ WebTypeEnum.WebAllProvinces }.gz"; break;
                case WebTypeEnum.WebAllReportTypes: fileName = $"{ WebTypeEnum.WebAllReportTypes }.gz"; break;
                case WebTypeEnum.WebAllTideLocations: fileName = $"{ WebTypeEnum.WebAllTideLocations }.gz"; break;
                case WebTypeEnum.WebAllTVItems: fileName = $"{ WebTypeEnum.WebAllTVItems }.gz"; break;
                case WebTypeEnum.WebAllTVItemLanguages: fileName = $"{ WebTypeEnum.WebAllTVItemLanguages }.gz"; break;
                case WebTypeEnum.WebArea: fileName = $"{ WebTypeEnum.WebArea }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebClimateDataValue: fileName = $"{ WebTypeEnum.WebClimateDataValue }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebClimateSite: fileName = $"{ WebTypeEnum.WebClimateSite }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebCountry: fileName = $"{ WebTypeEnum.WebCountry }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebDrogueRun: fileName = $"{ WebTypeEnum.WebDrogueRun }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebHydrometricDataValue: fileName = $"{ WebTypeEnum.WebHydrometricDataValue }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebHydrometricSite: fileName = $"{ WebTypeEnum.WebHydrometricSite }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebMikeScenario: fileName = $"{ WebTypeEnum.WebMikeScenario }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebMunicipalities: fileName = $"{ WebTypeEnum.WebMunicipalities }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebMunicipality: fileName = $"{ WebTypeEnum.WebMunicipality }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebMWQMRun: fileName = $"{ WebTypeEnum.WebMWQMRun }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebMWQMSample: fileName = $"{ WebTypeEnum.WebMWQMSample }_{ TVItemID }_{ Year }_{ Year + 9 }.gz"; break;
                case WebTypeEnum.WebMWQMSite: fileName = $"{ WebTypeEnum.WebMWQMSite }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebPolSourceSite: fileName = $"{ WebTypeEnum.WebPolSourceSite }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebProvince: fileName = $"{ WebTypeEnum.WebProvince }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebRoot: fileName = $"{ WebTypeEnum.WebRoot }.gz"; break;
                case WebTypeEnum.WebSamplingPlan: fileName = $"{ WebTypeEnum.WebSamplingPlan }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebSector: fileName = $"{ WebTypeEnum.WebSector }_{ TVItemID }.gz"; break;
                case WebTypeEnum.WebSubsector: fileName = $"{ WebTypeEnum.WebSubsector }_{ TVItemID }.gz"; break;
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
