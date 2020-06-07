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
    public partial interface IMWQMSampleLanguageController
    {
        Task<ActionResult<List<MWQMSampleLanguage>>> Get();
        Task<ActionResult<MWQMSampleLanguage>> Get(int MWQMSampleLanguageID);
        Task<ActionResult<MWQMSampleLanguage>> Post(MWQMSampleLanguage mwqmSampleLanguage);
        Task<ActionResult<MWQMSampleLanguage>> Put(MWQMSampleLanguage mwqmSampleLanguage);
        Task<ActionResult<bool>> Delete(int MWQMSampleLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMSampleLanguageController : ControllerBase, IMWQMSampleLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMSampleLanguageService mwqmSampleLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageController(IMWQMSampleLanguageService mwqmSampleLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmSampleLanguageService = mwqmSampleLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMSampleLanguage>>> Get()
        {
            return await mwqmSampleLanguageService.GetMWQMSampleLanguageList();
        }
        [HttpGet("{MWQMSampleLanguageID}")]
        public async Task<ActionResult<MWQMSampleLanguage>> Get(int MWQMSampleLanguageID)
        {
            return await mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(MWQMSampleLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMSampleLanguage>> Post(MWQMSampleLanguage mwqmSampleLanguage)
        {
            return await mwqmSampleLanguageService.Add(mwqmSampleLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMSampleLanguage>> Put(MWQMSampleLanguage mwqmSampleLanguage)
        {
            return await mwqmSampleLanguageService.Update(mwqmSampleLanguage);
        }
        [HttpDelete("{MWQMSampleLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMSampleLanguageID)
        {
            return await mwqmSampleLanguageService.Delete(MWQMSampleLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}