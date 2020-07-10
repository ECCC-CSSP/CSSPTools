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

namespace CSSPWebAPIs.Controllers
{
    public partial interface IBoxModelLanguageController
    {
        Task<ActionResult<List<BoxModelLanguage>>> Get();
        Task<ActionResult<BoxModelLanguage>> Get(int BoxModelLanguageID);
        Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage BoxModelLanguage);
        Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage BoxModelLanguage);
        Task<ActionResult<bool>> Delete(int BoxModelLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class BoxModelLanguageController : ControllerBase, IBoxModelLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IBoxModelLanguageService BoxModelLanguageService { get; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageController(ICultureService CultureService, ILoggedInService LoggedInService, IBoxModelLanguageService BoxModelLanguageService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.BoxModelLanguageService = BoxModelLanguageService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<BoxModelLanguage>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelLanguageService.GetBoxModelLanguageList();
        }
        [HttpGet("{BoxModelLanguageID}")]
        public async Task<ActionResult<BoxModelLanguage>> Get(int BoxModelLanguageID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(BoxModelLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<BoxModelLanguage>> Post(BoxModelLanguage BoxModelLanguage)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelLanguageService.Post(BoxModelLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<BoxModelLanguage>> Put(BoxModelLanguage BoxModelLanguage)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelLanguageService.Put(BoxModelLanguage);
        }
        [HttpDelete("{BoxModelLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int BoxModelLanguageID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await BoxModelLanguageService.Delete(BoxModelLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
