using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IVPScenarioLanguageController
    {
        Task<ActionResult<List<VPScenarioLanguage>>> Get();
        Task<ActionResult<VPScenarioLanguage>> Get(int VPScenarioLanguageID);
        Task<ActionResult<VPScenarioLanguage>> Post(VPScenarioLanguage vpScenarioLanguage);
        Task<ActionResult<VPScenarioLanguage>> Put(VPScenarioLanguage vpScenarioLanguage);
        Task<ActionResult<VPScenarioLanguage>> Delete(VPScenarioLanguage vpScenarioLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPScenarioLanguageController : ControllerBase, IVPScenarioLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IVPScenarioLanguageService vpScenarioLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageController(IVPScenarioLanguageService vpScenarioLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.vpScenarioLanguageService = vpScenarioLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPScenarioLanguage>>> Get()
        {
            return await vpScenarioLanguageService.GetVPScenarioLanguageList();
        }
        [HttpGet("{VPScenarioLanguageID}")]
        public async Task<ActionResult<VPScenarioLanguage>> Get(int VPScenarioLanguageID)
        {
            return await vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(VPScenarioLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<VPScenarioLanguage>> Post(VPScenarioLanguage vpScenarioLanguage)
        {
            return await vpScenarioLanguageService.Add(vpScenarioLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<VPScenarioLanguage>> Put(VPScenarioLanguage vpScenarioLanguage)
        {
            return await vpScenarioLanguageService.Update(vpScenarioLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<VPScenarioLanguage>> Delete(VPScenarioLanguage vpScenarioLanguage)
        {
            return await vpScenarioLanguageService.Delete(vpScenarioLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
