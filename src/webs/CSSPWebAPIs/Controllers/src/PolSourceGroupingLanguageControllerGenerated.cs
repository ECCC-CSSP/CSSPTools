using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceGroupingLanguageController
    {
        Task<ActionResult<List<PolSourceGroupingLanguage>>> Get();
        Task<ActionResult<PolSourceGroupingLanguage>> Get(int PolSourceGroupingLanguageID);
        Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage polSourceGroupingLanguage);
        Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage polSourceGroupingLanguage);
        Task<ActionResult<PolSourceGroupingLanguage>> Delete(PolSourceGroupingLanguage polSourceGroupingLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceGroupingLanguageController : ControllerBase, IPolSourceGroupingLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceGroupingLanguageService polSourceGroupingLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageController(IPolSourceGroupingLanguageService polSourceGroupingLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceGroupingLanguageService = polSourceGroupingLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceGroupingLanguage>>> Get()
        {
            return await polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList();
        }
        [HttpGet("{PolSourceGroupingLanguageID}")]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Get(int PolSourceGroupingLanguageID)
        {
            return await polSourceGroupingLanguageService.GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(PolSourceGroupingLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Post(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            return await polSourceGroupingLanguageService.Add(polSourceGroupingLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Put(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            return await polSourceGroupingLanguageService.Update(polSourceGroupingLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceGroupingLanguage>> Delete(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            return await polSourceGroupingLanguageService.Delete(polSourceGroupingLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
