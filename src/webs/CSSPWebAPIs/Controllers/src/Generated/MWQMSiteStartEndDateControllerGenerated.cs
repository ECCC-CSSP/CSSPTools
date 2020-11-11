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
        private IMWQMSiteStartEndDateDBService MWQMSiteStartEndDateDBService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMWQMSiteStartEndDateDBService MWQMSiteStartEndDateDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMSiteStartEndDateDBService = MWQMSiteStartEndDateDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSiteStartEndDate>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateDBService.GetMWQMSiteStartEndDateList();
        }
        [HttpGet("{MWQMSiteStartEndDateID}")]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Get(int MWQMSiteStartEndDateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateDBService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(MWQMSiteStartEndDateID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Post(MWQMSiteStartEndDate MWQMSiteStartEndDate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateDBService.Post(MWQMSiteStartEndDate);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSiteStartEndDate>> Put(MWQMSiteStartEndDate MWQMSiteStartEndDate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateDBService.Put(MWQMSiteStartEndDate);
        }
        [HttpDelete("{MWQMSiteStartEndDateID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSiteStartEndDateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMSiteStartEndDateDBService.Delete(MWQMSiteStartEndDateID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
