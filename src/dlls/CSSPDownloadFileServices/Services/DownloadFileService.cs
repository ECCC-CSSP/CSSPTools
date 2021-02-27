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
using CSSPDBFilesManagementServices;
using CSSPDBFilesManagementModels;
using CSSPScrambleServices;
using LoggedInServices;
//using WebAppLoadedServices;

namespace DownloadFileServices
{
    public interface IDownloadFileService
    {
        Task<ActionResult> DownloadOtherFile(string FileName);
        Task<ActionResult> DownloadFile(int ParentTVItemID, string FileName);
        Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
        Task<ActionResult<bool>> LocalizeAzureFile(int ParentTVItemID, string FileName);
    }
    public partial class DownloadFileService : ControllerBase, IDownloadFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; }
        //private IWebAppLoadedService WebAppLoadedService { get;  }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string CSSPFilesPath { get; set; }
        private string CSSPOtherFilesPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        #endregion Properties

        #region Constructors
        public DownloadFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IScrambleService ScrambleService, IEnums enums, ICSSPDBFilesManagementService CSSPDBFilesManagementService/*, IWebAppLoadedService WebAppLoadedService*/) : base()
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.CSSPDBFilesManagementService = CSSPDBFilesManagementService;
            //this.WebAppLoadedService = WebAppLoadedService;

            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            CSSPOtherFilesPath = Configuration.GetValue<string>("CSSPOtherFilesPath");
            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult> DownloadOtherFile(string FileName)
        {
            return await DoDownloadOtherFile(FileName);
        }
        public async Task<ActionResult> DownloadFile(int ParentTVItemID, string FileName)
        {
            return await DoDownloadFile(ParentTVItemID, FileName);
        }
        public async Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            return await DoDownloadGzFile(webType, TVItemID, webTypeYear);
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
