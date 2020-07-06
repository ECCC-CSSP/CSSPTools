/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
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
        Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact EmailDistributionListContact);
        Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact EmailDistributionListContact);
        Task<ActionResult<bool>> Delete(int EmailDistributionListContactID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailDistributionListContactController : ControllerBase, IEmailDistributionListContactController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEmailDistributionListContactService EmailDistributionListContactService { get; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactController(ICultureService CultureService, ILoggedInService LoggedInService, IEmailDistributionListContactService EmailDistributionListContactService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.EmailDistributionListContactService = EmailDistributionListContactService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<EmailDistributionListContact>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailDistributionListContactService.GetEmailDistributionListContactList();
        }
        [HttpGet("{EmailDistributionListContactID}")]
        public async Task<ActionResult<EmailDistributionListContact>> Get(int EmailDistributionListContactID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(EmailDistributionListContactID);
        }
        [HttpPost]
        public async Task<ActionResult<EmailDistributionListContact>> Post(EmailDistributionListContact EmailDistributionListContact)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailDistributionListContactService.Post(EmailDistributionListContact);
        }
        [HttpPut]
        public async Task<ActionResult<EmailDistributionListContact>> Put(EmailDistributionListContact EmailDistributionListContact)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailDistributionListContactService.Put(EmailDistributionListContact);
        }
        [HttpDelete("{EmailDistributionListContactID}")]
        public async Task<ActionResult<bool>> Delete(int EmailDistributionListContactID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailDistributionListContactService.Delete(EmailDistributionListContactID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
