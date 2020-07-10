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

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVItemLinkController
    {
        Task<ActionResult<List<TVItemLink>>> Get();
        Task<ActionResult<TVItemLink>> Get(int TVItemLinkID);
        Task<ActionResult<TVItemLink>> Post(TVItemLink TVItemLink);
        Task<ActionResult<TVItemLink>> Put(TVItemLink TVItemLink);
        Task<ActionResult<bool>> Delete(int TVItemLinkID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemLinkController : ControllerBase, ITVItemLinkController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITVItemLinkService TVItemLinkService { get; }
        #endregion Properties

        #region Constructors
        public TVItemLinkController(ICultureService CultureService, ILoggedInService LoggedInService, ITVItemLinkService TVItemLinkService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.TVItemLinkService = TVItemLinkService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemLink>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemLinkService.GetTVItemLinkList();
        }
        [HttpGet("{TVItemLinkID}")]
        public async Task<ActionResult<TVItemLink>> Get(int TVItemLinkID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemLinkService.GetTVItemLinkWithTVItemLinkID(TVItemLinkID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemLink>> Post(TVItemLink TVItemLink)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemLinkService.Post(TVItemLink);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemLink>> Put(TVItemLink TVItemLink)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemLinkService.Put(TVItemLink);
        }
        [HttpDelete("{TVItemLinkID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemLinkID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemLinkService.Delete(TVItemLinkID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
