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
    public partial interface IMWQMSubsectorController
    {
        Task<ActionResult<List<MWQMSubsector>>> Get();
        Task<ActionResult<MWQMSubsector>> Get(int MWQMSubsectorID);
        Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector MWQMSubsector);
        Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector MWQMSubsector);
        Task<ActionResult<bool>> Delete(int MWQMSubsectorID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSubsectorController : ControllerBase, IMWQMSubsectorController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMWQMSubsectorDBService MWQMSubsectorDBService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMWQMSubsectorDBService MWQMSubsectorDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMSubsectorDBService = MWQMSubsectorDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSubsector>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSubsectorDBService.GetMWQMSubsectorList();
        }
        [HttpGet("{MWQMSubsectorID}")]
        public async Task<ActionResult<MWQMSubsector>> Get(int MWQMSubsectorID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSubsectorDBService.GetMWQMSubsectorWithMWQMSubsectorID(MWQMSubsectorID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSubsector>> Post(MWQMSubsector MWQMSubsector)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSubsectorDBService.Post(MWQMSubsector);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSubsector>> Put(MWQMSubsector MWQMSubsector)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSubsectorDBService.Put(MWQMSubsector);
        }
        [HttpDelete("{MWQMSubsectorID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSubsectorID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSubsectorDBService.Delete(MWQMSubsectorID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
