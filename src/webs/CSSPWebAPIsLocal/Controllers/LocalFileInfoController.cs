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
using CSSPLocalFileInfoServices;
using Microsoft.Extensions.Configuration;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ILocalFileInfoController
    {
        Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int TVItemID);
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
        private ILocalFileInfoService LocalFileInfoService { get; }
        #endregion Properties

        #region Constructors
        public LocalFileInfoController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            ILoggedInService LoggedInService, ILocalFileInfoService LocalFileInfoService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.Configuration = Configuration;
            this.LocalFileInfoService = LocalFileInfoService;
        }
        #endregion Constructors

        #region Functions public
        [Route("{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            string CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            return await LocalFileInfoService.GetLocalFileInfoList(DirectoryPath);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
