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

namespace CSSPWebAPI.Controllers
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
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IPolSourceSiteEffectTermService PolSourceSiteEffectTermService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermController(ICultureService CultureService, ILoggedInService LoggedInService, IPolSourceSiteEffectTermService PolSourceSiteEffectTermService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.PolSourceSiteEffectTermService = PolSourceSiteEffectTermService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSiteEffectTerm>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermService.GetPolSourceSiteEffectTermList();
        }
        [HttpGet("{PolSourceSiteEffectTermID}")]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Get(int PolSourceSiteEffectTermID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermService.GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(PolSourceSiteEffectTermID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Post(PolSourceSiteEffectTerm PolSourceSiteEffectTerm)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermService.Post(PolSourceSiteEffectTerm);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSiteEffectTerm>> Put(PolSourceSiteEffectTerm PolSourceSiteEffectTerm)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermService.Put(PolSourceSiteEffectTerm);
        }
        [HttpDelete("{PolSourceSiteEffectTermID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectTermID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceSiteEffectTermService.Delete(PolSourceSiteEffectTermID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
