using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceGroupingController
    {
        Task<ActionResult<List<PolSourceGrouping>>> Get();
        Task<ActionResult<PolSourceGrouping>> Get(int PolSourceGroupingID);
        Task<ActionResult<PolSourceGrouping>> Post(PolSourceGrouping polSourceGrouping);
        Task<ActionResult<PolSourceGrouping>> Put(PolSourceGrouping polSourceGrouping);
        Task<ActionResult<PolSourceGrouping>> Delete(PolSourceGrouping polSourceGrouping);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceGroupingController : ControllerBase, IPolSourceGroupingController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceGroupingService polSourceGroupingService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingController(IPolSourceGroupingService polSourceGroupingService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceGroupingService = polSourceGroupingService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceGrouping>>> Get()
        {
            return await polSourceGroupingService.GetPolSourceGroupingList();
        }
        [HttpGet("{PolSourceGroupingID}")]
        public async Task<ActionResult<PolSourceGrouping>> Get(int PolSourceGroupingID)
        {
            return await polSourceGroupingService.GetPolSourceGroupingWithPolSourceGroupingID(PolSourceGroupingID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceGrouping>> Post(PolSourceGrouping polSourceGrouping)
        {
            return await polSourceGroupingService.Add(polSourceGrouping);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceGrouping>> Put(PolSourceGrouping polSourceGrouping)
        {
            return await polSourceGroupingService.Update(polSourceGrouping);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceGrouping>> Delete(PolSourceGrouping polSourceGrouping)
        {
            return await polSourceGroupingService.Delete(polSourceGrouping);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
