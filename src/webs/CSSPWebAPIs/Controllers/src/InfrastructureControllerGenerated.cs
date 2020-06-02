using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IInfrastructureController
    {
        Task<ActionResult<List<Infrastructure>>> Get();
        Task<ActionResult<Infrastructure>> Get(int InfrastructureID);
        Task<ActionResult<Infrastructure>> Post(Infrastructure infrastructure);
        Task<ActionResult<Infrastructure>> Put(Infrastructure infrastructure);
        Task<ActionResult<Infrastructure>> Delete(Infrastructure infrastructure);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class InfrastructureController : ControllerBase, IInfrastructureController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IInfrastructureService infrastructureService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public InfrastructureController(IInfrastructureService infrastructureService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.infrastructureService = infrastructureService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Infrastructure>>> Get()
        {
            return await infrastructureService.GetInfrastructureList();
        }
        [HttpGet("{InfrastructureID}")]
        public async Task<ActionResult<Infrastructure>> Get(int InfrastructureID)
        {
            return await infrastructureService.GetInfrastructureWithInfrastructureID(InfrastructureID);
        }
        [HttpPost]
        public async Task<ActionResult<Infrastructure>> Post(Infrastructure infrastructure)
        {
            return await infrastructureService.Add(infrastructure);
        }
        [HttpPut]
        public async Task<ActionResult<Infrastructure>> Put(Infrastructure infrastructure)
        {
            return await infrastructureService.Update(infrastructure);
        }
        [HttpDelete]
        public async Task<ActionResult<Infrastructure>> Delete(Infrastructure infrastructure)
        {
            return await infrastructureService.Delete(infrastructure);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
