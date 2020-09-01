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
        bool LoginRequired { get; set; }
        bool UpdateIsNeeded { get; set; }
        bool HasNewTVItemsOrTVItemLanguages { get; set; }
        bool HasHelpFiles { get; set; }
        string CSSPDBFilesManagement { get; set; }
        string CSSPDBLogin { get; set; }
        string CSSPDBLocal { get; set; }
        string CSSPDBSearch { get; set; }
        string CSSPAzureUrl { get; set; }
        string CSSPLocalUrl { get; set; }
        Preference preference { get; set; }
        string LocalCSSPWebAPIsPath { get; set; }
        Contact contact { get; set; }

        // Functions
        Task<bool> CheckIfHelpFilesExist();
        Task<bool> CheckIfLoginIsRequired();
        Task<bool> CheckIfNewTVItemsOrTVItemLanguagesExist();
        Task<bool> CheckIfUpdateIsNeeded();
        Task<bool> CheckingInternetConnection();
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> FillCSSPDBSearch();
        Task<bool> InstallUpdates();
        Task<bool> Login(LoginModel loginModel);
        Task<bool> Logoff();
        Task<bool> ReadConfiguration();
        Task<bool> Register(RegisterModel registerModel);
        Task<bool> Start();
        Task<bool> Stop();
        Task<bool> UpdateCSSPDBSearch();

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
        public bool IsEnglish { get; set; }
        public bool LoginRequired { get; set; } = false;
        public bool UpdateIsNeeded { get; set; } = false;
        public bool HasNewTVItemsOrTVItemLanguages { get; set; } = false;
        public bool HasHelpFiles { get; set; } = false;
        public string CSSPDBFilesManagement { get; set; }
        public string CSSPDBLogin { get; set; }
        public string CSSPDBLocal { get; set; }
        public string CSSPDBSearch { get; set; }
        public string CSSPAzureUrl { get; set; }
        public string CSSPLocalUrl { get; set; }
        public Preference preference { get; set; }
        public string LocalCSSPWebAPIsPath { get; set; }
        public Contact contact { get; set; }
        #endregion Properties public

        #region Properties private
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBSearchContext dbSearch { get; }
        private CSSPDBLoginContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ILocalService LocalService { get; }
        private ICSSPDBSearchService CSSPDBSearchService { get; }
        private IReadGzFileService ReadGzFileService { get; }
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
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, 
            ILocalService LocalService, CSSPDBLocalContext dbLocal, CSSPDBSearchContext dbSearch, 
            CSSPDBLoginContext dbLogin, CSSPDBFilesManagementContext dbFM, IReadGzFileService ReadGzFileService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.LocalService = LocalService;
            this.dbLocal = dbLocal;
            this.dbSearch = dbSearch;
            this.dbLogin = dbLogin;
            this.dbFM = dbFM;
            this.CSSPDBSearchService = CSSPDBSearchService;
            this.ReadGzFileService = ReadGzFileService;

            preference = new Preference();
            contact = new Contact();
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
        public async Task<bool> CheckIfNewTVItemsOrTVItemLanguagesExist()
        {
            if (!await DoCheckIfNewTVItemsOrTVItemLanguagesExist()) return await Task.FromResult(false);

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
        public async Task<string> Descramble(string Text)
        {
            return await Task.FromResult(await LocalService.Descramble(Text));
        }
        public async Task<bool> FillCSSPDBSearch()
        {
            return await DoFillCSSPDBSearch();
        }
        public async Task<bool> InstallUpdates()
        {
            // need to stop CSSPWebAPIs so we can copy over some files 
            foreach (var process in Process.GetProcessesByName("CSSPWebAPIs"))
            {
                process.Kill();
            }

            if (!await Stop()) await Task.FromResult(false);

            if (!await DoInstallUpdates()) return await Task.FromResult(false);

            if (!OpenCSSPWebAPIs()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Login(LoginModel loginModel)
        {
            if (!await DoLogin(loginModel)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Logoff()
        {
            if (!await DoLogoff()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> ReadConfiguration()
        {
            if (!await DoReadConfiguration()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Register(RegisterModel registerModel)
        {
            if (!await DoRegister(registerModel)) return await Task.FromResult(false);

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
        public async Task<bool> UpdateCSSPDBSearch()
        {
            return await DoUpdateCSSPDBSearch();
        }
        #endregion Function public
    }
}
