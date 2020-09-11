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
    public partial interface IPolSourceObservationIssueController
    {
        Task<ActionResult<List<PolSourceObservationIssue>>> Get();
        Task<ActionResult<PolSourceObservationIssue>> Get(int PolSourceObservationIssueID);
        Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue PolSourceObservationIssue);
        Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue PolSourceObservationIssue);
        Task<ActionResult<bool>> Delete(int PolSourceObservationIssueID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class PolSourceObservationIssueController : ControllerBase, IPolSourceObservationIssueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IPolSourceObservationIssueDBLocalService PolSourceObservationIssueDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IPolSourceObservationIssueDBLocalService PolSourceObservationIssueDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.PolSourceObservationIssueDBLocalService = PolSourceObservationIssueDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceObservationIssue>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBLocalService.GetPolSourceObservationIssueList();
        }
        [HttpGet("{PolSourceObservationIssueID}")]
        public async Task<ActionResult<PolSourceObservationIssue>> Get(int PolSourceObservationIssueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBLocalService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(PolSourceObservationIssueID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue PolSourceObservationIssue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBLocalService.Post(PolSourceObservationIssue);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue PolSourceObservationIssue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBLocalService.Put(PolSourceObservationIssue);
        }
        [HttpDelete("{PolSourceObservationIssueID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceObservationIssueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBLocalService.Delete(PolSourceObservationIssueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
