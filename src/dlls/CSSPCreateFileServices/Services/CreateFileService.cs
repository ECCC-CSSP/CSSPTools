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
using CSSPDBFilesManagementModels;
using CSSPScrambleServices;
using LoggedInServices;
using FilesManagementServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Http;

namespace CreateFileServices
{
    public interface ICreateFileService
    {
        Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel);
        Task<ActionResult<bool>> CreateTempPNG(HttpRequest request);
    }
    public partial class CreateFileService : ControllerBase, ICreateFileService
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
        private string CSSPTempFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public CreateFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IScrambleService ScrambleService, IEnums enums) : base()
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;

            CSSPTempFilesPath = Configuration.GetValue<string>("CSSPTempFilesPath");
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
