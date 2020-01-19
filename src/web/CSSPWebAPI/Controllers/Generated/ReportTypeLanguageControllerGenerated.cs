using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/reportTypeLanguage")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), lang, skip, take, asc, desc, where);

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
        public IHttpActionResult GetReportTypeLanguageWithID([FromUri]int ReportTypeLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), lang, 0, 1, "", "");

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
