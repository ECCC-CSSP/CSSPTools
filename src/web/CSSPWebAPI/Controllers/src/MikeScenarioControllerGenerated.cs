using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mikeScenario")]
    public partial class MikeScenarioController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioController() : base()
        {
        }
        public MikeScenarioController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeScenario
        [Route("")]
        public IActionResult GetMikeScenarioList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = lang }, db, ContactID);

                mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), lang, skip, take, asc, desc, where);

                 if (mikeScenarioService.Query.HasErrors)
                 {
                     return Ok(new List<MikeScenario>()
                     {
                         new MikeScenario()
                         {
                             HasErrors = mikeScenarioService.Query.HasErrors,
                             ValidationResults = mikeScenarioService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mikeScenarioService.GetMikeScenarioList().ToList());
                 }
            }
        }
        // GET api/mikeScenario/1
        [Route("{MikeScenarioID:int}")]
        public IActionResult GetMikeScenarioWithID([FromQuery]int MikeScenarioID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), lang, 0, 1, "", "");

                MikeScenario mikeScenario = new MikeScenario();
                mikeScenario = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(MikeScenarioID);

                if (mikeScenario == null)
                {
                    return NotFound();
                }

                return Ok(mikeScenario);
            }
        }
        // POST api/mikeScenario
        [Route("")]
        public IActionResult Post([FromBody]MikeScenario mikeScenario, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioService.Add(mikeScenario))
                {
                    return BadRequest(String.Join("|||", mikeScenario.ValidationResults));
                }
                else
                {
                    mikeScenario.ValidationResults = null;
                    return Created<MikeScenario>(new Uri(Request.RequestUri, mikeScenario.MikeScenarioID.ToString()), mikeScenario);
                }
            }
        }
        // PUT api/mikeScenario
        [Route("")]
        public IActionResult Put([FromBody]MikeScenario mikeScenario, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioService.Update(mikeScenario))
                {
                    return BadRequest(String.Join("|||", mikeScenario.ValidationResults));
                }
                else
                {
                    mikeScenario.ValidationResults = null;
                    return Ok(mikeScenario);
                }
            }
        }
        // DELETE api/mikeScenario
        [Route("")]
        public IActionResult Delete([FromBody]MikeScenario mikeScenario, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioService.Delete(mikeScenario))
                {
                    return BadRequest(String.Join("|||", mikeScenario.ValidationResults));
                }
                else
                {
                    mikeScenario.ValidationResults = null;
                    return Ok(mikeScenario);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
