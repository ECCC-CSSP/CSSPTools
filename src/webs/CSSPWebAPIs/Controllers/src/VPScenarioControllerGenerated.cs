using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IVPScenarioController
    {
        Task<ActionResult<List<VPScenario>>> Get();
        Task<ActionResult<VPScenario>> Get(int VPScenarioID);
        Task<ActionResult<VPScenario>> Post(VPScenario vpScenario);
        Task<ActionResult<VPScenario>> Put(VPScenario vpScenario);
        Task<ActionResult<VPScenario>> Delete(VPScenario vpScenario);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPScenarioController : ControllerBase, IVPScenarioController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IVPScenarioService vpScenarioService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public VPScenarioController(IVPScenarioService vpScenarioService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.vpScenarioService = vpScenarioService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPScenario>>> Get()
        {
            return await vpScenarioService.GetVPScenarioList();
        }
        [HttpGet("{VPScenarioID}")]
        public async Task<ActionResult<VPScenario>> Get(int VPScenarioID)
        {
            return await vpScenarioService.GetVPScenarioWithVPScenarioID(VPScenarioID);
        }
        [HttpPost]
        public async Task<ActionResult<VPScenario>> Post(VPScenario vpScenario)
        {
            return await vpScenarioService.Add(vpScenario);
        }
        [HttpPut]
        public async Task<ActionResult<VPScenario>> Put(VPScenario vpScenario)
        {
            return await vpScenarioService.Update(vpScenario);
        }
        [HttpDelete]
        public async Task<ActionResult<VPScenario>> Delete(VPScenario vpScenario)
        {
            return await vpScenarioService.Delete(vpScenario);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
