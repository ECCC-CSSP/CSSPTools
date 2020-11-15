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
    public partial interface ILocalMWQMAnalysisReportParameterController
    {
        Task<ActionResult<List<LocalMWQMAnalysisReportParameter>>> Get();
        Task<ActionResult<LocalMWQMAnalysisReportParameter>> Get(int LocalMWQMAnalysisReportParameterID);
        Task<ActionResult<LocalMWQMAnalysisReportParameter>> Post(LocalMWQMAnalysisReportParameter LocalMWQMAnalysisReportParameter);
        Task<ActionResult<LocalMWQMAnalysisReportParameter>> Put(LocalMWQMAnalysisReportParameter LocalMWQMAnalysisReportParameter);
        Task<ActionResult<bool>> Delete(int LocalMWQMAnalysisReportParameterID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMWQMAnalysisReportParameterController : ControllerBase, ILocalMWQMAnalysisReportParameterController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMWQMAnalysisReportParameterDBService LocalMWQMAnalysisReportParameterDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMWQMAnalysisReportParameterController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMWQMAnalysisReportParameterDBService LocalMWQMAnalysisReportParameterDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMWQMAnalysisReportParameterDBService = LocalMWQMAnalysisReportParameterDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMWQMAnalysisReportParameter>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMAnalysisReportParameterDBService.GetLocalMWQMAnalysisReportParameterList();
        }
        [HttpGet("{LocalMWQMAnalysisReportParameterID}")]
        public async Task<ActionResult<LocalMWQMAnalysisReportParameter>> Get(int MWQMAnalysisReportParameterID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMAnalysisReportParameterDBService.GetLocalMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMWQMAnalysisReportParameter>> Post(LocalMWQMAnalysisReportParameter LocalMWQMAnalysisReportParameter)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMAnalysisReportParameterDBService.Post(LocalMWQMAnalysisReportParameter);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMWQMAnalysisReportParameter>> Put(LocalMWQMAnalysisReportParameter LocalMWQMAnalysisReportParameter)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMAnalysisReportParameterDBService.Put(LocalMWQMAnalysisReportParameter);
        }
        [HttpDelete("{LocalMWQMAnalysisReportParameterID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMWQMAnalysisReportParameterID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMAnalysisReportParameterDBService.Delete(LocalMWQMAnalysisReportParameterID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}