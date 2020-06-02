using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ISamplingPlanSubsectorSiteController
    {
        Task<ActionResult<List<SamplingPlanSubsectorSite>>> Get();
        Task<ActionResult<SamplingPlanSubsectorSite>> Get(int SamplingPlanSubsectorSiteID);
        Task<ActionResult<SamplingPlanSubsectorSite>> Post(SamplingPlanSubsectorSite samplingPlanSubsectorSite);
        Task<ActionResult<SamplingPlanSubsectorSite>> Put(SamplingPlanSubsectorSite samplingPlanSubsectorSite);
        Task<ActionResult<SamplingPlanSubsectorSite>> Delete(SamplingPlanSubsectorSite samplingPlanSubsectorSite);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SamplingPlanSubsectorSiteController : ControllerBase, ISamplingPlanSubsectorSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteController(ISamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.samplingPlanSubsectorSiteService = samplingPlanSubsectorSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlanSubsectorSite>>> Get()
        {
            return await samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList();
        }
        [HttpGet("{SamplingPlanSubsectorSiteID}")]
        public async Task<ActionResult<SamplingPlanSubsectorSite>> Get(int SamplingPlanSubsectorSiteID)
        {
            return await samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(SamplingPlanSubsectorSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlanSubsectorSite>> Post(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            return await samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlanSubsectorSite>> Put(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            return await samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
        }
        [HttpDelete]
        public async Task<ActionResult<SamplingPlanSubsectorSite>> Delete(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            return await samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
