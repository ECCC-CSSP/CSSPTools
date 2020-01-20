using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult GetReportTypeLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

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
        // GET api/reportTypeLanguage/1
        [Route("{ReportTypeLanguageID:int}")]
        public IActionResult GetReportTypeLanguageWithID([FromQuery]int ReportTypeLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), lang, 0, 1, "", "");

                ReportTypeLanguage reportTypeLanguage = new ReportTypeLanguage();
                reportTypeLanguage = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(ReportTypeLanguageID);

                if (reportTypeLanguage == null)
                {
                    return NotFound();
                }

                return Ok(reportTypeLanguage);
            }
        }
        // POST api/reportTypeLanguage
        [Route("")]
        public IActionResult Post([FromBody]ReportTypeLanguage reportTypeLanguage, [FromQuery]string lang = "en")
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
        public IActionResult Put([FromBody]ReportTypeLanguage reportTypeLanguage, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]ReportTypeLanguage reportTypeLanguage, [FromQuery]string lang = "en")
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
