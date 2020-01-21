using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/polSourceSiteEffectTerm")]
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
        public IActionResult GetPolSourceSiteEffectTermList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Lang = lang }, db, ContactID);

                polSourceSiteEffectTermService.Query = polSourceSiteEffectTermService.FillQuery(typeof(PolSourceSiteEffectTerm), lang, skip, take, asc, desc, where);

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
        // GET api/polSourceSiteEffectTerm/1
        [Route("{PolSourceSiteEffectTermID:int}")]
        public IActionResult GetPolSourceSiteEffectTermWithID([FromQuery]int PolSourceSiteEffectTermID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceSiteEffectTermService.Query = polSourceSiteEffectTermService.FillQuery(typeof(PolSourceSiteEffectTerm), lang, 0, 1, "", "");

                PolSourceSiteEffectTerm polSourceSiteEffectTerm = new PolSourceSiteEffectTerm();
                polSourceSiteEffectTerm = polSourceSiteEffectTermService.GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(PolSourceSiteEffectTermID);

                if (polSourceSiteEffectTerm == null)
                {
                    return NotFound();
                }

                return Ok(polSourceSiteEffectTerm);
            }
        }
        // POST api/polSourceSiteEffectTerm
        [Route("")]
        public IActionResult Post([FromBody]PolSourceSiteEffectTerm polSourceSiteEffectTerm, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), polSourceSiteEffectTerm);
                }
            }
        }
        // PUT api/polSourceSiteEffectTerm
        [Route("")]
        public IActionResult Put([FromBody]PolSourceSiteEffectTerm polSourceSiteEffectTerm, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]PolSourceSiteEffectTerm polSourceSiteEffectTerm, [FromQuery]string lang = "en")
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
