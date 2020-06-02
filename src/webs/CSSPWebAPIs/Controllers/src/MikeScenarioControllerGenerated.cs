using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMikeScenarioController
    {
        Task<ActionResult<List<MikeScenario>>> Get();
        Task<ActionResult<MikeScenario>> Get(int MikeScenarioID);
        Task<ActionResult<MikeScenario>> Post(MikeScenario mikeScenario);
        Task<ActionResult<MikeScenario>> Put(MikeScenario mikeScenario);
        Task<ActionResult<MikeScenario>> Delete(MikeScenario mikeScenario);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeScenarioController : ControllerBase, IMikeScenarioController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMikeScenarioService mikeScenarioService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MikeScenarioController(IMikeScenarioService mikeScenarioService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mikeScenarioService = mikeScenarioService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeScenario>>> Get()
        {
            return await mikeScenarioService.GetMikeScenarioList();
        }
        [HttpGet("{MikeScenarioID}")]
        public async Task<ActionResult<MikeScenario>> Get(int MikeScenarioID)
        {
            return await mikeScenarioService.GetMikeScenarioWithMikeScenarioID(MikeScenarioID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeScenario>> Post(MikeScenario mikeScenario)
        {
            return await mikeScenarioService.Add(mikeScenario);
        }
        [HttpPut]
        public async Task<ActionResult<MikeScenario>> Put(MikeScenario mikeScenario)
        {
            return await mikeScenarioService.Update(mikeScenario);
        }
        [HttpDelete]
        public async Task<ActionResult<MikeScenario>> Delete(MikeScenario mikeScenario)
        {
            return await mikeScenarioService.Delete(mikeScenario);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
