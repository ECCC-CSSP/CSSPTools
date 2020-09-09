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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITelDBService TelDBService { get; }
        #endregion Properties

        #region Constructors
        public TelController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ITelDBService TelDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.TelDBService = TelDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Tel>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelDBService.GetTelList();
        }
        [HttpGet("{TelID}")]
        public async Task<ActionResult<Tel>> Get(int TelID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelDBService.GetTelWithTelID(TelID);
        }
        [HttpPost]
        public async Task<ActionResult<Tel>> Post(Tel Tel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelDBService.Post(Tel);
        }
        [HttpPut]
        public async Task<ActionResult<Tel>> Put(Tel Tel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelDBService.Put(Tel);
        }
        [HttpDelete("{TelID}")]
        public async Task<ActionResult<bool>> Delete(int TelID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TelDBService.Delete(TelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
