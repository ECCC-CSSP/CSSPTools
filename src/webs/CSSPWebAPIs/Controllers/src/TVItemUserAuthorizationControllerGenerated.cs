using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVItemUserAuthorizationController
    {
        Task<ActionResult<List<TVItemUserAuthorization>>> Get();
        Task<ActionResult<TVItemUserAuthorization>> Get(int TVItemUserAuthorizationID);
        Task<ActionResult<TVItemUserAuthorization>> Post(TVItemUserAuthorization tvItemUserAuthorization);
        Task<ActionResult<TVItemUserAuthorization>> Put(TVItemUserAuthorization tvItemUserAuthorization);
        Task<ActionResult<TVItemUserAuthorization>> Delete(TVItemUserAuthorization tvItemUserAuthorization);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemUserAuthorizationController : ControllerBase, ITVItemUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVItemUserAuthorizationService tvItemUserAuthorizationService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationController(ITVItemUserAuthorizationService tvItemUserAuthorizationService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvItemUserAuthorizationService = tvItemUserAuthorizationService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemUserAuthorization>>> Get()
        {
            return await tvItemUserAuthorizationService.GetTVItemUserAuthorizationList();
        }
        [HttpGet("{TVItemUserAuthorizationID}")]
        public async Task<ActionResult<TVItemUserAuthorization>> Get(int TVItemUserAuthorizationID)
        {
            return await tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(TVItemUserAuthorizationID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemUserAuthorization>> Post(TVItemUserAuthorization tvItemUserAuthorization)
        {
            return await tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemUserAuthorization>> Put(TVItemUserAuthorization tvItemUserAuthorization)
        {
            return await tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
        }
        [HttpDelete]
        public async Task<ActionResult<TVItemUserAuthorization>> Delete(TVItemUserAuthorization tvItemUserAuthorization)
        {
            return await tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
