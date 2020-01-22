using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/climateDataValue")]
    public partial class ClimateDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateDataValueController() : base()
        {
        }
        public ClimateDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/climateDataValue
        [Route("")]
        public IActionResult GetClimateDataValueList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = lang }, db, ContactID);

                climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), lang, skip, take, asc, desc, where);

                 if (climateDataValueService.Query.HasErrors)
                 {
                     return Ok(new List<ClimateDataValue>()
                     {
                         new ClimateDataValue()
                         {
                             HasErrors = climateDataValueService.Query.HasErrors,
                             ValidationResults = climateDataValueService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(climateDataValueService.GetClimateDataValueList().ToList());
                 }
            }
        }
        // GET api/climateDataValue/1
        [Route("{ClimateDataValueID:int}")]
        public IActionResult GetClimateDataValueWithID([FromQuery]int ClimateDataValueID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), lang, 0, 1, "", "");

                ClimateDataValue climateDataValue = new ClimateDataValue();
                climateDataValue = climateDataValueService.GetClimateDataValueWithClimateDataValueID(ClimateDataValueID);

                if (climateDataValue == null)
                {
                    return NotFound();
                }

                return Ok(climateDataValue);
            }
        }
        // POST api/climateDataValue
        [Route("")]
        public IActionResult Post([FromBody]ClimateDataValue climateDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateDataValueService.Add(climateDataValue))
                {
                    return BadRequest(String.Join("|||", climateDataValue.ValidationResults));
                }
                else
                {
                    climateDataValue.ValidationResults = null;
                    return Created(Url.ToString(), climateDataValue);
                }
            }
        }
        // PUT api/climateDataValue
        [Route("")]
        public IActionResult Put([FromBody]ClimateDataValue climateDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateDataValueService.Update(climateDataValue))
                {
                    return BadRequest(String.Join("|||", climateDataValue.ValidationResults));
                }
                else
                {
                    climateDataValue.ValidationResults = null;
                    return Ok(climateDataValue);
                }
            }
        }
        // DELETE api/climateDataValue
        [Route("")]
        public IActionResult Delete([FromBody]ClimateDataValue climateDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!climateDataValueService.Delete(climateDataValue))
                {
                    return BadRequest(String.Join("|||", climateDataValue.ValidationResults));
                }
                else
                {
                    climateDataValue.ValidationResults = null;
                    return Ok(climateDataValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
