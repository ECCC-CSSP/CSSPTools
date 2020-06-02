using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVItemController
    {
        Task<ActionResult<List<TVItem>>> Get();
        Task<ActionResult<TVItem>> Get(int TVItemID);
        Task<ActionResult<TVItem>> Post(TVItem tvItem);
        Task<ActionResult<TVItem>> Put(TVItem tvItem);
        Task<ActionResult<TVItem>> Delete(TVItem tvItem);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemController : ControllerBase, ITVItemController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVItemService tvItemService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVItemController(ITVItemService tvItemService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvItemService = tvItemService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItem>>> Get()
        {
            return await tvItemService.GetTVItemList();
        }
        [HttpGet("{TVItemID}")]
        public async Task<ActionResult<TVItem>> Get(int TVItemID)
        {
            return await tvItemService.GetTVItemWithTVItemID(TVItemID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItem>> Post(TVItem tvItem)
        {
            return await tvItemService.Add(tvItem);
        }
        [HttpPut]
        public async Task<ActionResult<TVItem>> Put(TVItem tvItem)
        {
            return await tvItemService.Update(tvItem);
        }
        [HttpDelete]
        public async Task<ActionResult<TVItem>> Delete(TVItem tvItem)
        {
            return await tvItemService.Delete(tvItem);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
