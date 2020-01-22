using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/polSourceObservationIssue")]
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
        public IActionResult GetPolSourceObservationIssueList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
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
        [Route("{PolSourceObservationIssueID:int}")]
        public IActionResult GetPolSourceObservationIssueWithID([FromQuery]int PolSourceObservationIssueID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Post([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), polSourceObservationIssue);
                }
            }
        }
        // PUT api/polSourceObservationIssue
        [Route("")]
        public IActionResult Put([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromQuery]string lang = "en")
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
