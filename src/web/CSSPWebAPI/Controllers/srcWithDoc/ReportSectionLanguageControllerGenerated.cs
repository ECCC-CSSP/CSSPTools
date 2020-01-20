using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/reportSectionLanguage")]
    public partial class ReportSectionLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageController() : base()
        {
        }
        public ReportSectionLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/reportSectionLanguage
        [Route("")]
        public IHttpActionResult GetReportSectionLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (reportSectionLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<ReportSectionLanguageExtraA>()
                        {
                            new ReportSectionLanguageExtraA()
                            {
                                HasErrors = reportSectionLanguageService.Query.HasErrors,
                                ValidationResults = reportSectionLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportSectionLanguageService.GetReportSectionLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (reportSectionLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<ReportSectionLanguageExtraB>()
                        {
                            new ReportSectionLanguageExtraB()
                            {
                                HasErrors = reportSectionLanguageService.Query.HasErrors,
                                ValidationResults = reportSectionLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportSectionLanguageService.GetReportSectionLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), lang, skip, take, asc, desc, where, extra);

                    if (reportSectionLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<ReportSectionLanguage>()
                        {
                            new ReportSectionLanguage()
                            {
                                HasErrors = reportSectionLanguageService.Query.HasErrors,
                                ValidationResults = reportSectionLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportSectionLanguageService.GetReportSectionLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/reportSectionLanguage/1
        [Route("{ReportSectionLanguageID:int}")]
        public IHttpActionResult GetReportSectionLanguageWithID([FromUri]int ReportSectionLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), lang, 0, 1, "", "", extra);

                if (reportSectionLanguageService.Query.Extra == "A")
                {
                    ReportSectionLanguageExtraA reportSectionLanguageExtraA = new ReportSectionLanguageExtraA();
                    reportSectionLanguageExtraA = reportSectionLanguageService.GetReportSectionLanguageExtraAWithReportSectionLanguageID(ReportSectionLanguageID);

                    if (reportSectionLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportSectionLanguageExtraA);
                }
                else if (reportSectionLanguageService.Query.Extra == "B")
                {
                    ReportSectionLanguageExtraB reportSectionLanguageExtraB = new ReportSectionLanguageExtraB();
                    reportSectionLanguageExtraB = reportSectionLanguageService.GetReportSectionLanguageExtraBWithReportSectionLanguageID(ReportSectionLanguageID);

                    if (reportSectionLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportSectionLanguageExtraB);
                }
                else
                {
                    ReportSectionLanguage reportSectionLanguage = new ReportSectionLanguage();
                    reportSectionLanguage = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(ReportSectionLanguageID);

                    if (reportSectionLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportSectionLanguage);
                }
            }
        }
        // POST api/reportSectionLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]ReportSectionLanguage reportSectionLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportSectionLanguageService.Add(reportSectionLanguage))
                {
                    return BadRequest(String.Join("|||", reportSectionLanguage.ValidationResults));
                }
                else
                {
                    reportSectionLanguage.ValidationResults = null;
                    return Created<ReportSectionLanguage>(new Uri(Request.RequestUri, reportSectionLanguage.ReportSectionLanguageID.ToString()), reportSectionLanguage);
                }
            }
        }
        // PUT api/reportSectionLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]ReportSectionLanguage reportSectionLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportSectionLanguageService.Update(reportSectionLanguage))
                {
                    return BadRequest(String.Join("|||", reportSectionLanguage.ValidationResults));
                }
                else
                {
                    reportSectionLanguage.ValidationResults = null;
                    return Ok(reportSectionLanguage);
                }
            }
        }
        // DELETE api/reportSectionLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]ReportSectionLanguage reportSectionLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportSectionLanguageService.Delete(reportSectionLanguage))
                {
                    return BadRequest(String.Join("|||", reportSectionLanguage.ValidationResults));
                }
                else
                {
                    reportSectionLanguage.ValidationResults = null;
                    return Ok(reportSectionLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
