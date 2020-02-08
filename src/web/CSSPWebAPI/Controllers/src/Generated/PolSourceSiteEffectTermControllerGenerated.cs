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
    public partial class PolSourceSiteEffectTermController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceSiteEffectTerm
        [HttpGet]
        public IActionResult GetPolSourceSiteEffectTermList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{PolSourceSiteEffectTermID}")]
        public IActionResult GetPolSourceSiteEffectTermWithID(int PolSourceSiteEffectTermID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPut]
        public IActionResult Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(PolSourceSiteEffectTerm polSourceSiteEffectTerm, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query() { Lang = lang }, db, ContactID);

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
