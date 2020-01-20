using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tideLocation")]
    public partial class TideLocationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideLocationController() : base()
        {
        }
        public TideLocationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tideLocation
        [Route("")]
        public IHttpActionResult GetTideLocationList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocationExtraA), lang, skip, take, asc, desc, where, extra);

                    if (tideLocationService.Query.HasErrors)
                    {
                        return Ok(new List<TideLocationExtraA>()
                        {
                            new TideLocationExtraA()
                            {
                                HasErrors = tideLocationService.Query.HasErrors,
                                ValidationResults = tideLocationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tideLocationService.GetTideLocationExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocationExtraB), lang, skip, take, asc, desc, where, extra);

                    if (tideLocationService.Query.HasErrors)
                    {
                        return Ok(new List<TideLocationExtraB>()
                        {
                            new TideLocationExtraB()
                            {
                                HasErrors = tideLocationService.Query.HasErrors,
                                ValidationResults = tideLocationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tideLocationService.GetTideLocationExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), lang, skip, take, asc, desc, where, extra);

                    if (tideLocationService.Query.HasErrors)
                    {
                        return Ok(new List<TideLocation>()
                        {
                            new TideLocation()
                            {
                                HasErrors = tideLocationService.Query.HasErrors,
                                ValidationResults = tideLocationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tideLocationService.GetTideLocationList().ToList());
                    }
                }
            }
        }
        // GET api/tideLocation/1
        [Route("{TideLocationID:int}")]
        public IHttpActionResult GetTideLocationWithID([FromUri]int TideLocationID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), lang, 0, 1, "", "", extra);

                if (tideLocationService.Query.Extra == "A")
                {
                    TideLocationExtraA tideLocationExtraA = new TideLocationExtraA();
                    tideLocationExtraA = tideLocationService.GetTideLocationExtraAWithTideLocationID(TideLocationID);

                    if (tideLocationExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(tideLocationExtraA);
                }
                else if (tideLocationService.Query.Extra == "B")
                {
                    TideLocationExtraB tideLocationExtraB = new TideLocationExtraB();
                    tideLocationExtraB = tideLocationService.GetTideLocationExtraBWithTideLocationID(TideLocationID);

                    if (tideLocationExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(tideLocationExtraB);
                }
                else
                {
                    TideLocation tideLocation = new TideLocation();
                    tideLocation = tideLocationService.GetTideLocationWithTideLocationID(TideLocationID);

                    if (tideLocation == null)
                    {
                        return NotFound();
                    }

                    return Ok(tideLocation);
                }
            }
        }
        // POST api/tideLocation
        [Route("")]
        public IHttpActionResult Post([FromBody]TideLocation tideLocation, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideLocationService.Add(tideLocation))
                {
                    return BadRequest(String.Join("|||", tideLocation.ValidationResults));
                }
                else
                {
                    tideLocation.ValidationResults = null;
                    return Created<TideLocation>(new Uri(Request.RequestUri, tideLocation.TideLocationID.ToString()), tideLocation);
                }
            }
        }
        // PUT api/tideLocation
        [Route("")]
        public IHttpActionResult Put([FromBody]TideLocation tideLocation, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideLocationService.Update(tideLocation))
                {
                    return BadRequest(String.Join("|||", tideLocation.ValidationResults));
                }
                else
                {
                    tideLocation.ValidationResults = null;
                    return Ok(tideLocation);
                }
            }
        }
        // DELETE api/tideLocation
        [Route("")]
        public IHttpActionResult Delete([FromBody]TideLocation tideLocation, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TideLocationService tideLocationService = new TideLocationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tideLocationService.Delete(tideLocation))
                {
                    return BadRequest(String.Join("|||", tideLocation.ValidationResults));
                }
                else
                {
                    tideLocation.ValidationResults = null;
                    return Ok(tideLocation);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
