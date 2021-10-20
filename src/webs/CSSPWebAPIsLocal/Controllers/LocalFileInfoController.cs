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
using CSSPReadGzFileServices;
using System.Threading;
using CSSPWebModels;
using CSSPLocalLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPFileServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ILocalFileInfoController
    {
        Task<ActionResult<LocalFileInfo>> GetLocalFileInfo(int ParentTVItemID, string FileName);
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
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ICSSPFileService FileService { get; }
        #endregion Properties

        #region Constructors
        public LocalFileInfoController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            ICSSPLocalLoggedInService CSSPLocalLoggedInService, ICSSPFileService FileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.Configuration = Configuration;
            this.FileService = FileService;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetLocalFileInfo/{ParentTVItemID:int}/{FileName}")]
        [HttpGet]
        public async Task<ActionResult<LocalFileInfo>> GetLocalFileInfo(int ParentTVItemID, string FileName)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            FileName = FileName.Replace(".mmdf", ".mdf");

            return await FileService.GetLocalFileInfo(ParentTVItemID, FileName);
        }
        [Route("GetLocalFileInfoList/{ParentTVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(int ParentTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await FileService.GetLocalFileInfoList(ParentTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
