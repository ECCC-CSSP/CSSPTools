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
    public partial interface IMWQMSubsectorLanguageController
    {
        Task<ActionResult<List<MWQMSubsectorLanguage>>> Get();
        Task<ActionResult<MWQMSubsectorLanguage>> Get(int MWQMSubsectorLanguageID);
        Task<ActionResult<MWQMSubsectorLanguage>> Post(MWQMSubsectorLanguage mwqmSubsectorLanguage);
        Task<ActionResult<MWQMSubsectorLanguage>> Put(MWQMSubsectorLanguage mwqmSubsectorLanguage);
        Task<ActionResult<bool>> Delete(int MWQMSubsectorLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSubsectorLanguageController : ControllerBase, IMWQMSubsectorLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageController(IMWQMSubsectorLanguageService mwqmSubsectorLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmSubsectorLanguageService = mwqmSubsectorLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSubsectorLanguage>>> Get()
        {
            return await mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList();
        }
        [HttpGet("{MWQMSubsectorLanguageID}")]
        public async Task<ActionResult<MWQMSubsectorLanguage>> Get(int MWQMSubsectorLanguageID)
        {
            return await mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(MWQMSubsectorLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSubsectorLanguage>> Post(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            return await mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSubsectorLanguage>> Put(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            return await mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
        }
        [HttpDelete("{MWQMSubsectorLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSubsectorLanguageID)
        {
            return await mwqmSubsectorLanguageService.Delete(MWQMSubsectorLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}