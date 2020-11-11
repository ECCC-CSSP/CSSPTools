/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IRatingCurveValueDBService RatingCurveValueDBService { get; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IRatingCurveValueDBService RatingCurveValueDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.RatingCurveValueDBService = RatingCurveValueDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RatingCurveValue>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueDBService.GetRatingCurveValueList();
        }
        [HttpGet("{RatingCurveValueID}")]
        public async Task<ActionResult<RatingCurveValue>> Get(int RatingCurveValueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueDBService.GetRatingCurveValueWithRatingCurveValueID(RatingCurveValueID);
        }
        [HttpPost]
        public async Task<ActionResult<RatingCurveValue>> Post(RatingCurveValue RatingCurveValue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueDBService.Post(RatingCurveValue);
        }
        [HttpPut]
        public async Task<ActionResult<RatingCurveValue>> Put(RatingCurveValue RatingCurveValue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueDBService.Put(RatingCurveValue);
        }
        [HttpDelete("{RatingCurveValueID}")]
        public async Task<ActionResult<bool>> Delete(int RatingCurveValueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await RatingCurveValueDBService.Delete(RatingCurveValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
