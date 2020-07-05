/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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

namespace CSSPWebAPI.Controllers
{
    public partial interface IRainExceedanceClimateSiteController
    {
        Task<ActionResult<List<RainExceedanceClimateSite>>> Get();
        Task<ActionResult<RainExceedanceClimateSite>> Get(int RainExceedanceClimateSiteID);
        Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite RainExceedanceClimateSite);
        Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite RainExceedanceClimateSite);
        Task<ActionResult<bool>> Delete(int RainExceedanceClimateSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RainExceedanceClimateSiteController : ControllerBase, IRainExceedanceClimateSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IRainExceedanceClimateSiteService RainExceedanceClimateSiteService { get; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteController(ICultureService CultureService, ILoggedInService LoggedInService, IRainExceedanceClimateSiteService RainExceedanceClimateSiteService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.RainExceedanceClimateSiteService = RainExceedanceClimateSiteService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RainExceedanceClimateSite>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList();
        }
        [HttpGet("{RainExceedanceClimateSiteID}")]
        public async Task<ActionResult<RainExceedanceClimateSite>> Get(int RainExceedanceClimateSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(RainExceedanceClimateSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite RainExceedanceClimateSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceClimateSiteService.Post(RainExceedanceClimateSite);
        }
        [HttpPut]
        public async Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite RainExceedanceClimateSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceClimateSiteService.Put(RainExceedanceClimateSite);
        }
        [HttpDelete("{RainExceedanceClimateSiteID}")]
        public async Task<ActionResult<bool>> Delete(int RainExceedanceClimateSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceClimateSiteService.Delete(RainExceedanceClimateSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
