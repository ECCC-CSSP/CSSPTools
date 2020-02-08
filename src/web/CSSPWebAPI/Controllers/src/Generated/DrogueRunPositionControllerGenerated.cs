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
    public partial class DrogueRunPositionController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunPositionController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/drogueRunPosition
        [HttpGet]
        public IActionResult GetDrogueRunPositionList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                drogueRunPositionService.Query = drogueRunPositionService.FillQuery(typeof(DrogueRunPosition), lang, skip, take, asc, desc, where);

                 if (drogueRunPositionService.Query.HasErrors)
                 {
                     return Ok(new List<DrogueRunPosition>()
                     {
                         new DrogueRunPosition()
                         {
                             HasErrors = drogueRunPositionService.Query.HasErrors,
                             ValidationResults = drogueRunPositionService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(drogueRunPositionService.GetDrogueRunPositionList().ToList());
                 }
            }
        }
        // GET api/drogueRunPosition/1
        [HttpGet("{DrogueRunPositionID}")]
        public IActionResult GetDrogueRunPositionWithID(int DrogueRunPositionID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                drogueRunPositionService.Query = drogueRunPositionService.FillQuery(typeof(DrogueRunPosition), lang, 0, 1, "", "");

                DrogueRunPosition drogueRunPosition = new DrogueRunPosition();
                drogueRunPosition = drogueRunPositionService.GetDrogueRunPositionWithDrogueRunPositionID(DrogueRunPositionID);

                if (drogueRunPosition == null)
                {
                    return NotFound();
                }

                return Ok(drogueRunPosition);
            }
        }
        // POST api/drogueRunPosition
        [HttpPost]
        public IActionResult Post(DrogueRunPosition drogueRunPosition, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                if (!drogueRunPositionService.Add(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Created(Url.ToString(), drogueRunPosition);
                }
            }
        }
        // PUT api/drogueRunPosition
        [HttpPut]
        public IActionResult Put(DrogueRunPosition drogueRunPosition, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                if (!drogueRunPositionService.Update(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Ok(drogueRunPosition);
                }
            }
        }
        // DELETE api/drogueRunPosition
        [HttpDelete]
        public IActionResult Delete(DrogueRunPosition drogueRunPosition, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query() { Lang = lang }, db, ContactID);

                if (!drogueRunPositionService.Delete(drogueRunPosition))
                {
                    return BadRequest(String.Join("|||", drogueRunPosition.ValidationResults));
                }
                else
                {
                    drogueRunPosition.ValidationResults = null;
                    return Ok(drogueRunPosition);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
