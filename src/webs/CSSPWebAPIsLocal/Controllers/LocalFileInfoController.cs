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
using Microsoft.Extensions.Configuration;
using FileServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ILocalFileInfoController
    {
        Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int ParentTVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalFileInfoController : ControllerBase, ILocalFileInfoController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get;  }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IFileService FileService { get; }
        #endregion Properties

        #region Constructors
        public LocalFileInfoController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            ILoggedInService LoggedInService, IFileService FileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.Configuration = Configuration;
            this.FileService = FileService;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetLocalFileInfoList/{ParentTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int ParentTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await FileService.GetLocalFileInfoList(ParentTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
