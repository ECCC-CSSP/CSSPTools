using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMSubsectorController
    {
        Task<ActionResult<List<MWQMSubsector>>> Get();
        Task<ActionResult<MWQMSubsector>> Get(int MWQMSubsectorID);
        Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector mwqmSubsector);
        Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector mwqmSubsector);
        Task<ActionResult<MWQMSubsector>> Delete(MWQMSubsector mwqmSubsector);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSubsectorController : ControllerBase, IMWQMSubsectorController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMSubsectorService mwqmSubsectorService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorController(IMWQMSubsectorService mwqmSubsectorService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmSubsectorService = mwqmSubsectorService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSubsector>>> Get()
        {
            return await mwqmSubsectorService.GetMWQMSubsectorList();
        }
        [HttpGet("{MWQMSubsectorID}")]
        public async Task<ActionResult<MWQMSubsector>> Get(int MWQMSubsectorID)
        {
            return await mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(MWQMSubsectorID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector mwqmSubsector)
        {
            return await mwqmSubsectorService.Add(mwqmSubsector);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector mwqmSubsector)
        {
            return await mwqmSubsectorService.Update(mwqmSubsector);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMSubsector>> Delete(MWQMSubsector mwqmSubsector)
        {
            return await mwqmSubsectorService.Delete(mwqmSubsector);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
