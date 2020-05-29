using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/tvTypeUserAuthorization")]
    public partial class TVTypeUserAuthorizationController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationController() : base()
        {
        }
        public TVTypeUserAuthorizationController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvTypeUserAuthorization
        [Route("")]
        public IHttpActionResult GetTVTypeUserAuthorizationList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), lang, skip, take, asc, desc, where, extra);

                    if (tvTypeUserAuthorizationService.Query.HasErrors)
                    {
                        return Ok(new List<TVTypeUserAuthorization>()
                        {
                            new TVTypeUserAuthorization()
                            {
                                HasErrors = tvTypeUserAuthorizationService.Query.HasErrors,
                                ValidationResults = tvTypeUserAuthorizationService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList());
                    }
                }
            }
        }
        // GET api/tvTypeUserAuthorization/1
        [Route("{TVTypeUserAuthorizationID:int}")]
        public IHttpActionResult GetTVTypeUserAuthorizationWithID([FromUri]int TVTypeUserAuthorizationID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), lang, 0, 1, "", "", extra);

                else
                {
                    TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();
                    tvTypeUserAuthorization = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(TVTypeUserAuthorizationID);

                    if (tvTypeUserAuthorization == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvTypeUserAuthorization);
                }
            }
        }
        // POST api/tvTypeUserAuthorization
        [Route("")]
        public IHttpActionResult Post([FromBody]TVTypeUserAuthorization tvTypeUserAuthorization, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization))
                {
                    return BadRequest(String.Join("|||", tvTypeUserAuthorization.ValidationResults));
                }
                else
                {
                    tvTypeUserAuthorization.ValidationResults = null;
                    return Created<TVTypeUserAuthorization>(new Uri(Request.RequestUri, tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), tvTypeUserAuthorization);
                }
            }
        }
        // PUT api/tvTypeUserAuthorization
        [Route("")]
        public IHttpActionResult Put([FromBody]TVTypeUserAuthorization tvTypeUserAuthorization, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization))
                {
                    return BadRequest(String.Join("|||", tvTypeUserAuthorization.ValidationResults));
                }
                else
                {
                    tvTypeUserAuthorization.ValidationResults = null;
                    return Ok(tvTypeUserAuthorization);
                }
            }
        }
        // DELETE api/tvTypeUserAuthorization
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVTypeUserAuthorization tvTypeUserAuthorization, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization))
                {
                    return BadRequest(String.Join("|||", tvTypeUserAuthorization.ValidationResults));
                }
                else
                {
                    tvTypeUserAuthorization.ValidationResults = null;
                    return Ok(tvTypeUserAuthorization);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
