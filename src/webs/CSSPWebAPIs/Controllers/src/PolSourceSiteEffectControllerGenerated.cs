using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceSiteEffectController
    {
        Task<ActionResult<List<PolSourceSiteEffect>>> Get();
        Task<ActionResult<PolSourceSiteEffect>> Get(int PolSourceSiteEffectID);
        Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect polSourceSiteEffect);
        Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect polSourceSiteEffect);
        Task<ActionResult<PolSourceSiteEffect>> Delete(PolSourceSiteEffect polSourceSiteEffect);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceSiteEffectController : ControllerBase, IPolSourceSiteEffectController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceSiteEffectService polSourceSiteEffectService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectController(IPolSourceSiteEffectService polSourceSiteEffectService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceSiteEffectService = polSourceSiteEffectService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSiteEffect>>> Get()
        {
            return await polSourceSiteEffectService.GetPolSourceSiteEffectList();
        }
        [HttpGet("{PolSourceSiteEffectID}")]
        public async Task<ActionResult<PolSourceSiteEffect>> Get(int PolSourceSiteEffectID)
        {
            return await polSourceSiteEffectService.GetPolSourceSiteEffectWithPolSourceSiteEffectID(PolSourceSiteEffectID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect polSourceSiteEffect)
        {
            return await polSourceSiteEffectService.Add(polSourceSiteEffect);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect polSourceSiteEffect)
        {
            return await polSourceSiteEffectService.Update(polSourceSiteEffect);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceSiteEffect>> Delete(PolSourceSiteEffect polSourceSiteEffect)
        {
            return await polSourceSiteEffectService.Delete(polSourceSiteEffect);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
