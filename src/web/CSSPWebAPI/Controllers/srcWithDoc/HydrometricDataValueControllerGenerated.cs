using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/hydrometricDataValue")]
    public partial class HydrometricDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricDataValueController() : base()
        {
        }
        public HydrometricDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/hydrometricDataValue
        [Route("")]
        public IActionResult GetHydrometricDataValueList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = lang }, db, ContactID);

                hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), lang, skip, take, asc, desc, where);

                 if (hydrometricDataValueService.Query.HasErrors)
                 {
                     return Ok(new List<HydrometricDataValue>()
                     {
                         new HydrometricDataValue()
                         {
                             HasErrors = hydrometricDataValueService.Query.HasErrors,
                             ValidationResults = hydrometricDataValueService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(hydrometricDataValueService.GetHydrometricDataValueList().ToList());
                 }
            }
        }
        // GET api/hydrometricDataValue/1
        [Route("{HydrometricDataValueID:int}")]
        public IActionResult GetHydrometricDataValueWithID([FromQuery]int HydrometricDataValueID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), lang, 0, 1, "", "");

                HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();
                hydrometricDataValue = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(HydrometricDataValueID);

                if (hydrometricDataValue == null)
                {
                    return NotFound();
                }

                return Ok(hydrometricDataValue);
            }
        }
        // POST api/hydrometricDataValue
        [Route("")]
        public IActionResult Post([FromBody]HydrometricDataValue hydrometricDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricDataValueService.Add(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Created(Url.ToString(), hydrometricDataValue);
                }
            }
        }
        // PUT api/hydrometricDataValue
        [Route("")]
        public IActionResult Put([FromBody]HydrometricDataValue hydrometricDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricDataValueService.Update(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Ok(hydrometricDataValue);
                }
            }
        }
        // DELETE api/hydrometricDataValue
        [Route("")]
        public IActionResult Delete([FromBody]HydrometricDataValue hydrometricDataValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!hydrometricDataValueService.Delete(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Ok(hydrometricDataValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
