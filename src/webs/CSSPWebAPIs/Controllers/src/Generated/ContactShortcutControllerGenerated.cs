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

namespace CSSPWebAPIs.Controllers
{
    public partial interface IContactShortcutController
    {
        Task<ActionResult<List<ContactShortcut>>> Get();
        Task<ActionResult<ContactShortcut>> Get(int ContactShortcutID);
        Task<ActionResult<ContactShortcut>> Post(ContactShortcut ContactShortcut);
        Task<ActionResult<ContactShortcut>> Put(ContactShortcut ContactShortcut);
        Task<ActionResult<bool>> Delete(int ContactShortcutID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ContactShortcutController : ControllerBase, IContactShortcutController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IContactShortcutService ContactShortcutService { get; }
        #endregion Properties

        #region Constructors
        public ContactShortcutController(ICultureService CultureService, ILoggedInService LoggedInService, IContactShortcutService ContactShortcutService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.ContactShortcutService = ContactShortcutService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ContactShortcut>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutService.GetContactShortcutList();
        }
        [HttpGet("{ContactShortcutID}")]
        public async Task<ActionResult<ContactShortcut>> Get(int ContactShortcutID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutService.GetContactShortcutWithContactShortcutID(ContactShortcutID);
        }
        [HttpPost]
        public async Task<ActionResult<ContactShortcut>> Post(ContactShortcut ContactShortcut)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutService.Post(ContactShortcut);
        }
        [HttpPut]
        public async Task<ActionResult<ContactShortcut>> Put(ContactShortcut ContactShortcut)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutService.Put(ContactShortcut);
        }
        [HttpDelete("{ContactShortcutID}")]
        public async Task<ActionResult<bool>> Delete(int ContactShortcutID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutService.Delete(ContactShortcutID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
