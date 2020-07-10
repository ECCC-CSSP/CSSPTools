/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
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
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMikeSourceService MikeSourceService { get; }
        #endregion Properties

        #region Constructors
        public MikeSourceController(ICultureService CultureService, ILoggedInService LoggedInService, IMikeSourceService MikeSourceService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.MikeSourceService = MikeSourceService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeSource>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.GetMikeSourceList();
        }
        [HttpGet("{MikeSourceID}")]
        public async Task<ActionResult<MikeSource>> Get(int MikeSourceID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.GetMikeSourceWithMikeSourceID(MikeSourceID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeSource>> Post(MikeSource MikeSource)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.Post(MikeSource);
        }
        [HttpPut]
        public async Task<ActionResult<MikeSource>> Put(MikeSource MikeSource)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.Put(MikeSource);
        }
        [HttpDelete("{MikeSourceID}")]
        public async Task<ActionResult<bool>> Delete(int MikeSourceID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeSourceService.Delete(MikeSourceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
