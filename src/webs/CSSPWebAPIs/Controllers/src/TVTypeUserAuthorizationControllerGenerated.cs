using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVTypeUserAuthorizationController
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> Get();
        Task<ActionResult<TVTypeUserAuthorization>> Get(int TVTypeUserAuthorizationID);
        Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization tvTypeUserAuthorization);
        Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization tvTypeUserAuthorization);
        Task<ActionResult<TVTypeUserAuthorization>> Delete(TVTypeUserAuthorization tvTypeUserAuthorization);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVTypeUserAuthorizationController : ControllerBase, ITVTypeUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationController(ITVTypeUserAuthorizationService tvTypeUserAuthorizationService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvTypeUserAuthorizationService = tvTypeUserAuthorizationService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> Get()
        {
            return await tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList();
        }
        [HttpGet("{TVTypeUserAuthorizationID}")]
        public async Task<ActionResult<TVTypeUserAuthorization>> Get(int TVTypeUserAuthorizationID)
        {
            return await tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(TVTypeUserAuthorizationID);
        }
        [HttpPost]
        public async Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            return await tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
        }
        [HttpPut]
        public async Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            return await tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
        }
        [HttpDelete]
        public async Task<ActionResult<TVTypeUserAuthorization>> Delete(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            return await tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
