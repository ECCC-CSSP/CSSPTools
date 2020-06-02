using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IRatingCurveController
    {
        Task<ActionResult<List<RatingCurve>>> Get();
        Task<ActionResult<RatingCurve>> Get(int RatingCurveID);
        Task<ActionResult<RatingCurve>> Post(RatingCurve ratingCurve);
        Task<ActionResult<RatingCurve>> Put(RatingCurve ratingCurve);
        Task<ActionResult<RatingCurve>> Delete(RatingCurve ratingCurve);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RatingCurveController : ControllerBase, IRatingCurveController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IRatingCurveService ratingCurveService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public RatingCurveController(IRatingCurveService ratingCurveService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.ratingCurveService = ratingCurveService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RatingCurve>>> Get()
        {
            return await ratingCurveService.GetRatingCurveList();
        }
        [HttpGet("{RatingCurveID}")]
        public async Task<ActionResult<RatingCurve>> Get(int RatingCurveID)
        {
            return await ratingCurveService.GetRatingCurveWithRatingCurveID(RatingCurveID);
        }
        [HttpPost]
        public async Task<ActionResult<RatingCurve>> Post(RatingCurve ratingCurve)
        {
            return await ratingCurveService.Add(ratingCurve);
        }
        [HttpPut]
        public async Task<ActionResult<RatingCurve>> Put(RatingCurve ratingCurve)
        {
            return await ratingCurveService.Update(ratingCurve);
        }
        [HttpDelete]
        public async Task<ActionResult<RatingCurve>> Delete(RatingCurve ratingCurve)
        {
            return await ratingCurveService.Delete(ratingCurve);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
