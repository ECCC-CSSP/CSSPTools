/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ISamplingPlanEmailController
    {
        Task<ActionResult<List<SamplingPlanEmail>>> Get();
        Task<ActionResult<SamplingPlanEmail>> Get(int SamplingPlanEmailID);
        Task<ActionResult<SamplingPlanEmail>> Post(SamplingPlanEmail SamplingPlanEmail);
        Task<ActionResult<SamplingPlanEmail>> Put(SamplingPlanEmail SamplingPlanEmail);
        Task<ActionResult<bool>> Delete(int SamplingPlanEmailID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class SamplingPlanEmailController : ControllerBase, ISamplingPlanEmailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ISamplingPlanEmailDBLocalService SamplingPlanEmailDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ISamplingPlanEmailDBLocalService SamplingPlanEmailDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.SamplingPlanEmailDBLocalService = SamplingPlanEmailDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SamplingPlanEmail>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await SamplingPlanEmailDBLocalService.GetSamplingPlanEmailList();
        }
        [HttpGet("{SamplingPlanEmailID}")]
        public async Task<ActionResult<SamplingPlanEmail>> Get(int SamplingPlanEmailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await SamplingPlanEmailDBLocalService.GetSamplingPlanEmailWithSamplingPlanEmailID(SamplingPlanEmailID);
        }
        [HttpPost]
        public async Task<ActionResult<SamplingPlanEmail>> Post(SamplingPlanEmail SamplingPlanEmail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await SamplingPlanEmailDBLocalService.Post(SamplingPlanEmail);
        }
        [HttpPut]
        public async Task<ActionResult<SamplingPlanEmail>> Put(SamplingPlanEmail SamplingPlanEmail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await SamplingPlanEmailDBLocalService.Put(SamplingPlanEmail);
        }
        [HttpDelete("{SamplingPlanEmailID}")]
        public async Task<ActionResult<bool>> Delete(int SamplingPlanEmailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await SamplingPlanEmailDBLocalService.Delete(SamplingPlanEmailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
