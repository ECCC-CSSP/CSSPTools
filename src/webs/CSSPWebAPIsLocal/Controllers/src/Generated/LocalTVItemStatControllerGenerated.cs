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
    public partial interface ILocalTVItemStatController
    {
        Task<ActionResult<List<LocalTVItemStat>>> Get();
        Task<ActionResult<LocalTVItemStat>> Get(int LocalTVItemStatID);
        Task<ActionResult<LocalTVItemStat>> Post(LocalTVItemStat LocalTVItemStat);
        Task<ActionResult<LocalTVItemStat>> Put(LocalTVItemStat LocalTVItemStat);
        Task<ActionResult<bool>> Delete(int LocalTVItemStatID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalTVItemStatController : ControllerBase, ILocalTVItemStatController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalTVItemStatDBService LocalTVItemStatDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalTVItemStatController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalTVItemStatDBService LocalTVItemStatDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalTVItemStatDBService = LocalTVItemStatDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalTVItemStat>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalTVItemStatDBService.GetLocalTVItemStatList();
        }
        [HttpGet("{LocalTVItemStatID}")]
        public async Task<ActionResult<LocalTVItemStat>> Get(int TVItemStatID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalTVItemStatDBService.GetLocalTVItemStatWithTVItemStatID(TVItemStatID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalTVItemStat>> Post(LocalTVItemStat LocalTVItemStat)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalTVItemStatDBService.Post(LocalTVItemStat);
        }
        [HttpPut]
        public async Task<ActionResult<LocalTVItemStat>> Put(LocalTVItemStat LocalTVItemStat)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalTVItemStatDBService.Put(LocalTVItemStat);
        }
        [HttpDelete("{LocalTVItemStatID}")]
        public async Task<ActionResult<bool>> Delete(int LocalTVItemStatID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalTVItemStatDBService.Delete(LocalTVItemStatID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}