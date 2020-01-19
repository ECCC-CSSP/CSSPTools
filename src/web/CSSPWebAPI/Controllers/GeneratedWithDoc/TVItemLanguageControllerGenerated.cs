using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvItemLanguage")]
    public partial class TVItemLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLanguageController() : base()
        {
        }
        public TVItemLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvItemLanguage
        [Route("")]
        public IHttpActionResult GetTVItemLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), lang, skip, take, asc, desc, where);

                    if (tvItemLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<TVItemLanguage>()
                        {
                            new TVItemLanguage()
                            {
                                HasErrors = tvItemLanguageService.Query.HasErrors,
                                ValidationResults = tvItemLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvItemLanguageService.GetTVItemLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/tvItemLanguage/1
        [Route("{TVItemLanguageID:int}")]
        public IHttpActionResult GetTVItemLanguageWithID([FromUri]int TVItemLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), lang, 0, 1, "", "");

                else
                {
                    TVItemLanguage tvItemLanguage = new TVItemLanguage();
                    tvItemLanguage = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(TVItemLanguageID);

                    if (tvItemLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvItemLanguage);
                }
            }
        }
        // POST api/tvItemLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]TVItemLanguage tvItemLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemLanguageService.Add(tvItemLanguage))
                {
                    return BadRequest(String.Join("|||", tvItemLanguage.ValidationResults));
                }
                else
                {
                    tvItemLanguage.ValidationResults = null;
                    return Created<TVItemLanguage>(new Uri(Request.RequestUri, tvItemLanguage.TVItemLanguageID.ToString()), tvItemLanguage);
                }
            }
        }
        // PUT api/tvItemLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]TVItemLanguage tvItemLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemLanguageService.Update(tvItemLanguage))
                {
                    return BadRequest(String.Join("|||", tvItemLanguage.ValidationResults));
                }
                else
                {
                    tvItemLanguage.ValidationResults = null;
                    return Ok(tvItemLanguage);
                }
            }
        }
        // DELETE api/tvItemLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVItemLanguage tvItemLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvItemLanguageService.Delete(tvItemLanguage))
                {
                    return BadRequest(String.Join("|||", tvItemLanguage.ValidationResults));
                }
                else
                {
                    tvItemLanguage.ValidationResults = null;
                    return Ok(tvItemLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
