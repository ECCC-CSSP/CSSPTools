using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        bool HasHelpFiles { get; set; }
        string CSSPDBLocal { get; set; }
        string CSSPDBFilesManagement { get; set; }
        string CSSPDBLogin { get; set; }
        string CSSPAzureUrl { get; set; }
        string CSSPLocalUrl { get; set; }
        string LoginEmail { get; set; }
        string Password { get; set; }
        Contact ContactLoggedIn { get; set; }
        string AzureStore { get; set; }
        string LocalCSSPHelpPath { get; set; }

        // Functions
        Task<bool> CheckIfHelpFilesExist();
        Task<bool> CheckIfLoginIsRequired();
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> AnalyseDirectoriesAndDatabases();
        Task<bool> CheckingAvailableUpdate();
        Task CheckingInternetConnection();
        Task<bool> InstallUpdates();
        Task<bool> Start();
        Task<bool> Stop();
        Task<bool> Login(string LoginEmail, string Password);
        Task<bool> ReadConfiguration();
        Task<bool> UnzipHelp();
        string Descramble(string Text);

        //string Scramble(string Text);
        //string Descramble(string Text);

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
        public bool HasHelpFiles { get; set; } = false;
        public string CSSPDBLocal { get; set; }
        public string CSSPDBFilesManagement { get; set; }
        public string CSSPDBLogin { get; set; }
        public string CSSPAzureUrl { get; set; }
        public string CSSPLocalUrl { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public Contact ContactLoggedIn { get; set; }
        public string AzureStore { get; set; }
        public string LocalCSSPHelpPath { get; set; }

        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        //private CSSPDBInMemoryContext dbIM { get; }
        private CSSPDBLoginContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        //private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        private bool? StoreLocal { get; set; }
        private bool? StoreInAzure { get; set; }
        private string LocalCSSPDatabasesPath { get; set; }
        private string LocalCSSPWebAPIsPath { get; set; }
        private string LocalCSSPJSONPath { get; set; }
        private string LocalCSSPFilesPath { get; set; }
        private string AzureStoreCSSPWebAPIsPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string AzureStoreCSSPHelpPath { get; set; }
        private Process processCSSPWebAPIs { get; set; }
        private Process processBrowser { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            IEnums enums, CSSPDBLocalContext dbLocal = null, CSSPDBLoginContext dbLogin = null, CSSPDBFilesManagementContext dbFM = null)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbLogin = dbLogin;
            this.dbFM = dbFM;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckIfHelpFilesExist()
        {
            if (!await DoCheckIfHelpFilesExist()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CheckIfLoginIsRequired()
        {
            if (!await DoCheckIfLoginIsRequired()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
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
        public async Task<bool> ReadConfiguration()
        {
            if (!await DoReadConfiguration()) return await Task.FromResult(false);

            return await Task.FromResult(true);
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
            this.LoginEmail = LoginEmail;
            this.Password = Password;

            if (!await DoLogin(LoginEmail, Password)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> UnzipHelp()
        {
            if (!await DoUnzipHelp()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public string Descramble(string Text)
        {
            return DoDescramble(Text);
        }
        #endregion Function public
    }
}
