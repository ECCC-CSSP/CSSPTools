using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/contactPreference")]
    public partial class ContactPreferenceController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactPreferenceController() : base()
        {
        }
        public ContactPreferenceController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/contactPreference
        [Route("")]
        public IActionResult GetContactPreferenceList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = lang }, db, ContactID);

                contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), lang, skip, take, asc, desc, where);

                 if (contactPreferenceService.Query.HasErrors)
                 {
                     return Ok(new List<ContactPreference>()
                     {
                         new ContactPreference()
                         {
                             HasErrors = contactPreferenceService.Query.HasErrors,
                             ValidationResults = contactPreferenceService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(contactPreferenceService.GetContactPreferenceList().ToList());
                 }
            }
        }
        // GET api/contactPreference/1
        [Route("{ContactPreferenceID:int}")]
        public IActionResult GetContactPreferenceWithID([FromQuery]int ContactPreferenceID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), lang, 0, 1, "", "");

                ContactPreference contactPreference = new ContactPreference();
                contactPreference = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(ContactPreferenceID);

                if (contactPreference == null)
                {
                    return NotFound();
                }

                return Ok(contactPreference);
            }
        }
        // POST api/contactPreference
        [Route("")]
        public IActionResult Post([FromBody]ContactPreference contactPreference, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactPreferenceService.Add(contactPreference))
                {
                    return BadRequest(String.Join("|||", contactPreference.ValidationResults));
                }
                else
                {
                    contactPreference.ValidationResults = null;
                    return Created<ContactPreference>(new Uri(Request.RequestUri, contactPreference.ContactPreferenceID.ToString()), contactPreference);
                }
            }
        }
        // PUT api/contactPreference
        [Route("")]
        public IActionResult Put([FromBody]ContactPreference contactPreference, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactPreferenceService.Update(contactPreference))
                {
                    return BadRequest(String.Join("|||", contactPreference.ValidationResults));
                }
                else
                {
                    contactPreference.ValidationResults = null;
                    return Ok(contactPreference);
                }
            }
        }
        // DELETE api/contactPreference
        [Route("")]
        public IActionResult Delete([FromBody]ContactPreference contactPreference, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!contactPreferenceService.Delete(contactPreference))
                {
                    return BadRequest(String.Join("|||", contactPreference.ValidationResults));
                }
                else
                {
                    contactPreference.ValidationResults = null;
                    return Ok(contactPreference);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
