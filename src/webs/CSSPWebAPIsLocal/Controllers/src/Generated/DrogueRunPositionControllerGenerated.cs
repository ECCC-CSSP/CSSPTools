/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIsLocal.Controllers
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
        private IDrogueRunPositionService DrogueRunPositionService { get; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IDrogueRunPositionService DrogueRunPositionService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.DrogueRunPositionService = DrogueRunPositionService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DrogueRunPosition>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionService.GetDrogueRunPositionList();
        }
        [HttpGet("{DrogueRunPositionID}")]
        public async Task<ActionResult<DrogueRunPosition>> Get(int DrogueRunPositionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionService.GetDrogueRunPositionWithDrogueRunPositionID(DrogueRunPositionID);
        }
        [HttpPost]
        public async Task<ActionResult<DrogueRunPosition>> Post(DrogueRunPosition DrogueRunPosition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionService.Post(DrogueRunPosition);
        }
        [HttpPut]
        public async Task<ActionResult<DrogueRunPosition>> Put(DrogueRunPosition DrogueRunPosition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionService.Put(DrogueRunPosition);
        }
        [HttpDelete("{DrogueRunPositionID}")]
        public async Task<ActionResult<bool>> Delete(int DrogueRunPositionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunPositionService.Delete(DrogueRunPositionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
