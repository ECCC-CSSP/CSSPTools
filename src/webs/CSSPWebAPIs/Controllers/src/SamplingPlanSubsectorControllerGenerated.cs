using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ISamplingPlanSubsectorController
    {
        Task<ActionResult<List<SamplingPlanSubsector>>> Get();
        Task<ActionResult<SamplingPlanSubsector>> Get(int SamplingPlanSubsectorID);
        Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector samplingPlanSubsector);
        Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector samplingPlanSubsector);
        Task<ActionResult<SamplingPlanSubsector>> Delete(SamplingPlanSubsector samplingPlanSubsector);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SamplingPlanSubsectorController : ControllerBase, ISamplingPlanSubsectorController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISamplingPlanSubsectorService samplingPlanSubsectorService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorController(ISamplingPlanSubsectorService samplingPlanSubsectorService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.samplingPlanSubsectorService = samplingPlanSubsectorService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlanSubsector>>> Get()
        {
            return await samplingPlanSubsectorService.GetSamplingPlanSubsectorList();
        }
        [HttpGet("{SamplingPlanSubsectorID}")]
        public async Task<ActionResult<SamplingPlanSubsector>> Get(int SamplingPlanSubsectorID)
        {
            return await samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(SamplingPlanSubsectorID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlanSubsector>> Post(SamplingPlanSubsector samplingPlanSubsector)
        {
            return await samplingPlanSubsectorService.Add(samplingPlanSubsector);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlanSubsector>> Put(SamplingPlanSubsector samplingPlanSubsector)
        {
            return await samplingPlanSubsectorService.Update(samplingPlanSubsector);
        }
        [HttpDelete]
        public async Task<ActionResult<SamplingPlanSubsector>> Delete(SamplingPlanSubsector samplingPlanSubsector)
        {
            return await samplingPlanSubsectorService.Delete(samplingPlanSubsector);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
