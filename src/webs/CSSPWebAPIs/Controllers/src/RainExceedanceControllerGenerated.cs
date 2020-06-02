using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IRainExceedanceController
    {
        Task<ActionResult<List<RainExceedance>>> Get();
        Task<ActionResult<RainExceedance>> Get(int RainExceedanceID);
        Task<ActionResult<RainExceedance>> Post(RainExceedance rainExceedance);
        Task<ActionResult<RainExceedance>> Put(RainExceedance rainExceedance);
        Task<ActionResult<RainExceedance>> Delete(RainExceedance rainExceedance);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RainExceedanceController : ControllerBase, IRainExceedanceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IRainExceedanceService rainExceedanceService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public RainExceedanceController(IRainExceedanceService rainExceedanceService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.rainExceedanceService = rainExceedanceService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RainExceedance>>> Get()
        {
            return await rainExceedanceService.GetRainExceedanceList();
        }
        [HttpGet("{RainExceedanceID}")]
        public async Task<ActionResult<RainExceedance>> Get(int RainExceedanceID)
        {
            return await rainExceedanceService.GetRainExceedanceWithRainExceedanceID(RainExceedanceID);
        }
        [HttpPost]
        public async Task<ActionResult<RainExceedance>> Post(RainExceedance rainExceedance)
        {
            return await rainExceedanceService.Add(rainExceedance);
        }
        [HttpPut]
        public async Task<ActionResult<RainExceedance>> Put(RainExceedance rainExceedance)
        {
            return await rainExceedanceService.Update(rainExceedance);
        }
        [HttpDelete]
        public async Task<ActionResult<RainExceedance>> Delete(RainExceedance rainExceedance)
        {
            return await rainExceedanceService.Delete(rainExceedance);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
