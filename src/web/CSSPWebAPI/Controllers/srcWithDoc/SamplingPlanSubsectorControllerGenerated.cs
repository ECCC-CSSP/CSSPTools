using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/samplingPlanSubsector")]
    public partial class SamplingPlanSubsectorController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorController() : base()
        {
        }
        public SamplingPlanSubsectorController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlanSubsector
        [Route("")]
        public IActionResult GetSamplingPlanSubsectorList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = lang }, db, ContactID);

                samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), lang, skip, take, asc, desc, where);

                 if (samplingPlanSubsectorService.Query.HasErrors)
                 {
                     return Ok(new List<SamplingPlanSubsector>()
                     {
                         new SamplingPlanSubsector()
                         {
                             HasErrors = samplingPlanSubsectorService.Query.HasErrors,
                             ValidationResults = samplingPlanSubsectorService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList());
                 }
            }
        }
        // GET api/samplingPlanSubsector/1
        [Route("{SamplingPlanSubsectorID:int}")]
        public IActionResult GetSamplingPlanSubsectorWithID([FromQuery]int SamplingPlanSubsectorID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), lang, 0, 1, "", "");

                SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();
                samplingPlanSubsector = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(SamplingPlanSubsectorID);

                if (samplingPlanSubsector == null)
                {
                    return NotFound();
                }

                return Ok(samplingPlanSubsector);
            }
        }
        // POST api/samplingPlanSubsector
        [Route("")]
        public IActionResult Post([FromBody]SamplingPlanSubsector samplingPlanSubsector, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorService.Add(samplingPlanSubsector))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsector.ValidationResults));
                }
                else
                {
                    samplingPlanSubsector.ValidationResults = null;
                    return Created(Url.ToString(), samplingPlanSubsector);
                }
            }
        }
        // PUT api/samplingPlanSubsector
        [Route("")]
        public IActionResult Put([FromBody]SamplingPlanSubsector samplingPlanSubsector, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorService.Update(samplingPlanSubsector))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsector.ValidationResults));
                }
                else
                {
                    samplingPlanSubsector.ValidationResults = null;
                    return Ok(samplingPlanSubsector);
                }
            }
        }
        // DELETE api/samplingPlanSubsector
        [Route("")]
        public IActionResult Delete([FromBody]SamplingPlanSubsector samplingPlanSubsector, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorService.Delete(samplingPlanSubsector))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsector.ValidationResults));
                }
                else
                {
                    samplingPlanSubsector.ValidationResults = null;
                    return Ok(samplingPlanSubsector);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
