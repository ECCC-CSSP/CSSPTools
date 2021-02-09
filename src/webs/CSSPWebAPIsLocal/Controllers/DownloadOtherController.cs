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
using LocalServices;
using System.Threading;
using DownloadFileServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IDownloadOtherController
    {
        Task<ActionResult> DownloadOther(string FileName);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class DownloadOtherController : ControllerBase, IDownloadOtherController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IDownloadFileService DownloadFileService { get; }
        #endregion Properties

        #region Constructors
        public DownloadOtherController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IDownloadFileService DownloadFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.DownloadFileService = DownloadFileService;

        }
        #endregion Constructors

        #region Functions public
        [Route("{FileName}")]
        [HttpGet]
        public async Task<ActionResult> DownloadOther(string FileName)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await DownloadFileService.DownloadOtherFile(FileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
