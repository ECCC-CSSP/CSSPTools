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
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class SamplingPlanController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/samplingPlan
        [HttpGet]
        public IActionResult GetSamplingPlanList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{SamplingPlanID}")]
        public IActionResult GetSamplingPlanWithID(int SamplingPlanID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(SamplingPlan samplingPlan, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = lang }, db, ContactID);

                if (!samplingPlanService.Add(samplingPlan))
                {
                    return BadRequest(String.Join("|||", samplingPlan.ValidationResults));
                }
                else
                {
                    samplingPlan.ValidationResults = null;
                    return Created("/api/samplingPlan/" + samplingPlan.SamplingPlanID, samplingPlan);
                }
            }
        }
        // PUT api/samplingPlan
        [HttpPut]
        public IActionResult Put(SamplingPlan samplingPlan, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(SamplingPlan samplingPlan, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = lang }, db, ContactID);

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
