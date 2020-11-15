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
    public partial interface ILocalMWQMRunController
    {
        Task<ActionResult<List<LocalMWQMRun>>> Get();
        Task<ActionResult<LocalMWQMRun>> Get(int LocalMWQMRunID);
        Task<ActionResult<LocalMWQMRun>> Post(LocalMWQMRun LocalMWQMRun);
        Task<ActionResult<LocalMWQMRun>> Put(LocalMWQMRun LocalMWQMRun);
        Task<ActionResult<bool>> Delete(int LocalMWQMRunID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMWQMRunController : ControllerBase, ILocalMWQMRunController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMWQMRunDBService LocalMWQMRunDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMWQMRunController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMWQMRunDBService LocalMWQMRunDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMWQMRunDBService = LocalMWQMRunDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMWQMRun>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMRunDBService.GetLocalMWQMRunList();
        }
        [HttpGet("{LocalMWQMRunID}")]
        public async Task<ActionResult<LocalMWQMRun>> Get(int MWQMRunID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMRunDBService.GetLocalMWQMRunWithMWQMRunID(MWQMRunID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMWQMRun>> Post(LocalMWQMRun LocalMWQMRun)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMRunDBService.Post(LocalMWQMRun);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMWQMRun>> Put(LocalMWQMRun LocalMWQMRun)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMRunDBService.Put(LocalMWQMRun);
        }
        [HttpDelete("{LocalMWQMRunID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMWQMRunID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMWQMRunDBService.Delete(LocalMWQMRunID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}