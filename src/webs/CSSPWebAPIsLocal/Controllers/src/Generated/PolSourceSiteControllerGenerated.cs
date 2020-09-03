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

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IPolSourceSiteController
    {
        Task<ActionResult<List<PolSourceSite>>> Get();
        Task<ActionResult<PolSourceSite>> Get(int PolSourceSiteID);
        Task<ActionResult<PolSourceSite>> Post(PolSourceSite PolSourceSite);
        Task<ActionResult<PolSourceSite>> Put(PolSourceSite PolSourceSite);
        Task<ActionResult<bool>> Delete(int PolSourceSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceSiteController : ControllerBase, IPolSourceSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IPolSourceSiteService PolSourceSiteService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IPolSourceSiteService PolSourceSiteService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.PolSourceSiteService = PolSourceSiteService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteService.GetPolSourceSiteList();
        }
        [HttpGet("{PolSourceSiteID}")]
        public async Task<ActionResult<PolSourceSite>> Get(int PolSourceSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(PolSourceSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSite>> Post(PolSourceSite PolSourceSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteService.Post(PolSourceSite);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSite>> Put(PolSourceSite PolSourceSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteService.Put(PolSourceSite);
        }
        [HttpDelete("{PolSourceSiteID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteService.Delete(PolSourceSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
