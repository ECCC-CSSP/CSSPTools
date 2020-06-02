using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMikeBoundaryConditionController
    {
        Task<ActionResult<List<MikeBoundaryCondition>>> Get();
        Task<ActionResult<MikeBoundaryCondition>> Get(int MikeBoundaryConditionID);
        Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition mikeBoundaryCondition);
        Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition mikeBoundaryCondition);
        Task<ActionResult<MikeBoundaryCondition>> Delete(MikeBoundaryCondition mikeBoundaryCondition);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeBoundaryConditionController : ControllerBase, IMikeBoundaryConditionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMikeBoundaryConditionService mikeBoundaryConditionService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionController(IMikeBoundaryConditionService mikeBoundaryConditionService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mikeBoundaryConditionService = mikeBoundaryConditionService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeBoundaryCondition>>> Get()
        {
            return await mikeBoundaryConditionService.GetMikeBoundaryConditionList();
        }
        [HttpGet("{MikeBoundaryConditionID}")]
        public async Task<ActionResult<MikeBoundaryCondition>> Get(int MikeBoundaryConditionID)
        {
            return await mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(MikeBoundaryConditionID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition mikeBoundaryCondition)
        {
            return await mikeBoundaryConditionService.Add(mikeBoundaryCondition);
        }
        [HttpPut]
        public async Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition mikeBoundaryCondition)
        {
            return await mikeBoundaryConditionService.Update(mikeBoundaryCondition);
        }
        [HttpDelete]
        public async Task<ActionResult<MikeBoundaryCondition>> Delete(MikeBoundaryCondition mikeBoundaryCondition)
        {
            return await mikeBoundaryConditionService.Delete(mikeBoundaryCondition);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
