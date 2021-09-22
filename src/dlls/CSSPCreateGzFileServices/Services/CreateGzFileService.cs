/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public interface ICreateGzFileService
    {
        Task<ActionResult<bool>> CreateAllGzFiles();
        Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID = 0);
        Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID = 0);
    }
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private ICSSPLogService CSSPLogService { get; set; }
        //private CSSPCreateGzFileServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        public CreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,
            ICSSPLogService CSSPLogService, CSSPDBContext db = null, CSSPDBLocalContext dbLocal = null)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (LoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "LoggedInService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (db == null && dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db && dbLocal") }");

            if (string.IsNullOrEmpty(Configuration["APISecret"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "APISecret", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["ComputerName"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "ComputerName", "CreateGzFileService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.CSSPLogService = CSSPLogService;
            this.db = db;
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
