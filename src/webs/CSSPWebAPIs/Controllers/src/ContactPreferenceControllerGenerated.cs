using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/contactPreference")]
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
        public IHttpActionResult GetContactPreferenceList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/contactPreference/1
        [Route("{ContactPreferenceID:int}")]
        public IHttpActionResult GetContactPreferenceWithID([FromUri]int ContactPreferenceID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), lang, 0, 1, "", "", extra);

                else
                {
                    ContactPreference contactPreference = new ContactPreference();
                    contactPreference = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(ContactPreferenceID);

                    if (contactPreference == null)
                    {
                        return NotFound();
                    }

                    return Ok(contactPreference);
                }
            }
        }
        // POST api/contactPreference
        [Route("")]
        public IHttpActionResult Post([FromBody]ContactPreference contactPreference, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]ContactPreference contactPreference, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]ContactPreference contactPreference, [FromUri]string lang = "en")
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
