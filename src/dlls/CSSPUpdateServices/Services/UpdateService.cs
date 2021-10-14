/*
 * Manually edited
 * 
 */
using CreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSSPScrambleServices;

namespace CSSPUpdateServices
{
    public interface ICSSPUpdateService
    {
        Task<bool> RunCommand(string[] args);
        Task<ActionResult<bool>> ClearOldUnnecessaryStats();
        Task<ActionResult<bool>> RemoveAzureDirectoriesNotFoundInTVFiles();
        Task<ActionResult<bool>> RemoveAzureFilesNotFoundInTVFiles();
        Task<ActionResult<bool>> RemoveLocalDirectoriesNotFoundInTVFiles();
        Task<ActionResult<bool>> RemoveLocalFilesNotFoundInTVFiles();
        Task<ActionResult<bool>> RemoveNationalBackupDirectoriesNotFoundInTVFiles();
        Task<ActionResult<bool>> RemoveNationalBackupFilesNotFoundInTVFiles();
        Task<ActionResult<bool>> RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
        Task<ActionResult<bool>> RemoveTVItemsNoAssociatedWithTVFiles();
        Task<ActionResult<bool>> UpdateAllTVItemStats();
        Task<ActionResult<bool>> UpdateChangedTVItemStats(DateTime UpdateFromDate);
        Task<ActionResult<bool>> UploadAllFilesToAzure();
        Task<ActionResult<bool>> UploadAllJsonFilesToAzure();
        Task<ActionResult<bool>> UploadChangedFilesToAzure(DateTime UpdateFromDate);
        Task<ActionResult<bool>> UploadChangedJsonFilesToAzure(DateTime UpdateFromDate);

        Task<bool> GetNeedToChangedWebAllAddresses(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllContacts(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllCountries(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllEmails(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllHelpDocs(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllMunicipalities(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllMWQMLookupMPNs(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllPolSourceGroupings(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllPolSourceSiteEffectTerms(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllProvinces(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllReportTypes(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllSearch(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllTels(DateTime LastWriteTimeUtc);
        Task<bool> GetNeedToChangedWebAllTideLocations(DateTime LastWriteTimeUtc);

        Task<ActionResult<bool>> GetRunSiteSampleStatsForCountry(List<TVItemStat> TVItemStat2List);
        Task<ActionResult<bool>> GetRunSiteSampleStatsUnderProvince(List<TVItem> TVItemList, List<TVItem> TVItemProvList, List<TVItemStat> TVItemStat2List);
        List<TVTypeEnum> GetSubTVTypeForTVItemStat(TVTypeEnum TVType);

        Task<List<int>> GetTVItemIDListAllOfChangedMapInfo(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListAllOfChangedTVFile(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListAllOfChangedTVItem(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListAllOfChangedTVItemLink(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListAllOfChangedUseOfSite(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListCountryOfChangedEmailDistributionList(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListCountryOfChangedRainExceedance(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedBoxModel(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedInfrastructure(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedMikeScenario(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedVPScenario(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListProvinceOfChangedClimateSite(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListProvinceOfChangedDrogueRun(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListProvinceOfChangedHydrometricSite(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListProvinceOfChangedSamplingPlan(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListProvinceOfChangedTideSite(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedClassification(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedLabSheet(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameter(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMRun(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSample(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSite(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSubsector(DateTime LastWriteTimeUtc);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedPolSourceSite(DateTime LastWriteTimeUtc);

    }
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        #region Variables
        #endregion Variables

        #region Properties

        private IConfiguration Configuration { get; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        private DateTime UpdateFromDate { get; set; }

        #endregion Properties

        #region Constructors
        public CSSPUpdateService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService, 
            ICSSPScrambleService CSSPScrambleService, ICSSPLogService CSSPLogService, ICreateGzFileService CreateGzFileService, CSSPDBContext db, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
            if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (CreateGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CreateGzFileService") }");
            if (db == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["LocalAppDataPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LocalAppDataPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["NationalBackupAppDataPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "NationalBackupAppDataPath", "CreateGzFileService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPLogService = CSSPLogService;
            this.CreateGzFileService = CreateGzFileService;
            this.db = db;
            this.dbManage = dbManage;
        }
        #endregion Constructors

    }
}
