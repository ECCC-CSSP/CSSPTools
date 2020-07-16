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
    public partial interface IInfrastructureController
    {
        Task<ActionResult<List<Infrastructure>>> Get();
        Task<ActionResult<Infrastructure>> Get(int InfrastructureID);
        Task<ActionResult<Infrastructure>> Post(Infrastructure Infrastructure);
        Task<ActionResult<Infrastructure>> Put(Infrastructure Infrastructure);
        Task<ActionResult<bool>> Delete(int InfrastructureID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class InfrastructureController : ControllerBase, IInfrastructureController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IInfrastructureService InfrastructureService { get; }
        #endregion Properties

        #region Constructors
        public InfrastructureController(ICultureService CultureService, ILoggedInService LoggedInService, IInfrastructureService InfrastructureService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.InfrastructureService = InfrastructureService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Infrastructure>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await InfrastructureService.GetInfrastructureList();
        }
        [HttpGet("{InfrastructureID}")]
        public async Task<ActionResult<Infrastructure>> Get(int InfrastructureID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await InfrastructureService.GetInfrastructureWithInfrastructureID(InfrastructureID);
        }
        [HttpPost]
        public async Task<ActionResult<Infrastructure>> Post(Infrastructure Infrastructure)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await InfrastructureService.Post(Infrastructure);
        }
        [HttpPut]
        public async Task<ActionResult<Infrastructure>> Put(Infrastructure Infrastructure)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await InfrastructureService.Put(Infrastructure);
        }
        [HttpDelete("{InfrastructureID}")]
        public async Task<ActionResult<bool>> Delete(int InfrastructureID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await InfrastructureService.Delete(InfrastructureID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
