using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/samplingPlanEmail")]
    public partial class SamplingPlanEmailController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailController() : base()
        {
        }
        public SamplingPlanEmailController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlanEmail
        [Route("")]
        public IActionResult GetSamplingPlanEmailList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = lang }, db, ContactID);

                samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), lang, skip, take, asc, desc, where);

                 if (samplingPlanEmailService.Query.HasErrors)
                 {
                     return Ok(new List<SamplingPlanEmail>()
                     {
                         new SamplingPlanEmail()
                         {
                             HasErrors = samplingPlanEmailService.Query.HasErrors,
                             ValidationResults = samplingPlanEmailService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(samplingPlanEmailService.GetSamplingPlanEmailList().ToList());
                 }
            }
        }
        // GET api/samplingPlanEmail/1
        [Route("{SamplingPlanEmailID:int}")]
        public IActionResult GetSamplingPlanEmailWithID([FromQuery]int SamplingPlanEmailID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), lang, 0, 1, "", "");

                SamplingPlanEmail samplingPlanEmail = new SamplingPlanEmail();
                samplingPlanEmail = samplingPlanEmailService.GetSamplingPlanEmailWithSamplingPlanEmailID(SamplingPlanEmailID);

                if (samplingPlanEmail == null)
                {
                    return NotFound();
                }

                return Ok(samplingPlanEmail);
            }
        }
        // POST api/samplingPlanEmail
        [Route("")]
        public IActionResult Post([FromBody]SamplingPlanEmail samplingPlanEmail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanEmailService.Add(samplingPlanEmail))
                {
                    return BadRequest(String.Join("|||", samplingPlanEmail.ValidationResults));
                }
                else
                {
                    samplingPlanEmail.ValidationResults = null;
                    return Created(Url.ToString(), samplingPlanEmail);
                }
            }
        }
        // PUT api/samplingPlanEmail
        [Route("")]
        public IActionResult Put([FromBody]SamplingPlanEmail samplingPlanEmail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanEmailService.Update(samplingPlanEmail))
                {
                    return BadRequest(String.Join("|||", samplingPlanEmail.ValidationResults));
                }
                else
                {
                    samplingPlanEmail.ValidationResults = null;
                    return Ok(samplingPlanEmail);
                }
            }
        }
        // DELETE api/samplingPlanEmail
        [Route("")]
        public IActionResult Delete([FromBody]SamplingPlanEmail samplingPlanEmail, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanEmailService.Delete(samplingPlanEmail))
                {
                    return BadRequest(String.Join("|||", samplingPlanEmail.ValidationResults));
                }
                else
                {
                    samplingPlanEmail.ValidationResults = null;
                    return Ok(samplingPlanEmail);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
