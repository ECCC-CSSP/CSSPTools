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
using CSSPFileServices.Models;
using CSSPLogServices;

namespace FileServices
{
    public interface IFileService
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
        Task<bool> FillConfigModel(CSSPFileServiceConfigModel config);
    }
    public partial class FileService : ControllerBase, IFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IManageFileService ManageFileService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private IEnums enums { get; }
        private CSSPFileServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        public FileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IEnums enums, ICSSPLogService CSSPLogService, IManageFileService ManageFileService) : base()
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.ManageFileService = ManageFileService;
            this.CSSPLogService = CSSPLogService;
        }
        #endregion Constructors
    }
}
