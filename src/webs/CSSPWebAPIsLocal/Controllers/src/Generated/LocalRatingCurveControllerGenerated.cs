/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsLocalController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBLocalModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ILocalRatingCurveController
    {
        Task<ActionResult<List<LocalRatingCurve>>> Get();
        Task<ActionResult<LocalRatingCurve>> Get(int LocalRatingCurveID);
        Task<ActionResult<LocalRatingCurve>> Post(LocalRatingCurve LocalRatingCurve);
        Task<ActionResult<LocalRatingCurve>> Put(LocalRatingCurve LocalRatingCurve);
        Task<ActionResult<bool>> Delete(int LocalRatingCurveID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalRatingCurveController : ControllerBase, ILocalRatingCurveController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalRatingCurveDBService LocalRatingCurveDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalRatingCurveController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalRatingCurveDBService LocalRatingCurveDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalRatingCurveDBService = LocalRatingCurveDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalRatingCurve>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalRatingCurveDBService.GetLocalRatingCurveList();
        }
        [HttpGet("{LocalRatingCurveID}")]
        public async Task<ActionResult<LocalRatingCurve>> Get(int RatingCurveID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalRatingCurveDBService.GetLocalRatingCurveWithRatingCurveID(RatingCurveID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalRatingCurve>> Post(LocalRatingCurve LocalRatingCurve)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalRatingCurveDBService.Post(LocalRatingCurve);
        }
        [HttpPut]
        public async Task<ActionResult<LocalRatingCurve>> Put(LocalRatingCurve LocalRatingCurve)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalRatingCurveDBService.Put(LocalRatingCurve);
        }
        [HttpDelete("{LocalRatingCurveID}")]
        public async Task<ActionResult<bool>> Delete(int LocalRatingCurveID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalRatingCurveDBService.Delete(LocalRatingCurveID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}