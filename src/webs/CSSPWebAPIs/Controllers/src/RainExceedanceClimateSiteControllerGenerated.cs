using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IRainExceedanceClimateSiteController
    {
        Task<ActionResult<List<RainExceedanceClimateSite>>> Get();
        Task<ActionResult<RainExceedanceClimateSite>> Get(int RainExceedanceClimateSiteID);
        Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite rainExceedanceClimateSite);
        Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite rainExceedanceClimateSite);
        Task<ActionResult<RainExceedanceClimateSite>> Delete(RainExceedanceClimateSite rainExceedanceClimateSite);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RainExceedanceClimateSiteController : ControllerBase, IRainExceedanceClimateSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IRainExceedanceClimateSiteService rainExceedanceClimateSiteService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteController(IRainExceedanceClimateSiteService rainExceedanceClimateSiteService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.rainExceedanceClimateSiteService = rainExceedanceClimateSiteService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RainExceedanceClimateSite>>> Get()
        {
            return await rainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList();
        }
        [HttpGet("{RainExceedanceClimateSiteID}")]
        public async Task<ActionResult<RainExceedanceClimateSite>> Get(int RainExceedanceClimateSiteID)
        {
            return await rainExceedanceClimateSiteService.GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(RainExceedanceClimateSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            return await rainExceedanceClimateSiteService.Add(rainExceedanceClimateSite);
        }
        [HttpPut]
        public async Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            return await rainExceedanceClimateSiteService.Update(rainExceedanceClimateSite);
        }
        [HttpDelete]
        public async Task<ActionResult<RainExceedanceClimateSite>> Delete(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            return await rainExceedanceClimateSiteService.Delete(rainExceedanceClimateSite);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
