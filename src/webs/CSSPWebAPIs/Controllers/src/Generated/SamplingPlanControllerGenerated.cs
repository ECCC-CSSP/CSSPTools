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
    public partial interface ISamplingPlanController
    {
        Task<ActionResult<List<SamplingPlan>>> Get();
        Task<ActionResult<SamplingPlan>> Get(int SamplingPlanID);
        Task<ActionResult<SamplingPlan>> Post(SamplingPlan SamplingPlan);
        Task<ActionResult<SamplingPlan>> Put(SamplingPlan SamplingPlan);
        Task<ActionResult<bool>> Delete(int SamplingPlanID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SamplingPlanController : ControllerBase, ISamplingPlanController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ISamplingPlanService SamplingPlanService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanController(ICultureService CultureService, ILoggedInService LoggedInService, ISamplingPlanService SamplingPlanService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.SamplingPlanService = SamplingPlanService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlan>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanService.GetSamplingPlanList();
        }
        [HttpGet("{SamplingPlanID}")]
        public async Task<ActionResult<SamplingPlan>> Get(int SamplingPlanID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanService.GetSamplingPlanWithSamplingPlanID(SamplingPlanID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlan>> Post(SamplingPlan SamplingPlan)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanService.Post(SamplingPlan);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlan>> Put(SamplingPlan SamplingPlan)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanService.Put(SamplingPlan);
        }
        [HttpDelete("{SamplingPlanID}")]
        public async Task<ActionResult<bool>> Delete(int SamplingPlanID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await SamplingPlanService.Delete(SamplingPlanID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
