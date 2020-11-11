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
    public partial interface IPolSourceSiteEffectController
    {
        Task<ActionResult<List<PolSourceSiteEffect>>> Get();
        Task<ActionResult<PolSourceSiteEffect>> Get(int PolSourceSiteEffectID);
        Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect PolSourceSiteEffect);
        Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect PolSourceSiteEffect);
        Task<ActionResult<bool>> Delete(int PolSourceSiteEffectID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class PolSourceSiteEffectController : ControllerBase, IPolSourceSiteEffectController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IPolSourceSiteEffectDBLocalService PolSourceSiteEffectDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IPolSourceSiteEffectDBLocalService PolSourceSiteEffectDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.PolSourceSiteEffectDBLocalService = PolSourceSiteEffectDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceSiteEffect>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteEffectDBLocalService.GetPolSourceSiteEffectList();
        }
        [HttpGet("{PolSourceSiteEffectID}")]
        public async Task<ActionResult<PolSourceSiteEffect>> Get(int PolSourceSiteEffectID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteEffectDBLocalService.GetPolSourceSiteEffectWithPolSourceSiteEffectID(PolSourceSiteEffectID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceSiteEffect>> Post(PolSourceSiteEffect PolSourceSiteEffect)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteEffectDBLocalService.Post(PolSourceSiteEffect);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceSiteEffect>> Put(PolSourceSiteEffect PolSourceSiteEffect)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteEffectDBLocalService.Put(PolSourceSiteEffect);
        }
        [HttpDelete("{PolSourceSiteEffectID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceSiteEffectID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceSiteEffectDBLocalService.Delete(PolSourceSiteEffectID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
