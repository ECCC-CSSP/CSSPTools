/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IAppTaskLanguageController
    {
        Task<ActionResult<List<AppTaskLanguage>>> Get();
        Task<ActionResult<AppTaskLanguage>> Get(int AppTaskLanguageID);
        Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage appTaskLanguage);
        Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage appTaskLanguage);
        Task<ActionResult<bool>> Delete(int AppTaskLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class AppTaskLanguageController : ControllerBase, IAppTaskLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAppTaskLanguageService appTaskLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageController(IAppTaskLanguageService appTaskLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.appTaskLanguageService = appTaskLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppTaskLanguage>>> Get()
        {
            return await appTaskLanguageService.GetAppTaskLanguageList();
        }
        [HttpGet("{AppTaskLanguageID}")]
        public async Task<ActionResult<AppTaskLanguage>> Get(int AppTaskLanguageID)
        {
            return await appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(AppTaskLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<AppTaskLanguage>> Post(AppTaskLanguage appTaskLanguage)
        {
            return await appTaskLanguageService.Add(appTaskLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<AppTaskLanguage>> Put(AppTaskLanguage appTaskLanguage)
        {
            return await appTaskLanguageService.Update(appTaskLanguage);
        }
        [HttpDelete("{AppTaskLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int AppTaskLanguageID)
        {
            return await appTaskLanguageService.Delete(AppTaskLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}