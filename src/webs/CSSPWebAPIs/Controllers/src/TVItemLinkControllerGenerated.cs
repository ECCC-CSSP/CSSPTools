using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVItemLinkController
    {
        Task<ActionResult<List<TVItemLink>>> Get();
        Task<ActionResult<TVItemLink>> Get(int TVItemLinkID);
        Task<ActionResult<TVItemLink>> Post(TVItemLink tvItemLink);
        Task<ActionResult<TVItemLink>> Put(TVItemLink tvItemLink);
        Task<ActionResult<TVItemLink>> Delete(TVItemLink tvItemLink);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemLinkController : ControllerBase, ITVItemLinkController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVItemLinkService tvItemLinkService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVItemLinkController(ITVItemLinkService tvItemLinkService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvItemLinkService = tvItemLinkService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemLink>>> Get()
        {
            return await tvItemLinkService.GetTVItemLinkList();
        }
        [HttpGet("{TVItemLinkID}")]
        public async Task<ActionResult<TVItemLink>> Get(int TVItemLinkID)
        {
            return await tvItemLinkService.GetTVItemLinkWithTVItemLinkID(TVItemLinkID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemLink>> Post(TVItemLink tvItemLink)
        {
            return await tvItemLinkService.Add(tvItemLink);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemLink>> Put(TVItemLink tvItemLink)
        {
            return await tvItemLinkService.Update(tvItemLink);
        }
        [HttpDelete]
        public async Task<ActionResult<TVItemLink>> Delete(TVItemLink tvItemLink)
        {
            return await tvItemLinkService.Delete(tvItemLink);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
