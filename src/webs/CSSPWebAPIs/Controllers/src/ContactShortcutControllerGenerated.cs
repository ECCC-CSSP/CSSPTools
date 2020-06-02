using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IContactShortcutController
    {
        Task<ActionResult<List<ContactShortcut>>> Get();
        Task<ActionResult<ContactShortcut>> Get(int ContactShortcutID);
        Task<ActionResult<ContactShortcut>> Post(ContactShortcut contactShortcut);
        Task<ActionResult<ContactShortcut>> Put(ContactShortcut contactShortcut);
        Task<ActionResult<ContactShortcut>> Delete(ContactShortcut contactShortcut);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ContactShortcutController : ControllerBase, IContactShortcutController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IContactShortcutService contactShortcutService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ContactShortcutController(IContactShortcutService contactShortcutService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.contactShortcutService = contactShortcutService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ContactShortcut>>> Get()
        {
            return await contactShortcutService.GetContactShortcutList();
        }
        [HttpGet("{ContactShortcutID}")]
        public async Task<ActionResult<ContactShortcut>> Get(int ContactShortcutID)
        {
            return await contactShortcutService.GetContactShortcutWithContactShortcutID(ContactShortcutID);
        }
        [HttpPost]
        public async Task<ActionResult<ContactShortcut>> Post(ContactShortcut contactShortcut)
        {
            return await contactShortcutService.Add(contactShortcut);
        }
        [HttpPut]
        public async Task<ActionResult<ContactShortcut>> Put(ContactShortcut contactShortcut)
        {
            return await contactShortcutService.Update(contactShortcut);
        }
        [HttpDelete]
        public async Task<ActionResult<ContactShortcut>> Delete(ContactShortcut contactShortcut)
        {
            return await contactShortcutService.Delete(contactShortcut);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
