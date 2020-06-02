using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ISamplingPlanEmailController
    {
        Task<ActionResult<List<SamplingPlanEmail>>> Get();
        Task<ActionResult<SamplingPlanEmail>> Get(int SamplingPlanEmailID);
        Task<ActionResult<SamplingPlanEmail>> Post(SamplingPlanEmail samplingPlanEmail);
        Task<ActionResult<SamplingPlanEmail>> Put(SamplingPlanEmail samplingPlanEmail);
        Task<ActionResult<SamplingPlanEmail>> Delete(SamplingPlanEmail samplingPlanEmail);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SamplingPlanEmailController : ControllerBase, ISamplingPlanEmailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISamplingPlanEmailService samplingPlanEmailService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailController(ISamplingPlanEmailService samplingPlanEmailService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.samplingPlanEmailService = samplingPlanEmailService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlanEmail>>> Get()
        {
            return await samplingPlanEmailService.GetSamplingPlanEmailList();
        }
        [HttpGet("{SamplingPlanEmailID}")]
        public async Task<ActionResult<SamplingPlanEmail>> Get(int SamplingPlanEmailID)
        {
            return await samplingPlanEmailService.GetSamplingPlanEmailWithSamplingPlanEmailID(SamplingPlanEmailID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlanEmail>> Post(SamplingPlanEmail samplingPlanEmail)
        {
            return await samplingPlanEmailService.Add(samplingPlanEmail);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlanEmail>> Put(SamplingPlanEmail samplingPlanEmail)
        {
            return await samplingPlanEmailService.Update(samplingPlanEmail);
        }
        [HttpDelete]
        public async Task<ActionResult<SamplingPlanEmail>> Delete(SamplingPlanEmail samplingPlanEmail)
        {
            return await samplingPlanEmailService.Delete(samplingPlanEmail);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
