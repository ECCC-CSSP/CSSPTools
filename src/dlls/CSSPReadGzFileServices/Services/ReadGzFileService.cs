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
using LocalServices;
using CSSPDBFilesManagementServices;
using CSSPDBPreferenceServices;
using DownloadFileServices;

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
        private IDownloadFileService DownloadFileService { get; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; }
        private IPreferenceService PreferenceService { get; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILocalService LocalService, 
            IEnums enums, IDownloadFileService DownloadFileService, ICSSPDBFilesManagementService CSSPDBFilesManagementService, IPreferenceService PreferenceService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.DownloadFileService = DownloadFileService;
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
