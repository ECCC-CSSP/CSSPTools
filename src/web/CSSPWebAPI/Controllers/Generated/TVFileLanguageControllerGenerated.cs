using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/tvFileLanguage")]
    public partial class TVFileLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileLanguageController() : base()
        {
        }
        public TVFileLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/tvFileLanguage
        [Route("")]
        public IHttpActionResult GetTVFileLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), lang, skip, take, asc, desc, where);

                    if (tvFileLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<TVFileLanguage>()
                        {
                            new TVFileLanguage()
                            {
                                HasErrors = tvFileLanguageService.Query.HasErrors,
                                ValidationResults = tvFileLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(tvFileLanguageService.GetTVFileLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/tvFileLanguage/1
        [Route("{TVFileLanguageID:int}")]
        public IHttpActionResult GetTVFileLanguageWithID([FromUri]int TVFileLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), lang, 0, 1, "", "");

                else
                {
                    TVFileLanguage tvFileLanguage = new TVFileLanguage();
                    tvFileLanguage = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(TVFileLanguageID);

                    if (tvFileLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(tvFileLanguage);
                }
            }
        }
        // POST api/tvFileLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]TVFileLanguage tvFileLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvFileLanguageService.Add(tvFileLanguage))
                {
                    return BadRequest(String.Join("|||", tvFileLanguage.ValidationResults));
                }
                else
                {
                    tvFileLanguage.ValidationResults = null;
                    return Created<TVFileLanguage>(new Uri(Request.RequestUri, tvFileLanguage.TVFileLanguageID.ToString()), tvFileLanguage);
                }
            }
        }
        // PUT api/tvFileLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]TVFileLanguage tvFileLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvFileLanguageService.Update(tvFileLanguage))
                {
                    return BadRequest(String.Join("|||", tvFileLanguage.ValidationResults));
                }
                else
                {
                    tvFileLanguage.ValidationResults = null;
                    return Ok(tvFileLanguage);
                }
            }
        }
        // DELETE api/tvFileLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]TVFileLanguage tvFileLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!tvFileLanguageService.Delete(tvFileLanguage))
                {
                    return BadRequest(String.Join("|||", tvFileLanguage.ValidationResults));
                }
                else
                {
                    tvFileLanguage.ValidationResults = null;
                    return Ok(tvFileLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
