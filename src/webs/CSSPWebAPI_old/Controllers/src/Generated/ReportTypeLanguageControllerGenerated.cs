/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class ReportTypeLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/reportTypeLanguage
        [HttpGet]
        public IActionResult GetReportTypeLanguageList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{ReportTypeLanguageID}")]
        public IActionResult GetReportTypeLanguageWithID(int ReportTypeLanguageID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(ReportTypeLanguage reportTypeLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (!reportTypeLanguageService.Add(reportTypeLanguage))
                {
                    return BadRequest(String.Join("|||", reportTypeLanguage.ValidationResults));
                }
                else
                {
                    reportTypeLanguage.ValidationResults = null;
                    return Created("/api/reportTypeLanguage/" + reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguage);
                }
            }
        }
        // PUT api/reportTypeLanguage
        [HttpPut]
        public IActionResult Put(ReportTypeLanguage reportTypeLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(ReportTypeLanguage reportTypeLanguage, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = lang }, db, ContactID);

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