using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/rainExceedance")]
    public partial class RainExceedanceController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceController() : base()
        {
        }
        public RainExceedanceController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/rainExceedance
        [Route("")]
        public IHttpActionResult GetRainExceedanceList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedanceExtraA), lang, skip, take, asc, desc, where, extra);

                    if (rainExceedanceService.Query.HasErrors)
                    {
                        return Ok(new List<RainExceedanceExtraA>()
                        {
                            new RainExceedanceExtraA()
                            {
                                HasErrors = rainExceedanceService.Query.HasErrors,
                                ValidationResults = rainExceedanceService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(rainExceedanceService.GetRainExceedanceExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedanceExtraB), lang, skip, take, asc, desc, where, extra);

                    if (rainExceedanceService.Query.HasErrors)
                    {
                        return Ok(new List<RainExceedanceExtraB>()
                        {
                            new RainExceedanceExtraB()
                            {
                                HasErrors = rainExceedanceService.Query.HasErrors,
                                ValidationResults = rainExceedanceService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(rainExceedanceService.GetRainExceedanceExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), lang, skip, take, asc, desc, where, extra);

                    if (rainExceedanceService.Query.HasErrors)
                    {
                        return Ok(new List<RainExceedance>()
                        {
                            new RainExceedance()
                            {
                                HasErrors = rainExceedanceService.Query.HasErrors,
                                ValidationResults = rainExceedanceService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(rainExceedanceService.GetRainExceedanceList().ToList());
                    }
                }
            }
        }
        // GET api/rainExceedance/1
        [Route("{RainExceedanceID:int}")]
        public IHttpActionResult GetRainExceedanceWithID([FromUri]int RainExceedanceID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), lang, 0, 1, "", "", extra);

                if (rainExceedanceService.Query.Extra == "A")
                {
                    RainExceedanceExtraA rainExceedanceExtraA = new RainExceedanceExtraA();
                    rainExceedanceExtraA = rainExceedanceService.GetRainExceedanceExtraAWithRainExceedanceID(RainExceedanceID);

                    if (rainExceedanceExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(rainExceedanceExtraA);
                }
                else if (rainExceedanceService.Query.Extra == "B")
                {
                    RainExceedanceExtraB rainExceedanceExtraB = new RainExceedanceExtraB();
                    rainExceedanceExtraB = rainExceedanceService.GetRainExceedanceExtraBWithRainExceedanceID(RainExceedanceID);

                    if (rainExceedanceExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(rainExceedanceExtraB);
                }
                else
                {
                    RainExceedance rainExceedance = new RainExceedance();
                    rainExceedance = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(RainExceedanceID);

                    if (rainExceedance == null)
                    {
                        return NotFound();
                    }

                    return Ok(rainExceedance);
                }
            }
        }
        // POST api/rainExceedance
        [Route("")]
        public IHttpActionResult Post([FromBody]RainExceedance rainExceedance, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceService.Add(rainExceedance))
                {
                    return BadRequest(String.Join("|||", rainExceedance.ValidationResults));
                }
                else
                {
                    rainExceedance.ValidationResults = null;
                    return Created<RainExceedance>(new Uri(Request.RequestUri, rainExceedance.RainExceedanceID.ToString()), rainExceedance);
                }
            }
        }
        // PUT api/rainExceedance
        [Route("")]
        public IHttpActionResult Put([FromBody]RainExceedance rainExceedance, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceService.Update(rainExceedance))
                {
                    return BadRequest(String.Join("|||", rainExceedance.ValidationResults));
                }
                else
                {
                    rainExceedance.ValidationResults = null;
                    return Ok(rainExceedance);
                }
            }
        }
        // DELETE api/rainExceedance
        [Route("")]
        public IHttpActionResult Delete([FromBody]RainExceedance rainExceedance, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!rainExceedanceService.Delete(rainExceedance))
                {
                    return BadRequest(String.Join("|||", rainExceedance.ValidationResults));
                }
                else
                {
                    rainExceedance.ValidationResults = null;
                    return Ok(rainExceedance);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
