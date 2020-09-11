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
    public partial interface IClimateSiteController
    {
        Task<ActionResult<List<ClimateSite>>> Get();
        Task<ActionResult<ClimateSite>> Get(int ClimateSiteID);
        Task<ActionResult<ClimateSite>> Post(ClimateSite ClimateSite);
        Task<ActionResult<ClimateSite>> Put(ClimateSite ClimateSite);
        Task<ActionResult<bool>> Delete(int ClimateSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class ClimateSiteController : ControllerBase, IClimateSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IClimateSiteDBLocalService ClimateSiteDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public ClimateSiteController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IClimateSiteDBLocalService ClimateSiteDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.ClimateSiteDBLocalService = ClimateSiteDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ClimateSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ClimateSiteDBLocalService.GetClimateSiteList();
        }
        [HttpGet("{ClimateSiteID}")]
        public async Task<ActionResult<ClimateSite>> Get(int ClimateSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ClimateSiteDBLocalService.GetClimateSiteWithClimateSiteID(ClimateSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<ClimateSite>> Post(ClimateSite ClimateSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ClimateSiteDBLocalService.Post(ClimateSite);
        }
        [HttpPut]
        public async Task<ActionResult<ClimateSite>> Put(ClimateSite ClimateSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ClimateSiteDBLocalService.Put(ClimateSite);
        }
        [HttpDelete("{ClimateSiteID}")]
        public async Task<ActionResult<bool>> Delete(int ClimateSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ClimateSiteDBLocalService.Delete(ClimateSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
