using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMSiteController
    {
        Task<ActionResult<List<MWQMSite>>> Get();
        Task<ActionResult<MWQMSite>> Get(int MWQMSiteID);
        Task<ActionResult<MWQMSite>> Post(MWQMSite mwqmSite);
        Task<ActionResult<MWQMSite>> Put(MWQMSite mwqmSite);
        Task<ActionResult<MWQMSite>> Delete(MWQMSite mwqmSite);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSiteController : ControllerBase, IMWQMSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMSiteService mwqmSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteController(IMWQMSiteService mwqmSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmSiteService = mwqmSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSite>>> Get()
        {
            return await mwqmSiteService.GetMWQMSiteList();
        }
        [HttpGet("{MWQMSiteID}")]
        public async Task<ActionResult<MWQMSite>> Get(int MWQMSiteID)
        {
            return await mwqmSiteService.GetMWQMSiteWithMWQMSiteID(MWQMSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSite>> Post(MWQMSite mwqmSite)
        {
            return await mwqmSiteService.Add(mwqmSite);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSite>> Put(MWQMSite mwqmSite)
        {
            return await mwqmSiteService.Update(mwqmSite);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMSite>> Delete(MWQMSite mwqmSite)
        {
            return await mwqmSiteService.Delete(mwqmSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
