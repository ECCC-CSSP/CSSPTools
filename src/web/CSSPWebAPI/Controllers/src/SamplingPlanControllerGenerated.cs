using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/samplingPlan")]
    public partial class SamplingPlanController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanController() : base()
        {
        }
        public SamplingPlanController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlan
        [Route("")]
        public IActionResult GetSamplingPlanList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = lang }, db, ContactID);

                samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), lang, skip, take, asc, desc, where);

                 if (samplingPlanService.Query.HasErrors)
                 {
                     return Ok(new List<SamplingPlan>()
                     {
                         new SamplingPlan()
                         {
                             HasErrors = samplingPlanService.Query.HasErrors,
                             ValidationResults = samplingPlanService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(samplingPlanService.GetSamplingPlanList().ToList());
                 }
            }
        }
        // GET api/samplingPlan/1
        [Route("{SamplingPlanID:int}")]
        public IActionResult GetSamplingPlanWithID([FromQuery]int SamplingPlanID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), lang, 0, 1, "", "");

                SamplingPlan samplingPlan = new SamplingPlan();
                samplingPlan = samplingPlanService.GetSamplingPlanWithSamplingPlanID(SamplingPlanID);

                if (samplingPlan == null)
                {
                    return NotFound();
                }

                return Ok(samplingPlan);
            }
        }
        // POST api/samplingPlan
        [Route("")]
        public IActionResult Post([FromBody]SamplingPlan samplingPlan, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanService.Add(samplingPlan))
                {
                    return BadRequest(String.Join("|||", samplingPlan.ValidationResults));
                }
                else
                {
                    samplingPlan.ValidationResults = null;
                    return Created(Url.ToString(), samplingPlan);
                }
            }
        }
        // PUT api/samplingPlan
        [Route("")]
        public IActionResult Put([FromBody]SamplingPlan samplingPlan, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanService.Update(samplingPlan))
                {
                    return BadRequest(String.Join("|||", samplingPlan.ValidationResults));
                }
                else
                {
                    samplingPlan.ValidationResults = null;
                    return Ok(samplingPlan);
                }
            }
        }
        // DELETE api/samplingPlan
        [Route("")]
        public IActionResult Delete([FromBody]SamplingPlan samplingPlan, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanService.Delete(samplingPlan))
                {
                    return BadRequest(String.Join("|||", samplingPlan.ValidationResults));
                }
                else
                {
                    samplingPlan.ValidationResults = null;
                    return Ok(samplingPlan);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
