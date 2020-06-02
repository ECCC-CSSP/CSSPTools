using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceSiteController
    {
        Task<ActionResult<List<PolSourceSite>>> Get();
        Task<ActionResult<PolSourceSite>> Get(int PolSourceSiteID);
        Task<ActionResult<PolSourceSite>> Post(PolSourceSite polSourceSite);
        Task<ActionResult<PolSourceSite>> Put(PolSourceSite polSourceSite);
        Task<ActionResult<PolSourceSite>> Delete(PolSourceSite polSourceSite);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceSiteController : ControllerBase, IPolSourceSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceSiteService polSourceSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteController(IPolSourceSiteService polSourceSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceSiteService = polSourceSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSite>>> Get()
        {
            return await polSourceSiteService.GetPolSourceSiteList();
        }
        [HttpGet("{PolSourceSiteID}")]
        public async Task<ActionResult<PolSourceSite>> Get(int PolSourceSiteID)
        {
            return await polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(PolSourceSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSite>> Post(PolSourceSite polSourceSite)
        {
            return await polSourceSiteService.Add(polSourceSite);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSite>> Put(PolSourceSite polSourceSite)
        {
            return await polSourceSiteService.Update(polSourceSite);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceSite>> Delete(PolSourceSite polSourceSite)
        {
            return await polSourceSiteService.Delete(polSourceSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
