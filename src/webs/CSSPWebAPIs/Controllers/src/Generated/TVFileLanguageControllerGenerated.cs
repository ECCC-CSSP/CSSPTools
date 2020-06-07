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
    public partial interface ITVFileLanguageController
    {
        Task<ActionResult<List<TVFileLanguage>>> Get();
        Task<ActionResult<TVFileLanguage>> Get(int TVFileLanguageID);
        Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage tvFileLanguage);
        Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage tvFileLanguage);
        Task<ActionResult<bool>> Delete(int TVFileLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVFileLanguageController : ControllerBase, ITVFileLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVFileLanguageService tvFileLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageController(ITVFileLanguageService tvFileLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvFileLanguageService = tvFileLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVFileLanguage>>> Get()
        {
            return await tvFileLanguageService.GetTVFileLanguageList();
        }
        [HttpGet("{TVFileLanguageID}")]
        public async Task<ActionResult<TVFileLanguage>> Get(int TVFileLanguageID)
        {
            return await tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(TVFileLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage tvFileLanguage)
        {
            return await tvFileLanguageService.Add(tvFileLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage tvFileLanguage)
        {
            return await tvFileLanguageService.Update(tvFileLanguage);
        }
        [HttpDelete("{TVFileLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int TVFileLanguageID)
        {
            return await tvFileLanguageService.Delete(TVFileLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
