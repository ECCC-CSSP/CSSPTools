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
    public partial interface ITideSiteController
    {
        Task<ActionResult<List<TideSite>>> Get();
        Task<ActionResult<TideSite>> Get(int TideSiteID);
        Task<ActionResult<TideSite>> Post(TideSite TideSite);
        Task<ActionResult<TideSite>> Put(TideSite TideSite);
        Task<ActionResult<bool>> Delete(int TideSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class TideSiteController : ControllerBase, ITideSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ITideSiteDBService TideSiteDBService { get; }
        #endregion Properties

        #region Constructors
        public TideSiteController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ITideSiteDBService TideSiteDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.TideSiteDBService = TideSiteDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TideSiteDBService.GetTideSiteList();
        }
        [HttpGet("{TideSiteID}")]
        public async Task<ActionResult<TideSite>> Get(int TideSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TideSiteDBService.GetTideSiteWithTideSiteID(TideSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<TideSite>> Post(TideSite TideSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TideSiteDBService.Post(TideSite);
        }
        [HttpPut]
        public async Task<ActionResult<TideSite>> Put(TideSite TideSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TideSiteDBService.Put(TideSite);
        }
        [HttpDelete("{TideSiteID}")]
        public async Task<ActionResult<bool>> Delete(int TideSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TideSiteDBService.Delete(TideSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}