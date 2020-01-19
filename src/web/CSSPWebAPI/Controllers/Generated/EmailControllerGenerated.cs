using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/email")]
    public partial class EmailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailController() : base()
        {
        }
        public EmailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/email
        [Route("")]
        public IHttpActionResult GetEmailList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   emailService.Query = emailService.FillQuery(typeof(Email), lang, skip, take, asc, desc, where);

                    if (emailService.Query.HasErrors)
                    {
                        return Ok(new List<Email>()
                        {
                            new Email()
                            {
                                HasErrors = emailService.Query.HasErrors,
                                ValidationResults = emailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailService.GetEmailList().ToList());
                    }
                }
            }
        }
        // GET api/email/1
        [Route("{EmailID:int}")]
        public IHttpActionResult GetEmailWithID([FromUri]int EmailID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailService.Query = emailService.FillQuery(typeof(Email), lang, 0, 1, "", "");

                else
                {
                    Email email = new Email();
                    email = emailService.GetEmailWithEmailID(EmailID);

                    if (email == null)
                    {
                        return NotFound();
                    }

                    return Ok(email);
                }
            }
        }
        // POST api/email
        [Route("")]
        public IHttpActionResult Post([FromBody]Email email, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailService.Add(email))
                {
                    return BadRequest(String.Join("|||", email.ValidationResults));
                }
                else
                {
                    email.ValidationResults = null;
                    return Created<Email>(new Uri(Request.RequestUri, email.EmailID.ToString()), email);
                }
            }
        }
        // PUT api/email
        [Route("")]
        public IHttpActionResult Put([FromBody]Email email, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailService.Update(email))
                {
                    return BadRequest(String.Join("|||", email.ValidationResults));
                }
                else
                {
                    email.ValidationResults = null;
                    return Ok(email);
                }
            }
        }
        // DELETE api/email
        [Route("")]
        public IHttpActionResult Delete([FromBody]Email email, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailService.Delete(email))
                {
                    return BadRequest(String.Join("|||", email.ValidationResults));
                }
                else
                {
                    email.ValidationResults = null;
                    return Ok(email);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
