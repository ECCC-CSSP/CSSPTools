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
    public partial interface IMikeSourceStartEndController
    {
        Task<ActionResult<List<MikeSourceStartEnd>>> Get();
        Task<ActionResult<MikeSourceStartEnd>> Get(int MikeSourceStartEndID);
        Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd MikeSourceStartEnd);
        Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd MikeSourceStartEnd);
        Task<ActionResult<bool>> Delete(int MikeSourceStartEndID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class MikeSourceStartEndController : ControllerBase, IMikeSourceStartEndController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IMikeSourceStartEndDBLocalService MikeSourceStartEndDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IMikeSourceStartEndDBLocalService MikeSourceStartEndDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.MikeSourceStartEndDBLocalService = MikeSourceStartEndDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeSourceStartEnd>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MikeSourceStartEndDBLocalService.GetMikeSourceStartEndList();
        }
        [HttpGet("{MikeSourceStartEndID}")]
        public async Task<ActionResult<MikeSourceStartEnd>> Get(int MikeSourceStartEndID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MikeSourceStartEndDBLocalService.GetMikeSourceStartEndWithMikeSourceStartEndID(MikeSourceStartEndID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeSourceStartEnd>> Post(MikeSourceStartEnd MikeSourceStartEnd)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MikeSourceStartEndDBLocalService.Post(MikeSourceStartEnd);
        }
        [HttpPut]
        public async Task<ActionResult<MikeSourceStartEnd>> Put(MikeSourceStartEnd MikeSourceStartEnd)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MikeSourceStartEndDBLocalService.Put(MikeSourceStartEnd);
        }
        [HttpDelete("{MikeSourceStartEndID}")]
        public async Task<ActionResult<bool>> Delete(int MikeSourceStartEndID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MikeSourceStartEndDBLocalService.Delete(MikeSourceStartEndID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}