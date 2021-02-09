/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPWebAPIsLocalController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

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
    public partial class TVItemLinkController : ControllerBase, ITVItemLinkController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ITVItemLinkDBService TVItemLinkDBService { get; }
        #endregion Properties

        #region Constructors
        public TVItemLinkController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ITVItemLinkDBService TVItemLinkDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.TVItemLinkDBService = TVItemLinkDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemLink>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLinkDBService.GetTVItemLinkList();
        }
        [HttpGet("{TVItemLinkID}")]
        public async Task<ActionResult<TVItemLink>> Get(int TVItemLinkID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLinkDBService.GetTVItemLinkWithTVItemLinkID(TVItemLinkID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemLink>> Post(TVItemLink TVItemLink)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLinkDBService.Post(TVItemLink);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemLink>> Put(TVItemLink TVItemLink)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLinkDBService.Put(TVItemLink);
        }
        [HttpDelete("{TVItemLinkID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemLinkID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLinkDBService.Delete(TVItemLinkID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}