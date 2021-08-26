/*
 * Manually edited
 * 
 */
using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPLogServices;
using LoggedInServices;
using ManageServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public interface ICSSPUpdateService
    {
        Task<bool> ClearOldUnnecessaryStats();
        Task<bool> RemoveAzureDirectoriesNotFoundInTVFiles();
        Task<bool> RemoveAzureFilesNotFoundInTVFiles();
        Task<bool> RemoveLocalDirectoriesNotFoundInTVFiles();
        Task<bool> RemoveLocalFilesNotFoundInTVFiles();
        Task<bool> RemoveNationalBackupDirectoriesNotFoundInTVFiles();
        Task<bool> RemoveNationalBackupFilesNotFoundInTVFiles();
        Task<bool> RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
        Task<bool> RemoveTVItemsNoAssociatedWithTVFiles();
        Task<bool> UpdateAllTVItemStats();
        Task<bool> UpdateChangedTVItemStats();
        Task<bool> UploadAllFilesToAzure();
        Task<bool> UploadAllJsonFilesToAzure();
        Task<bool> UploadChangedFilesToAzure();
        Task<bool> UploadChangedJsonFilesToAzure();

        Task<bool> GetNeedToChangedWebAllAddresses(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllContacts(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllCountries(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllEmails(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllHelpDocs(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllMunicipalities(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllMWQMLookupMPNs(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllPolSourceGroupings(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllPolSourceSiteEffectTerms(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllProvinces(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllReportTypes(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllSearch(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllTels(DateTime LastUpdate);
        Task<bool> GetNeedToChangedWebAllTideLocations(DateTime LastUpdate);

        Task<List<int>> GetTVItemIDListAllOfChangedMapInfo(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListAllOfChangedTVFile(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListAllOfChangedTVItem(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListAllOfChangedTVItemLink(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListAllOfChangedUseOfSite(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListCountryOfChangedEmailDistributionList(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListCountryOfChangedRainExceedance(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedBoxModel(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedInfrastructure(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedMikeScenario(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListMunicipalityOfChangedVPScenario(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListProvinceOfChangedClimateSite(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListProvinceOfChangedDrogueRun(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListProvinceOfChangedHydrometricSite(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListProvinceOfChangedSamplingPlan(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListProvinceOfChangedTideSite(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedClassification(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedLabSheet(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameter(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMRun(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSample(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSite(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSubsector(DateTime LastUpdate);
        Task<List<int>> GetTVItemIDListSubsectorOfChangedPolSourceSite(DateTime LastUpdate);
    }
    public partial class CSSPUpdateService : ICSSPUpdateService
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
        public async Task<bool> ClearOldUnnecessaryStats()
        {
            return await DoClearOldUnnecessaryStats();
        }
        public async Task<bool> RemoveAzureDirectoriesNotFoundInTVFiles()
        {
            return await DoRemoveAzureDirectoriesNotFoundInTVFiles();
        }
        public async Task<bool> RemoveAzureFilesNotFoundInTVFiles()
        {
            return await DoRemoveAzureFilesNotFoundInTVFiles();
        }
        public async Task<bool> RemoveLocalDirectoriesNotFoundInTVFiles()
        {
            return await DoRemoveLocalDirectoriesNotFoundInTVFiles();
        }
        public async Task<bool> RemoveLocalFilesNotFoundInTVFiles()
        {
            return await DoRemoveLocalFilesNotFoundInTVFiles();
        }
        public async Task<bool> RemoveNationalBackupDirectoriesNotFoundInTVFiles()
        {
            return await DoRemoveNationalBackupDirectoriesNotFoundInTVFiles();
        }
        public async Task<bool> RemoveNationalBackupFilesNotFoundInTVFiles()
        {
            return await DoRemoveNationalBackupFilesNotFoundInTVFiles();
        }
        public async Task<bool> RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile()
        {
            return await DoRemoveTVFilesDoubleAssociatedWithTVItemsTypeFile();
        }
        public async Task<bool> RemoveTVItemsNoAssociatedWithTVFiles()
        {
            return await DoRemoveTVItemsNoAssociatedWithTVFiles();
        }
        public async Task<bool> UpdateAllTVItemStats()
        {
            return await DoUpdateAllTVItemStats();
        }
        public async Task<bool> UpdateChangedTVItemStats()
        {
            return await DoUpdateChangedTVItemStats();
        }
        public async Task<bool> UploadAllFilesToAzure()
        {
            return await DoUploadAllFilesToAzure();
        }
        public async Task<bool> UploadAllJsonFilesToAzure()
        {
            return await DoUploadAllJsonFilesToAzure();
        }
        public async Task<bool> UploadChangedFilesToAzure()
        {
            return await DoUploadChangedFilesToAzure();
        }
        public async Task<bool> UploadChangedJsonFilesToAzure()
        {
            return await DoUploadChangedJsonFilesToAzure();
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
