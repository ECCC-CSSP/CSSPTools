using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvTypeUserAuthorization")]
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
        public IActionResult GetTVTypeUserAuthorizationList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = lang }, db, ContactID);

                tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), lang, skip, take, asc, desc, where);

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
        // GET api/tvTypeUserAuthorization/1
        [Route("{TVTypeUserAuthorizationID:int}")]
        public IActionResult GetTVTypeUserAuthorizationWithID([FromQuery]int TVTypeUserAuthorizationID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), lang, 0, 1, "", "");

                TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();
                tvTypeUserAuthorization = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(TVTypeUserAuthorizationID);

                if (tvTypeUserAuthorization == null)
                {
                    return NotFound();
                }

                return Ok(tvTypeUserAuthorization);
            }
        }
        // POST api/tvTypeUserAuthorization
        [Route("")]
        public IActionResult Post([FromBody]TVTypeUserAuthorization tvTypeUserAuthorization, [FromQuery]string lang = "en")
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
                    return Created(Url.ToString(), tvTypeUserAuthorization);
                }
            }
        }
        // PUT api/tvTypeUserAuthorization
        [Route("")]
        public IActionResult Put([FromBody]TVTypeUserAuthorization tvTypeUserAuthorization, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]TVTypeUserAuthorization tvTypeUserAuthorization, [FromQuery]string lang = "en")
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
