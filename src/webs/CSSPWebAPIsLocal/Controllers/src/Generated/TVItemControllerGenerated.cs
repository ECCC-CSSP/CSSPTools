/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVItemController
    {
        Task<ActionResult<List<TVItem>>> Get();
        Task<ActionResult<TVItem>> Get(int TVItemID);
        Task<ActionResult<TVItem>> Post(TVItem TVItem);
        Task<ActionResult<TVItem>> Put(TVItem TVItem);
        Task<ActionResult<bool>> Delete(int TVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class TVItemController : ControllerBase, ITVItemController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ITVItemDBLocalService TVItemDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public TVItemController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ITVItemDBLocalService TVItemDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.TVItemDBLocalService = TVItemDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItem>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemDBLocalService.GetTVItemList();
        }
        [HttpGet("{TVItemID}")]
        public async Task<ActionResult<TVItem>> Get(int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemDBLocalService.GetTVItemWithTVItemID(TVItemID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItem>> Post(TVItem TVItem)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemDBLocalService.Post(TVItem);
        }
        [HttpPut]
        public async Task<ActionResult<TVItem>> Put(TVItem TVItem)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemDBLocalService.Put(TVItem);
        }
        [HttpDelete("{TVItemID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemDBLocalService.Delete(TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
