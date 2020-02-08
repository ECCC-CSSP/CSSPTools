/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class SamplingPlanSubsectorController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlanSubsector
        [HttpGet]
        public IActionResult GetSamplingPlanSubsectorList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{SamplingPlanSubsectorID}")]
        public IActionResult GetSamplingPlanSubsectorWithID(int SamplingPlanSubsectorID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(SamplingPlanSubsector samplingPlanSubsector, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPut]
        public IActionResult Put(SamplingPlanSubsector samplingPlanSubsector, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(SamplingPlanSubsector samplingPlanSubsector, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = lang }, db, ContactID);

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
