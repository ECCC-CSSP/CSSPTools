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
    public partial interface ITVItemStatController
    {
        Task<ActionResult<List<TVItemStat>>> Get();
        Task<ActionResult<TVItemStat>> Get(int TVItemStatID);
        Task<ActionResult<TVItemStat>> Post(TVItemStat TVItemStat);
        Task<ActionResult<TVItemStat>> Put(TVItemStat TVItemStat);
        Task<ActionResult<bool>> Delete(int TVItemStatID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class TVItemStatController : ControllerBase, ITVItemStatController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ITVItemStatDBService TVItemStatDBService { get; }
        #endregion Properties

        #region Constructors
        public TVItemStatController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ITVItemStatDBService TVItemStatDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.TVItemStatDBService = TVItemStatDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemStat>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemStatDBService.GetTVItemStatList();
        }
        [HttpGet("{TVItemStatID}")]
        public async Task<ActionResult<TVItemStat>> Get(int TVItemStatID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemStatDBService.GetTVItemStatWithTVItemStatID(TVItemStatID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemStat>> Post(TVItemStat TVItemStat)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemStatDBService.Post(TVItemStat);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemStat>> Put(TVItemStat TVItemStat)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemStatDBService.Put(TVItemStat);
        }
        [HttpDelete("{TVItemStatID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemStatID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemStatDBService.Delete(TVItemStatID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}