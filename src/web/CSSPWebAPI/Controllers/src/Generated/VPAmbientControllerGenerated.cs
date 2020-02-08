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
    public partial class VPAmbientController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpAmbient
        [HttpGet]
        public IActionResult GetVPAmbientList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = lang }, db, ContactID);

                vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), lang, skip, take, asc, desc, where);

                 if (vpAmbientService.Query.HasErrors)
                 {
                     return Ok(new List<VPAmbient>()
                     {
                         new VPAmbient()
                         {
                             HasErrors = vpAmbientService.Query.HasErrors,
                             ValidationResults = vpAmbientService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(vpAmbientService.GetVPAmbientList().ToList());
                 }
            }
        }
        // GET api/vpAmbient/1
        [HttpGet("{VPAmbientID}")]
        public IActionResult GetVPAmbientWithID(int VPAmbientID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = lang }, db, ContactID);

                vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), lang, 0, 1, "", "");

                VPAmbient vpAmbient = new VPAmbient();
                vpAmbient = vpAmbientService.GetVPAmbientWithVPAmbientID(VPAmbientID);

                if (vpAmbient == null)
                {
                    return NotFound();
                }

                return Ok(vpAmbient);
            }
        }
        // POST api/vpAmbient
        [HttpPost]
        public IActionResult Post(VPAmbient vpAmbient, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = lang }, db, ContactID);

                if (!vpAmbientService.Add(vpAmbient))
                {
                    return BadRequest(String.Join("|||", vpAmbient.ValidationResults));
                }
                else
                {
                    vpAmbient.ValidationResults = null;
                    return Created(Url.ToString(), vpAmbient);
                }
            }
        }
        // PUT api/vpAmbient
        [HttpPut]
        public IActionResult Put(VPAmbient vpAmbient, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = lang }, db, ContactID);

                if (!vpAmbientService.Update(vpAmbient))
                {
                    return BadRequest(String.Join("|||", vpAmbient.ValidationResults));
                }
                else
                {
                    vpAmbient.ValidationResults = null;
                    return Ok(vpAmbient);
                }
            }
        }
        // DELETE api/vpAmbient
        [HttpDelete]
        public IActionResult Delete(VPAmbient vpAmbient, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = lang }, db, ContactID);

                if (!vpAmbientService.Delete(vpAmbient))
                {
                    return BadRequest(String.Join("|||", vpAmbient.ValidationResults));
                }
                else
                {
                    vpAmbient.ValidationResults = null;
                    return Ok(vpAmbient);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
