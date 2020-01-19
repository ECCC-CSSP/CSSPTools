using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/ratingCurve")]
    public partial class RatingCurveController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveController() : base()
        {
        }
        public RatingCurveController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/ratingCurve
        [Route("")]
        public IHttpActionResult GetRatingCurveList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), lang, skip, take, asc, desc, where);

                    if (ratingCurveService.Query.HasErrors)
                    {
                        return Ok(new List<RatingCurve>()
                        {
                            new RatingCurve()
                            {
                                HasErrors = ratingCurveService.Query.HasErrors,
                                ValidationResults = ratingCurveService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(ratingCurveService.GetRatingCurveList().ToList());
                    }
                }
            }
        }
        // GET api/ratingCurve/1
        [Route("{RatingCurveID:int}")]
        public IHttpActionResult GetRatingCurveWithID([FromUri]int RatingCurveID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), lang, 0, 1, "", "");

                else
                {
                    RatingCurve ratingCurve = new RatingCurve();
                    ratingCurve = ratingCurveService.GetRatingCurveWithRatingCurveID(RatingCurveID);

                    if (ratingCurve == null)
                    {
                        return NotFound();
                    }

                    return Ok(ratingCurve);
                }
            }
        }
        // POST api/ratingCurve
        [Route("")]
        public IHttpActionResult Post([FromBody]RatingCurve ratingCurve, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!ratingCurveService.Add(ratingCurve))
                {
                    return BadRequest(String.Join("|||", ratingCurve.ValidationResults));
                }
                else
                {
                    ratingCurve.ValidationResults = null;
                    return Created<RatingCurve>(new Uri(Request.RequestUri, ratingCurve.RatingCurveID.ToString()), ratingCurve);
                }
            }
        }
        // PUT api/ratingCurve
        [Route("")]
        public IHttpActionResult Put([FromBody]RatingCurve ratingCurve, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!ratingCurveService.Update(ratingCurve))
                {
                    return BadRequest(String.Join("|||", ratingCurve.ValidationResults));
                }
                else
                {
                    ratingCurve.ValidationResults = null;
                    return Ok(ratingCurve);
                }
            }
        }
        // DELETE api/ratingCurve
        [Route("")]
        public IHttpActionResult Delete([FromBody]RatingCurve ratingCurve, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!ratingCurveService.Delete(ratingCurve))
                {
                    return BadRequest(String.Join("|||", ratingCurve.ValidationResults));
                }
                else
                {
                    ratingCurve.ValidationResults = null;
                    return Ok(ratingCurve);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
