using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/contactShortcut")]
    public partial class ContactShortcutController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactShortcutController() : base()
        {
        }
        public ContactShortcutController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/contactShortcut
        [Route("")]
        public IHttpActionResult GetContactShortcutList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), lang, skip, take, asc, desc, where, extra);

                    if (contactShortcutService.Query.HasErrors)
                    {
                        return Ok(new List<ContactShortcut>()
                        {
                            new ContactShortcut()
                            {
                                HasErrors = contactShortcutService.Query.HasErrors,
                                ValidationResults = contactShortcutService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(contactShortcutService.GetContactShortcutList().ToList());
                    }
                }
            }
        }
        // GET api/contactShortcut/1
        [Route("{ContactShortcutID:int}")]
        public IHttpActionResult GetContactShortcutWithID([FromUri]int ContactShortcutID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), lang, 0, 1, "", "", extra);

                else
                {
                    ContactShortcut contactShortcut = new ContactShortcut();
                    contactShortcut = contactShortcutService.GetContactShortcutWithContactShortcutID(ContactShortcutID);

                    if (contactShortcut == null)
                    {
                        return NotFound();
                    }

                    return Ok(contactShortcut);
                }
            }
        }
        // POST api/contactShortcut
        [Route("")]
        public IHttpActionResult Post([FromBody]ContactShortcut contactShortcut, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactShortcutService.Add(contactShortcut))
                {
                    return BadRequest(String.Join("|||", contactShortcut.ValidationResults));
                }
                else
                {
                    contactShortcut.ValidationResults = null;
                    return Created<ContactShortcut>(new Uri(Request.RequestUri, contactShortcut.ContactShortcutID.ToString()), contactShortcut);
                }
            }
        }
        // PUT api/contactShortcut
        [Route("")]
        public IHttpActionResult Put([FromBody]ContactShortcut contactShortcut, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactShortcutService.Update(contactShortcut))
                {
                    return BadRequest(String.Join("|||", contactShortcut.ValidationResults));
                }
                else
                {
                    contactShortcut.ValidationResults = null;
                    return Ok(contactShortcut);
                }
            }
        }
        // DELETE api/contactShortcut
        [Route("")]
        public IHttpActionResult Delete([FromBody]ContactShortcut contactShortcut, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactShortcutService.Delete(contactShortcut))
                {
                    return BadRequest(String.Join("|||", contactShortcut.ValidationResults));
                }
                else
                {
                    contactShortcut.ValidationResults = null;
                    return Ok(contactShortcut);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
