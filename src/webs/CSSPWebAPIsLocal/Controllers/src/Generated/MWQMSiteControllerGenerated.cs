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
    public partial interface IMWQMSiteController
    {
        Task<ActionResult<List<MWQMSite>>> Get();
        Task<ActionResult<MWQMSite>> Get(int MWQMSiteID);
        Task<ActionResult<MWQMSite>> Post(MWQMSite MWQMSite);
        Task<ActionResult<MWQMSite>> Put(MWQMSite MWQMSite);
        Task<ActionResult<bool>> Delete(int MWQMSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class MWQMSiteController : ControllerBase, IMWQMSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IMWQMSiteDBService MWQMSiteDBService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSiteController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IMWQMSiteDBService MWQMSiteDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.MWQMSiteDBService = MWQMSiteDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMSiteDBService.GetMWQMSiteList();
        }
        [HttpGet("{MWQMSiteID}")]
        public async Task<ActionResult<MWQMSite>> Get(int MWQMSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMSiteDBService.GetMWQMSiteWithMWQMSiteID(MWQMSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSite>> Post(MWQMSite MWQMSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMSiteDBService.Post(MWQMSite);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSite>> Put(MWQMSite MWQMSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMSiteDBService.Put(MWQMSite);
        }
        [HttpDelete("{MWQMSiteID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await MWQMSiteDBService.Delete(MWQMSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}