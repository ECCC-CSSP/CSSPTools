using CSSPEnums;
using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IContactController
    {
        Task<ActionResult<List<Contact>>> Get();
        Task<ActionResult<Contact>> Get(int ContactID);
        Task<ActionResult<Contact>> Post(Contact contact);
        Task<ActionResult<Contact>> Put(Contact contact);
        Task<ActionResult<Contact>> Delete(Contact contact);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ContactController : ControllerBase, IContactController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IContactService contactService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ContactController(IContactService contactService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.contactService = contactService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return await contactService.GetContactList();
        }
        [HttpGet("{ContactID}")]
        public async Task<ActionResult<Contact>> Get(int ContactID)
        {
            return await contactService.GetContactWithContactID(ContactID);
        }
        [HttpPost]
        public async Task<ActionResult<Contact>> Post(Contact contact)
        {
            return await contactService.Add(contact, AddContactTypeEnum.Register);
        }
        [HttpPut]
        public async Task<ActionResult<Contact>> Put(Contact contact)
        {
            return await contactService.Update(contact);
        }
        [HttpDelete]
        public async Task<ActionResult<Contact>> Delete(Contact contact)
        {
            return await contactService.Delete(contact);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
