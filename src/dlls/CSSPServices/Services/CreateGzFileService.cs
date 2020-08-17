﻿/*
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

namespace CSSPServices
{
    public interface ICreateGzFileService
    {
        Task<bool> CreateAllGzFiles();
        Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
    }
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private bool StoreLocal { get; set; }
        private bool StoreInAzure { get; set; }
        private string AzureCSSPStorageConnectionString { get; set; }
        private string AzureCSSPStorageCustomerProvidedKey { get; set; }
        private string AzureCSSPStorageCSSPFiles { get; set; }
        private string AzureCSSPStorageCSSPJSON { get; set; }
        private string LocalJSONPath { get; set; }
        private string LocalFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public CreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            Setup();
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateAllGzFiles()
        {
            return await Task.FromResult(false);
            //return await DoCreateAllGzFiles();
        }
        public async Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    return await DoCreateWebRootGzFile();
                case WebTypeEnum.WebCountry:
                    return await DoCreateWebCountryGzFile(TVItemID); // TVItemID = CountryTVItemID
                case WebTypeEnum.WebProvince:
                    return await DoCreateWebProvinceGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebArea:
                    return await DoCreateWebAreaGzFile(TVItemID); // TVItemID = AreaTVItemID
                case WebTypeEnum.WebMunicipalities:
                    return await DoCreateWebMunicipalitiesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebSector:
                    return await DoCreateWebSectorGzFile(TVItemID); // TVItemID = SectorTVItemID
                case WebTypeEnum.WebSubsector:
                    return await DoCreateWebSubsectorGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMunicipality:
                    return await DoCreateWebMunicipalityGzFile(TVItemID); // TVItemID = MunicipalityTVItemID
                case WebTypeEnum.WebMWQMSample:
                    {
                        switch (webTypeYear)
                        {
                            case WebTypeYearEnum.Year1980:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 1980); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year1990:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 1990); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2000:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2000); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2010:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2010); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2020:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2020); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2030:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2030); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2040:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2040); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2050:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2050); // TVItemID = SubsectorTVItemID
                            default:
                                return await Task.FromResult(BadRequest($"{ webTypeYear } not implemented yet"));
                        }
                    }
                case WebTypeEnum.WebSamplingPlan:
                    return await DoCreateWebSamplingPlanGzFile(TVItemID); // TVItemID = SamplingPlanID
                case WebTypeEnum.WebMWQMRun:
                    return await DoCreateWebMWQMRunGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMSite:
                    return await DoCreateWebMWQMSiteGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebContact:
                    return await DoCreateWebContactGzFile();
                case WebTypeEnum.WebClimateSite:
                    return await DoCreateWebClimateSiteGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebHydrometricSite:
                    return await DoCreateWebHydrometricSiteGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebDrogueRun:
                    return await DoCreateWebDrogueRunGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMLookupMPN:
                    return await DoCreateWebMWQMLookupMPNGzFile();
                case WebTypeEnum.WebMikeScenario:
                    return await DoCreateWebMikeScenarioGzFile(TVItemID); // TVItemID = MikeScenarioTVItemID
                case WebTypeEnum.WebClimateDataValue:
                    return await DoCreateWebClimateDataValueGzFile(TVItemID); // TVItemID = ClimateSiteTVItemID
                case WebTypeEnum.WebHydrometricDataValue:
                    return await DoCreateWebHydrometricDataValueGzFile(TVItemID); // TVItemID = HydrometricSiteTVItemID
                case WebTypeEnum.WebHelpDoc:
                    return await DoCreateWebHelpDocGzFile();
                case WebTypeEnum.WebTideLocation:
                    return await DoCreateWebTideLocationGzFile();
                case WebTypeEnum.WebPolSourceSite:
                    return await DoCreateWebPolSourceSiteGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebPolSourceGrouping:
                    return await DoCreateWebPolSourceGroupingGzFile();
                case WebTypeEnum.WebReportType:
                    return await DoCreateWebReportTypeGzFile();
                default:
                    return await Task.FromResult(BadRequest($"{ webType } not implemented yet"));
            }
        }
        #endregion Functions public

        #region Functions private
        private void Setup()
        {
            StoreLocal = bool.Parse(Configuration.GetValue<string>("StoreLocal"));
            StoreInAzure = bool.Parse(Configuration.GetValue<string>("StoreInAzure"));
            AzureCSSPStorageConnectionString = Configuration.GetValue<string>("AzureCSSPStorageConnectionString");
            AzureCSSPStorageCustomerProvidedKey = Configuration.GetValue<string>("AzureCSSPStorageCustomerProvidedKey");
            AzureCSSPStorageCSSPFiles = Configuration.GetValue<string>("AzureCSSPStorageCSSPFiles");
            AzureCSSPStorageCSSPJSON = Configuration.GetValue<string>("AzureCSSPStorageCSSPJSON");

            if (StoreLocal)
            {
                List<string> StoragePathList = new List<string>() { "LocalJSONPath", "LocalFilesPath" };
                foreach (string StoragePath in StoragePathList)
                {
                    if (Configuration.GetValue<string>(StoragePath) == null)
                    {
                        throw new Exception($"{ String.Format(CSSPCultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, StoragePath) }");
                    }

                    DirectoryInfo di = new DirectoryInfo(Configuration.GetValue<string>(StoragePath));

                    if (!di.Exists)
                    {
                        try
                        {
                            di.Create();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    if (StoragePath == "LocalJSONPath")
                    {
                        LocalJSONPath = di.FullName;
                    }

                    if (StoragePath == "LocalFilesPath")
                    {
                        LocalFilesPath = di.FullName;
                    }
                }
            }
        }
        #endregion Functions private
    }
}
