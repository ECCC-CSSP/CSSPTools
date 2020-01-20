using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/polSourceObservation")]
    public partial class PolSourceObservationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationController() : base()
        {
        }
        public PolSourceObservationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/polSourceObservation
        [Route("")]
        public IHttpActionResult GetPolSourceObservationList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservationExtraA), lang, skip, take, asc, desc, where, extra);

                    if (polSourceObservationService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceObservationExtraA>()
                        {
                            new PolSourceObservationExtraA()
                            {
                                HasErrors = polSourceObservationService.Query.HasErrors,
                                ValidationResults = polSourceObservationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceObservationService.GetPolSourceObservationExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservationExtraB), lang, skip, take, asc, desc, where, extra);

                    if (polSourceObservationService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceObservationExtraB>()
                        {
                            new PolSourceObservationExtraB()
                            {
                                HasErrors = polSourceObservationService.Query.HasErrors,
                                ValidationResults = polSourceObservationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceObservationService.GetPolSourceObservationExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), lang, skip, take, asc, desc, where, extra);

                    if (polSourceObservationService.Query.HasErrors)
                    {
                        return Ok(new List<PolSourceObservation>()
                        {
                            new PolSourceObservation()
                            {
                                HasErrors = polSourceObservationService.Query.HasErrors,
                                ValidationResults = polSourceObservationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(polSourceObservationService.GetPolSourceObservationList().ToList());
                    }
                }
            }
        }
        // GET api/polSourceObservation/1
        [Route("{PolSourceObservationID:int}")]
        public IHttpActionResult GetPolSourceObservationWithID([FromUri]int PolSourceObservationID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), lang, 0, 1, "", "", extra);

                if (polSourceObservationService.Query.Extra == "A")
                {
                    PolSourceObservationExtraA polSourceObservationExtraA = new PolSourceObservationExtraA();
                    polSourceObservationExtraA = polSourceObservationService.GetPolSourceObservationExtraAWithPolSourceObservationID(PolSourceObservationID);

                    if (polSourceObservationExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservationExtraA);
                }
                else if (polSourceObservationService.Query.Extra == "B")
                {
                    PolSourceObservationExtraB polSourceObservationExtraB = new PolSourceObservationExtraB();
                    polSourceObservationExtraB = polSourceObservationService.GetPolSourceObservationExtraBWithPolSourceObservationID(PolSourceObservationID);

                    if (polSourceObservationExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservationExtraB);
                }
                else
                {
                    PolSourceObservation polSourceObservation = new PolSourceObservation();
                    polSourceObservation = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(PolSourceObservationID);

                    if (polSourceObservation == null)
                    {
                        return NotFound();
                    }

                    return Ok(polSourceObservation);
                }
            }
        }
        // POST api/polSourceObservation
        [Route("")]
        public IHttpActionResult Post([FromBody]PolSourceObservation polSourceObservation, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationService.Add(polSourceObservation))
                {
                    return BadRequest(String.Join("|||", polSourceObservation.ValidationResults));
                }
                else
                {
                    polSourceObservation.ValidationResults = null;
                    return Created<PolSourceObservation>(new Uri(Request.RequestUri, polSourceObservation.PolSourceObservationID.ToString()), polSourceObservation);
                }
            }
        }
        // PUT api/polSourceObservation
        [Route("")]
        public IHttpActionResult Put([FromBody]PolSourceObservation polSourceObservation, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationService.Update(polSourceObservation))
                {
                    return BadRequest(String.Join("|||", polSourceObservation.ValidationResults));
                }
                else
                {
                    polSourceObservation.ValidationResults = null;
                    return Ok(polSourceObservation);
                }
            }
        }
        // DELETE api/polSourceObservation
        [Route("")]
        public IHttpActionResult Delete([FromBody]PolSourceObservation polSourceObservation, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!polSourceObservationService.Delete(polSourceObservation))
                {
                    return BadRequest(String.Join("|||", polSourceObservation.ValidationResults));
                }
                else
                {
                    polSourceObservation.ValidationResults = null;
                    return Ok(polSourceObservation);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
