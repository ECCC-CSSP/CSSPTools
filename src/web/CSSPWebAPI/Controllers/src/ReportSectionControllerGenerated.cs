using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/reportSection")]
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
        public IActionResult GetReportSectionList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = lang }, db, ContactID);

                reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), lang, skip, take, asc, desc, where);

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
        // GET api/reportSection/1
        [Route("{ReportSectionID:int}")]
        public IActionResult GetReportSectionWithID([FromQuery]int ReportSectionID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportSectionService reportSectionService = new ReportSectionService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), lang, 0, 1, "", "");

                ReportSection reportSection = new ReportSection();
                reportSection = reportSectionService.GetReportSectionWithReportSectionID(ReportSectionID);

                if (reportSection == null)
                {
                    return NotFound();
                }

                return Ok(reportSection);
            }
        }
        // POST api/reportSection
        [Route("")]
        public IActionResult Post([FromBody]ReportSection reportSection, [FromQuery]string lang = "en")
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
        public IActionResult Put([FromBody]ReportSection reportSection, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]ReportSection reportSection, [FromQuery]string lang = "en")
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
