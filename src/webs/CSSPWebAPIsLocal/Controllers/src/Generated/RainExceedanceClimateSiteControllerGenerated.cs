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
    public partial interface IRainExceedanceClimateSiteController
    {
        Task<ActionResult<List<RainExceedanceClimateSite>>> Get();
        Task<ActionResult<RainExceedanceClimateSite>> Get(int RainExceedanceClimateSiteID);
        Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite RainExceedanceClimateSite);
        Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite RainExceedanceClimateSite);
        Task<ActionResult<bool>> Delete(int RainExceedanceClimateSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class RainExceedanceClimateSiteController : ControllerBase, IRainExceedanceClimateSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IRainExceedanceClimateSiteDBLocalService RainExceedanceClimateSiteDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IRainExceedanceClimateSiteDBLocalService RainExceedanceClimateSiteDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.RainExceedanceClimateSiteDBLocalService = RainExceedanceClimateSiteDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RainExceedanceClimateSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceClimateSiteDBLocalService.GetRainExceedanceClimateSiteList();
        }
        [HttpGet("{RainExceedanceClimateSiteID}")]
        public async Task<ActionResult<RainExceedanceClimateSite>> Get(int RainExceedanceClimateSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceClimateSiteDBLocalService.GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(RainExceedanceClimateSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<RainExceedanceClimateSite>> Post(RainExceedanceClimateSite RainExceedanceClimateSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceClimateSiteDBLocalService.Post(RainExceedanceClimateSite);
        }
        [HttpPut]
        public async Task<ActionResult<RainExceedanceClimateSite>> Put(RainExceedanceClimateSite RainExceedanceClimateSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceClimateSiteDBLocalService.Put(RainExceedanceClimateSite);
        }
        [HttpDelete("{RainExceedanceClimateSiteID}")]
        public async Task<ActionResult<bool>> Delete(int RainExceedanceClimateSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceClimateSiteDBLocalService.Delete(RainExceedanceClimateSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
