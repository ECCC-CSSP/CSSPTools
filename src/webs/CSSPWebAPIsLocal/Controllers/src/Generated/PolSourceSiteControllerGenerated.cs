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
    public partial interface IPolSourceSiteController
    {
        Task<ActionResult<List<PolSourceSite>>> Get();
        Task<ActionResult<PolSourceSite>> Get(int PolSourceSiteID);
        Task<ActionResult<PolSourceSite>> Post(PolSourceSite PolSourceSite);
        Task<ActionResult<PolSourceSite>> Put(PolSourceSite PolSourceSite);
        Task<ActionResult<bool>> Delete(int PolSourceSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class PolSourceSiteController : ControllerBase, IPolSourceSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IPolSourceSiteDBService PolSourceSiteDBService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IPolSourceSiteDBService PolSourceSiteDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.PolSourceSiteDBService = PolSourceSiteDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteDBService.GetPolSourceSiteList();
        }
        [HttpGet("{PolSourceSiteID}")]
        public async Task<ActionResult<PolSourceSite>> Get(int PolSourceSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteDBService.GetPolSourceSiteWithPolSourceSiteID(PolSourceSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSite>> Post(PolSourceSite PolSourceSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteDBService.Post(PolSourceSite);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSite>> Put(PolSourceSite PolSourceSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteDBService.Put(PolSourceSite);
        }
        [HttpDelete("{PolSourceSiteID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteDBService.Delete(PolSourceSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}