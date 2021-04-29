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
//using CSSPDBFilesManagementServices;
using DownloadFileServices;
using CSSPDBFilesManagementModels;
using CSSPScrambleServices;
using LoggedInServices;
using CSSPWebModels;
using FilesManagementServices;
using CSSPDBPreferenceModels;

namespace ReadGzFileServices
{
    public interface IReadGzFileService
    {
        WebAppLoaded webAppLoaded { get; set; }
        Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0);
        Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0);
    }
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public WebAppLoaded webAppLoaded { get; set; } = new WebAppLoaded();

        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IDownloadFileService DownloadFileService { get; }
        private IFilesManagementService FilesManagementService { get; }
        private IScrambleService ScrambleService { get; }
        //private IPreferenceService PreferenceService { get; }
        private CSSPDBPreferenceContext dbPreference { get; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IScrambleService ScrambleService, IEnums enums, IDownloadFileService DownloadFileService, 
            IFilesManagementService CSSPDBFilesManagementService, CSSPDBPreferenceContext dbPreference /*, IPreferenceService PreferenceService*/)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.DownloadFileService = DownloadFileService;
            this.FilesManagementService = CSSPDBFilesManagementService;
            //this.PreferenceService = PreferenceService;
            this.dbPreference = dbPreference;

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            return await DoReadJSON<T>(webType, TVItemID);
        }
        public async Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            var actionRes = await ReadJSON<T>(webType, TVItemID);
            return (T)((OkObjectResult)actionRes.Result).Value;
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
