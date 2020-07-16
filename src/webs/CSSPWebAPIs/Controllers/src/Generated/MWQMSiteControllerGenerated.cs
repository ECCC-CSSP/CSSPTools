/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
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
    public partial interface IMWQMSiteController
    {
        Task<ActionResult<List<MWQMSite>>> Get();
        Task<ActionResult<MWQMSite>> Get(int MWQMSiteID);
        Task<ActionResult<MWQMSite>> Post(MWQMSite MWQMSite);
        Task<ActionResult<MWQMSite>> Put(MWQMSite MWQMSite);
        Task<ActionResult<bool>> Delete(int MWQMSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSiteController : ControllerBase, IMWQMSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMWQMSiteService MWQMSiteService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteController(ICultureService CultureService, ILoggedInService LoggedInService, IMWQMSiteService MWQMSiteService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMSiteService = MWQMSiteService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSite>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteService.GetMWQMSiteList();
        }
        [HttpGet("{MWQMSiteID}")]
        public async Task<ActionResult<MWQMSite>> Get(int MWQMSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteService.GetMWQMSiteWithMWQMSiteID(MWQMSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSite>> Post(MWQMSite MWQMSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteService.Post(MWQMSite);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSite>> Put(MWQMSite MWQMSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteService.Put(MWQMSite);
        }
        [HttpDelete("{MWQMSiteID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteService.Delete(MWQMSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
