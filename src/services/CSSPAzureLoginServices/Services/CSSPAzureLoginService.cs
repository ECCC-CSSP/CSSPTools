using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPHelperModels;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

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
        private ICSSPLogService CSSPLogService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private string culture { get; set; }
        #endregion Properties private

        #region Constructors
        public CSSPAzureLoginService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService,
            ICSSPLogService CSSPLogService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPAzureLoginService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPAzureLoginService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPAzureLoginService") }");

            this.Configuration = Configuration;
            this.CSSPLogService = CSSPLogService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.dbManage = dbManage;

            culture = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? "fr-CA" : "en-CA";
        }
        #endregion Constructors

    }
}
