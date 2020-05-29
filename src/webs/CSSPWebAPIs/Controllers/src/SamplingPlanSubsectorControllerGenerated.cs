using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/samplingPlanSubsector")]
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
        public IHttpActionResult GetSamplingPlanSubsectorList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/samplingPlanSubsector/1
        [Route("{SamplingPlanSubsectorID:int}")]
        public IHttpActionResult GetSamplingPlanSubsectorWithID([FromUri]int SamplingPlanSubsectorID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), lang, 0, 1, "", "", extra);

                else
                {
                    SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();
                    samplingPlanSubsector = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(SamplingPlanSubsectorID);

                    if (samplingPlanSubsector == null)
                    {
                        return NotFound();
                    }

                    return Ok(samplingPlanSubsector);
                }
            }
        }
        // POST api/samplingPlanSubsector
        [Route("")]
        public IHttpActionResult Post([FromBody]SamplingPlanSubsector samplingPlanSubsector, [FromUri]string lang = "en")
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
                    return Created<SamplingPlanSubsector>(new Uri(Request.RequestUri, samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), samplingPlanSubsector);
                }
            }
        }
        // PUT api/samplingPlanSubsector
        [Route("")]
        public IHttpActionResult Put([FromBody]SamplingPlanSubsector samplingPlanSubsector, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]SamplingPlanSubsector samplingPlanSubsector, [FromUri]string lang = "en")
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
