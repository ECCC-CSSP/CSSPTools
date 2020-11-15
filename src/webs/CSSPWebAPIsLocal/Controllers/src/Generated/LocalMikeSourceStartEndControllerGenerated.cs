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
    public partial interface ILocalMikeSourceStartEndController
    {
        Task<ActionResult<List<LocalMikeSourceStartEnd>>> Get();
        Task<ActionResult<LocalMikeSourceStartEnd>> Get(int LocalMikeSourceStartEndID);
        Task<ActionResult<LocalMikeSourceStartEnd>> Post(LocalMikeSourceStartEnd LocalMikeSourceStartEnd);
        Task<ActionResult<LocalMikeSourceStartEnd>> Put(LocalMikeSourceStartEnd LocalMikeSourceStartEnd);
        Task<ActionResult<bool>> Delete(int LocalMikeSourceStartEndID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMikeSourceStartEndController : ControllerBase, ILocalMikeSourceStartEndController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMikeSourceStartEndDBService LocalMikeSourceStartEndDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMikeSourceStartEndController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMikeSourceStartEndDBService LocalMikeSourceStartEndDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMikeSourceStartEndDBService = LocalMikeSourceStartEndDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMikeSourceStartEnd>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeSourceStartEndDBService.GetLocalMikeSourceStartEndList();
        }
        [HttpGet("{LocalMikeSourceStartEndID}")]
        public async Task<ActionResult<LocalMikeSourceStartEnd>> Get(int MikeSourceStartEndID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeSourceStartEndDBService.GetLocalMikeSourceStartEndWithMikeSourceStartEndID(MikeSourceStartEndID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMikeSourceStartEnd>> Post(LocalMikeSourceStartEnd LocalMikeSourceStartEnd)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeSourceStartEndDBService.Post(LocalMikeSourceStartEnd);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMikeSourceStartEnd>> Put(LocalMikeSourceStartEnd LocalMikeSourceStartEnd)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeSourceStartEndDBService.Put(LocalMikeSourceStartEnd);
        }
        [HttpDelete("{LocalMikeSourceStartEndID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMikeSourceStartEndID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeSourceStartEndDBService.Delete(LocalMikeSourceStartEndID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}