using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/ratingCurveValue")]
    public partial class RatingCurveValueController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveValueController() : base()
        {
        }
        public RatingCurveValueController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/ratingCurveValue
        [Route("")]
        public IActionResult GetRatingCurveValueList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
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
        [Route("{RatingCurveValueID:int}")]
        public IActionResult GetRatingCurveValueWithID([FromQuery]int RatingCurveValueID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Post([FromBody]RatingCurveValue ratingCurveValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!ratingCurveValueService.Add(ratingCurveValue))
                {
                    return BadRequest(String.Join("|||", ratingCurveValue.ValidationResults));
                }
                else
                {
                    ratingCurveValue.ValidationResults = null;
                    return Created<RatingCurveValue>(new Uri(Request.RequestUri, ratingCurveValue.RatingCurveValueID.ToString()), ratingCurveValue);
                }
            }
        }
        // PUT api/ratingCurveValue
        [Route("")]
        public IActionResult Put([FromBody]RatingCurveValue ratingCurveValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
        [Route("")]
        public IActionResult Delete([FromBody]RatingCurveValue ratingCurveValue, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

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
