using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/polSourceSiteEffectTerm")]
    public partial class PolSourceSiteEffectTermController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermController() : base()
        {
        }
        public PolSourceSiteEffectTermController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceSiteEffectTerm
        [Route("")]
        public IHttpActionResult GetPolSourceSiteEffectTermList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   polSourceSiteEffectTermService.Query = polSourceSiteEffectTermService.FillQuery(typeof(PolSourceSiteEffectTerm), lang, skip, take, asc, desc, where, extra);

                    if (polSourceSiteEffectTermService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceSiteEffectTerm>()
                        {
                            new PolSourceSiteEffectTerm()
                            {
                                HasErrors = polSourceSiteEffectTermService.Query.HasErrors,
                                ValidationResults = polSourceSiteEffectTermService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceSiteEffectTermService.GetPolSourceSiteEffectTermList().ToList());
                    }
                }
            }
        }
        // GET api/polSourceSiteEffectTerm/1
        [Route("{PolSourceSiteEffectTermID:int}")]
        public IHttpActionResult GetPolSourceSiteEffectTermWithID([FromUri]int PolSourceSiteEffectTermID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceSiteEffectTermService.Query = polSourceSiteEffectTermService.FillQuery(typeof(PolSourceSiteEffectTerm), lang, 0, 1, "", "", extra);

                else
                {
                    PolSourceSiteEffectTerm polSourceSiteEffectTerm = new PolSourceSiteEffectTerm();
                    polSourceSiteEffectTerm = polSourceSiteEffectTermService.GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(PolSourceSiteEffectTermID);

                    if (polSourceSiteEffectTerm == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceSiteEffectTerm);
                }
            }
        }
        // POST api/polSourceSiteEffectTerm
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceSiteEffectTerm polSourceSiteEffectTerm, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteEffectTermService.Add(polSourceSiteEffectTerm))
                {
                    return BadRequest(String.Join("|||", polSourceSiteEffectTerm.ValidationResults));
                }
                else
                {
                    polSourceSiteEffectTerm.ValidationResults = null;
                    return Created<PolSourceSiteEffectTerm>(new Uri(Request.RequestUri, polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString()), polSourceSiteEffectTerm);
                }
            }
        }
        // PUT api/polSourceSiteEffectTerm
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceSiteEffectTerm polSourceSiteEffectTerm, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteEffectTermService.Update(polSourceSiteEffectTerm))
                {
                    return BadRequest(String.Join("|||", polSourceSiteEffectTerm.ValidationResults));
                }
                else
                {
                    polSourceSiteEffectTerm.ValidationResults = null;
                    return Ok(polSourceSiteEffectTerm);
                }
            }
        }
        // DELETE api/polSourceSiteEffectTerm
        [Route("")]
        public IHttpActionResult Delete([FromBody]PolSourceSiteEffectTerm polSourceSiteEffectTerm, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceSiteEffectTermService.Delete(polSourceSiteEffectTerm))
                {
                    return BadRequest(String.Join("|||", polSourceSiteEffectTerm.ValidationResults));
                }
                else
                {
                    polSourceSiteEffectTerm.ValidationResults = null;
                    return Ok(polSourceSiteEffectTerm);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
