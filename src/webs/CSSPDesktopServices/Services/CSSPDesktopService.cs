using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using ReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using CSSPScrambleServices;
using ManageServices;
using LoggedInServices;

namespace CSSPDesktopServices.Services
{
    public interface ICSSPDesktopService
    {
        // Properties
        bool IsEnglish { get; set; }
        bool LoginRequired { get; set; }
        bool UpdateIsNeeded { get; set; }
        bool HasCSSPOtherFiles { get; set; }
        string CSSPDBManage { get; set; }
        string CSSPDBLocal { get; set; }
        string CSSPAzureUrl { get; set; }
        string CSSPLocalUrl { get; set; }       
        string CSSPWebAPIsLocalPath { get; set; }
        string CSSPOtherFilesPath { get; set; }
        Contact contact { get; set; }

        // Functions
        Task<bool> CheckIfCSSPOtherFilesExist();
        Task<bool> CheckIfLoginIsRequired();
        Task<bool> CheckIfUpdateIsNeeded();
        Task<bool> CheckingInternetConnection();
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> InstallUpdates();
        Task<bool> Login(LoginModel loginModel);
        Task<bool> Logoff();
        Task<bool> ReadConfiguration();
        Task<bool> Start();
        Task<bool> Stop();

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
        public string CSSPDBManage { get; set; }
        public string CSSPDBLocal { get; set; }
        public string CSSPAzureUrl { get; set; }
        public string CSSPLocalUrl { get; set; }
        public string CSSPWebAPIsLocalPath { get; set; }
        public  string CSSPOtherFilesPath { get; set; }
        public string CSSPTempFilesPath { get; set; }
        public string AzureStore { get; set; }
        public Contact contact { get; set; }
        #endregion Properties public

        #region Properties private
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private IScrambleService ScrambleService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        private string CSSPDesktopPath { get; set; }
        private string CSSPDatabasesPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string CSSPFilesPath { get; set; }
        private string AzureStoreCSSPWebAPIsLocalPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private Process processCSSPWebAPIsLocal { get; set; }
        private Process processBrowser { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
            CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage, IReadGzFileService ReadGzFileService, ILoggedInService LoggedInService,
            IScrambleService ScrambleService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbManage = dbManage;
            this.ReadGzFileService = ReadGzFileService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;

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
            if (!await LoggedInService.SetLoggedInLocalContactInfo()) return await Task.FromResult(false);

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
        public async Task<bool> InstallUpdates()
        {
            // need to stop CSSPWebAPIsLocal so we can copy over some files 
            foreach (var process in Process.GetProcessesByName("CSSPWebAPIsLocal"))
            {
                process.Kill();
            }

            if (!await Stop()) await Task.FromResult(false);

            if (!await LoggedInService.SetLoggedInLocalContactInfo()) return await Task.FromResult(false);

            if (!await DoInstallUpdates()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Login(LoginModel loginModel)
        {
            if (!await DoLogin(loginModel)) return await Task.FromResult(false);

            if (!await LoggedInService.SetLoggedInLocalContactInfo()) return await Task.FromResult(false);

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
        #endregion Function public

        #region Functions private
        #endregion Functions private
    }
}
