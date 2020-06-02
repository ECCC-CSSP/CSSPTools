using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IEmailController
    {
        Task<ActionResult<List<Email>>> Get();
        Task<ActionResult<Email>> Get(int EmailID);
        Task<ActionResult<Email>> Post(Email email);
        Task<ActionResult<Email>> Put(Email email);
        Task<ActionResult<Email>> Delete(Email email);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailController : ControllerBase, IEmailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEmailService emailService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public EmailController(IEmailService emailService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.emailService = emailService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Email>>> Get()
        {
            return await emailService.GetEmailList();
        }
        [HttpGet("{EmailID}")]
        public async Task<ActionResult<Email>> Get(int EmailID)
        {
            return await emailService.GetEmailWithEmailID(EmailID);
        }
        [HttpPost]
        public async Task<ActionResult<Email>> Post(Email email)
        {
            return await emailService.Add(email);
        }
        [HttpPut]
        public async Task<ActionResult<Email>> Put(Email email)
        {
            return await emailService.Update(email);
        }
        [HttpDelete]
        public async Task<ActionResult<Email>> Delete(Email email)
        {
            return await emailService.Delete(email);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
