using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/contact")]
    public partial class ContactController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactController() : base()
        {
        }
        public ContactController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/contact
        [Route("")]
        public IActionResult GetContactList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Lang = lang }, db, ContactID);

                contactService.Query = contactService.FillQuery(typeof(Contact), lang, skip, take, asc, desc, where);

                 if (contactService.Query.HasErrors)
                 {
                     return Ok(new List<Contact>()
                     {
                         new Contact()
                         {
                             HasErrors = contactService.Query.HasErrors,
                             ValidationResults = contactService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(contactService.GetContactList().ToList());
                 }
            }
        }
        // GET api/contact/1
        [Route("{ContactID:int}")]
        public IActionResult GetContactWithID([FromQuery]int ContactID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                contactService.Query = contactService.FillQuery(typeof(Contact), lang, 0, 1, "", "");

                Contact contact = new Contact();
                contact = contactService.GetContactWithContactID(ContactID);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
        }
        // POST api/contact
        [Route("")]
        public IActionResult Post([FromBody]Contact contact, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactService.Add(contact, AddContactTypeEnum.LoggedIn))
                {
                    return BadRequest(String.Join("|||", contact.ValidationResults));
                }
                else
                {
                    contact.ValidationResults = null;
                    return Created<Contact>(new Uri(Request.RequestUri, contact.ContactID.ToString()), contact);
                }
            }
        }
        // PUT api/contact
        [Route("")]
        public IActionResult Put([FromBody]Contact contact, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactService.Update(contact))
                {
                    return BadRequest(String.Join("|||", contact.ValidationResults));
                }
                else
                {
                    contact.ValidationResults = null;
                    return Ok(contact);
                }
            }
        }
        // DELETE api/contact
        [Route("")]
        public IActionResult Delete([FromBody]Contact contact, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactService.Delete(contact))
                {
                    return BadRequest(String.Join("|||", contact.ValidationResults));
                }
                else
                {
                    contact.ValidationResults = null;
                    return Ok(contact);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
