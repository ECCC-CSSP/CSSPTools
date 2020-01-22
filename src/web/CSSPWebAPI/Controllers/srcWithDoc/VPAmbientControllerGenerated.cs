using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/vpAmbient")]
    public partial class VPAmbientController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientController() : base()
        {
        }
        public VPAmbientController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpAmbient
        [Route("")]
        public IActionResult GetVPAmbientList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
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
        [Route("{VPAmbientID:int}")]
        public IActionResult GetVPAmbientWithID([FromQuery]int VPAmbientID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Post([FromBody]VPAmbient vpAmbient, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Put([FromBody]VPAmbient vpAmbient, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Delete([FromBody]VPAmbient vpAmbient, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
