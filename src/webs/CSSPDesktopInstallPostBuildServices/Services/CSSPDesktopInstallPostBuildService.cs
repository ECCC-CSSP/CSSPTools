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

namespace CSSPDesktopInstallPostBuildServices.Services
{
    public interface ICSSPDesktopInstallPostBuildService
    {
        Task<bool> CSSPOtherFilesCompressAndSendToAzureAsync();
        Task<bool> CSSPWebAPIsLocalCompressAndSendToAzureAsync();
        Task<bool> CSSPClientCompressAndSendToAzureAsync();
        Task<bool> LoginAsync();
        bool IsEnglish { get; set; }
        Contact contact { get; set; }
        string AzureStoreHash { get; set; }
    }
    public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
    {
        #region Variables
        #endregion Variables

        #region Properties public
        public bool IsEnglish { get; set; } = true;
        public Contact contact { get; set; }
        public string AzureStoreHash { get; set; }
        #endregion Properties public

        #region Properties private
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPScrambleService CSSPScrambleService { get; }
        #endregion Properties private

        #region Constructors
        public CSSPDesktopInstallPostBuildService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ICSSPScrambleService CSSPScrambleService)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");

            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPDesktopInstallPostBuildService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDesktopInstallPostBuildService") }");
            if (string.IsNullOrEmpty(Configuration["LoginEmail"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LoginEmail", "CSSPDesktopInstallPostBuildService") }");
            if (string.IsNullOrEmpty(Configuration["Password"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "Password", "CSSPDesktopInstallPostBuildService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPScrambleService = CSSPScrambleService;
        }
        #endregion Constructors

        #region Functions public
        #endregion Function public

        #region Functions private
        #endregion Functions private
    }
}
