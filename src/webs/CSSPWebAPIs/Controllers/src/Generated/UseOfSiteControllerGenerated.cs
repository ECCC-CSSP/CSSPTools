/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IUseOfSiteController
    {
        Task<ActionResult<List<UseOfSite>>> Get();
        Task<ActionResult<UseOfSite>> Get(int UseOfSiteID);
        Task<ActionResult<UseOfSite>> Post(UseOfSite UseOfSite);
        Task<ActionResult<UseOfSite>> Put(UseOfSite UseOfSite);
        Task<ActionResult<bool>> Delete(int UseOfSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class UseOfSiteController : ControllerBase, IUseOfSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IUseOfSiteService UseOfSiteService { get; }
        #endregion Properties

        #region Constructors
        public UseOfSiteController(ICultureService CultureService, ILoggedInService LoggedInService, IUseOfSiteService UseOfSiteService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.UseOfSiteService = UseOfSiteService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<UseOfSite>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await UseOfSiteService.GetUseOfSiteList();
        }
        [HttpGet("{UseOfSiteID}")]
        public async Task<ActionResult<UseOfSite>> Get(int UseOfSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await UseOfSiteService.GetUseOfSiteWithUseOfSiteID(UseOfSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<UseOfSite>> Post(UseOfSite UseOfSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await UseOfSiteService.Post(UseOfSite);
        }
        [HttpPut]
        public async Task<ActionResult<UseOfSite>> Put(UseOfSite UseOfSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await UseOfSiteService.Put(UseOfSite);
        }
        [HttpDelete("{UseOfSiteID}")]
        public async Task<ActionResult<bool>> Delete(int UseOfSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await UseOfSiteService.Delete(UseOfSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
