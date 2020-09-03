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

namespace CSSPServices
{
    public interface IDownloadGzFileService
    {
        Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
    }
    public partial class DownloadGzFileService : ControllerBase, IDownloadGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private ICSSPFileService CSSPFileService { get; }
        private string AzureStoreConnectionString { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string LocalCSSPJSONPath { get; set; }
        private string LocalFilesPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public DownloadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILocalService LocalService, 
            IEnums enums, ICSSPFileService CSSPFileService) : base()
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.CSSPFileService = CSSPFileService;

            AzureStoreConnectionString = Configuration.GetValue<string>("AzureStoreConnectionString");
            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            LocalCSSPJSONPath = Configuration.GetValue<string>("LocalCSSPJSONPath");
            LocalFilesPath = Configuration.GetValue<string>("LocalFilesPath");
            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            return await DoDownloadGzFile(webType, TVItemID, webTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
