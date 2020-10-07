/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using LocalServices;
using DownloadGzFileServices;
using CSSPDBFilesManagementServices;
using CSSPDBLoginServices;

namespace ReadGzFileServices
{
    public interface IReadGzFileService
    {
        Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear);
    }
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private IDownloadGzFileService DownloadGzFileService { get; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; }
        private IPreferenceService PreferenceService { get; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILocalService LocalService, 
            IEnums enums, IDownloadGzFileService DownloadGzFileService, ICSSPDBFilesManagementService CSSPDBFilesManagementService, IPreferenceService PreferenceService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.DownloadGzFileService = DownloadGzFileService;
            this.CSSPDBFilesManagementService = CSSPDBFilesManagementService;
            this.PreferenceService = PreferenceService;

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            return await DoReadJSON<T>(webType, TVItemID, webTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
