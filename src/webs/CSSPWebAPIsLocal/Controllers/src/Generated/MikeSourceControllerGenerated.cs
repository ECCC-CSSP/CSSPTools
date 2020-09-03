/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IMikeSourceController
    {
        Task<ActionResult<List<MikeSource>>> Get();
        Task<ActionResult<MikeSource>> Get(int MikeSourceID);
        Task<ActionResult<MikeSource>> Post(MikeSource MikeSource);
        Task<ActionResult<MikeSource>> Put(MikeSource MikeSource);
        Task<ActionResult<bool>> Delete(int MikeSourceID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeSourceController : ControllerBase, IMikeSourceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMikeSourceService MikeSourceService { get; }
        #endregion Properties

        #region Constructors
        public MikeSourceController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMikeSourceService MikeSourceService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MikeSourceService = MikeSourceService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeSource>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.GetMikeSourceList();
        }
        [HttpGet("{MikeSourceID}")]
        public async Task<ActionResult<MikeSource>> Get(int MikeSourceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.GetMikeSourceWithMikeSourceID(MikeSourceID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeSource>> Post(MikeSource MikeSource)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.Post(MikeSource);
        }
        [HttpPut]
        public async Task<ActionResult<MikeSource>> Put(MikeSource MikeSource)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.Put(MikeSource);
        }
        [HttpDelete("{MikeSourceID}")]
        public async Task<ActionResult<bool>> Delete(int MikeSourceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.Delete(MikeSourceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
