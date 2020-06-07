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
    public partial interface IEmailDistributionListContactLanguageController
    {
        Task<ActionResult<List<EmailDistributionListContactLanguage>>> Get();
        Task<ActionResult<EmailDistributionListContactLanguage>> Get(int EmailDistributionListContactLanguageID);
        Task<ActionResult<EmailDistributionListContactLanguage>> Post(EmailDistributionListContactLanguage emailDistributionListContactLanguage);
        Task<ActionResult<EmailDistributionListContactLanguage>> Put(EmailDistributionListContactLanguage emailDistributionListContactLanguage);
        Task<ActionResult<bool>> Delete(int EmailDistributionListContactLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailDistributionListContactLanguageController : ControllerBase, IEmailDistributionListContactLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEmailDistributionListContactLanguageService emailDistributionListContactLanguageService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageController(IEmailDistributionListContactLanguageService emailDistributionListContactLanguageService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.emailDistributionListContactLanguageService = emailDistributionListContactLanguageService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<EmailDistributionListContactLanguage>>> Get()
        {
            return await emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList();
        }
        [HttpGet("{EmailDistributionListContactLanguageID}")]
        public async Task<ActionResult<EmailDistributionListContactLanguage>> Get(int EmailDistributionListContactLanguageID)
        {
            return await emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(EmailDistributionListContactLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<EmailDistributionListContactLanguage>> Post(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            return await emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<EmailDistributionListContactLanguage>> Put(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            return await emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage);
        }
        [HttpDelete("{EmailDistributionListContactLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListContactLanguageID)
        {
            return await emailDistributionListContactLanguageService.Delete(EmailDistributionListContactLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
