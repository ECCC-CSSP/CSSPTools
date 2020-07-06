/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
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
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IBoxModelService BoxModelService { get; }
        #endregion Properties

        #region Constructors
        public BoxModelController(ICultureService CultureService, ILoggedInService LoggedInService, IBoxModelService BoxModelService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.BoxModelService = BoxModelService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<BoxModel>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelService.GetBoxModelList();
        }
        [HttpGet("{BoxModelID}")]
        public async Task<ActionResult<BoxModel>> Get(int BoxModelID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelService.GetBoxModelWithBoxModelID(BoxModelID);
        }
        [HttpPost]
        public async Task<ActionResult<BoxModel>> Post(BoxModel BoxModel)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelService.Post(BoxModel);
        }
        [HttpPut]
        public async Task<ActionResult<BoxModel>> Put(BoxModel BoxModel)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelService.Put(BoxModel);
        }
        [HttpDelete("{BoxModelID}")]
        public async Task<ActionResult<bool>> Delete(int BoxModelID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelService.Delete(BoxModelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
