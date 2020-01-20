using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/emailDistributionListContactLanguage")]
    public partial class EmailDistributionListContactLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageController() : base()
        {
        }
        public EmailDistributionListContactLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListContactLanguage
        [Route("")]
        public IHttpActionResult GetEmailDistributionListContactLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListContactLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListContactLanguageExtraA>()
                        {
                            new EmailDistributionListContactLanguageExtraA()
                            {
                                HasErrors = emailDistributionListContactLanguageService.Query.HasErrors,
                                ValidationResults = emailDistributionListContactLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListContactLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListContactLanguageExtraB>()
                        {
                            new EmailDistributionListContactLanguageExtraB()
                            {
                                HasErrors = emailDistributionListContactLanguageService.Query.HasErrors,
                                ValidationResults = emailDistributionListContactLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListContactLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListContactLanguage>()
                        {
                            new EmailDistributionListContactLanguage()
                            {
                                HasErrors = emailDistributionListContactLanguageService.Query.HasErrors,
                                ValidationResults = emailDistributionListContactLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/emailDistributionListContactLanguage/1
        [Route("{EmailDistributionListContactLanguageID:int}")]
        public IHttpActionResult GetEmailDistributionListContactLanguageWithID([FromUri]int EmailDistributionListContactLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), lang, 0, 1, "", "", extra);

                if (emailDistributionListContactLanguageService.Query.Extra == "A")
                {
                    EmailDistributionListContactLanguageExtraA emailDistributionListContactLanguageExtraA = new EmailDistributionListContactLanguageExtraA();
                    emailDistributionListContactLanguageExtraA = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAWithEmailDistributionListContactLanguageID(EmailDistributionListContactLanguageID);

                    if (emailDistributionListContactLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListContactLanguageExtraA);
                }
                else if (emailDistributionListContactLanguageService.Query.Extra == "B")
                {
                    EmailDistributionListContactLanguageExtraB emailDistributionListContactLanguageExtraB = new EmailDistributionListContactLanguageExtraB();
                    emailDistributionListContactLanguageExtraB = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBWithEmailDistributionListContactLanguageID(EmailDistributionListContactLanguageID);

                    if (emailDistributionListContactLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListContactLanguageExtraB);
                }
                else
                {
                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = new EmailDistributionListContactLanguage();
                    emailDistributionListContactLanguage = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(EmailDistributionListContactLanguageID);

                    if (emailDistributionListContactLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListContactLanguage);
                }
            }
        }
        // POST api/emailDistributionListContactLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]EmailDistributionListContactLanguage emailDistributionListContactLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContactLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListContactLanguage.ValidationResults = null;
                    return Created<EmailDistributionListContactLanguage>(new Uri(Request.RequestUri, emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), emailDistributionListContactLanguage);
                }
            }
        }
        // PUT api/emailDistributionListContactLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]EmailDistributionListContactLanguage emailDistributionListContactLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContactLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListContactLanguage.ValidationResults = null;
                    return Ok(emailDistributionListContactLanguage);
                }
            }
        }
        // DELETE api/emailDistributionListContactLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]EmailDistributionListContactLanguage emailDistributionListContactLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListContactLanguageService.Delete(emailDistributionListContactLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListContactLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListContactLanguage.ValidationResults = null;
                    return Ok(emailDistributionListContactLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
