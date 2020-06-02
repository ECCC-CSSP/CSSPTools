using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceObservationController
    {
        Task<ActionResult<List<PolSourceObservation>>> Get();
        Task<ActionResult<PolSourceObservation>> Get(int PolSourceObservationID);
        Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation polSourceObservation);
        Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation polSourceObservation);
        Task<ActionResult<PolSourceObservation>> Delete(PolSourceObservation polSourceObservation);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceObservationController : ControllerBase, IPolSourceObservationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceObservationService polSourceObservationService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationController(IPolSourceObservationService polSourceObservationService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceObservationService = polSourceObservationService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceObservation>>> Get()
        {
            return await polSourceObservationService.GetPolSourceObservationList();
        }
        [HttpGet("{PolSourceObservationID}")]
        public async Task<ActionResult<PolSourceObservation>> Get(int PolSourceObservationID)
        {
            return await polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(PolSourceObservationID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation polSourceObservation)
        {
            return await polSourceObservationService.Add(polSourceObservation);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation polSourceObservation)
        {
            return await polSourceObservationService.Update(polSourceObservation);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceObservation>> Delete(PolSourceObservation polSourceObservation)
        {
            return await polSourceObservationService.Delete(polSourceObservation);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
