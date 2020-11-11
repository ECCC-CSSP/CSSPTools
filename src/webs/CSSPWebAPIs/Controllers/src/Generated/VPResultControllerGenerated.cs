/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IVPResultDBService VPResultDBService { get; }
        #endregion Properties

        #region Constructors
        public VPResultController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IVPResultDBService VPResultDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.VPResultDBService = VPResultDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPResult>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultDBService.GetVPResultList();
        }
        [HttpGet("{VPResultID}")]
        public async Task<ActionResult<VPResult>> Get(int VPResultID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultDBService.GetVPResultWithVPResultID(VPResultID);
        }
        [HttpPost]
        public async Task<ActionResult<VPResult>> Post(VPResult VPResult)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultDBService.Post(VPResult);
        }
        [HttpPut]
        public async Task<ActionResult<VPResult>> Put(VPResult VPResult)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultDBService.Put(VPResult);
        }
        [HttpDelete("{VPResultID}")]
        public async Task<ActionResult<bool>> Delete(int VPResultID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPResultDBService.Delete(VPResultID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
