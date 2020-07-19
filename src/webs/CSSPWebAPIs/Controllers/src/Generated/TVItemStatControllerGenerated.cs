/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVItemStatController
    {
        Task<ActionResult<List<TVItemStat>>> Get();
        Task<ActionResult<TVItemStat>> Get(int TVItemStatID);
        Task<ActionResult<TVItemStat>> Post(TVItemStat TVItemStat);
        Task<ActionResult<TVItemStat>> Put(TVItemStat TVItemStat);
        Task<ActionResult<bool>> Delete(int TVItemStatID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemStatController : ControllerBase, ITVItemStatController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITVItemStatService TVItemStatService { get; }
        #endregion Properties

        #region Constructors
        public TVItemStatController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ITVItemStatService TVItemStatService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.TVItemStatService = TVItemStatService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemStat>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemStatService.GetTVItemStatList();
        }
        [HttpGet("{TVItemStatID}")]
        public async Task<ActionResult<TVItemStat>> Get(int TVItemStatID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemStatService.GetTVItemStatWithTVItemStatID(TVItemStatID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemStat>> Post(TVItemStat TVItemStat)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemStatService.Post(TVItemStat);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemStat>> Put(TVItemStat TVItemStat)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemStatService.Put(TVItemStat);
        }
        [HttpDelete("{TVItemStatID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemStatID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemStatService.Delete(TVItemStatID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
