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
