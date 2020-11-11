/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsLocalController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBLocalModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ILocalClassificationController
    {
        Task<ActionResult<List<LocalClassification>>> Get();
        Task<ActionResult<LocalClassification>> Get(int LocalClassificationID);
        Task<ActionResult<LocalClassification>> Post(LocalClassification LocalClassification);
        Task<ActionResult<LocalClassification>> Put(LocalClassification LocalClassification);
        Task<ActionResult<bool>> Delete(int LocalClassificationID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalClassificationController : ControllerBase, ILocalClassificationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalClassificationDBService LocalClassificationDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalClassificationController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalClassificationDBService LocalClassificationDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalClassificationDBService = LocalClassificationDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalClassification>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalClassificationDBService.GetLocalClassificationList();
        }
        [HttpGet("{LocalClassificationID}")]
        public async Task<ActionResult<LocalClassification>> Get(int ClassificationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalClassificationDBService.GetLocalClassificationWithClassificationID(ClassificationID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalClassification>> Post(LocalClassification LocalClassification)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalClassificationDBService.Post(LocalClassification);
        }
        [HttpPut]
        public async Task<ActionResult<LocalClassification>> Put(LocalClassification LocalClassification)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalClassificationDBService.Put(LocalClassification);
        }
        [HttpDelete("{LocalClassificationID}")]
        public async Task<ActionResult<bool>> Delete(int LocalClassificationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalClassificationDBService.Delete(LocalClassificationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
