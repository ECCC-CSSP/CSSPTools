/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IContactPreferenceController
    {
        Task<ActionResult<List<ContactPreference>>> Get();
        Task<ActionResult<ContactPreference>> Get(int ContactPreferenceID);
        Task<ActionResult<ContactPreference>> Post(ContactPreference ContactPreference);
        Task<ActionResult<ContactPreference>> Put(ContactPreference ContactPreference);
        Task<ActionResult<bool>> Delete(int ContactPreferenceID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ContactPreferenceController : ControllerBase, IContactPreferenceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IContactPreferenceDBService ContactPreferenceDBService { get; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IContactPreferenceDBService ContactPreferenceDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ContactPreferenceDBService = ContactPreferenceDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ContactPreference>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactPreferenceDBService.GetContactPreferenceList();
        }
        [HttpGet("{ContactPreferenceID}")]
        public async Task<ActionResult<ContactPreference>> Get(int ContactPreferenceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactPreferenceDBService.GetContactPreferenceWithContactPreferenceID(ContactPreferenceID);
        }
        [HttpPost]
        public async Task<ActionResult<ContactPreference>> Post(ContactPreference ContactPreference)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactPreferenceDBService.Post(ContactPreference);
        }
        [HttpPut]
        public async Task<ActionResult<ContactPreference>> Put(ContactPreference ContactPreference)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactPreferenceDBService.Put(ContactPreference);
        }
        [HttpDelete("{ContactPreferenceID}")]
        public async Task<ActionResult<bool>> Delete(int ContactPreferenceID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactPreferenceDBService.Delete(ContactPreferenceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
