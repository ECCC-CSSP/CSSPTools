using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ISamplingPlanController
    {
        Task<ActionResult<List<SamplingPlan>>> Get();
        Task<ActionResult<SamplingPlan>> Get(int SamplingPlanID);
        Task<ActionResult<SamplingPlan>> Post(SamplingPlan samplingPlan);
        Task<ActionResult<SamplingPlan>> Put(SamplingPlan samplingPlan);
        Task<ActionResult<SamplingPlan>> Delete(SamplingPlan samplingPlan);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SamplingPlanController : ControllerBase, ISamplingPlanController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISamplingPlanService samplingPlanService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanController(ISamplingPlanService samplingPlanService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.samplingPlanService = samplingPlanService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlan>>> Get()
        {
            return await samplingPlanService.GetSamplingPlanList();
        }
        [HttpGet("{SamplingPlanID}")]
        public async Task<ActionResult<SamplingPlan>> Get(int SamplingPlanID)
        {
            return await samplingPlanService.GetSamplingPlanWithSamplingPlanID(SamplingPlanID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlan>> Post(SamplingPlan samplingPlan)
        {
            return await samplingPlanService.Add(samplingPlan);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlan>> Put(SamplingPlan samplingPlan)
        {
            return await samplingPlanService.Update(samplingPlan);
        }
        [HttpDelete]
        public async Task<ActionResult<SamplingPlan>> Delete(SamplingPlan samplingPlan)
        {
            return await samplingPlanService.Delete(samplingPlan);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
