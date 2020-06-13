/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
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
    public partial interface IEmailDistributionListLanguageController
    {
        Task<ActionResult<List<EmailDistributionListLanguage>>> Get();
        Task<ActionResult<EmailDistributionListLanguage>> Get(int EmailDistributionListLanguageID);
        Task<ActionResult<EmailDistributionListLanguage>> Post(EmailDistributionListLanguage emailDistributionListLanguage);
        Task<ActionResult<EmailDistributionListLanguage>> Put(EmailDistributionListLanguage emailDistributionListLanguage);
        Task<ActionResult<bool>> Delete(int EmailDistributionListLanguageID);
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
        [HttpDelete("{EmailDistributionListLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListLanguageID)
        {
            return await emailDistributionListLanguageService.Delete(EmailDistributionListLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
