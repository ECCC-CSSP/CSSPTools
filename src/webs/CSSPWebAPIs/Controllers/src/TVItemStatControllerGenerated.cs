using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVItemStatController
    {
        Task<ActionResult<List<TVItemStat>>> Get();
        Task<ActionResult<TVItemStat>> Get(int TVItemStatID);
        Task<ActionResult<TVItemStat>> Post(TVItemStat tvItemStat);
        Task<ActionResult<TVItemStat>> Put(TVItemStat tvItemStat);
        Task<ActionResult<TVItemStat>> Delete(TVItemStat tvItemStat);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemStatController : ControllerBase, ITVItemStatController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVItemStatService tvItemStatService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVItemStatController(ITVItemStatService tvItemStatService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvItemStatService = tvItemStatService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemStat>>> Get()
        {
            return await tvItemStatService.GetTVItemStatList();
        }
        [HttpGet("{TVItemStatID}")]
        public async Task<ActionResult<TVItemStat>> Get(int TVItemStatID)
        {
            return await tvItemStatService.GetTVItemStatWithTVItemStatID(TVItemStatID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemStat>> Post(TVItemStat tvItemStat)
        {
            return await tvItemStatService.Add(tvItemStat);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemStat>> Put(TVItemStat tvItemStat)
        {
            return await tvItemStatService.Update(tvItemStat);
        }
        [HttpDelete]
        public async Task<ActionResult<TVItemStat>> Delete(TVItemStat tvItemStat)
        {
            return await tvItemStatService.Delete(tvItemStat);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
