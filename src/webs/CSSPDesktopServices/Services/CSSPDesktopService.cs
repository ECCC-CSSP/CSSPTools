using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;

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
        Task<bool> CheckIfCSSPOtherFilesExistAsync();
        Task<bool> CheckIfLoginIsRequiredAsync();
        Task<bool> CheckIfUpdateIsNeededAsync();
        Task<bool> CheckingInternetConnectionAsync();
        Task<bool> CreateAllRequiredDirectoriesAsync();
        Task<bool> InstallUpdatesAsync();
        Task<bool> LoginAsync(LoginModel loginModel);
        Task<bool> LogoffAsync();
        Task<bool> StartAsync();
        Task<bool> StopAsync();

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
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private ICSSPReadGzFileService ReadGzFileService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        private Process processCSSPWebAPIsLocal { get; set; }
        private Process processBrowser { get; set; }
        private string AzureStoreHash { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPDesktopService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPScrambleService CSSPScrambleService,
            ICSSPLogService CSSPLogService, CSSPDBManageContext dbManage, ICSSPReadGzFileService ReadGzFileService, ICSSPLocalLoggedInService CSSPLocalLoggedInService)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
            if (ReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "ReadGzFileService") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");

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
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPLogService = CSSPLogService;
            this.dbManage = dbManage;
            this.ReadGzFileService = ReadGzFileService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;

            CSSPLocalLoggedInService.SetLoggedInContactInfo();

            if (CSSPLocalLoggedInService.LoggedInContactInfo == null || CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                CSSPLogService.AppendError(CSSPCultureServicesRes.NeedToBeLoggedIn);
                return;
            }

            AzureStoreHash = (from c in dbManage.Contacts
                              where c.ContactID == CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactID
                              select c.AzureStoreHash).FirstOrDefault();


            contact = new Contact();
        }
        #endregion Constructors

    }
}
