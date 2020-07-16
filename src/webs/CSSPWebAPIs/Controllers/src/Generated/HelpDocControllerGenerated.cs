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
    public partial interface IHelpDocController
    {
        Task<ActionResult<List<HelpDoc>>> Get();
        Task<ActionResult<HelpDoc>> Get(int HelpDocID);
        Task<ActionResult<HelpDoc>> Post(HelpDoc HelpDoc);
        Task<ActionResult<HelpDoc>> Put(HelpDoc HelpDoc);
        Task<ActionResult<bool>> Delete(int HelpDocID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class HelpDocController : ControllerBase, IHelpDocController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IHelpDocService HelpDocService { get; }
        #endregion Properties

        #region Constructors
        public HelpDocController(ICultureService CultureService, ILoggedInService LoggedInService, IHelpDocService HelpDocService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.HelpDocService = HelpDocService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<HelpDoc>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HelpDocService.GetHelpDocList();
        }
        [HttpGet("{HelpDocID}")]
        public async Task<ActionResult<HelpDoc>> Get(int HelpDocID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HelpDocService.GetHelpDocWithHelpDocID(HelpDocID);
        }
        [HttpPost]
        public async Task<ActionResult<HelpDoc>> Post(HelpDoc HelpDoc)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HelpDocService.Post(HelpDoc);
        }
        [HttpPut]
        public async Task<ActionResult<HelpDoc>> Put(HelpDoc HelpDoc)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HelpDocService.Put(HelpDoc);
        }
        [HttpDelete("{HelpDocID}")]
        public async Task<ActionResult<bool>> Delete(int HelpDocID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await HelpDocService.Delete(HelpDocID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
