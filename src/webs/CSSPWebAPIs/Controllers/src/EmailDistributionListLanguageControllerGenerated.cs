using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IEmailDistributionListLanguageController
    {
        Task<ActionResult<List<EmailDistributionListLanguage>>> Get();
        Task<ActionResult<EmailDistributionListLanguage>> Get(int EmailDistributionListLanguageID);
        Task<ActionResult<EmailDistributionListLanguage>> Post(EmailDistributionListLanguage emailDistributionListLanguage);
        Task<ActionResult<EmailDistributionListLanguage>> Put(EmailDistributionListLanguage emailDistributionListLanguage);
        Task<ActionResult<EmailDistributionListLanguage>> Delete(EmailDistributionListLanguage emailDistributionListLanguage);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailDistributionListLanguageController : ControllerBase, IEmailDistributionListLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEmailDistributionListLanguageService emailDistributionListLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageController(IEmailDistributionListLanguageService emailDistributionListLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.emailDistributionListLanguageService = emailDistributionListLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<EmailDistributionListLanguage>>> Get()
        {
            return await emailDistributionListLanguageService.GetEmailDistributionListLanguageList();
        }
        [HttpGet("{EmailDistributionListLanguageID}")]
        public async Task<ActionResult<EmailDistributionListLanguage>> Get(int EmailDistributionListLanguageID)
        {
            return await emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(EmailDistributionListLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<EmailDistributionListLanguage>> Post(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            return await emailDistributionListLanguageService.Add(emailDistributionListLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<EmailDistributionListLanguage>> Put(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            return await emailDistributionListLanguageService.Update(emailDistributionListLanguage);
        }
        [HttpDelete]
        public async Task<ActionResult<EmailDistributionListLanguage>> Delete(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            return await emailDistributionListLanguageService.Delete(emailDistributionListLanguage);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
