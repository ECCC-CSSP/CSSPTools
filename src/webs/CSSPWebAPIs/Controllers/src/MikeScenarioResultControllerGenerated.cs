using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMikeScenarioResultController
    {
        Task<ActionResult<List<MikeScenarioResult>>> Get();
        Task<ActionResult<MikeScenarioResult>> Get(int MikeScenarioResultID);
        Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult mikeScenarioResult);
        Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult mikeScenarioResult);
        Task<ActionResult<MikeScenarioResult>> Delete(MikeScenarioResult mikeScenarioResult);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeScenarioResultController : ControllerBase, IMikeScenarioResultController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMikeScenarioResultService mikeScenarioResultService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultController(IMikeScenarioResultService mikeScenarioResultService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mikeScenarioResultService = mikeScenarioResultService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeScenarioResult>>> Get()
        {
            return await mikeScenarioResultService.GetMikeScenarioResultList();
        }
        [HttpGet("{MikeScenarioResultID}")]
        public async Task<ActionResult<MikeScenarioResult>> Get(int MikeScenarioResultID)
        {
            return await mikeScenarioResultService.GetMikeScenarioResultWithMikeScenarioResultID(MikeScenarioResultID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult mikeScenarioResult)
        {
            return await mikeScenarioResultService.Add(mikeScenarioResult);
        }
        [HttpPut]
        public async Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult mikeScenarioResult)
        {
            return await mikeScenarioResultService.Update(mikeScenarioResult);
        }
        [HttpDelete]
        public async Task<ActionResult<MikeScenarioResult>> Delete(MikeScenarioResult mikeScenarioResult)
        {
            return await mikeScenarioResultService.Delete(mikeScenarioResult);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
