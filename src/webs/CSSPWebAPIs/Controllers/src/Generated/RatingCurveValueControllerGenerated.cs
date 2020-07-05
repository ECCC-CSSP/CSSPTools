/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
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
        Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue RatingCurveValue);
        Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue RatingCurveValue);
        Task<ActionResult<bool>> Delete(int RatingCurveValueID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class RatingCurveValueController : ControllerBase, IRatingCurveValueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IRatingCurveValueService RatingCurveValueService { get; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueController(ICultureService CultureService, ILoggedInService LoggedInService, IRatingCurveValueService RatingCurveValueService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.RatingCurveValueService = RatingCurveValueService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RatingCurveValue>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueService.GetRatingCurveValueList();
        }
        [HttpGet("{RatingCurveValueID}")]
        public async Task<ActionResult<RatingCurveValue>> Get(int RatingCurveValueID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(RatingCurveValueID);
        }
        [HttpPost]
        public async Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue RatingCurveValue)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueService.Post(RatingCurveValue);
        }
        [HttpPut]
        public async Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue RatingCurveValue)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueService.Put(RatingCurveValue);
        }
        [HttpDelete("{RatingCurveValueID}")]
        public async Task<ActionResult<bool>> Delete(int RatingCurveValueID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueService.Delete(RatingCurveValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
