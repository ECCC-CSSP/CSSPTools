using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/emailDistributionListContact")]
    public partial class EmailDistributionListContactController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactController() : base()
        {
        }
        public EmailDistributionListContactController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListContact
        [Route("")]
        public IHttpActionResult GetEmailDistributionListContactList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListContactService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListContact>()
                        {
                            new EmailDistributionListContact()
                            {
                                HasErrors = emailDistributionListContactService.Query.HasErrors,
                                ValidationResults = emailDistributionListContactService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListContactService.GetEmailDistributionListContactList().ToList());
                    }
                }
            }
        }
        // GET api/emailDistributionListContact/1
        [Route("{EmailDistributionListContactID:int}")]
        public IHttpActionResult GetEmailDistributionListContactWithID([FromUri]int EmailDistributionListContactID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), lang, 0, 1, "", "", extra);

                else
                {
                    EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();
                    emailDistributionListContact = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(EmailDistributionListContactID);

                    if (emailDistributionListContact == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListContact);
                }
            }
        }
        // POST api/emailDistributionListContact
        [Route("")]
        public IHttpActionResult Post([FromBody]EmailDistributionListContact emailDistributionListContact, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactService.Add(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Created<EmailDistributionListContact>(new Uri(Request.RequestUri, emailDistributionListContact.EmailDistributionListContactID.ToString()), emailDistributionListContact);
                }
            }
        }
        // PUT api/emailDistributionListContact
        [Route("")]
        public IHttpActionResult Put([FromBody]EmailDistributionListContact emailDistributionListContact, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactService.Update(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Ok(emailDistributionListContact);
                }
            }
        }
        // DELETE api/emailDistributionListContact
        [Route("")]
        public IHttpActionResult Delete([FromBody]EmailDistributionListContact emailDistributionListContact, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactService.Delete(emailDistributionListContact))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContact.ValidationResults));
                }
                else
                {
                    emailDistributionListContact.ValidationResults = null;
                    return Ok(emailDistributionListContact);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
