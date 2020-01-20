using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/polSourceObservationIssue")]
    public partial class PolSourceObservationIssueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueController() : base()
        {
        }
        public PolSourceObservationIssueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceObservationIssue
        [Route("")]
        public IHttpActionResult GetPolSourceObservationIssueList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssueExtraA), lang, skip, take, asc, desc, where, extra);

                    if (polSourceObservationIssueService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceObservationIssueExtraA>()
                        {
                            new PolSourceObservationIssueExtraA()
                            {
                                HasErrors = polSourceObservationIssueService.Query.HasErrors,
                                ValidationResults = polSourceObservationIssueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceObservationIssueService.GetPolSourceObservationIssueExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssueExtraB), lang, skip, take, asc, desc, where, extra);

                    if (polSourceObservationIssueService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceObservationIssueExtraB>()
                        {
                            new PolSourceObservationIssueExtraB()
                            {
                                HasErrors = polSourceObservationIssueService.Query.HasErrors,
                                ValidationResults = polSourceObservationIssueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceObservationIssueService.GetPolSourceObservationIssueExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), lang, skip, take, asc, desc, where, extra);

                    if (polSourceObservationIssueService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceObservationIssue>()
                        {
                            new PolSourceObservationIssue()
                            {
                                HasErrors = polSourceObservationIssueService.Query.HasErrors,
                                ValidationResults = polSourceObservationIssueService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList());
                    }
                }
            }
        }
        // GET api/polSourceObservationIssue/1
        [Route("{PolSourceObservationIssueID:int}")]
        public IHttpActionResult GetPolSourceObservationIssueWithID([FromUri]int PolSourceObservationIssueID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), lang, 0, 1, "", "", extra);

                if (polSourceObservationIssueService.Query.Extra == "A")
                {
                    PolSourceObservationIssueExtraA polSourceObservationIssueExtraA = new PolSourceObservationIssueExtraA();
                    polSourceObservationIssueExtraA = polSourceObservationIssueService.GetPolSourceObservationIssueExtraAWithPolSourceObservationIssueID(PolSourceObservationIssueID);

                    if (polSourceObservationIssueExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservationIssueExtraA);
                }
                else if (polSourceObservationIssueService.Query.Extra == "B")
                {
                    PolSourceObservationIssueExtraB polSourceObservationIssueExtraB = new PolSourceObservationIssueExtraB();
                    polSourceObservationIssueExtraB = polSourceObservationIssueService.GetPolSourceObservationIssueExtraBWithPolSourceObservationIssueID(PolSourceObservationIssueID);

                    if (polSourceObservationIssueExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservationIssueExtraB);
                }
                else
                {
                    PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();
                    polSourceObservationIssue = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(PolSourceObservationIssueID);

                    if (polSourceObservationIssue == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservationIssue);
                }
            }
        }
        // POST api/polSourceObservationIssue
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationIssueService.Add(polSourceObservationIssue))
                {
                    return BadRequest(String.Join("|||", polSourceObservationIssue.ValidationResults));
                }
                else
                {
                    polSourceObservationIssue.ValidationResults = null;
                    return Created<PolSourceObservationIssue>(new Uri(Request.RequestUri, polSourceObservationIssue.PolSourceObservationIssueID.ToString()), polSourceObservationIssue);
                }
            }
        }
        // PUT api/polSourceObservationIssue
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationIssueService.Update(polSourceObservationIssue))
                {
                    return BadRequest(String.Join("|||", polSourceObservationIssue.ValidationResults));
                }
                else
                {
                    polSourceObservationIssue.ValidationResults = null;
                    return Ok(polSourceObservationIssue);
                }
            }
        }
        // DELETE api/polSourceObservationIssue
        [Route("")]
        public IHttpActionResult Delete([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationIssueService.Delete(polSourceObservationIssue))
                {
                    return BadRequest(String.Join("|||", polSourceObservationIssue.ValidationResults));
                }
                else
                {
                    polSourceObservationIssue.ValidationResults = null;
                    return Ok(polSourceObservationIssue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
