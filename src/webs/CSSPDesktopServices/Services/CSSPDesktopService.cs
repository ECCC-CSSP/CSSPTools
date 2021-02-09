using CSSPCultureServices.Services;
using CSSPDBPreferenceServices;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using LocalServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CSSPHelperModels;
using CSSPDBPreferenceModels;
using CSSPDBSearchModels;
using CSSPDBCommandLogModels;
using CSSPDBFilesManagementModels;

namespace CSSPDesktopServices.Services
{
    public interface ICSSPDesktopService
    {
        // Properties
        bool IsEnglish { get; set; }
        //AppTextModel appTextModel { get; set; }
        bool LoginRequired { get; set; }
        bool UpdateIsNeeded { get; set; }
        //bool HasNewTVItemsOrTVItemLanguages { get; set; }
        bool HasCSSPOtherFiles { get; set; }
        string CSSPDBFilesManagement { get; set; }
        string CSSPDBPreference { get; set; }
        string CSSPDBLocal { get; set; }
        string CSSPDBSearch { get; set; }
        string CSSPDBCommandLog { get; set; }
        string CSSPAzureUrl { get; set; }
        string CSSPLocalUrl { get; set; }       
        string CSSPWebAPIsLocalPath { get; set; }
        string CSSPOtherFilesPath { get; set; }
        Contact contact { get; set; }
        //string AzureStore { get; set; }
        //string LoginEmail { get; set; }
        //string Password { get; set; }
        //bool HasInternetConnection { get; set; }
        //bool LoggedIn { get; set; }
        //string Token { get; set; }

        // Functions
        Task<bool> CheckIfCSSPOtherFilesExist();
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
        Task<Preference> GetPreferenceWithVariableName(string VariableName);

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
        public bool IsEnglish { get; set; }
        public bool LoginRequired { get; set; } = false;
        public bool UpdateIsNeeded { get; set; } = false;
        public bool HasCSSPOtherFiles { get; set; } = false;
        public string CSSPDBFilesManagement { get; set; }
        public string CSSPDBPreference { get; set; }
        public string CSSPDBLocal { get; set; }
        public string CSSPDBSearch { get; set; }
        public string CSSPDBCommandLog { get; set; }
        public string CSSPAzureUrl { get; set; }
        public string CSSPLocalUrl { get; set; }
        public string CSSPWebAPIsLocalPath { get; set; }
        public  string CSSPOtherFilesPath { get; set; }
        public Contact contact { get; set; }
        #endregion Properties public

        #region Properties private
        private CSSPDBContext dbLocal { get; }
        private CSSPDBSearchContext dbSearch { get; }
        private CSSPDBCommandLogContext dbCommandLog { get; }
        private CSSPDBPreferenceContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ILocalService LocalService { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private IPreferenceService PreferenceService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        private string CSSPDesktopPath { get; set; }
        private string CSSPDatabasesPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPFilesPath { get; set; }
        private string AzureStoreCSSPWebAPIsLocalPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private Process processCSSPWebAPIsLocal { get; set; }
        private Process processBrowser { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, 
            ILocalService LocalService, CSSPDBContext dbLocal, CSSPDBSearchContext dbSearch, CSSPDBCommandLogContext dbCommandLog, 
            CSSPDBPreferenceContext dbLogin, CSSPDBFilesManagementContext dbFM, IReadGzFileService ReadGzFileService, IPreferenceService PreferenceService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.LocalService = LocalService;
            this.dbLocal = dbLocal;
            this.dbSearch = dbSearch;
            this.dbCommandLog = dbCommandLog;
            this.dbLogin = dbLogin;
            this.dbFM = dbFM;
            this.ReadGzFileService = ReadGzFileService;
            this.PreferenceService = PreferenceService;

            contact = new Contact();
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckIfCSSPOtherFilesExist()
        {
            if (!await DoCheckIfCSSPOtherFilesExist()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CheckIfLoginIsRequired()
        {
            if (!await DoCheckIfLoginIsRequired()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CheckIfUpdateIsNeeded()
        {
            if (!await LocalService.SetLoggedInContactInfo()) return await Task.FromResult(false);

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
        public async Task<bool> FillCSSPDBSearch()
        {
            return await DoFillCSSPDBSearch();
        }
        public async Task<bool> InstallUpdates()
        {
            // need to stop CSSPWebAPIsLocal so we can copy over some files 
            foreach (var process in Process.GetProcessesByName("CSSPWebAPIsLocal"))
            {
                process.Kill();
            }

            if (!await Stop()) await Task.FromResult(false);

            if (!await LocalService.SetLoggedInContactInfo()) await Task.FromResult(false);           

            if (!await DoInstallUpdates()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Login(LoginModel loginModel)
        {
            if (!await DoLogin(loginModel)) return await Task.FromResult(false);

            if (!await LocalService.SetLoggedInContactInfo()) return await Task.FromResult(false);

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
        public async Task<Preference> GetPreferenceWithVariableName(string VariableName)
        {
            return await DoGetPreferenceWithVariableName(VariableName);
        }
        public async Task<Preference> AddOrModifyPreferenceWithVariableName(string VariableName, string VariableValue)
        {
            return await DoAddOrModifyPreference(VariableName, VariableValue);
        }
        #endregion Function public
    }
}
