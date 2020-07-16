/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
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
    public partial interface IPolSourceGroupingLanguageController
    {
        Task<ActionResult<List<PolSourceGroupingLanguage>>> Get();
        Task<ActionResult<PolSourceGroupingLanguage>> Get(int PolSourceGroupingLanguageID);
        Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage PolSourceGroupingLanguage);
        Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage PolSourceGroupingLanguage);
        Task<ActionResult<bool>> Delete(int PolSourceGroupingLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceGroupingLanguageController : ControllerBase, IPolSourceGroupingLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IPolSourceGroupingLanguageService PolSourceGroupingLanguageService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageController(ICultureService CultureService, ILoggedInService LoggedInService, IPolSourceGroupingLanguageService PolSourceGroupingLanguageService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.PolSourceGroupingLanguageService = PolSourceGroupingLanguageService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceGroupingLanguage>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceGroupingLanguageService.GetPolSourceGroupingLanguageList();
        }
        [HttpGet("{PolSourceGroupingLanguageID}")]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Get(int PolSourceGroupingLanguageID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceGroupingLanguageService.GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(PolSourceGroupingLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage PolSourceGroupingLanguage)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceGroupingLanguageService.Post(PolSourceGroupingLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage PolSourceGroupingLanguage)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceGroupingLanguageService.Put(PolSourceGroupingLanguage);
        }
        [HttpDelete("{PolSourceGroupingLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int PolSourceGroupingLanguageID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await PolSourceGroupingLanguageService.Delete(PolSourceGroupingLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
