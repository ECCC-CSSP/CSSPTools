using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IHydrometricDataValueController
    {
        Task<ActionResult<List<HydrometricDataValue>>> Get();
        Task<ActionResult<HydrometricDataValue>> Get(int HydrometricDataValueID);
        Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue hydrometricDataValue);
        Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue hydrometricDataValue);
        Task<ActionResult<HydrometricDataValue>> Delete(HydrometricDataValue hydrometricDataValue);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class HydrometricDataValueController : ControllerBase, IHydrometricDataValueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IHydrometricDataValueService hydrometricDataValueService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueController(IHydrometricDataValueService hydrometricDataValueService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.hydrometricDataValueService = hydrometricDataValueService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<HydrometricDataValue>>> Get()
        {
            return await hydrometricDataValueService.GetHydrometricDataValueList();
        }
        [HttpGet("{HydrometricDataValueID}")]
        public async Task<ActionResult<HydrometricDataValue>> Get(int HydrometricDataValueID)
        {
            return await hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(HydrometricDataValueID);
        }
        [HttpPost]
        public async Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue hydrometricDataValue)
        {
            return await hydrometricDataValueService.Add(hydrometricDataValue);
        }
        [HttpPut]
        public async Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue hydrometricDataValue)
        {
            return await hydrometricDataValueService.Update(hydrometricDataValue);
        }
        [HttpDelete]
        public async Task<ActionResult<HydrometricDataValue>> Delete(HydrometricDataValue hydrometricDataValue)
        {
            return await hydrometricDataValueService.Delete(hydrometricDataValue);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
