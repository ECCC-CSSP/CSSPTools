using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IEmailDistributionListContactController
    {
        Task<ActionResult<List<EmailDistributionListContact>>> Get();
        Task<ActionResult<EmailDistributionListContact>> Get(int EmailDistributionListContactID);
        Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact emailDistributionListContact);
        Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact emailDistributionListContact);
        Task<ActionResult<EmailDistributionListContact>> Delete(EmailDistributionListContact emailDistributionListContact);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailDistributionListContactController : ControllerBase, IEmailDistributionListContactController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEmailDistributionListContactService emailDistributionListContactService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactController(IEmailDistributionListContactService emailDistributionListContactService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.emailDistributionListContactService = emailDistributionListContactService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<EmailDistributionListContact>>> Get()
        {
            return await emailDistributionListContactService.GetEmailDistributionListContactList();
        }
        [HttpGet("{EmailDistributionListContactID}")]
        public async Task<ActionResult<EmailDistributionListContact>> Get(int EmailDistributionListContactID)
        {
            return await emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(EmailDistributionListContactID);
        }
        [HttpPost]
        public async Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact emailDistributionListContact)
        {
            return await emailDistributionListContactService.Add(emailDistributionListContact);
        }
        [HttpPut]
        public async Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact emailDistributionListContact)
        {
            return await emailDistributionListContactService.Update(emailDistributionListContact);
        }
        [HttpDelete]
        public async Task<ActionResult<EmailDistributionListContact>> Delete(EmailDistributionListContact emailDistributionListContact)
        {
            return await emailDistributionListContactService.Delete(emailDistributionListContact);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
