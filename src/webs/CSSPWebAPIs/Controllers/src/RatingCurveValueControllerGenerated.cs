using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/ratingCurveValue")]
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
        public IHttpActionResult GetRatingCurveValueList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/ratingCurveValue/1
        [Route("{RatingCurveValueID:int}")]
        public IHttpActionResult GetRatingCurveValueWithID([FromUri]int RatingCurveValueID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), lang, 0, 1, "", "", extra);

                else
                {
                    RatingCurveValue ratingCurveValue = new RatingCurveValue();
                    ratingCurveValue = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(RatingCurveValueID);

                    if (ratingCurveValue == null)
                    {
                        return NotFound();
                    }

                    return Ok(ratingCurveValue);
                }
            }
        }
        // POST api/ratingCurveValue
        [Route("")]
        public IHttpActionResult Post([FromBody]RatingCurveValue ratingCurveValue, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]RatingCurveValue ratingCurveValue, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]RatingCurveValue ratingCurveValue, [FromUri]string lang = "en")
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
