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
    public partial interface ISamplingPlanSubsectorController
    {
        Task<ActionResult<List<SamplingPlanSubsector>>> Get();
        Task<ActionResult<SamplingPlanSubsector>> Get(int SamplingPlanSubsectorID);
        Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector SamplingPlanSubsector);
        Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector SamplingPlanSubsector);
        Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SamplingPlanSubsectorController : ControllerBase, ISamplingPlanSubsectorController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ISamplingPlanSubsectorService SamplingPlanSubsectorService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorController(ICultureService CultureService, ILoggedInService LoggedInService, ISamplingPlanSubsectorService SamplingPlanSubsectorService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.SamplingPlanSubsectorService = SamplingPlanSubsectorService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlanSubsector>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanSubsectorService.GetSamplingPlanSubsectorList();
        }
        [HttpGet("{SamplingPlanSubsectorID}")]
        public async Task<ActionResult<SamplingPlanSubsector>> Get(int SamplingPlanSubsectorID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(SamplingPlanSubsectorID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector SamplingPlanSubsector)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanSubsectorService.Post(SamplingPlanSubsector);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector SamplingPlanSubsector)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanSubsectorService.Put(SamplingPlanSubsector);
        }
        [HttpDelete("{SamplingPlanSubsectorID}")]
        public async Task<ActionResult<bool>> Delete(int SamplingPlanSubsectorID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanSubsectorService.Delete(SamplingPlanSubsectorID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
