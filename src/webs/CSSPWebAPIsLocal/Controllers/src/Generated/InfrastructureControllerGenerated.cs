/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

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
    public partial class InfrastructureController : ControllerBase, IInfrastructureController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IInfrastructureDBLocalService InfrastructureDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public InfrastructureController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IInfrastructureDBLocalService InfrastructureDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.InfrastructureDBLocalService = InfrastructureDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Infrastructure>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureDBLocalService.GetInfrastructureList();
        }
        [HttpGet("{InfrastructureID}")]
        public async Task<ActionResult<Infrastructure>> Get(int InfrastructureID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureDBLocalService.GetInfrastructureWithInfrastructureID(InfrastructureID);
        }
        [HttpPost]
        public async Task<ActionResult<Infrastructure>> Post(Infrastructure Infrastructure)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureDBLocalService.Post(Infrastructure);
        }
        [HttpPut]
        public async Task<ActionResult<Infrastructure>> Put(Infrastructure Infrastructure)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureDBLocalService.Put(Infrastructure);
        }
        [HttpDelete("{InfrastructureID}")]
        public async Task<ActionResult<bool>> Delete(int InfrastructureID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureDBLocalService.Delete(InfrastructureID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
