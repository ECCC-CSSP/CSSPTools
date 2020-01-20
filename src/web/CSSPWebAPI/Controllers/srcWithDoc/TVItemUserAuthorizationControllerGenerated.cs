using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tvItemUserAuthorization")]
    public partial class TVItemUserAuthorizationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationController() : base()
        {
        }
        public TVItemUserAuthorizationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvItemUserAuthorization
        [Route("")]
        public IHttpActionResult GetTVItemUserAuthorizationList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorizationExtraA), lang, skip, take, asc, desc, where, extra);

                    if (tvItemUserAuthorizationService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemUserAuthorizationExtraA>()
                        {
                            new TVItemUserAuthorizationExtraA()
                            {
                                HasErrors = tvItemUserAuthorizationService.Query.HasErrors,
                                ValidationResults = tvItemUserAuthorizationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemUserAuthorizationService.GetTVItemUserAuthorizationExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorizationExtraB), lang, skip, take, asc, desc, where, extra);

                    if (tvItemUserAuthorizationService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemUserAuthorizationExtraB>()
                        {
                            new TVItemUserAuthorizationExtraB()
                            {
                                HasErrors = tvItemUserAuthorizationService.Query.HasErrors,
                                ValidationResults = tvItemUserAuthorizationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemUserAuthorizationService.GetTVItemUserAuthorizationExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), lang, skip, take, asc, desc, where, extra);

                    if (tvItemUserAuthorizationService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemUserAuthorization>()
                        {
                            new TVItemUserAuthorization()
                            {
                                HasErrors = tvItemUserAuthorizationService.Query.HasErrors,
                                ValidationResults = tvItemUserAuthorizationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList());
                    }
                }
            }
        }
        // GET api/tvItemUserAuthorization/1
        [Route("{TVItemUserAuthorizationID:int}")]
        public IHttpActionResult GetTVItemUserAuthorizationWithID([FromUri]int TVItemUserAuthorizationID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), lang, 0, 1, "", "", extra);

                if (tvItemUserAuthorizationService.Query.Extra == "A")
                {
                    TVItemUserAuthorizationExtraA tvItemUserAuthorizationExtraA = new TVItemUserAuthorizationExtraA();
                    tvItemUserAuthorizationExtraA = tvItemUserAuthorizationService.GetTVItemUserAuthorizationExtraAWithTVItemUserAuthorizationID(TVItemUserAuthorizationID);

                    if (tvItemUserAuthorizationExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemUserAuthorizationExtraA);
                }
                else if (tvItemUserAuthorizationService.Query.Extra == "B")
                {
                    TVItemUserAuthorizationExtraB tvItemUserAuthorizationExtraB = new TVItemUserAuthorizationExtraB();
                    tvItemUserAuthorizationExtraB = tvItemUserAuthorizationService.GetTVItemUserAuthorizationExtraBWithTVItemUserAuthorizationID(TVItemUserAuthorizationID);

                    if (tvItemUserAuthorizationExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemUserAuthorizationExtraB);
                }
                else
                {
                    TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();
                    tvItemUserAuthorization = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(TVItemUserAuthorizationID);

                    if (tvItemUserAuthorization == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemUserAuthorization);
                }
            }
        }
        // POST api/tvItemUserAuthorization
        [Route("")]
        public IHttpActionResult Post([FromBody]TVItemUserAuthorization tvItemUserAuthorization, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemUserAuthorizationService.Add(tvItemUserAuthorization))
                {
                    return BadRequest(String.Join("|||", tvItemUserAuthorization.ValidationResults));
                }
                else
                {
                    tvItemUserAuthorization.ValidationResults = null;
                    return Created<TVItemUserAuthorization>(new Uri(Request.RequestUri, tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), tvItemUserAuthorization);
                }
            }
        }
        // PUT api/tvItemUserAuthorization
        [Route("")]
        public IHttpActionResult Put([FromBody]TVItemUserAuthorization tvItemUserAuthorization, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemUserAuthorizationService.Update(tvItemUserAuthorization))
                {
                    return BadRequest(String.Join("|||", tvItemUserAuthorization.ValidationResults));
                }
                else
                {
                    tvItemUserAuthorization.ValidationResults = null;
                    return Ok(tvItemUserAuthorization);
                }
            }
        }
        // DELETE api/tvItemUserAuthorization
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVItemUserAuthorization tvItemUserAuthorization, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemUserAuthorizationService.Delete(tvItemUserAuthorization))
                {
                    return BadRequest(String.Join("|||", tvItemUserAuthorization.ValidationResults));
                }
                else
                {
                    tvItemUserAuthorization.ValidationResults = null;
                    return Ok(tvItemUserAuthorization);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
