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
using System.Threading;
using FileServices;
using LoggedInServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IDownloadTempController
    {
        Task<ActionResult> DownloadTemp(string FileName);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class DownloadTempController : ControllerBase, IDownloadTempController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IFileService FileService { get; }
        #endregion Properties

        #region Constructors
        public DownloadTempController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IFileService FileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.FileService = FileService;

        }
        #endregion Constructors

        #region Functions public
        [Route("{FileName}")]
        [HttpGet]
        public async Task<ActionResult> DownloadTemp(string FileName)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await FileService.DownloadTempFile(FileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
