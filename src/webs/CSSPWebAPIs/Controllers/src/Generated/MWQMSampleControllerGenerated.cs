/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IMWQMSampleController
    {
        Task<ActionResult<List<MWQMSample>>> Get();
        Task<ActionResult<MWQMSample>> Get(int MWQMSampleID);
        Task<ActionResult<MWQMSample>> Post(MWQMSample MWQMSample);
        Task<ActionResult<MWQMSample>> Put(MWQMSample MWQMSample);
        Task<ActionResult<bool>> Delete(int MWQMSampleID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSampleController : ControllerBase, IMWQMSampleController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMWQMSampleService MWQMSampleService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSampleController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMWQMSampleService MWQMSampleService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMSampleService = MWQMSampleService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSample>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSampleService.GetMWQMSampleList();
        }
        [HttpGet("{MWQMSampleID}")]
        public async Task<ActionResult<MWQMSample>> Get(int MWQMSampleID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSampleService.GetMWQMSampleWithMWQMSampleID(MWQMSampleID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSample>> Post(MWQMSample MWQMSample)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSampleService.Post(MWQMSample);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSample>> Put(MWQMSample MWQMSample)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSampleService.Put(MWQMSample);
        }
        [HttpDelete("{MWQMSampleID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSampleID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSampleService.Delete(MWQMSampleID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
