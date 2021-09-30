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
using CSSPLocalLoggedInServices;
using CSSPDBLocalServices;
using System.IO;
using CSSPFileServices;
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
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ICSSPFileService FileService { get; }
        #endregion Properties

        #region Constructors
        public CreateFileController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, 
            ICSSPFileService FileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.FileService = FileService;
        }
        #endregion Constructors

        #region Functions public
        [Route("CreateTempCSV")]
        [HttpPost]
        public async Task<ActionResult<bool>> CreateTempCSV(TableConvertToCSVModel tableConvertToCSVModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await FileService.CreateTempCSV(tableConvertToCSVModel);
        }
        [Route("CreateTempPNG")]
        [HttpPost]
        public async Task<ActionResult<bool>> CreateTempPNG()
        {

            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await FileService.CreateTempPNG(Request);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
