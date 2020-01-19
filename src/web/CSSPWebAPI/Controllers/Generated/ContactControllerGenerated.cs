using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetContactList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/contact/1
        [Route("{ContactID:int}")]
        public IHttpActionResult GetContactWithID([FromUri]int ContactID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactService contactService = new ContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                contactService.Query = contactService.FillQuery(typeof(Contact), lang, 0, 1, "", "");

                else
                {
                    Contact contact = new Contact();
                    contact = contactService.GetContactWithContactID(ContactID);

                    if (contact == null)
                    {
                        return NotFound();
                    }

                    return Ok(contact);
                }
            }
        }
        // POST api/contact
        [Route("")]
        public IHttpActionResult Post([FromBody]Contact contact, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]Contact contact, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]Contact contact, [FromUri]string lang = "en")
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
