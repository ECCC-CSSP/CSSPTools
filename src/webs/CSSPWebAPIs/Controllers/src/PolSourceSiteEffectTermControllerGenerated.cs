using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceSiteEffectTermController
    {
        Task<ActionResult<List<PolSourceSiteEffectTerm>>> Get();
        Task<ActionResult<PolSourceSiteEffectTerm>> Get(int PolSourceSiteEffectTermID);
        Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm);
        Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm);
        Task<ActionResult<PolSourceSiteEffectTerm>> Delete(PolSourceSiteEffectTerm polSourceSiteEffectTerm);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceSiteEffectTermController : ControllerBase, IPolSourceSiteEffectTermController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceSiteEffectTermService polSourceSiteEffectTermService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermController(IPolSourceSiteEffectTermService polSourceSiteEffectTermService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceSiteEffectTermService = polSourceSiteEffectTermService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSiteEffectTerm>>> Get()
        {
            return await polSourceSiteEffectTermService.GetPolSourceSiteEffectTermList();
        }
        [HttpGet("{PolSourceSiteEffectTermID}")]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Get(int PolSourceSiteEffectTermID)
        {
            return await polSourceSiteEffectTermService.GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(PolSourceSiteEffectTermID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            return await polSourceSiteEffectTermService.Add(polSourceSiteEffectTerm);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            return await polSourceSiteEffectTermService.Update(polSourceSiteEffectTerm);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Delete(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
        {
            return await polSourceSiteEffectTermService.Delete(polSourceSiteEffectTerm);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
