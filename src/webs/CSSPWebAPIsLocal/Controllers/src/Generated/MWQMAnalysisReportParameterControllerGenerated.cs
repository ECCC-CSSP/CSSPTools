/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IMWQMAnalysisReportParameterController
    {
        Task<ActionResult<List<MWQMAnalysisReportParameter>>> Get();
        Task<ActionResult<MWQMAnalysisReportParameter>> Get(int MWQMAnalysisReportParameterID);
        Task<ActionResult<MWQMAnalysisReportParameter>> Post(MWQMAnalysisReportParameter MWQMAnalysisReportParameter);
        Task<ActionResult<MWQMAnalysisReportParameter>> Put(MWQMAnalysisReportParameter MWQMAnalysisReportParameter);
        Task<ActionResult<bool>> Delete(int MWQMAnalysisReportParameterID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class MWQMAnalysisReportParameterController : ControllerBase, IMWQMAnalysisReportParameterController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IMWQMAnalysisReportParameterDBLocalService MWQMAnalysisReportParameterDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IMWQMAnalysisReportParameterDBLocalService MWQMAnalysisReportParameterDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.MWQMAnalysisReportParameterDBLocalService = MWQMAnalysisReportParameterDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMAnalysisReportParameter>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMAnalysisReportParameterDBLocalService.GetMWQMAnalysisReportParameterList();
        }
        [HttpGet("{MWQMAnalysisReportParameterID}")]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Get(int MWQMAnalysisReportParameterID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMAnalysisReportParameterDBLocalService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Post(MWQMAnalysisReportParameter MWQMAnalysisReportParameter)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMAnalysisReportParameterDBLocalService.Post(MWQMAnalysisReportParameter);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Put(MWQMAnalysisReportParameter MWQMAnalysisReportParameter)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMAnalysisReportParameterDBLocalService.Put(MWQMAnalysisReportParameter);
        }
        [HttpDelete("{MWQMAnalysisReportParameterID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMAnalysisReportParameterID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMAnalysisReportParameterDBLocalService.Delete(MWQMAnalysisReportParameterID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
