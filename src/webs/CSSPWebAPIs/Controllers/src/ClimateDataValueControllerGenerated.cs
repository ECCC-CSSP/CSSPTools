using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IClimateDataValueController
    {
        Task<ActionResult<List<ClimateDataValue>>> Get();
        Task<ActionResult<ClimateDataValue>> Get(int ClimateDataValueID);
        Task<ActionResult<ClimateDataValue>> Post(ClimateDataValue climateDataValue);
        Task<ActionResult<ClimateDataValue>> Put(ClimateDataValue climateDataValue);
        Task<ActionResult<ClimateDataValue>> Delete(ClimateDataValue climateDataValue);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ClimateDataValueController : ControllerBase, IClimateDataValueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IClimateDataValueService climateDataValueService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueController(IClimateDataValueService climateDataValueService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.climateDataValueService = climateDataValueService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ClimateDataValue>>> Get()
        {
            return await climateDataValueService.GetClimateDataValueList();
        }
        [HttpGet("{ClimateDataValueID}")]
        public async Task<ActionResult<ClimateDataValue>> Get(int ClimateDataValueID)
        {
            return await climateDataValueService.GetClimateDataValueWithClimateDataValueID(ClimateDataValueID);
        }
        [HttpPost]
        public async Task<ActionResult<ClimateDataValue>> Post(ClimateDataValue climateDataValue)
        {
            return await climateDataValueService.Add(climateDataValue);
        }
        [HttpPut]
        public async Task<ActionResult<ClimateDataValue>> Put(ClimateDataValue climateDataValue)
        {
            return await climateDataValueService.Update(climateDataValue);
        }
        [HttpDelete]
        public async Task<ActionResult<ClimateDataValue>> Delete(ClimateDataValue climateDataValue)
        {
            return await climateDataValueService.Delete(climateDataValue);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
