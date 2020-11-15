﻿/*
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
using CSSPDBFilesManagementModels;

namespace DownloadFileServices
{
    public interface IDownloadFileService
    {
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
        private ILocalService LocalService { get; }
        private IEnums enums { get; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; }
        private string AzureStoreConnectionString { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string CSSPFilesPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        #endregion Properties

        #region Constructors
        public DownloadFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILocalService LocalService, 
            IEnums enums, ICSSPDBFilesManagementService CSSPDBFilesManagementService) : base()
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.enums = enums;
            this.CSSPDBFilesManagementService = CSSPDBFilesManagementService;

            AzureStoreConnectionString = Configuration.GetValue<string>("AzureStoreConnectionString");
            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
        }
        #endregion Constructors

        #region Functions public
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