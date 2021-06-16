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
    public partial interface ILocalFileController
    {
        Task<ActionResult<LocalFileInfo>> GetLocalFileInfo(int TVItemID, string FileName);
        Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int TVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalFileController : ControllerBase, ILocalFileController
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
        public LocalFileController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            ILoggedInService LoggedInService, IFileService FileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.Configuration = Configuration;
            this.FileService = FileService;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetLocalFileInfo/{TVItemID:int}/{FileName}")]
        [HttpGet]
        public async Task<ActionResult<LocalFileInfo>> GetLocalFileInfo(int TVItemID, string FileName)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            string CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            return await FileService.GetLocalFileInfo(DirectoryPath, FileName);
        }
        [Route("GetLocalFileInfoList/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            string CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            return await FileService.GetLocalFileInfoList(DirectoryPath);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
