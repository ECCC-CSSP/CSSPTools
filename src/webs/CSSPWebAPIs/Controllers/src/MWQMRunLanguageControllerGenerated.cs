using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMRunLanguageController
    {
        Task<ActionResult<List<MWQMRunLanguage>>> Get();
        Task<ActionResult<MWQMRunLanguage>> Get(int MWQMRunLanguageID);
        Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage mwqmRunLanguage);
        Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage mwqmRunLanguage);
        Task<ActionResult<MWQMRunLanguage>> Delete(MWQMRunLanguage mwqmRunLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMRunLanguageController : ControllerBase, IMWQMRunLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMRunLanguageService mwqmRunLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageController(IMWQMRunLanguageService mwqmRunLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmRunLanguageService = mwqmRunLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMRunLanguage>>> Get()
        {
            return await mwqmRunLanguageService.GetMWQMRunLanguageList();
        }
        [HttpGet("{MWQMRunLanguageID}")]
        public async Task<ActionResult<MWQMRunLanguage>> Get(int MWQMRunLanguageID)
        {
            return await mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(MWQMRunLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMRunLanguage>> Post(MWQMRunLanguage mwqmRunLanguage)
        {
            return await mwqmRunLanguageService.Add(mwqmRunLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMRunLanguage>> Put(MWQMRunLanguage mwqmRunLanguage)
        {
            return await mwqmRunLanguageService.Update(mwqmRunLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMRunLanguage>> Delete(MWQMRunLanguage mwqmRunLanguage)
        {
            return await mwqmRunLanguageService.Delete(mwqmRunLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
