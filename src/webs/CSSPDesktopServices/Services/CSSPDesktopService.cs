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
        bool UpdateIsNeeded { get; set; }
        bool IsLoggedIn { get; set; }
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
        string LocalCSSPWebAPIsPath { get; set; }

        // Functions
        Task<bool> CheckIfHelpFilesExist();
        bool CheckIfLoginIsRequired();
        bool CheckIfUpdateIsNeeded();
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> CheckingAvailableUpdate();
        Task CheckingInternetConnection();
        bool InstallUpdates();
        Task<bool> Start();
        bool Stop();
        bool Login(string LoginEmail, string Password);
        void Logoff();
        Task<bool> ReadConfiguration();
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
        public bool UpdateIsNeeded { get; set; } = false;
        public bool IsLoggedIn { get; set; } = false;
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
        public string LocalCSSPWebAPIsPath { get; set; }

        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBLoginContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        private bool? StoreLocal { get; set; }
        private bool? StoreInAzure { get; set; }
        private string LocalCSSPDesktopPath { get; set; }
        private string LocalCSSPDatabasesPath { get; set; }
        private string LocalCSSPJSONPath { get; set; }
        private string LocalCSSPFilesPath { get; set; }
        private string AzureStoreCSSPWebAPIsPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
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
        public bool CheckIfLoginIsRequired()
        {
            if (!DoCheckIfLoginIsRequired()) return false;

            return true;
        }
        public bool CheckIfUpdateIsNeeded()
        {
            if (! DoCheckIfUpdateIsNeeded()) return false;

            return true;
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
        public bool Stop()
        {
            if (! DoStop()) return false;

            return true;
        }
        public bool InstallUpdates()
        {
            if (! DoInstallUpdates()) return false;

            return true;
        }
        public bool Login(string LoginEmail, string Password)
        {
            this.LoginEmail = LoginEmail;
            this.Password = Password;

            if (! DoLogin(LoginEmail, Password)) return false;

            return true;
        }
        public void Logoff()
        {
            DoLogoff();
        }
        public string Descramble(string Text)
        {
            return DoDescramble(Text);
        }
        #endregion Function public
    }
}
