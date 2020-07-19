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
    public partial interface IReportTypeController
    {
        Task<ActionResult<List<ReportType>>> Get();
        Task<ActionResult<ReportType>> Get(int ReportTypeID);
        Task<ActionResult<ReportType>> Post(ReportType ReportType);
        Task<ActionResult<ReportType>> Put(ReportType ReportType);
        Task<ActionResult<bool>> Delete(int ReportTypeID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ReportTypeController : ControllerBase, IReportTypeController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IReportTypeService ReportTypeService { get; }
        #endregion Properties

        #region Constructors
        public ReportTypeController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IReportTypeService ReportTypeService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ReportTypeService = ReportTypeService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ReportType>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ReportTypeService.GetReportTypeList();
        }
        [HttpGet("{ReportTypeID}")]
        public async Task<ActionResult<ReportType>> Get(int ReportTypeID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ReportTypeService.GetReportTypeWithReportTypeID(ReportTypeID);
        }
        [HttpPost]
        public async Task<ActionResult<ReportType>> Post(ReportType ReportType)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ReportTypeService.Post(ReportType);
        }
        [HttpPut]
        public async Task<ActionResult<ReportType>> Put(ReportType ReportType)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ReportTypeService.Put(ReportType);
        }
        [HttpDelete("{ReportTypeID}")]
        public async Task<ActionResult<bool>> Delete(int ReportTypeID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ReportTypeService.Delete(ReportTypeID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
