/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IMWQMRunLanguageController
    {
        Task<ActionResult<List<MWQMRunLanguage>>> Get();
        Task<ActionResult<MWQMRunLanguage>> Get(int MWQMRunLanguageID);
        Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage MWQMRunLanguage);
        Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage MWQMRunLanguage);
        Task<ActionResult<bool>> Delete(int MWQMRunLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMRunLanguageController : ControllerBase, IMWQMRunLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMWQMRunLanguageService MWQMRunLanguageService { get; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMWQMRunLanguageService MWQMRunLanguageService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMRunLanguageService = MWQMRunLanguageService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMRunLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunLanguageService.GetMWQMRunLanguageList();
        }
        [HttpGet("{MWQMRunLanguageID}")]
        public async Task<ActionResult<MWQMRunLanguage>> Get(int MWQMRunLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(MWQMRunLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage MWQMRunLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunLanguageService.Post(MWQMRunLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage MWQMRunLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunLanguageService.Put(MWQMRunLanguage);
        }
        [HttpDelete("{MWQMRunLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMRunLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunLanguageService.Delete(MWQMRunLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
