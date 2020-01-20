using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/emailDistributionList")]
    public partial class EmailDistributionListController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListController() : base()
        {
        }
        public EmailDistributionListController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/emailDistributionList
        [Route("")]
        public IHttpActionResult GetEmailDistributionListList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionListExtraA), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListExtraA>()
                        {
                            new EmailDistributionListExtraA()
                            {
                                HasErrors = emailDistributionListService.Query.HasErrors,
                                ValidationResults = emailDistributionListService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListService.GetEmailDistributionListExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionListExtraB), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionListExtraB>()
                        {
                            new EmailDistributionListExtraB()
                            {
                                HasErrors = emailDistributionListService.Query.HasErrors,
                                ValidationResults = emailDistributionListService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListService.GetEmailDistributionListExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), lang, skip, take, asc, desc, where, extra);

                    if (emailDistributionListService.Query.HasErrors)
                    {
                        return Ok(new List<EmailDistributionList>()
                        {
                            new EmailDistributionList()
                            {
                                HasErrors = emailDistributionListService.Query.HasErrors,
                                ValidationResults = emailDistributionListService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(emailDistributionListService.GetEmailDistributionListList().ToList());
                    }
                }
            }
        }
        // GET api/emailDistributionList/1
        [Route("{EmailDistributionListID:int}")]
        public IHttpActionResult GetEmailDistributionListWithID([FromUri]int EmailDistributionListID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), lang, 0, 1, "", "", extra);

                if (emailDistributionListService.Query.Extra == "A")
                {
                    EmailDistributionListExtraA emailDistributionListExtraA = new EmailDistributionListExtraA();
                    emailDistributionListExtraA = emailDistributionListService.GetEmailDistributionListExtraAWithEmailDistributionListID(EmailDistributionListID);

                    if (emailDistributionListExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListExtraA);
                }
                else if (emailDistributionListService.Query.Extra == "B")
                {
                    EmailDistributionListExtraB emailDistributionListExtraB = new EmailDistributionListExtraB();
                    emailDistributionListExtraB = emailDistributionListService.GetEmailDistributionListExtraBWithEmailDistributionListID(EmailDistributionListID);

                    if (emailDistributionListExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionListExtraB);
                }
                else
                {
                    EmailDistributionList emailDistributionList = new EmailDistributionList();
                    emailDistributionList = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(EmailDistributionListID);

                    if (emailDistributionList == null)
                    {
                        return NotFound();
                    }

                    return Ok(emailDistributionList);
                }
            }
        }
        // POST api/emailDistributionList
        [Route("")]
        public IHttpActionResult Post([FromBody]EmailDistributionList emailDistributionList, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListService.Add(emailDistributionList))
                {
                    return BadRequest(String.Join("|||", emailDistributionList.ValidationResults));
                }
                else
                {
                    emailDistributionList.ValidationResults = null;
                    return Created<EmailDistributionList>(new Uri(Request.RequestUri, emailDistributionList.EmailDistributionListID.ToString()), emailDistributionList);
                }
            }
        }
        // PUT api/emailDistributionList
        [Route("")]
        public IHttpActionResult Put([FromBody]EmailDistributionList emailDistributionList, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListService.Update(emailDistributionList))
                {
                    return BadRequest(String.Join("|||", emailDistributionList.ValidationResults));
                }
                else
                {
                    emailDistributionList.ValidationResults = null;
                    return Ok(emailDistributionList);
                }
            }
        }
        // DELETE api/emailDistributionList
        [Route("")]
        public IHttpActionResult Delete([FromBody]EmailDistributionList emailDistributionList, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!emailDistributionListService.Delete(emailDistributionList))
                {
                    return BadRequest(String.Join("|||", emailDistributionList.ValidationResults));
                }
                else
                {
                    emailDistributionList.ValidationResults = null;
                    return Ok(emailDistributionList);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
