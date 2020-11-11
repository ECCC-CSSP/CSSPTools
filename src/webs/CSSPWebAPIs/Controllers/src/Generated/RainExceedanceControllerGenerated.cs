/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
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
    public partial interface IRainExceedanceController
    {
        Task<ActionResult<List<RainExceedance>>> Get();
        Task<ActionResult<RainExceedance>> Get(int RainExceedanceID);
        Task<ActionResult<RainExceedance>> Post(RainExceedance RainExceedance);
        Task<ActionResult<RainExceedance>> Put(RainExceedance RainExceedance);
        Task<ActionResult<bool>> Delete(int RainExceedanceID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RainExceedanceController : ControllerBase, IRainExceedanceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IRainExceedanceDBService RainExceedanceDBService { get; }
        #endregion Properties

        #region Constructors
        public RainExceedanceController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IRainExceedanceDBService RainExceedanceDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.RainExceedanceDBService = RainExceedanceDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RainExceedance>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceDBService.GetRainExceedanceList();
        }
        [HttpGet("{RainExceedanceID}")]
        public async Task<ActionResult<RainExceedance>> Get(int RainExceedanceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceDBService.GetRainExceedanceWithRainExceedanceID(RainExceedanceID);
        }
        [HttpPost]
        public async Task<ActionResult<RainExceedance>> Post(RainExceedance RainExceedance)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceDBService.Post(RainExceedance);
        }
        [HttpPut]
        public async Task<ActionResult<RainExceedance>> Put(RainExceedance RainExceedance)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceDBService.Put(RainExceedance);
        }
        [HttpDelete("{RainExceedanceID}")]
        public async Task<ActionResult<bool>> Delete(int RainExceedanceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RainExceedanceDBService.Delete(RainExceedanceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
