using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/emailDistributionListLanguage")]
    public partial class EmailDistributionListLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageController() : base()
        {
        }
        public EmailDistributionListLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionListLanguage
        [Route("")]
        public IHttpActionResult GetEmailDistributionListLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListLanguageExtraA>()
                        {
                            new EmailDistributionListLanguageExtraA()
                            {
                                HasErrors = emailDistributionListLanguageService.Query.HasErrors,
                                ValidationResults = emailDistributionListLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListLanguageService.GetEmailDistributionListLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListLanguageExtraB>()
                        {
                            new EmailDistributionListLanguageExtraB()
                            {
                                HasErrors = emailDistributionListLanguageService.Query.HasErrors,
                                ValidationResults = emailDistributionListLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListLanguageService.GetEmailDistributionListLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListLanguage>()
                        {
                            new EmailDistributionListLanguage()
                            {
                                HasErrors = emailDistributionListLanguageService.Query.HasErrors,
                                ValidationResults = emailDistributionListLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/emailDistributionListLanguage/1
        [Route("{EmailDistributionListLanguageID:int}")]
        public IHttpActionResult GetEmailDistributionListLanguageWithID([FromUri]int EmailDistributionListLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), lang, 0, 1, "", "", extra);

                if (emailDistributionListLanguageService.Query.Extra == "A")
                {
                    EmailDistributionListLanguageExtraA emailDistributionListLanguageExtraA = new EmailDistributionListLanguageExtraA();
                    emailDistributionListLanguageExtraA = emailDistributionListLanguageService.GetEmailDistributionListLanguageExtraAWithEmailDistributionListLanguageID(EmailDistributionListLanguageID);

                    if (emailDistributionListLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListLanguageExtraA);
                }
                else if (emailDistributionListLanguageService.Query.Extra == "B")
                {
                    EmailDistributionListLanguageExtraB emailDistributionListLanguageExtraB = new EmailDistributionListLanguageExtraB();
                    emailDistributionListLanguageExtraB = emailDistributionListLanguageService.GetEmailDistributionListLanguageExtraBWithEmailDistributionListLanguageID(EmailDistributionListLanguageID);

                    if (emailDistributionListLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListLanguageExtraB);
                }
                else
                {
                    EmailDistributionListLanguage emailDistributionListLanguage = new EmailDistributionListLanguage();
                    emailDistributionListLanguage = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(EmailDistributionListLanguageID);

                    if (emailDistributionListLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListLanguage);
                }
            }
        }
        // POST api/emailDistributionListLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]EmailDistributionListLanguage emailDistributionListLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListLanguageService.Add(emailDistributionListLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListLanguage.ValidationResults = null;
                    return Created<EmailDistributionListLanguage>(new Uri(Request.RequestUri, emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), emailDistributionListLanguage);
                }
            }
        }
        // PUT api/emailDistributionListLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]EmailDistributionListLanguage emailDistributionListLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListLanguageService.Update(emailDistributionListLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListLanguage.ValidationResults = null;
                    return Ok(emailDistributionListLanguage);
                }
            }
        }
        // DELETE api/emailDistributionListLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]EmailDistributionListLanguage emailDistributionListLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListLanguageService.Delete(emailDistributionListLanguage))
                {
                    return BadRequest(String.Join("|||", emailDistributionListLanguage.ValidationResults));
                }
                else
                {
                    emailDistributionListLanguage.ValidationResults = null;
                    return Ok(emailDistributionListLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
