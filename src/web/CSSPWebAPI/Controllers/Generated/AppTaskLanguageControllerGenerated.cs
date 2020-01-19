using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

namespace CSSPWebAPI.Controllers
{
    [Route("api/appTaskLanguage")]
    public partial class AppTaskLanguageController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskLanguageController() : base()
        {
        }
        public AppTaskLanguageController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/appTaskLanguage
        [Route("")]
        public IHttpActionResult GetAppTaskLanguageList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = lang }, db, ContactID);

                else
                {
                   appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), lang, skip, take, asc, desc, where);

                    if (appTaskLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<AppTaskLanguage>()
                        {
                            new AppTaskLanguage()
                            {
                                HasErrors = appTaskLanguageService.Query.HasErrors,
                                ValidationResults = appTaskLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(appTaskLanguageService.GetAppTaskLanguageList().ToList());
                    }
                }
            }
        }
        // GET api/appTaskLanguage/1
        [Route("{AppTaskLanguageID:int}")]
        public IHttpActionResult GetAppTaskLanguageWithID([FromUri]int AppTaskLanguageID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), lang, 0, 1, "", "");

                else
                {
                    AppTaskLanguage appTaskLanguage = new AppTaskLanguage();
                    appTaskLanguage = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(AppTaskLanguageID);

                    if (appTaskLanguage == null)
                    {
                        return NotFound();
                    }

                    return Ok(appTaskLanguage);
                }
            }
        }
        // POST api/appTaskLanguage
        [Route("")]
        public IHttpActionResult Post([FromBody]AppTaskLanguage appTaskLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskLanguageService.Add(appTaskLanguage))
                {
                    return BadRequest(String.Join("|||", appTaskLanguage.ValidationResults));
                }
                else
                {
                    appTaskLanguage.ValidationResults = null;
                    return Created<AppTaskLanguage>(new Uri(Request.RequestUri, appTaskLanguage.AppTaskLanguageID.ToString()), appTaskLanguage);
                }
            }
        }
        // PUT api/appTaskLanguage
        [Route("")]
        public IHttpActionResult Put([FromBody]AppTaskLanguage appTaskLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskLanguageService.Update(appTaskLanguage))
                {
                    return BadRequest(String.Join("|||", appTaskLanguage.ValidationResults));
                }
                else
                {
                    appTaskLanguage.ValidationResults = null;
                    return Ok(appTaskLanguage);
                }
            }
        }
        // DELETE api/appTaskLanguage
        [Route("")]
        public IHttpActionResult Delete([FromBody]AppTaskLanguage appTaskLanguage, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskLanguageService.Delete(appTaskLanguage))
                {
                    return BadRequest(String.Join("|||", appTaskLanguage.ValidationResults));
                }
                else
                {
                    appTaskLanguage.ValidationResults = null;
                    return Ok(appTaskLanguage);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
