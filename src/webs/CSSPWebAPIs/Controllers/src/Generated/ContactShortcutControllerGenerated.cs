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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IContactShortcutDBService ContactShortcutDBService { get; }
        #endregion Properties

        #region Constructors
        public ContactShortcutController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IContactShortcutDBService ContactShortcutDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ContactShortcutDBService = ContactShortcutDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ContactShortcut>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutDBService.GetContactShortcutList();
        }
        [HttpGet("{ContactShortcutID}")]
        public async Task<ActionResult<ContactShortcut>> Get(int ContactShortcutID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutDBService.GetContactShortcutWithContactShortcutID(ContactShortcutID);
        }
        [HttpPost]
        public async Task<ActionResult<ContactShortcut>> Post(ContactShortcut ContactShortcut)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutDBService.Post(ContactShortcut);
        }
        [HttpPut]
        public async Task<ActionResult<ContactShortcut>> Put(ContactShortcut ContactShortcut)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutDBService.Put(ContactShortcut);
        }
        [HttpDelete("{ContactShortcutID}")]
        public async Task<ActionResult<bool>> Delete(int ContactShortcutID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactShortcutDBService.Delete(ContactShortcutID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
