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
using ManageServices;
using LoggedInServices;
using CSSPCultureServices.Resources;

namespace CSSPDesktopServices.Services
{
    public interface ICSSPDesktopService
    {
        // Properties
        bool IsEnglish { get; set; }
        bool LoginRequired { get; set; }
        bool UpdateIsNeeded { get; set; }
        bool HasCSSPOtherFiles { get; set; }
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
        public Contact contact { get; set; }
        #endregion Properties public

        #region Properties private
        //private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private ILoggedInService LoggedInService { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        private Process processCSSPWebAPIsLocal { get; set; }
        private Process processBrowser { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
            CSSPDBManageContext dbManage, IReadGzFileService ReadGzFileService, ILoggedInService LoggedInService)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
            if (ReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "ReadGzFileService") }");
            if (LoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "LoggedInService") }");

            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPDesktopService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "CSSPDesktopService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.dbManage = dbManage;
            this.ReadGzFileService = ReadGzFileService;
            this.LoggedInService = LoggedInService;

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
        //public async Task<bool> ReadConfiguration()
        //{
        //    if (!await DoReadConfiguration()) return await Task.FromResult(false);

        //    return await Task.FromResult(true);
        //}
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
