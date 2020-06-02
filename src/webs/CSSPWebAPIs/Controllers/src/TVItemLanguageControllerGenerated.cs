using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ITVItemLanguageController
    {
        Task<ActionResult<List<TVItemLanguage>>> Get();
        Task<ActionResult<TVItemLanguage>> Get(int TVItemLanguageID);
        Task<ActionResult<TVItemLanguage>> Post(TVItemLanguage tvItemLanguage);
        Task<ActionResult<TVItemLanguage>> Put(TVItemLanguage tvItemLanguage);
        Task<ActionResult<TVItemLanguage>> Delete(TVItemLanguage tvItemLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemLanguageController : ControllerBase, ITVItemLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ITVItemLanguageService tvItemLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageController(ITVItemLanguageService tvItemLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.tvItemLanguageService = tvItemLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemLanguage>>> Get()
        {
            return await tvItemLanguageService.GetTVItemLanguageList();
        }
        [HttpGet("{TVItemLanguageID}")]
        public async Task<ActionResult<TVItemLanguage>> Get(int TVItemLanguageID)
        {
            return await tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(TVItemLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemLanguage>> Post(TVItemLanguage tvItemLanguage)
        {
            return await tvItemLanguageService.Add(tvItemLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemLanguage>> Put(TVItemLanguage tvItemLanguage)
        {
            return await tvItemLanguageService.Update(tvItemLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<TVItemLanguage>> Delete(TVItemLanguage tvItemLanguage)
        {
            return await tvItemLanguageService.Delete(tvItemLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
