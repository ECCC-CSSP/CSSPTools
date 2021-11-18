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
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using CSSPWebModels;

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
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ICSSPFileService FileService { get; }
        #endregion Properties

        #region Constructors
        public DownloadOtherController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, ICSSPFileService FileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.FileService = FileService;

        }
        #endregion Constructors

        #region Functions public
        [Route("{FileName}")]
        [HttpGet]
        public async Task<ActionResult> DownloadOther(string FileName)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();

            return await FileService.DownloadOtherFile(FileName);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
