using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITideLocationController
    {
        Task<ActionResult<List<TideLocation>>> Get();
        Task<ActionResult<TideLocation>> Get(int TideLocationID);
        Task<ActionResult<TideLocation>> Post(TideLocation tideLocation);
        Task<ActionResult<TideLocation>> Put(TideLocation tideLocation);
        Task<ActionResult<TideLocation>> Delete(TideLocation tideLocation);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TideLocationController : ControllerBase, ITideLocationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITideLocationService tideLocationService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TideLocationController(ITideLocationService tideLocationService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tideLocationService = tideLocationService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideLocation>>> Get()
        {
            return await tideLocationService.GetTideLocationList();
        }
        [HttpGet("{TideLocationID}")]
        public async Task<ActionResult<TideLocation>> Get(int TideLocationID)
        {
            return await tideLocationService.GetTideLocationWithTideLocationID(TideLocationID);
        }
        [HttpPost]
        public async Task<ActionResult<TideLocation>> Post(TideLocation tideLocation)
        {
            return await tideLocationService.Add(tideLocation);
        }
        [HttpPut]
        public async Task<ActionResult<TideLocation>> Put(TideLocation tideLocation)
        {
            return await tideLocationService.Update(tideLocation);
        }
        [HttpDelete]
        public async Task<ActionResult<TideLocation>> Delete(TideLocation tideLocation)
        {
            return await tideLocationService.Delete(tideLocation);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
