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
        Task<bool> CheckIfLoginIsRequired();
        Task<bool> CheckIfUpdateIsNeeded();
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> CheckingInternetConnection();
        Task<bool> InstallUpdates();
        Task<bool> Start();
        Task<bool> Stop();
        Task<bool> Login(string LoginEmail, string Password);
        Task<bool> Logoff();
        Task<bool> ReadConfiguration();
        Task<string> Descramble(string Text);

        //string Scramble(string Text);
        //string Descramble(string Text);

        // Events
        event EventHandler<ClearEventArgs> StatusClear;
        event EventHandler<AppendEventArgs> StatusAppend;
        event EventHandler<InstallingEventArgs> StatusInstalling;

    }
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Variables
        #endregion Variables

        #region Properties public
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
        #endregion Properties public
        
        #region Properties private
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBLoginContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        private string LocalCSSPDesktopPath { get; set; }
        private string LocalCSSPDatabasesPath { get; set; }
        private string LocalCSSPJSONPath { get; set; }
        private string LocalCSSPFilesPath { get; set; }
        private string AzureStoreCSSPWebAPIsPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private Process processCSSPWebAPIs { get; set; }
        private Process processBrowser { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            IEnums enums, CSSPDBLocalContext dbLocal = null, CSSPDBLoginContext dbLogin = null,
            CSSPDBFilesManagementContext dbFM = null)
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
        public async Task<bool> CheckIfUpdateIsNeeded()
        {
            if (!await DoCheckIfUpdateIsNeeded()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CheckingInternetConnection()
        {
            if(!await DoCheckingInternetConnection()) return await Task.FromResult(false);

            return await Task.FromResult(true);
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
        public async Task<bool> Login(string LoginEmail, string Password)
        {
            this.LoginEmail = LoginEmail;
            this.Password = Password;

            if (!await DoLogin(LoginEmail, Password)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Logoff()
        {
            if (!await DoLogoff()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<string> Descramble(string Text)
        {
            return await Task.FromResult(DoDescramble(Text));
        }
        #endregion Function public
    }
}
