using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/samplingPlanSubsectorSite")]
    public partial class SamplingPlanSubsectorSiteController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteController() : base()
        {
        }
        public SamplingPlanSubsectorSiteController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlanSubsectorSite
        [Route("")]
        public IActionResult GetSamplingPlanSubsectorSiteList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = lang }, db, ContactID);

                samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), lang, skip, take, asc, desc, where);

                 if (samplingPlanSubsectorSiteService.Query.HasErrors)
                 {
                     return Ok(new List<SamplingPlanSubsectorSite>()
                     {
                         new SamplingPlanSubsectorSite()
                         {
                             HasErrors = samplingPlanSubsectorSiteService.Query.HasErrors,
                             ValidationResults = samplingPlanSubsectorSiteService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList());
                 }
            }
        }
        // GET api/samplingPlanSubsectorSite/1
        [Route("{SamplingPlanSubsectorSiteID:int}")]
        public IActionResult GetSamplingPlanSubsectorSiteWithID([FromQuery]int SamplingPlanSubsectorSiteID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), lang, 0, 1, "", "");

                SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();
                samplingPlanSubsectorSite = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(SamplingPlanSubsectorSiteID);

                if (samplingPlanSubsectorSite == null)
                {
                    return NotFound();
                }

                return Ok(samplingPlanSubsectorSite);
            }
        }
        // POST api/samplingPlanSubsectorSite
        [Route("")]
        public IActionResult Post([FromBody]SamplingPlanSubsectorSite samplingPlanSubsectorSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsectorSite.ValidationResults));
                }
                else
                {
                    samplingPlanSubsectorSite.ValidationResults = null;
                    return Created(Url.ToString(), samplingPlanSubsectorSite);
                }
            }
        }
        // PUT api/samplingPlanSubsectorSite
        [Route("")]
        public IActionResult Put([FromBody]SamplingPlanSubsectorSite samplingPlanSubsectorSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsectorSite.ValidationResults));
                }
                else
                {
                    samplingPlanSubsectorSite.ValidationResults = null;
                    return Ok(samplingPlanSubsectorSite);
                }
            }
        }
        // DELETE api/samplingPlanSubsectorSite
        [Route("")]
        public IActionResult Delete([FromBody]SamplingPlanSubsectorSite samplingPlanSubsectorSite, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite))
                {
                    return BadRequest(String.Join("|||", samplingPlanSubsectorSite.ValidationResults));
                }
                else
                {
                    samplingPlanSubsectorSite.ValidationResults = null;
                    return Ok(samplingPlanSubsectorSite);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
