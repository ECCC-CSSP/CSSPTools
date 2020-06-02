using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IRatingCurveValueController
    {
        Task<ActionResult<List<RatingCurveValue>>> Get();
        Task<ActionResult<RatingCurveValue>> Get(int RatingCurveValueID);
        Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue ratingCurveValue);
        Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue ratingCurveValue);
        Task<ActionResult<RatingCurveValue>> Delete(RatingCurveValue ratingCurveValue);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RatingCurveValueController : ControllerBase, IRatingCurveValueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IRatingCurveValueService ratingCurveValueService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueController(IRatingCurveValueService ratingCurveValueService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.ratingCurveValueService = ratingCurveValueService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RatingCurveValue>>> Get()
        {
            return await ratingCurveValueService.GetRatingCurveValueList();
        }
        [HttpGet("{RatingCurveValueID}")]
        public async Task<ActionResult<RatingCurveValue>> Get(int RatingCurveValueID)
        {
            return await ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(RatingCurveValueID);
        }
        [HttpPost]
        public async Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue ratingCurveValue)
        {
            return await ratingCurveValueService.Add(ratingCurveValue);
        }
        [HttpPut]
        public async Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue ratingCurveValue)
        {
            return await ratingCurveValueService.Update(ratingCurveValue);
        }
        [HttpDelete]
        public async Task<ActionResult<RatingCurveValue>> Delete(RatingCurveValue ratingCurveValue)
        {
            return await ratingCurveValueService.Delete(ratingCurveValue);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
