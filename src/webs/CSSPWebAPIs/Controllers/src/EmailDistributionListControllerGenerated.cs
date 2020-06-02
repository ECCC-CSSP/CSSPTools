using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IEmailDistributionListController
    {
        Task<ActionResult<List<EmailDistributionList>>> Get();
        Task<ActionResult<EmailDistributionList>> Get(int EmailDistributionListID);
        Task<ActionResult<EmailDistributionList>> Post(EmailDistributionList emailDistributionList);
        Task<ActionResult<EmailDistributionList>> Put(EmailDistributionList emailDistributionList);
        Task<ActionResult<EmailDistributionList>> Delete(EmailDistributionList emailDistributionList);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailDistributionListController : ControllerBase, IEmailDistributionListController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEmailDistributionListService emailDistributionListService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListController(IEmailDistributionListService emailDistributionListService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.emailDistributionListService = emailDistributionListService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<EmailDistributionList>>> Get()
        {
            return await emailDistributionListService.GetEmailDistributionListList();
        }
        [HttpGet("{EmailDistributionListID}")]
        public async Task<ActionResult<EmailDistributionList>> Get(int EmailDistributionListID)
        {
            return await emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(EmailDistributionListID);
        }
        [HttpPost]
        public async Task<ActionResult<EmailDistributionList>> Post(EmailDistributionList emailDistributionList)
        {
            return await emailDistributionListService.Add(emailDistributionList);
        }
        [HttpPut]
        public async Task<ActionResult<EmailDistributionList>> Put(EmailDistributionList emailDistributionList)
        {
            return await emailDistributionListService.Update(emailDistributionList);
        }
        [HttpDelete]
        public async Task<ActionResult<EmailDistributionList>> Delete(EmailDistributionList emailDistributionList)
        {
            return await emailDistributionListService.Delete(emailDistributionList);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
