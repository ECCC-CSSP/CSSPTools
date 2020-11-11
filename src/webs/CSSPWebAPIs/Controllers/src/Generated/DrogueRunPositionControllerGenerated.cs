/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
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
    public partial interface IDrogueRunPositionController
    {
        Task<ActionResult<List<DrogueRunPosition>>> Get();
        Task<ActionResult<DrogueRunPosition>> Get(int DrogueRunPositionID);
        Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition DrogueRunPosition);
        Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition DrogueRunPosition);
        Task<ActionResult<bool>> Delete(int DrogueRunPositionID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class DrogueRunPositionController : ControllerBase, IDrogueRunPositionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IDrogueRunPositionDBService DrogueRunPositionDBService { get; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IDrogueRunPositionDBService DrogueRunPositionDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.DrogueRunPositionDBService = DrogueRunPositionDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DrogueRunPosition>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionDBService.GetDrogueRunPositionList();
        }
        [HttpGet("{DrogueRunPositionID}")]
        public async Task<ActionResult<DrogueRunPosition>> Get(int DrogueRunPositionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionDBService.GetDrogueRunPositionWithDrogueRunPositionID(DrogueRunPositionID);
        }
        [HttpPost]
        public async Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition DrogueRunPosition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionDBService.Post(DrogueRunPosition);
        }
        [HttpPut]
        public async Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition DrogueRunPosition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionDBService.Put(DrogueRunPosition);
        }
        [HttpDelete("{DrogueRunPositionID}")]
        public async Task<ActionResult<bool>> Delete(int DrogueRunPositionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionDBService.Delete(DrogueRunPositionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
