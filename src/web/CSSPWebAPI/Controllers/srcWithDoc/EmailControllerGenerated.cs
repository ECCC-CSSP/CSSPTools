using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/email")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   emailService.Query = emailService.FillQuery(typeof(EmailExtraA), lang, skip, take, asc, desc, where, extra);

                    if (emailService.Query.HasErrors)
                    {
                        return Ok(new List<EmailExtraA>()
                        {
                            new EmailExtraA()
                            {
                                HasErrors = emailService.Query.HasErrors,
                                ValidationResults = emailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailService.GetEmailExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   emailService.Query = emailService.FillQuery(typeof(EmailExtraB), lang, skip, take, asc, desc, where, extra);

                    if (emailService.Query.HasErrors)
                    {
                        return Ok(new List<EmailExtraB>()
                        {
                            new EmailExtraB()
                            {
                                HasErrors = emailService.Query.HasErrors,
                                ValidationResults = emailService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailService.GetEmailExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   emailService.Query = emailService.FillQuery(typeof(Email), lang, skip, take, asc, desc, where, extra);

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
        public IHttpActionResult GetEmailWithID([FromUri]int EmailID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailService emailService = new EmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailService.Query = emailService.FillQuery(typeof(Email), lang, 0, 1, "", "", extra);

                if (emailService.Query.Extra == "A")
                {
                    EmailExtraA emailExtraA = new EmailExtraA();
                    emailExtraA = emailService.GetEmailExtraAWithEmailID(EmailID);

                    if (emailExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailExtraA);
                }
                else if (emailService.Query.Extra == "B")
                {
                    EmailExtraB emailExtraB = new EmailExtraB();
                    emailExtraB = emailService.GetEmailExtraBWithEmailID(EmailID);

                    if (emailExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailExtraB);
                }
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
