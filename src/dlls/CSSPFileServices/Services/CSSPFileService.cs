/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using CSSPWebModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using LoggedInServices;
using ManageServices;
using CSSPLogServices;

namespace CSSPFileServices
{
    public interface ICSSPFileService
    {
        Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel);
        Task<ActionResult<bool>> CreateTempPNG(HttpRequest request);
        Task<ActionResult> DownloadTempFile(string FileName);
        Task<ActionResult> DownloadOtherFile(string FileName);
        Task<ActionResult> DownloadFile(int ParentTVItemID, string FileName);
        Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID = 0);
        Task<ActionResult<bool>> LocalizeAzureFile(int ParentTVItemID, string FileName);
        Task<ActionResult<LocalFileInfo>> GetAzureFileInfo(int ParentTVItemID, string FileName);
        Task<ActionResult<LocalFileInfo>> GetLocalFileInfo(int ParentTVItemID, string FileName);
        Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int ParentTVItemID);
    }
    public partial class CSSPFileService : ControllerBase, ICSSPFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private IManageFileService ManageFileService { get; }
        #endregion Properties

        #region Constructors
        public CSSPFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService, 
            ICSSPLogService CSSPLogService, IManageFileService ManageFileService) : base()
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (LoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "LoggedInService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (ManageFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "ManageFileService") }");

            if (string.IsNullOrEmpty(Configuration["APISecret"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "APISecret", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPFileService") }");
            //if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPFileService") }");
            //if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsPath", "CSSPFileService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.LoggedInService = LoggedInService;
            this.CSSPLogService = CSSPLogService;
            this.ManageFileService = ManageFileService;
        }
        #endregion Constructors
    }
}
