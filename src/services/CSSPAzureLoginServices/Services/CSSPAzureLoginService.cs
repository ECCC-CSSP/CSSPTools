using CSSPCultureServices.Services;
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
using Microsoft.AspNetCore.Mvc;

namespace CSSPAzureLoginServices.Services
{
    public interface ICSSPAzureLoginService
    {
        Task<ActionResult<bool>> AzureLoginAsync(LoginModel loginModel);
    }
    public partial class CSSPAzureLoginService : ICSSPAzureLoginService
    {
        #region Variables
        #endregion Variables

        #region Properties public
        #endregion Properties public

        #region Properties private
        private Contact contact { get; set; } = new Contact();
        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private string culture { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPAzureLoginService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ICSSPScrambleService CSSPScrambleService,
            ICSSPLogService CSSPLogService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            //if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPAzureLoginService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPAzureLoginService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPAzureLoginService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPAzureLoginService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "CSSPAzureLoginService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPLogService = CSSPLogService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.dbManage = dbManage;

            culture = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? "fr-CA" : "en-CA";

        }
        #endregion Constructors

    }
}
