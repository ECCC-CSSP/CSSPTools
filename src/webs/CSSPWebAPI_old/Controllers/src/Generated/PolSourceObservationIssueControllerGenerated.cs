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
    public partial class PolSourceObservationIssueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceObservationIssue
        [HttpGet]
        public IActionResult GetPolSourceObservationIssueList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

                polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), lang, skip, take, asc, desc, where);

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
        // GET api/polSourceObservationIssue/1
        [HttpGet("{PolSourceObservationIssueID}")]
        public IActionResult GetPolSourceObservationIssueWithID(int PolSourceObservationIssueID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

                polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), lang, 0, 1, "", "");

                PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();
                polSourceObservationIssue = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(PolSourceObservationIssueID);

                if (polSourceObservationIssue == null)
                {
                    return NotFound();
                }

                return Ok(polSourceObservationIssue);
            }
        }
        // POST api/polSourceObservationIssue
        [HttpPost]
        public IActionResult Post(PolSourceObservationIssue polSourceObservationIssue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

                if (!polSourceObservationIssueService.Add(polSourceObservationIssue))
                {
                    return BadRequest(String.Join("|||", polSourceObservationIssue.ValidationResults));
                }
                else
                {
                    polSourceObservationIssue.ValidationResults = null;
                    return Created("/api/polSourceObservationIssue/" + polSourceObservationIssue.PolSourceObservationIssueID, polSourceObservationIssue);
                }
            }
        }
        // PUT api/polSourceObservationIssue
        [HttpPut]
        public IActionResult Put(PolSourceObservationIssue polSourceObservationIssue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(PolSourceObservationIssue polSourceObservationIssue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

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