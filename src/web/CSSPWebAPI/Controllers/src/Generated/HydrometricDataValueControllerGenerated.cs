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
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class HydrometricDataValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricDataValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/hydrometricDataValue
        [HttpGet]
        public IActionResult GetHydrometricDataValueList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{HydrometricDataValueID}")]
        public IActionResult GetHydrometricDataValueWithID(int HydrometricDataValueID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(HydrometricDataValue hydrometricDataValue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = lang }, db, ContactID);

                if (!hydrometricDataValueService.Add(hydrometricDataValue))
                {
                    return BadRequest(String.Join("|||", hydrometricDataValue.ValidationResults));
                }
                else
                {
                    hydrometricDataValue.ValidationResults = null;
                    return Created("/api/hydrometricDataValue/" + hydrometricDataValue.HydrometricDataValueID, hydrometricDataValue);
                }
            }
        }
        // PUT api/hydrometricDataValue
        [HttpPut]
        public IActionResult Put(HydrometricDataValue hydrometricDataValue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(HydrometricDataValue hydrometricDataValue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = lang }, db, ContactID);

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
