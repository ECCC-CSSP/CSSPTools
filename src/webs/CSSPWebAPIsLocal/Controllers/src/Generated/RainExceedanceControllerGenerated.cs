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
    public partial interface IRainExceedanceController
    {
        Task<ActionResult<List<RainExceedance>>> Get();
        Task<ActionResult<RainExceedance>> Get(int RainExceedanceID);
        Task<ActionResult<RainExceedance>> Post(RainExceedance RainExceedance);
        Task<ActionResult<RainExceedance>> Put(RainExceedance RainExceedance);
        Task<ActionResult<bool>> Delete(int RainExceedanceID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class RainExceedanceController : ControllerBase, IRainExceedanceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IRainExceedanceDBLocalService RainExceedanceDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public RainExceedanceController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IRainExceedanceDBLocalService RainExceedanceDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.RainExceedanceDBLocalService = RainExceedanceDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<RainExceedance>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceDBLocalService.GetRainExceedanceList();
        }
        [HttpGet("{RainExceedanceID}")]
        public async Task<ActionResult<RainExceedance>> Get(int RainExceedanceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceDBLocalService.GetRainExceedanceWithRainExceedanceID(RainExceedanceID);
        }
        [HttpPost]
        public async Task<ActionResult<RainExceedance>> Post(RainExceedance RainExceedance)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceDBLocalService.Post(RainExceedance);
        }
        [HttpPut]
        public async Task<ActionResult<RainExceedance>> Put(RainExceedance RainExceedance)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceDBLocalService.Put(RainExceedance);
        }
        [HttpDelete("{RainExceedanceID}")]
        public async Task<ActionResult<bool>> Delete(int RainExceedanceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await RainExceedanceDBLocalService.Delete(RainExceedanceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
