using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/mikeScenarioResult")]
    public partial class MikeScenarioResultController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioResultController() : base()
        {
        }
        public MikeScenarioResultController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/mikeScenarioResult
        [Route("")]
        public IActionResult GetMikeScenarioResultList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = lang }, db, ContactID);

                mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), lang, skip, take, asc, desc, where);

                 if (mikeScenarioResultService.Query.HasErrors)
                 {
                     return Ok(new List<MikeScenarioResult>()
                     {
                         new MikeScenarioResult()
                         {
                             HasErrors = mikeScenarioResultService.Query.HasErrors,
                             ValidationResults = mikeScenarioResultService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(mikeScenarioResultService.GetMikeScenarioResultList().ToList());
                 }
            }
        }
        // GET api/mikeScenarioResult/1
        [Route("{MikeScenarioResultID:int}")]
        public IActionResult GetMikeScenarioResultWithID([FromQuery]int MikeScenarioResultID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), lang, 0, 1, "", "");

                MikeScenarioResult mikeScenarioResult = new MikeScenarioResult();
                mikeScenarioResult = mikeScenarioResultService.GetMikeScenarioResultWithMikeScenarioResultID(MikeScenarioResultID);

                if (mikeScenarioResult == null)
                {
                    return NotFound();
                }

                return Ok(mikeScenarioResult);
            }
        }
        // POST api/mikeScenarioResult
        [Route("")]
        public IActionResult Post([FromBody]MikeScenarioResult mikeScenarioResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioResultService.Add(mikeScenarioResult))
                {
                    return BadRequest(String.Join("|||", mikeScenarioResult.ValidationResults));
                }
                else
                {
                    mikeScenarioResult.ValidationResults = null;
                    return Created(Url.ToString(), mikeScenarioResult);
                }
            }
        }
        // PUT api/mikeScenarioResult
        [Route("")]
        public IActionResult Put([FromBody]MikeScenarioResult mikeScenarioResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioResultService.Update(mikeScenarioResult))
                {
                    return BadRequest(String.Join("|||", mikeScenarioResult.ValidationResults));
                }
                else
                {
                    mikeScenarioResult.ValidationResults = null;
                    return Ok(mikeScenarioResult);
                }
            }
        }
        // DELETE api/mikeScenarioResult
        [Route("")]
        public IActionResult Delete([FromBody]MikeScenarioResult mikeScenarioResult, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!mikeScenarioResultService.Delete(mikeScenarioResult))
                {
                    return BadRequest(String.Join("|||", mikeScenarioResult.ValidationResults));
                }
                else
                {
                    mikeScenarioResult.ValidationResults = null;
                    return Ok(mikeScenarioResult);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
