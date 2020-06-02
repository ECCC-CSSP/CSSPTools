using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ISpillController
    {
        Task<ActionResult<List<Spill>>> Get();
        Task<ActionResult<Spill>> Get(int SpillID);
        Task<ActionResult<Spill>> Post(Spill spill);
        Task<ActionResult<Spill>> Put(Spill spill);
        Task<ActionResult<Spill>> Delete(Spill spill);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SpillController : ControllerBase, ISpillController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISpillService spillService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public SpillController(ISpillService spillService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.spillService = spillService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Spill>>> Get()
        {
            return await spillService.GetSpillList();
        }
        [HttpGet("{SpillID}")]
        public async Task<ActionResult<Spill>> Get(int SpillID)
        {
            return await spillService.GetSpillWithSpillID(SpillID);
        }
        [HttpPost]
        public async Task<ActionResult<Spill>> Post(Spill spill)
        {
            return await spillService.Add(spill);
        }
        [HttpPut]
        public async Task<ActionResult<Spill>> Put(Spill spill)
        {
            return await spillService.Update(spill);
        }
        [HttpDelete]
        public async Task<ActionResult<Spill>> Delete(Spill spill)
        {
            return await spillService.Delete(spill);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
