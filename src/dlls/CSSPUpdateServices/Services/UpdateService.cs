/*
 * Manually edited
 * 
 */
using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using LoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public interface ICSSPUpdateService
    {
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
        Task<ActionResult<bool>> UpdateChangedTVItemStats();
        Task<ActionResult<bool>> UploadAllFilesToAzure();
        Task<ActionResult<bool>> UploadAllJsonFilesToAzure();
        Task<ActionResult<bool>> UploadChangedFilesToAzure();
        Task<ActionResult<bool>> UploadChangedJsonFilesToAzure();

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
        private ILoggedInService LoggedInService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string CSSPFilesPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string LocalAppDataPath { get; set; }
        private string NationalBackupAppDataPath { get; set; }
        private string ComputerName { get; set; }
        private string azure_csspjson_backup_uncompress { get; set; }
        private string azure_csspjson_backup { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPUpdateService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            CSSPDBContext db, CSSPDBManageContext dbManage, ICSSPLogService CSSPLogService, ICreateGzFileService CreateGzFileService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.db = db;
            this.dbManage = dbManage;
            this.CSSPLogService = CSSPLogService;
            this.CreateGzFileService = CreateGzFileService;

            if (!ReadConfiguration().GetAwaiter().GetResult())
            {
                return;
            }
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<bool>> ClearOldUnnecessaryStats()
        {
            return await DoClearOldUnnecessaryStats();
        }
        public async Task<ActionResult<bool>> RemoveAzureDirectoriesNotFoundInTVFiles()
        {
            return await DoRemoveAzureDirectoriesNotFoundInTVFiles();
        }
        public async Task<ActionResult<bool>> RemoveAzureFilesNotFoundInTVFiles()
        {
            return await DoRemoveAzureFilesNotFoundInTVFiles();
        }
        public async Task<ActionResult<bool>> RemoveLocalDirectoriesNotFoundInTVFiles()
        {
            return await DoRemoveLocalDirectoriesNotFoundInTVFiles();
        }
        public async Task<ActionResult<bool>> RemoveLocalFilesNotFoundInTVFiles()
        {
            return await DoRemoveLocalFilesNotFoundInTVFiles();
        }
        public async Task<ActionResult<bool>> RemoveNationalBackupDirectoriesNotFoundInTVFiles()
        {
            return await DoRemoveNationalBackupDirectoriesNotFoundInTVFiles();
        }
        public async Task<ActionResult<bool>> RemoveNationalBackupFilesNotFoundInTVFiles()
        {
            return await DoRemoveNationalBackupFilesNotFoundInTVFiles();
        }
        public async Task<ActionResult<bool>> RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile()
        {
            return await DoRemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
        }
        public async Task<ActionResult<bool>> RemoveTVItemsNoAssociatedWithTVFiles()
        {
            return await DoRemoveTVItemsNoAssociatedWithTVFiles();
        }
        public async Task<ActionResult<bool>> UpdateAllTVItemStats()
        {
            return await DoUpdateAllTVItemStats();
        }
        public async Task<ActionResult<bool>> UpdateChangedTVItemStats()
        {
            return await DoUpdateChangedTVItemStats();
        }
        public async Task<ActionResult<bool>> UploadAllFilesToAzure()
        {
            return await DoUploadAllFilesToAzure();
        }
        public async Task<ActionResult<bool>> UploadAllJsonFilesToAzure()
        {
            return await DoUploadAllJsonFilesToAzure();
        }
        public async Task<ActionResult<bool>> UploadChangedFilesToAzure()
        {
            return await DoUploadChangedFilesToAzure();
        }
        public async Task<ActionResult<bool>> UploadChangedJsonFilesToAzure()
        {
            return await DoUploadChangedJsonFilesToAzure();
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
