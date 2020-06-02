using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IInfrastructureLanguageController
    {
        Task<ActionResult<List<InfrastructureLanguage>>> Get();
        Task<ActionResult<InfrastructureLanguage>> Get(int InfrastructureLanguageID);
        Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage infrastructureLanguage);
        Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage infrastructureLanguage);
        Task<ActionResult<InfrastructureLanguage>> Delete(InfrastructureLanguage infrastructureLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class InfrastructureLanguageController : ControllerBase, IInfrastructureLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IInfrastructureLanguageService infrastructureLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageController(IInfrastructureLanguageService infrastructureLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.infrastructureLanguageService = infrastructureLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<InfrastructureLanguage>>> Get()
        {
            return await infrastructureLanguageService.GetInfrastructureLanguageList();
        }
        [HttpGet("{InfrastructureLanguageID}")]
        public async Task<ActionResult<InfrastructureLanguage>> Get(int InfrastructureLanguageID)
        {
            return await infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(InfrastructureLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage infrastructureLanguage)
        {
            return await infrastructureLanguageService.Add(infrastructureLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage infrastructureLanguage)
        {
            return await infrastructureLanguageService.Update(infrastructureLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<InfrastructureLanguage>> Delete(InfrastructureLanguage infrastructureLanguage)
        {
            return await infrastructureLanguageService.Delete(infrastructureLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
