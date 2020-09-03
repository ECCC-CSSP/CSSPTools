/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IEmailController
    {
        Task<ActionResult<List<Email>>> Get();
        Task<ActionResult<Email>> Get(int EmailID);
        Task<ActionResult<Email>> Post(Email Email);
        Task<ActionResult<Email>> Put(Email Email);
        Task<ActionResult<bool>> Delete(int EmailID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class EmailController : ControllerBase, IEmailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEmailService EmailService { get; }
        #endregion Properties

        #region Constructors
        public EmailController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEmailService EmailService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.EmailService = EmailService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Email>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailService.GetEmailList();
        }
        [HttpGet("{EmailID}")]
        public async Task<ActionResult<Email>> Get(int EmailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailService.GetEmailWithEmailID(EmailID);
        }
        [HttpPost]
        public async Task<ActionResult<Email>> Post(Email Email)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailService.Post(Email);
        }
        [HttpPut]
        public async Task<ActionResult<Email>> Put(Email Email)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailService.Put(Email);
        }
        [HttpDelete("{EmailID}")]
        public async Task<ActionResult<bool>> Delete(int EmailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await EmailService.Delete(EmailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
