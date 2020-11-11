/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsLocalController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBLocalModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ILocalMWQMSiteStartEndDateController
    {
        Task<ActionResult<List<LocalMWQMSiteStartEndDate>>> Get();
        Task<ActionResult<LocalMWQMSiteStartEndDate>> Get(int LocalMWQMSiteStartEndDateID);
        Task<ActionResult<LocalMWQMSiteStartEndDate>> Post(LocalMWQMSiteStartEndDate LocalMWQMSiteStartEndDate);
        Task<ActionResult<LocalMWQMSiteStartEndDate>> Put(LocalMWQMSiteStartEndDate LocalMWQMSiteStartEndDate);
        Task<ActionResult<bool>> Delete(int LocalMWQMSiteStartEndDateID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMWQMSiteStartEndDateController : ControllerBase, ILocalMWQMSiteStartEndDateController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMWQMSiteStartEndDateDBService LocalMWQMSiteStartEndDateDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMWQMSiteStartEndDateController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMWQMSiteStartEndDateDBService LocalMWQMSiteStartEndDateDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMWQMSiteStartEndDateDBService = LocalMWQMSiteStartEndDateDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMWQMSiteStartEndDate>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSiteStartEndDateDBService.GetLocalMWQMSiteStartEndDateList();
        }
        [HttpGet("{LocalMWQMSiteStartEndDateID}")]
        public async Task<ActionResult<LocalMWQMSiteStartEndDate>> Get(int MWQMSiteStartEndDateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSiteStartEndDateDBService.GetLocalMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(MWQMSiteStartEndDateID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMWQMSiteStartEndDate>> Post(LocalMWQMSiteStartEndDate LocalMWQMSiteStartEndDate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSiteStartEndDateDBService.Post(LocalMWQMSiteStartEndDate);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMWQMSiteStartEndDate>> Put(LocalMWQMSiteStartEndDate LocalMWQMSiteStartEndDate)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSiteStartEndDateDBService.Put(LocalMWQMSiteStartEndDate);
        }
        [HttpDelete("{LocalMWQMSiteStartEndDateID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMWQMSiteStartEndDateID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSiteStartEndDateDBService.Delete(LocalMWQMSiteStartEndDateID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
