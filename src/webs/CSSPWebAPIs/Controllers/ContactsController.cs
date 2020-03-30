using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CSSPWebAPIs.Services;
using CSSPWebAPIs.Models;
using System.Linq;
using CSSPModels;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/{culture}/[controller]")]
    public class ContactsController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService) : base()
        {
            _contactService = contactService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            
            await SetCulture();
            await _contactService.SetCulture(Culture);
            var contact = await _contactService.Login(model);

            if (contact.HasErrors)
                return BadRequest(new { HasErrors = contact.HasErrors, ValidationResults = contact.ValidationResults });

            return Ok(contact);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            await SetCulture();
            await _contactService.SetCulture(Culture);
            var contact = await _contactService.Register(model);

            if (contact == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(contact);
        }
    }
}
