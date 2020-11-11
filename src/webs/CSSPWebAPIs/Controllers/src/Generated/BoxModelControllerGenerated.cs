/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
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
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IBoxModelController
    {
        Task<ActionResult<List<BoxModel>>> Get();
        Task<ActionResult<BoxModel>> Get(int BoxModelID);
        Task<ActionResult<BoxModel>> Post(BoxModel BoxModel);
        Task<ActionResult<BoxModel>> Put(BoxModel BoxModel);
        Task<ActionResult<bool>> Delete(int BoxModelID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class BoxModelController : ControllerBase, IBoxModelController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IBoxModelDBService BoxModelDBService { get; }
        #endregion Properties

        #region Constructors
        public BoxModelController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IBoxModelDBService BoxModelDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.BoxModelDBService = BoxModelDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<BoxModel>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelDBService.GetBoxModelList();
        }
        [HttpGet("{BoxModelID}")]
        public async Task<ActionResult<BoxModel>> Get(int BoxModelID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelDBService.GetBoxModelWithBoxModelID(BoxModelID);
        }
        [HttpPost]
        public async Task<ActionResult<BoxModel>> Post(BoxModel BoxModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelDBService.Post(BoxModel);
        }
        [HttpPut]
        public async Task<ActionResult<BoxModel>> Put(BoxModel BoxModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelDBService.Put(BoxModel);
        }
        [HttpDelete("{BoxModelID}")]
        public async Task<ActionResult<bool>> Delete(int BoxModelID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelDBService.Delete(BoxModelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
