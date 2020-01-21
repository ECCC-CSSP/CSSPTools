using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/spill")]
    public partial class SpillController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillController() : base()
        {
        }
        public SpillController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/spill
        [Route("")]
        public IActionResult GetSpillList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Lang = lang }, db, ContactID);

                spillService.Query = spillService.FillQuery(typeof(Spill), lang, skip, take, asc, desc, where);

                 if (spillService.Query.HasErrors)
                 {
                     return Ok(new List<Spill>()
                     {
                         new Spill()
                         {
                             HasErrors = spillService.Query.HasErrors,
                             ValidationResults = spillService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(spillService.GetSpillList().ToList());
                 }
            }
        }
        // GET api/spill/1
        [Route("{SpillID:int}")]
        public IActionResult GetSpillWithID([FromQuery]int SpillID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                spillService.Query = spillService.FillQuery(typeof(Spill), lang, 0, 1, "", "");

                Spill spill = new Spill();
                spill = spillService.GetSpillWithSpillID(SpillID);

                if (spill == null)
                {
                    return NotFound();
                }

                return Ok(spill);
            }
        }
        // POST api/spill
        [Route("")]
        public IActionResult Post([FromBody]Spill spill, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillService.Add(spill))
                {
                    return BadRequest(String.Join("|||", spill.ValidationResults));
                }
                else
                {
                    spill.ValidationResults = null;
                    return Created(Url.ToString(), spill);
                }
            }
        }
        // PUT api/spill
        [Route("")]
        public IActionResult Put([FromBody]Spill spill, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillService.Update(spill))
                {
                    return BadRequest(String.Join("|||", spill.ValidationResults));
                }
                else
                {
                    spill.ValidationResults = null;
                    return Ok(spill);
                }
            }
        }
        // DELETE api/spill
        [Route("")]
        public IActionResult Delete([FromBody]Spill spill, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                SpillService spillService = new SpillService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!spillService.Delete(spill))
                {
                    return BadRequest(String.Join("|||", spill.ValidationResults));
                }
                else
                {
                    spill.ValidationResults = null;
                    return Ok(spill);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
