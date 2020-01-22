using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/contactShortcut")]
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
        public IActionResult GetContactShortcutList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = lang }, db, ContactID);

                contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), lang, skip, take, asc, desc, where);

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
        // GET api/contactShortcut/1
        [Route("{ContactShortcutID:int}")]
        public IActionResult GetContactShortcutWithID([FromQuery]int ContactShortcutID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), lang, 0, 1, "", "");

                ContactShortcut contactShortcut = new ContactShortcut();
                contactShortcut = contactShortcutService.GetContactShortcutWithContactShortcutID(ContactShortcutID);

                if (contactShortcut == null)
                {
                    return NotFound();
                }

                return Ok(contactShortcut);
            }
        }
        // POST api/contactShortcut
        [Route("")]
        public IActionResult Post([FromBody]ContactShortcut contactShortcut, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), contactShortcut);
                }
            }
        }
        // PUT api/contactShortcut
        [Route("")]
        public IActionResult Put([FromBody]ContactShortcut contactShortcut, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]ContactShortcut contactShortcut, [FromQuery]string lang = "en")
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
