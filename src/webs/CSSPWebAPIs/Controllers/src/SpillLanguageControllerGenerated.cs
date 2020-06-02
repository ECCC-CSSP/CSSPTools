using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ISpillLanguageController
    {
        Task<ActionResult<List<SpillLanguage>>> Get();
        Task<ActionResult<SpillLanguage>> Get(int SpillLanguageID);
        Task<ActionResult<SpillLanguage>> Post(SpillLanguage spillLanguage);
        Task<ActionResult<SpillLanguage>> Put(SpillLanguage spillLanguage);
        Task<ActionResult<SpillLanguage>> Delete(SpillLanguage spillLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class SpillLanguageController : ControllerBase, ISpillLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISpillLanguageService spillLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public SpillLanguageController(ISpillLanguageService spillLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.spillLanguageService = spillLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<SpillLanguage>>> Get()
        {
            return await spillLanguageService.GetSpillLanguageList();
        }
        [HttpGet("{SpillLanguageID}")]
        public async Task<ActionResult<SpillLanguage>> Get(int SpillLanguageID)
        {
            return await spillLanguageService.GetSpillLanguageWithSpillLanguageID(SpillLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<SpillLanguage>> Post(SpillLanguage spillLanguage)
        {
            return await spillLanguageService.Add(spillLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<SpillLanguage>> Put(SpillLanguage spillLanguage)
        {
            return await spillLanguageService.Update(spillLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<SpillLanguage>> Delete(SpillLanguage spillLanguage)
        {
            return await spillLanguageService.Delete(spillLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
