/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
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
    public partial interface IPolSourceSiteEffectTermController
    {
        Task<ActionResult<List<PolSourceSiteEffectTerm>>> Get();
        Task<ActionResult<PolSourceSiteEffectTerm>> Get(int PolSourceSiteEffectTermID);
        Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm PolSourceSiteEffectTerm);
        Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm PolSourceSiteEffectTerm);
        Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceSiteEffectTermController : ControllerBase, IPolSourceSiteEffectTermController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IPolSourceSiteEffectTermDBService PolSourceSiteEffectTermDBService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IPolSourceSiteEffectTermDBService PolSourceSiteEffectTermDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.PolSourceSiteEffectTermDBService = PolSourceSiteEffectTermDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSiteEffectTerm>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermDBService.GetPolSourceSiteEffectTermList();
        }
        [HttpGet("{PolSourceSiteEffectTermID}")]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Get(int PolSourceSiteEffectTermID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermDBService.GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(PolSourceSiteEffectTermID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm PolSourceSiteEffectTerm)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermDBService.Post(PolSourceSiteEffectTerm);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm PolSourceSiteEffectTerm)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermDBService.Put(PolSourceSiteEffectTerm);
        }
        [HttpDelete("{PolSourceSiteEffectTermID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermDBService.Delete(PolSourceSiteEffectTermID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
