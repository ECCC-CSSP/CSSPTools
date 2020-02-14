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
    public partial class DrogueRunController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/drogueRun
        [HttpGet]
        public IActionResult GetDrogueRunList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                drogueRunService.Query = drogueRunService.FillQuery(typeof(DrogueRun), lang, skip, take, asc, desc, where);

                 if (drogueRunService.Query.HasErrors)
                 {
                     return Ok(new List<DrogueRun>()
                     {
                         new DrogueRun()
                         {
                             HasErrors = drogueRunService.Query.HasErrors,
                             ValidationResults = drogueRunService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(drogueRunService.GetDrogueRunList().ToList());
                 }
            }
        }
        // GET api/drogueRun/1
        [HttpGet("{DrogueRunID}")]
        public IActionResult GetDrogueRunWithID(int DrogueRunID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                drogueRunService.Query = drogueRunService.FillQuery(typeof(DrogueRun), lang, 0, 1, "", "");

                DrogueRun drogueRun = new DrogueRun();
                drogueRun = drogueRunService.GetDrogueRunWithDrogueRunID(DrogueRunID);

                if (drogueRun == null)
                {
                    return NotFound();
                }

                return Ok(drogueRun);
            }
        }
        // POST api/drogueRun
        [HttpPost]
        public IActionResult Post(DrogueRun drogueRun, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                if (!drogueRunService.Add(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Created("/api/drogueRun/" + drogueRun.DrogueRunID, drogueRun);
                }
            }
        }
        // PUT api/drogueRun
        [HttpPut]
        public IActionResult Put(DrogueRun drogueRun, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                if (!drogueRunService.Update(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Ok(drogueRun);
                }
            }
        }
        // DELETE api/drogueRun
        [HttpDelete]
        public IActionResult Delete(DrogueRun drogueRun, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunService drogueRunService = new DrogueRunService(new Query() { Lang = lang }, db, ContactID);

                if (!drogueRunService.Delete(drogueRun))
                {
                    return BadRequest(String.Join("|||", drogueRun.ValidationResults));
                }
                else
                {
                    drogueRun.ValidationResults = null;
                    return Ok(drogueRun);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
