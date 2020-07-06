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

namespace CSSPWebAPI.Controllers
{
    public partial interface ITideLocationController
    {
        Task<ActionResult<List<TideLocation>>> Get();
        Task<ActionResult<TideLocation>> Get(int TideLocationID);
        Task<ActionResult<TideLocation>> Post(TideLocation TideLocation);
        Task<ActionResult<TideLocation>> Put(TideLocation TideLocation);
        Task<ActionResult<bool>> Delete(int TideLocationID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TideLocationController : ControllerBase, ITideLocationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITideLocationService TideLocationService { get; }
        #endregion Properties

        #region Constructors
        public TideLocationController(ICultureService CultureService, ILoggedInService LoggedInService, ITideLocationService TideLocationService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.TideLocationService = TideLocationService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideLocation>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideLocationService.GetTideLocationList();
        }
        [HttpGet("{TideLocationID}")]
        public async Task<ActionResult<TideLocation>> Get(int TideLocationID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideLocationService.GetTideLocationWithTideLocationID(TideLocationID);
        }
        [HttpPost]
        public async Task<ActionResult<TideLocation>> Post(TideLocation TideLocation)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideLocationService.Post(TideLocation);
        }
        [HttpPut]
        public async Task<ActionResult<TideLocation>> Put(TideLocation TideLocation)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideLocationService.Put(TideLocation);
        }
        [HttpDelete("{TideLocationID}")]
        public async Task<ActionResult<bool>> Delete(int TideLocationID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideLocationService.Delete(TideLocationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
