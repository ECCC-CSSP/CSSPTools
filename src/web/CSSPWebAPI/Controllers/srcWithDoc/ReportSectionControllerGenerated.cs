using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/reportSection")]
    public partial class ReportSectionController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionController() : base()
        {
        }
        public ReportSectionController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/reportSection
        [Route("")]
        public IHttpActionResult GetReportSectionList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSectionExtraA), lang, skip, take, asc, desc, where, extra);

                    if (reportSectionService.Query.HasErrors)
                    {
                        return Ok(new List<ReportSectionExtraA>()
                        {
                            new ReportSectionExtraA()
                            {
                                HasErrors = reportSectionService.Query.HasErrors,
                                ValidationResults = reportSectionService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportSectionService.GetReportSectionExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSectionExtraB), lang, skip, take, asc, desc, where, extra);

                    if (reportSectionService.Query.HasErrors)
                    {
                        return Ok(new List<ReportSectionExtraB>()
                        {
                            new ReportSectionExtraB()
                            {
                                HasErrors = reportSectionService.Query.HasErrors,
                                ValidationResults = reportSectionService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportSectionService.GetReportSectionExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), lang, skip, take, asc, desc, where, extra);

                    if (reportSectionService.Query.HasErrors)
                    {
                        return Ok(new List<ReportSection>()
                        {
                            new ReportSection()
                            {
                                HasErrors = reportSectionService.Query.HasErrors,
                                ValidationResults = reportSectionService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(reportSectionService.GetReportSectionList().ToList());
                    }
                }
            }
        }
        // GET api/reportSection/1
        [Route("{ReportSectionID:int}")]
        public IHttpActionResult GetReportSectionWithID([FromUri]int ReportSectionID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), lang, 0, 1, "", "", extra);

                if (reportSectionService.Query.Extra == "A")
                {
                    ReportSectionExtraA reportSectionExtraA = new ReportSectionExtraA();
                    reportSectionExtraA = reportSectionService.GetReportSectionExtraAWithReportSectionID(ReportSectionID);

                    if (reportSectionExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportSectionExtraA);
                }
                else if (reportSectionService.Query.Extra == "B")
                {
                    ReportSectionExtraB reportSectionExtraB = new ReportSectionExtraB();
                    reportSectionExtraB = reportSectionService.GetReportSectionExtraBWithReportSectionID(ReportSectionID);

                    if (reportSectionExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportSectionExtraB);
                }
                else
                {
                    ReportSection reportSection = new ReportSection();
                    reportSection = reportSectionService.GetReportSectionWithReportSectionID(ReportSectionID);

                    if (reportSection == null)
                    {
                        return NotFound();
                    }

                    return Ok(reportSection);
                }
            }
        }
        // POST api/reportSection
        [Route("")]
        public IHttpActionResult Post([FromBody]ReportSection reportSection, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportSectionService.Add(reportSection))
                {
                    return BadRequest(String.Join("|||", reportSection.ValidationResults));
                }
                else
                {
                    reportSection.ValidationResults = null;
                    return Created<ReportSection>(new Uri(Request.RequestUri, reportSection.ReportSectionID.ToString()), reportSection);
                }
            }
        }
        // PUT api/reportSection
        [Route("")]
        public IHttpActionResult Put([FromBody]ReportSection reportSection, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportSectionService.Update(reportSection))
                {
                    return BadRequest(String.Join("|||", reportSection.ValidationResults));
                }
                else
                {
                    reportSection.ValidationResults = null;
                    return Ok(reportSection);
                }
            }
        }
        // DELETE api/reportSection
        [Route("")]
        public IHttpActionResult Delete([FromBody]ReportSection reportSection, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!reportSectionService.Delete(reportSection))
                {
                    return BadRequest(String.Join("|||", reportSection.ValidationResults));
                }
                else
                {
                    reportSection.ValidationResults = null;
                    return Ok(reportSection);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
