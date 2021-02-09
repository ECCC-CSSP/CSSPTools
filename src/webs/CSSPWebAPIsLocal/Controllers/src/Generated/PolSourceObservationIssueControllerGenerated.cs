/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPWebAPIsLocalController.exe
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
        private IPolSourceObservationIssueDBService PolSourceObservationIssueDBService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IPolSourceObservationIssueDBService PolSourceObservationIssueDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.PolSourceObservationIssueDBService = PolSourceObservationIssueDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceObservationIssue>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBService.GetPolSourceObservationIssueList();
        }
        [HttpGet("{PolSourceObservationIssueID}")]
        public async Task<ActionResult<PolSourceObservationIssue>> Get(int PolSourceObservationIssueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(PolSourceObservationIssueID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue PolSourceObservationIssue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBService.Post(PolSourceObservationIssue);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue PolSourceObservationIssue)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBService.Put(PolSourceObservationIssue);
        }
        [HttpDelete("{PolSourceObservationIssueID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceObservationIssueID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationIssueDBService.Delete(PolSourceObservationIssueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}