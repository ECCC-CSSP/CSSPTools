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
        private IEnums enums { get; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string CSSPFilesPath { get; set; }
        private string CSSPOtherFilesPath { get; set; }
        private string CSSPTempFilesPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        #endregion Properties

        #region Constructors
        public FileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IEnums enums, IManageFileService ManageFileService) : base()
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.ManageFileService = ManageFileService;

            AzureStore = LoggedInService.Descramble(Configuration.GetValue<string>("AzureStore"));
            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            CSSPOtherFilesPath = Configuration.GetValue<string>("CSSPOtherFilesPath");
            CSSPTempFilesPath = Configuration.GetValue<string>("CSSPTempFilesPath");
            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel)
        {
            return await DoCreateTempCSV(tableConvertToCSVModel);
        }
        public async Task<ActionResult<bool>> CreateTempPNG(HttpRequest request)
        {
            return await DoCreateTempPNG(request);
        }
        public async Task<ActionResult> DownloadFile(int ParentTVItemID, string FileName)
        {
            return await DoDownloadFile(ParentTVItemID, FileName);
        }
        public async Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID)
        {
            return await DoDownloadGzFile(webType, TVItemID);
        }
        public async Task<ActionResult> DownloadOtherFile(string FileName)
        {
            return await DoDownloadOtherFile(FileName);
        }
        public async Task<ActionResult> DownloadTempFile(string FileName)
        {
            return await DoDownloadTempFile(FileName);
        }
        public async Task<ActionResult<LocalFileInfo>> GetAzureFileInfo(int ParentTVItemID, string FileName)
        {
            return await DoGetAzureFileInfo(ParentTVItemID, FileName);
        }
        public async Task<ActionResult<LocalFileInfo>> GetLocalFileInfo(int ParentTVItemID, string FileName)
        {
            return await DoGetLocalFileInfo(ParentTVItemID, FileName);
        }
        public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int ParentTVItemID)
        {
            return await DoGetLocalFileInfoList(ParentTVItemID);
        }
        public async Task<ActionResult<bool>> LocalizeAzureFile(int ParentTVItemID, string FileName)
        {
            return await DoLocalizeAzureFile(ParentTVItemID, FileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
