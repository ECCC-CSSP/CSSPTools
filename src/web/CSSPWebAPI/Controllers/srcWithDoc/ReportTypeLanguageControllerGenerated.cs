using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/reportTypeLanguage")]
    public partial class ReportTypeLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageController() : base()
        {
        }
        public ReportTypeLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/reportTypeLanguage
        [Route("")]
        public IHttpActionResult GetReportTypeLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (reportTypeLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<ReportTypeLanguageExtraA>()
                        {
                            new ReportTypeLanguageExtraA()
                            {
                                HasErrors = reportTypeLanguageService.Query.HasErrors,
                                ValidationResults = reportTypeLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (reportTypeLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<ReportTypeLanguageExtraB>()
                        {
                            new ReportTypeLanguageExtraB()
                            {
                                HasErrors = reportTypeLanguageService.Query.HasErrors,
                                ValidationResults = reportTypeLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), lang, skip, take, asc, desc, where, extra);

                    if (reportTypeLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<ReportTypeLanguage>()
                        {
                            new ReportTypeLanguage()
                            {
                                HasErrors = reportTypeLanguageService.Query.HasErrors,
                                ValidationResults = reportTypeLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportTypeLanguageService.GetReportTypeLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/reportTypeLanguage/1
        [Route("{ReportTypeLanguageID:int}")]
        public IHttpActionResult GetReportTypeLanguageWithID([FromUri]int ReportTypeLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), lang, 0, 1, "", "", extra);

                if (reportTypeLanguageService.Query.Extra == "A")
                {
                    ReportTypeLanguageExtraA reportTypeLanguageExtraA = new ReportTypeLanguageExtraA();
                    reportTypeLanguageExtraA = reportTypeLanguageService.GetReportTypeLanguageExtraAWithReportTypeLanguageID(ReportTypeLanguageID);

                    if (reportTypeLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportTypeLanguageExtraA);
                }
                else if (reportTypeLanguageService.Query.Extra == "B")
                {
                    ReportTypeLanguageExtraB reportTypeLanguageExtraB = new ReportTypeLanguageExtraB();
                    reportTypeLanguageExtraB = reportTypeLanguageService.GetReportTypeLanguageExtraBWithReportTypeLanguageID(ReportTypeLanguageID);

                    if (reportTypeLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportTypeLanguageExtraB);
                }
                else
                {
                    ReportTypeLanguage reportTypeLanguage = new ReportTypeLanguage();
                    reportTypeLanguage = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(ReportTypeLanguageID);

                    if (reportTypeLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportTypeLanguage);
                }
            }
        }
        // POST api/reportTypeLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]ReportTypeLanguage reportTypeLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportTypeLanguageService.Add(reportTypeLanguage))
                {
                    return BadRequest(String.Join("|||", reportTypeLanguage.ValidationResults));
                }
                else
                {
                    reportTypeLanguage.ValidationResults = null;
                    return Created<ReportTypeLanguage>(new Uri(Request.RequestUri, reportTypeLanguage.ReportTypeLanguageID.ToString()), reportTypeLanguage);
                }
            }
        }
        // PUT api/reportTypeLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]ReportTypeLanguage reportTypeLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportTypeLanguageService.Update(reportTypeLanguage))
                {
                    return BadRequest(String.Join("|||", reportTypeLanguage.ValidationResults));
                }
                else
                {
                    reportTypeLanguage.ValidationResults = null;
                    return Ok(reportTypeLanguage);
                }
            }
        }
        // DELETE api/reportTypeLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]ReportTypeLanguage reportTypeLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportTypeLanguageService.Delete(reportTypeLanguage))
                {
                    return BadRequest(String.Join("|||", reportTypeLanguage.ValidationResults));
                }
                else
                {
                    reportTypeLanguage.ValidationResults = null;
                    return Ok(reportTypeLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
