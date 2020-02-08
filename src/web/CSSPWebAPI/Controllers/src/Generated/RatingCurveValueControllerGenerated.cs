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
    public partial class RatingCurveValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/ratingCurveValue
        [HttpGet]
        public IActionResult GetRatingCurveValueList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = lang }, db, ContactID);

                ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), lang, skip, take, asc, desc, where);

                 if (ratingCurveValueService.Query.HasErrors)
                 {
                     return Ok(new List<RatingCurveValue>()
                     {
                         new RatingCurveValue()
                         {
                             HasErrors = ratingCurveValueService.Query.HasErrors,
                             ValidationResults = ratingCurveValueService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(ratingCurveValueService.GetRatingCurveValueList().ToList());
                 }
            }
        }
        // GET api/ratingCurveValue/1
        [HttpGet("{RatingCurveValueID}")]
        public IActionResult GetRatingCurveValueWithID(int RatingCurveValueID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = lang }, db, ContactID);

                ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), lang, 0, 1, "", "");

                RatingCurveValue ratingCurveValue = new RatingCurveValue();
                ratingCurveValue = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(RatingCurveValueID);

                if (ratingCurveValue == null)
                {
                    return NotFound();
                }

                return Ok(ratingCurveValue);
            }
        }
        // POST api/ratingCurveValue
        [HttpPost]
        public IActionResult Post(RatingCurveValue ratingCurveValue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = lang }, db, ContactID);

                if (!ratingCurveValueService.Add(ratingCurveValue))
                {
                    return BadRequest(String.Join("|||", ratingCurveValue.ValidationResults));
                }
                else
                {
                    ratingCurveValue.ValidationResults = null;
                    return Created(Url.ToString(), ratingCurveValue);
                }
            }
        }
        // PUT api/ratingCurveValue
        [HttpPut]
        public IActionResult Put(RatingCurveValue ratingCurveValue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = lang }, db, ContactID);

                if (!ratingCurveValueService.Update(ratingCurveValue))
                {
                    return BadRequest(String.Join("|||", ratingCurveValue.ValidationResults));
                }
                else
                {
                    ratingCurveValue.ValidationResults = null;
                    return Ok(ratingCurveValue);
                }
            }
        }
        // DELETE api/ratingCurveValue
        [HttpDelete]
        public IActionResult Delete(RatingCurveValue ratingCurveValue, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = lang }, db, ContactID);

                if (!ratingCurveValueService.Delete(ratingCurveValue))
                {
                    return BadRequest(String.Join("|||", ratingCurveValue.ValidationResults));
                }
                else
                {
                    ratingCurveValue.ValidationResults = null;
                    return Ok(ratingCurveValue);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
