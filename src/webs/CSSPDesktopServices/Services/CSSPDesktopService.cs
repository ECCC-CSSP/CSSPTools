using CSSPDesktopServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public interface ICSSPDesktopService
    {
        // Properties
        bool IsEnglish { get; set; }
        AppTextModel appTextModel { get; set; }
        bool? HasInternetConnection { get; set; }
        bool LoginRequired { get; set; }
        string CSSPDesktopPath { get; set; }
        string CSSPDBLocal { get; set; }
        string CSSPDBFilesManagement { get; set; }
        string CSSPDBLogin { get; set; }

        // Functions
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> CheckingAvailableUpdate();
        Task CheckingInternetConnection();
        Task<bool> InstallUpdates();
        Task<bool> Start();
        Task<bool> Stop();
        Task<bool> AnalyseDirectoriesAndDatabases();
        Task<bool> Login(string LoginEmail, string Password);
        bool ReadConfiguration();
        
        // Events
        event EventHandler<ClearEventArgs> StatusClear;
        event EventHandler<AppendEventArgs> StatusAppend;
        event EventHandler<AppendTempEventArgs> StatusAppendTemp;
        event EventHandler<InstallingEventArgs> StatusInstalling;
        event EventHandler<ErrorMessageEventArgs> StatusErrorMessage;

    }
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTextModel appTextModel { get; set; }
        public bool? HasInternetConnection { get; set; } = null;
        public bool IsEnglish { get; set; }
        public bool LoginRequired { get; set; } = false;
        public string CSSPDBLocal { get; set; }
        public string CSSPDBFilesManagement { get; set; }
        public string CSSPDBLogin { get; set; }
        public string CSSPDesktopPath { get; set; }

        private IConfiguration Configuration { get; set; }
        private bool? StoreLocal { get; set; }
        private bool? StoreInAzure { get; set; }
        private string LocalCSSPWebAPIsPath { get; set; }
        private string LocalCSSPJSONPath { get; set; }
        private string LocalCSSPFilesPath { get; set; }
        private string AzureStoreCSSPWebAPIsPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string CSSPLocalUrl { get; set; }
        private Process processCSSPWebAPIs { get; set; }
        private Process processBrowser { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckingAvailableUpdate()
        {
            if (!await DoCheckingAvailableUpdate()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task CheckingInternetConnection()
        {
            await DoCheckingInternetConnection();
        }
        public async Task<bool> CreateAllRequiredDirectories()
        {
            if (!await DoCreateAllRequiredDirectories()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public bool ReadConfiguration()
        {
            CSSPDesktopPath = Configuration.GetValue<string>("CSSPDesktopPath");
            if (string.IsNullOrWhiteSpace(CSSPDesktopPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDesktopPath", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocal))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBLocal", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBFilesManagement", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            if (string.IsNullOrWhiteSpace(CSSPDBLogin))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPDBLogin", "appsettings_csspdesktop.json")));
                return false;
            }

            StoreLocal = Configuration.GetValue<bool>("StoreLocal");
            if (StoreLocal == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "StoreLocal", "appsettings_csspdesktop.json")));
                return false;
            }

            StoreInAzure = Configuration.GetValue<bool>("StoreInAzure");
            if (StoreInAzure == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "StoreInAzure", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPWebAPIsPath = Configuration.GetValue<string>("LocalCSSPWebAPIsPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPWebAPIsPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPWebAPIsPath", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPJSONPath = Configuration.GetValue<string>("LocalCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPJSONPath", "appsettings_csspdesktop.json")));
                return false;
            }

            LocalCSSPFilesPath = Configuration.GetValue<string>("LocalCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(LocalCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "LocalCSSPFilesPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPWebAPIsPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPWebAPIsPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPWebAPIsPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPJSONPath", "appsettings_csspdesktop.json")));
                return false;
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrWhiteSpace(AzureStoreCSSPFilesPath))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "AzureStoreCSSPFilesPath", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            if (string.IsNullOrWhiteSpace(CSSPAzureUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPAzureUrl", "appsettings_csspdesktop.json")));
                return false;
            }

            CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            if (string.IsNullOrWhiteSpace(CSSPLocalUrl))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel._CouldNotBeFoundInConfigurationFile_, "CSSPLocalUrl", "appsettings_csspdesktop.json")));
                return false;
            }

            return true;
        }
        public async Task<bool> Start()
        {
            if (!await DoStart()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Stop()
        {
            if (!await DoStop()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> InstallUpdates()
        {
            if (!await DoInstallUpdates()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> AnalyseDirectoriesAndDatabases()
        {
            if (!await DoAnalyseDirectoriesAndDatabases()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Login(string LoginEmail, string Password)
        {
            if (!await DoLogin(LoginEmail, Password)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Function public
    }
}
