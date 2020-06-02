using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IContactPreferenceController
    {
        Task<ActionResult<List<ContactPreference>>> Get();
        Task<ActionResult<ContactPreference>> Get(int ContactPreferenceID);
        Task<ActionResult<ContactPreference>> Post(ContactPreference contactPreference);
        Task<ActionResult<ContactPreference>> Put(ContactPreference contactPreference);
        Task<ActionResult<ContactPreference>> Delete(ContactPreference contactPreference);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ContactPreferenceController : ControllerBase, IContactPreferenceController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IContactPreferenceService contactPreferenceService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceController(IContactPreferenceService contactPreferenceService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.contactPreferenceService = contactPreferenceService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ContactPreference>>> Get()
        {
            return await contactPreferenceService.GetContactPreferenceList();
        }
        [HttpGet("{ContactPreferenceID}")]
        public async Task<ActionResult<ContactPreference>> Get(int ContactPreferenceID)
        {
            return await contactPreferenceService.GetContactPreferenceWithContactPreferenceID(ContactPreferenceID);
        }
        [HttpPost]
        public async Task<ActionResult<ContactPreference>> Post(ContactPreference contactPreference)
        {
            return await contactPreferenceService.Add(contactPreference);
        }
        [HttpPut]
        public async Task<ActionResult<ContactPreference>> Put(ContactPreference contactPreference)
        {
            return await contactPreferenceService.Update(contactPreference);
        }
        [HttpDelete]
        public async Task<ActionResult<ContactPreference>> Delete(ContactPreference contactPreference)
        {
            return await contactPreferenceService.Delete(contactPreference);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
