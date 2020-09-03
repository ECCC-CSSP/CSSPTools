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

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IMWQMSiteStartEndDateController
    {
        Task<ActionResult<List<MWQMSiteStartEndDate>>> Get();
        Task<ActionResult<MWQMSiteStartEndDate>> Get(int MWQMSiteStartEndDateID);
        Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate MWQMSiteStartEndDate);
        Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate MWQMSiteStartEndDate);
        Task<ActionResult<bool>> Delete(int MWQMSiteStartEndDateID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSiteStartEndDateController : ControllerBase, IMWQMSiteStartEndDateController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMWQMSiteStartEndDateService MWQMSiteStartEndDateService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMWQMSiteStartEndDateService MWQMSiteStartEndDateService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMSiteStartEndDateService = MWQMSiteStartEndDateService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSiteStartEndDate>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateService.GetMWQMSiteStartEndDateList();
        }
        [HttpGet("{MWQMSiteStartEndDateID}")]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Get(int MWQMSiteStartEndDateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(MWQMSiteStartEndDateID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate MWQMSiteStartEndDate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateService.Post(MWQMSiteStartEndDate);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate MWQMSiteStartEndDate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateService.Put(MWQMSiteStartEndDate);
        }
        [HttpDelete("{MWQMSiteStartEndDateID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSiteStartEndDateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateService.Delete(MWQMSiteStartEndDateID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
