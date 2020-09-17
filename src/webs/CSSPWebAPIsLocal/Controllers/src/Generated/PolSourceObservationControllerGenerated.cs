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
    public partial interface IPolSourceObservationController
    {
        Task<ActionResult<List<PolSourceObservation>>> Get();
        Task<ActionResult<PolSourceObservation>> Get(int PolSourceObservationID);
        Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation PolSourceObservation);
        Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation PolSourceObservation);
        Task<ActionResult<bool>> Delete(int PolSourceObservationID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class PolSourceObservationController : ControllerBase, IPolSourceObservationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IPolSourceObservationDBLocalService PolSourceObservationDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IPolSourceObservationDBLocalService PolSourceObservationDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.PolSourceObservationDBLocalService = PolSourceObservationDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceObservation>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationDBLocalService.GetPolSourceObservationList();
        }
        [HttpGet("{PolSourceObservationID}")]
        public async Task<ActionResult<PolSourceObservation>> Get(int PolSourceObservationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationDBLocalService.GetPolSourceObservationWithPolSourceObservationID(PolSourceObservationID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceObservation>> Post(PolSourceObservation PolSourceObservation)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationDBLocalService.Post(PolSourceObservation);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceObservation>> Put(PolSourceObservation PolSourceObservation)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationDBLocalService.Put(PolSourceObservation);
        }
        [HttpDelete("{PolSourceObservationID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceObservationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await PolSourceObservationDBLocalService.Delete(PolSourceObservationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}