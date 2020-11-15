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
    public partial interface ILocalMapInfoController
    {
        Task<ActionResult<List<LocalMapInfo>>> Get();
        Task<ActionResult<LocalMapInfo>> Get(int LocalMapInfoID);
        Task<ActionResult<LocalMapInfo>> Post(LocalMapInfo LocalMapInfo);
        Task<ActionResult<LocalMapInfo>> Put(LocalMapInfo LocalMapInfo);
        Task<ActionResult<bool>> Delete(int LocalMapInfoID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMapInfoController : ControllerBase, ILocalMapInfoController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMapInfoDBService LocalMapInfoDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMapInfoController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMapInfoDBService LocalMapInfoDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMapInfoDBService = LocalMapInfoDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMapInfo>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMapInfoDBService.GetLocalMapInfoList();
        }
        [HttpGet("{LocalMapInfoID}")]
        public async Task<ActionResult<LocalMapInfo>> Get(int MapInfoID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMapInfoDBService.GetLocalMapInfoWithMapInfoID(MapInfoID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMapInfo>> Post(LocalMapInfo LocalMapInfo)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMapInfoDBService.Post(LocalMapInfo);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMapInfo>> Put(LocalMapInfo LocalMapInfo)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMapInfoDBService.Put(LocalMapInfo);
        }
        [HttpDelete("{LocalMapInfoID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMapInfoID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMapInfoDBService.Delete(LocalMapInfoID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}