using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetPolSourceObservationIssueList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/polSourceObservationIssue/1
        [Route("{PolSourceObservationIssueID:int}")]
        public IHttpActionResult GetPolSourceObservationIssueWithID([FromUri]int PolSourceObservationIssueID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), lang, 0, 1, "", "");

                else
                {
                    PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();
                    polSourceObservationIssue = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(PolSourceObservationIssueID);

                    if (polSourceObservationIssue == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservationIssue);
                }
            }
        }
        // POST api/polSourceObservationIssue
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromUri]string lang = "en")
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
                    return Created<PolSourceObservationIssue>(new Uri(Request.RequestUri, polSourceObservationIssue.PolSourceObservationIssueID.ToString()), polSourceObservationIssue);
                }
            }
        }
        // PUT api/polSourceObservationIssue
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]PolSourceObservationIssue polSourceObservationIssue, [FromUri]string lang = "en")
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
