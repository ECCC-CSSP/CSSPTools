using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetSamplingPlanList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/samplingPlan/1
        [Route("{SamplingPlanID:int}")]
        public IHttpActionResult GetSamplingPlanWithID([FromUri]int SamplingPlanID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), lang, 0, 1, "", "");

                else
                {
                    SamplingPlan samplingPlan = new SamplingPlan();
                    samplingPlan = samplingPlanService.GetSamplingPlanWithSamplingPlanID(SamplingPlanID);

                    if (samplingPlan == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlan);
                }
            }
        }
        // POST api/samplingPlan
        [Route("")]
        public IHttpActionResult Post([FromBody]SamplingPlan samplingPlan, [FromUri]string lang = "en")
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
                    return Created<SamplingPlan>(new Uri(Request.RequestUri, samplingPlan.SamplingPlanID.ToString()), samplingPlan);
                }
            }
        }
        // PUT api/samplingPlan
        [Route("")]
        public IHttpActionResult Put([FromBody]SamplingPlan samplingPlan, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]SamplingPlan samplingPlan, [FromUri]string lang = "en")
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
