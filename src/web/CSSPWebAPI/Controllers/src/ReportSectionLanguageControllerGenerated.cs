using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/reportSectionLanguage")]
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
        public IActionResult GetReportSectionLanguageList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = lang }, db, ContactID);

                reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), lang, skip, take, asc, desc, where);

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
        // GET api/reportSectionLanguage/1
        [Route("{ReportSectionLanguageID:int}")]
        public IActionResult GetReportSectionLanguageWithID([FromQuery]int ReportSectionLanguageID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), lang, 0, 1, "", "");

                ReportSectionLanguage reportSectionLanguage = new ReportSectionLanguage();
                reportSectionLanguage = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(ReportSectionLanguageID);

                if (reportSectionLanguage == null)
                {
                    return NotFound();
                }

                return Ok(reportSectionLanguage);
            }
        }
        // POST api/reportSectionLanguage
        [Route("")]
        public IActionResult Post([FromBody]ReportSectionLanguage reportSectionLanguage, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), reportSectionLanguage);
                }
            }
        }
        // PUT api/reportSectionLanguage
        [Route("")]
        public IActionResult Put([FromBody]ReportSectionLanguage reportSectionLanguage, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]ReportSectionLanguage reportSectionLanguage, [FromQuery]string lang = "en")
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
