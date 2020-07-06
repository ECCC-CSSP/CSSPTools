/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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

namespace CSSPWebAPI.Controllers
{
    public partial interface IVPResultController
    {
        Task<ActionResult<List<VPResult>>> Get();
        Task<ActionResult<VPResult>> Get(int VPResultID);
        Task<ActionResult<VPResult>> Post(VPResult VPResult);
        Task<ActionResult<VPResult>> Put(VPResult VPResult);
        Task<ActionResult<bool>> Delete(int VPResultID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPResultController : ControllerBase, IVPResultController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IVPResultService VPResultService { get; }
        #endregion Properties

        #region Constructors
        public VPResultController(ICultureService CultureService, ILoggedInService LoggedInService, IVPResultService VPResultService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.VPResultService = VPResultService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPResult>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultService.GetVPResultList();
        }
        [HttpGet("{VPResultID}")]
        public async Task<ActionResult<VPResult>> Get(int VPResultID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultService.GetVPResultWithVPResultID(VPResultID);
        }
        [HttpPost]
        public async Task<ActionResult<VPResult>> Post(VPResult VPResult)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultService.Post(VPResult);
        }
        [HttpPut]
        public async Task<ActionResult<VPResult>> Put(VPResult VPResult)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultService.Put(VPResult);
        }
        [HttpDelete("{VPResultID}")]
        public async Task<ActionResult<bool>> Delete(int VPResultID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultService.Delete(VPResultID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
