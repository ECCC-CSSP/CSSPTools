using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITideDataValueController
    {
        Task<ActionResult<List<TideDataValue>>> Get();
        Task<ActionResult<TideDataValue>> Get(int TideDataValueID);
        Task<ActionResult<TideDataValue>> Post(TideDataValue tideDataValue);
        Task<ActionResult<TideDataValue>> Put(TideDataValue tideDataValue);
        Task<ActionResult<TideDataValue>> Delete(TideDataValue tideDataValue);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TideDataValueController : ControllerBase, ITideDataValueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITideDataValueService tideDataValueService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TideDataValueController(ITideDataValueService tideDataValueService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tideDataValueService = tideDataValueService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideDataValue>>> Get()
        {
            return await tideDataValueService.GetTideDataValueList();
        }
        [HttpGet("{TideDataValueID}")]
        public async Task<ActionResult<TideDataValue>> Get(int TideDataValueID)
        {
            return await tideDataValueService.GetTideDataValueWithTideDataValueID(TideDataValueID);
        }
        [HttpPost]
        public async Task<ActionResult<TideDataValue>> Post(TideDataValue tideDataValue)
        {
            return await tideDataValueService.Add(tideDataValue);
        }
        [HttpPut]
        public async Task<ActionResult<TideDataValue>> Put(TideDataValue tideDataValue)
        {
            return await tideDataValueService.Update(tideDataValue);
        }
        [HttpDelete]
        public async Task<ActionResult<TideDataValue>> Delete(TideDataValue tideDataValue)
        {
            return await tideDataValueService.Delete(tideDataValue);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
