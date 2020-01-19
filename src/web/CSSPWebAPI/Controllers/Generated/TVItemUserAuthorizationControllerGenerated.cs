using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvItemUserAuthorization")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), lang, skip, take, asc, desc, where);

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
        public IHttpActionResult GetTVItemUserAuthorizationWithID([FromUri]int TVItemUserAuthorizationID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), lang, 0, 1, "", "");

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
