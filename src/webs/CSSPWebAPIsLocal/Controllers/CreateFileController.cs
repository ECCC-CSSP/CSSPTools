/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using ReadGzFileServices;
using System.Threading;
using CSSPWebModels;
using LoggedInServices;
using CSSPDBLocalServices;
using System.IO;
using CreateFileServices;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System;
using Microsoft.Extensions.Configuration;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ICreateFileController
    {
        Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class CreateFileController : ControllerBase, ICreateFileController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ICreateFileService CreateFileService { get; }
        #endregion Properties

        #region Constructors
        public CreateFileController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            ICreateFileService CreateFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.CreateFileService = CreateFileService;
        }
        #endregion Constructors

        #region Functions public
        [HttpPost]
        [Route("CreateTempCSV")]
        public async Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await CreateFileService.CreateTempCSV(tableConvertToCSVModel);
        }
        [HttpPost]
        [Route("CreateTempPNG")]
        public async Task<ActionResult<bool>> CreateTempPNG()
        {

            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await CreateFileService.CreateTempPNG(Request);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
