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
    public partial interface IVPAmbientController
    {
        Task<ActionResult<List<VPAmbient>>> Get();
        Task<ActionResult<VPAmbient>> Get(int VPAmbientID);
        Task<ActionResult<VPAmbient>> Post(VPAmbient VPAmbient);
        Task<ActionResult<VPAmbient>> Put(VPAmbient VPAmbient);
        Task<ActionResult<bool>> Delete(int VPAmbientID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPAmbientController : ControllerBase, IVPAmbientController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IVPAmbientService VPAmbientService { get; }
        #endregion Properties

        #region Constructors
        public VPAmbientController(ICultureService CultureService, ILoggedInService LoggedInService, IVPAmbientService VPAmbientService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.VPAmbientService = VPAmbientService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPAmbient>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPAmbientService.GetVPAmbientList();
        }
        [HttpGet("{VPAmbientID}")]
        public async Task<ActionResult<VPAmbient>> Get(int VPAmbientID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPAmbientService.GetVPAmbientWithVPAmbientID(VPAmbientID);
        }
        [HttpPost]
        public async Task<ActionResult<VPAmbient>> Post(VPAmbient VPAmbient)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPAmbientService.Post(VPAmbient);
        }
        [HttpPut]
        public async Task<ActionResult<VPAmbient>> Put(VPAmbient VPAmbient)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPAmbientService.Put(VPAmbient);
        }
        [HttpDelete("{VPAmbientID}")]
        public async Task<ActionResult<bool>> Delete(int VPAmbientID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPAmbientService.Delete(VPAmbientID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
