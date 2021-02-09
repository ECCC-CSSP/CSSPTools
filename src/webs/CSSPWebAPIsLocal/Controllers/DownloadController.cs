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
        private ILocalService LocalService { get; }
        private IDownloadFileService DownloadFileService { get; }
        #endregion Properties

        #region Constructors
        public DownloadController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IDownloadFileService DownloadFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
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
            await LocalService.SetLoggedInContactInfo();

            return await DownloadFileService.DownloadFile(ParentTVItemID, FileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
