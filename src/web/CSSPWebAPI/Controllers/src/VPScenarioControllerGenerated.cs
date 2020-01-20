using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/vpScenario")]
    public partial class VPScenarioController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioController() : base()
        {
        }
        public VPScenarioController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/vpScenario
        [Route("")]
        public IActionResult GetVPScenarioList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = lang }, db, ContactID);

                vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), lang, skip, take, asc, desc, where);

                 if (vpScenarioService.Query.HasErrors)
                 {
                     return Ok(new List<VPScenario>()
                     {
                         new VPScenario()
                         {
                             HasErrors = vpScenarioService.Query.HasErrors,
                             ValidationResults = vpScenarioService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(vpScenarioService.GetVPScenarioList().ToList());
                 }
            }
        }
        // GET api/vpScenario/1
        [Route("{VPScenarioID:int}")]
        public IActionResult GetVPScenarioWithID([FromQuery]int VPScenarioID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), lang, 0, 1, "", "");

                VPScenario vpScenario = new VPScenario();
                vpScenario = vpScenarioService.GetVPScenarioWithVPScenarioID(VPScenarioID);

                if (vpScenario == null)
                {
                    return NotFound();
                }

                return Ok(vpScenario);
            }
        }
        // POST api/vpScenario
        [Route("")]
        public IActionResult Post([FromBody]VPScenario vpScenario, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioService.Add(vpScenario))
                {
                    return BadRequest(String.Join("|||", vpScenario.ValidationResults));
                }
                else
                {
                    vpScenario.ValidationResults = null;
                    return Created<VPScenario>(new Uri(Request.RequestUri, vpScenario.VPScenarioID.ToString()), vpScenario);
                }
            }
        }
        // PUT api/vpScenario
        [Route("")]
        public IActionResult Put([FromBody]VPScenario vpScenario, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioService.Update(vpScenario))
                {
                    return BadRequest(String.Join("|||", vpScenario.ValidationResults));
                }
                else
                {
                    vpScenario.ValidationResults = null;
                    return Ok(vpScenario);
                }
            }
        }
        // DELETE api/vpScenario
        [Route("")]
        public IActionResult Delete([FromBody]VPScenario vpScenario, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!vpScenarioService.Delete(vpScenario))
                {
                    return BadRequest(String.Join("|||", vpScenario.ValidationResults));
                }
                else
                {
                    vpScenario.ValidationResults = null;
                    return Ok(vpScenario);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
