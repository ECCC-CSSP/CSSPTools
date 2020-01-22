using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tideDataValue")]
    public partial class TideDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideDataValueController() : base()
        {
        }
        public TideDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tideDataValue
        [Route("")]
        public IActionResult GetTideDataValueList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = lang }, db, ContactID);

                tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), lang, skip, take, asc, desc, where);

                 if (tideDataValueService.Query.HasErrors)
                 {
                     return Ok(new List<TideDataValue>()
                     {
                         new TideDataValue()
                         {
                             HasErrors = tideDataValueService.Query.HasErrors,
                             ValidationResults = tideDataValueService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(tideDataValueService.GetTideDataValueList().ToList());
                 }
            }
        }
        // GET api/tideDataValue/1
        [Route("{TideDataValueID:int}")]
        public IActionResult GetTideDataValueWithID([FromQuery]int TideDataValueID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), lang, 0, 1, "", "");

                TideDataValue tideDataValue = new TideDataValue();
                tideDataValue = tideDataValueService.GetTideDataValueWithTideDataValueID(TideDataValueID);

                if (tideDataValue == null)
                {
                    return NotFound();
                }

                return Ok(tideDataValue);
            }
        }
        // POST api/tideDataValue
        [Route("")]
        public IActionResult Post([FromBody]TideDataValue tideDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideDataValueService.Add(tideDataValue))
                {
                    return BadRequest(String.Join("|||", tideDataValue.ValidationResults));
                }
                else
                {
                    tideDataValue.ValidationResults = null;
                    return Created(Url.ToString(), tideDataValue);
                }
            }
        }
        // PUT api/tideDataValue
        [Route("")]
        public IActionResult Put([FromBody]TideDataValue tideDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideDataValueService.Update(tideDataValue))
                {
                    return BadRequest(String.Join("|||", tideDataValue.ValidationResults));
                }
                else
                {
                    tideDataValue.ValidationResults = null;
                    return Ok(tideDataValue);
                }
            }
        }
        // DELETE api/tideDataValue
        [Route("")]
        public IActionResult Delete([FromBody]TideDataValue tideDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideDataValueService.Delete(tideDataValue))
                {
                    return BadRequest(String.Join("|||", tideDataValue.ValidationResults));
                }
                else
                {
                    tideDataValue.ValidationResults = null;
                    return Ok(tideDataValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
