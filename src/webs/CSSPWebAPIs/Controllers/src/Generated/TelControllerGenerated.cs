/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
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

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITelController
    {
        Task<ActionResult<List<Tel>>> Get();
        Task<ActionResult<Tel>> Get(int TelID);
        Task<ActionResult<Tel>> Post(Tel Tel);
        Task<ActionResult<Tel>> Put(Tel Tel);
        Task<ActionResult<bool>> Delete(int TelID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TelController : ControllerBase, ITelController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITelService TelService { get; }
        #endregion Properties

        #region Constructors
        public TelController(ICultureService CultureService, ILoggedInService LoggedInService, ITelService TelService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.TelService = TelService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Tel>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelService.GetTelList();
        }
        [HttpGet("{TelID}")]
        public async Task<ActionResult<Tel>> Get(int TelID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelService.GetTelWithTelID(TelID);
        }
        [HttpPost]
        public async Task<ActionResult<Tel>> Post(Tel Tel)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelService.Post(Tel);
        }
        [HttpPut]
        public async Task<ActionResult<Tel>> Put(Tel Tel)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelService.Put(Tel);
        }
        [HttpDelete("{TelID}")]
        public async Task<ActionResult<bool>> Delete(int TelID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelService.Delete(TelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
