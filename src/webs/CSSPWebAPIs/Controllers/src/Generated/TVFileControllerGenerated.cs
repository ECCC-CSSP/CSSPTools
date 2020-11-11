/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVFileController
    {
        Task<ActionResult<List<TVFile>>> Get();
        Task<ActionResult<TVFile>> Get(int TVFileID);
        Task<ActionResult<TVFile>> Post(TVFile TVFile);
        Task<ActionResult<TVFile>> Put(TVFile TVFile);
        Task<ActionResult<bool>> Delete(int TVFileID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVFileController : ControllerBase, ITVFileController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITVFileDBService TVFileDBService { get; }
        #endregion Properties

        #region Constructors
        public TVFileController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ITVFileDBService TVFileDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.TVFileDBService = TVFileDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVFile>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVFileDBService.GetTVFileList();
        }
        [HttpGet("{TVFileID}")]
        public async Task<ActionResult<TVFile>> Get(int TVFileID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVFileDBService.GetTVFileWithTVFileID(TVFileID);
        }
        [HttpPost]
        public async Task<ActionResult<TVFile>> Post(TVFile TVFile)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVFileDBService.Post(TVFile);
        }
        [HttpPut]
        public async Task<ActionResult<TVFile>> Put(TVFile TVFile)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVFileDBService.Put(TVFile);
        }
        [HttpDelete("{TVFileID}")]
        public async Task<ActionResult<bool>> Delete(int TVFileID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVFileDBService.Delete(TVFileID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
