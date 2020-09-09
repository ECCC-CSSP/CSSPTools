/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IHydrometricDataValueController
    {
        Task<ActionResult<List<HydrometricDataValue>>> Get();
        Task<ActionResult<HydrometricDataValue>> Get(int HydrometricDataValueID);
        Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue HydrometricDataValue);
        Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue HydrometricDataValue);
        Task<ActionResult<bool>> Delete(int HydrometricDataValueID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class HydrometricDataValueController : ControllerBase, IHydrometricDataValueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IHydrometricDataValueDBService HydrometricDataValueDBService { get; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IHydrometricDataValueDBService HydrometricDataValueDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.HydrometricDataValueDBService = HydrometricDataValueDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<HydrometricDataValue>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HydrometricDataValueDBService.GetHydrometricDataValueList();
        }
        [HttpGet("{HydrometricDataValueID}")]
        public async Task<ActionResult<HydrometricDataValue>> Get(int HydrometricDataValueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HydrometricDataValueDBService.GetHydrometricDataValueWithHydrometricDataValueID(HydrometricDataValueID);
        }
        [HttpPost]
        public async Task<ActionResult<HydrometricDataValue>> Post(HydrometricDataValue HydrometricDataValue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HydrometricDataValueDBService.Post(HydrometricDataValue);
        }
        [HttpPut]
        public async Task<ActionResult<HydrometricDataValue>> Put(HydrometricDataValue HydrometricDataValue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HydrometricDataValueDBService.Put(HydrometricDataValue);
        }
        [HttpDelete("{HydrometricDataValueID}")]
        public async Task<ActionResult<bool>> Delete(int HydrometricDataValueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HydrometricDataValueDBService.Delete(HydrometricDataValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
