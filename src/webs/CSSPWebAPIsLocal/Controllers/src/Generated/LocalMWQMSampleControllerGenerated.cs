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
    public partial interface ILocalMWQMSampleController
    {
        Task<ActionResult<List<LocalMWQMSample>>> Get();
        Task<ActionResult<LocalMWQMSample>> Get(int LocalMWQMSampleID);
        Task<ActionResult<LocalMWQMSample>> Post(LocalMWQMSample LocalMWQMSample);
        Task<ActionResult<LocalMWQMSample>> Put(LocalMWQMSample LocalMWQMSample);
        Task<ActionResult<bool>> Delete(int LocalMWQMSampleID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMWQMSampleController : ControllerBase, ILocalMWQMSampleController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMWQMSampleDBService LocalMWQMSampleDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMWQMSampleController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMWQMSampleDBService LocalMWQMSampleDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMWQMSampleDBService = LocalMWQMSampleDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMWQMSample>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSampleDBService.GetLocalMWQMSampleList();
        }
        [HttpGet("{LocalMWQMSampleID}")]
        public async Task<ActionResult<LocalMWQMSample>> Get(int MWQMSampleID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSampleDBService.GetLocalMWQMSampleWithMWQMSampleID(MWQMSampleID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMWQMSample>> Post(LocalMWQMSample LocalMWQMSample)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSampleDBService.Post(LocalMWQMSample);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMWQMSample>> Put(LocalMWQMSample LocalMWQMSample)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSampleDBService.Put(LocalMWQMSample);
        }
        [HttpDelete("{LocalMWQMSampleID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMWQMSampleID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMSampleDBService.Delete(LocalMWQMSampleID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}