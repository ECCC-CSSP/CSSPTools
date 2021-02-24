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
using DownloadFileServices;
using LoggedInServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IDownloadController
    {
        Task<ActionResult> Download(int ParentTVItemID, string FileName);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class DownloadController : ControllerBase, IDownloadController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IDownloadFileService DownloadFileService { get; }
        #endregion Properties

        #region Constructors
        public DownloadController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IDownloadFileService DownloadFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.DownloadFileService = DownloadFileService;

        }
        #endregion Constructors

        #region Functions public
        [Route("{ParentTVItemID}/{FileName}")]
        [HttpGet]
        public async Task<ActionResult> Download(int ParentTVItemID, string FileName)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await DownloadFileService.DownloadFile(ParentTVItemID, FileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
