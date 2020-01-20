using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/appTaskLanguage")]
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
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguageExtraA), lang, skip, take, asc, desc, where, extra);

                    if (appTaskLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<AppTaskLanguageExtraA>()
                        {
                            new AppTaskLanguageExtraA()
                            {
                                HasErrors = appTaskLanguageService.Query.HasErrors,
                                ValidationResults = appTaskLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguageExtraB), lang, skip, take, asc, desc, where, extra);

                    if (appTaskLanguageService.Query.HasErrors)
                    {
                        return Ok(new List<AppTaskLanguageExtraB>()
                        {
                            new AppTaskLanguageExtraB()
                            {
                                HasErrors = appTaskLanguageService.Query.HasErrors,
                                ValidationResults = appTaskLanguageService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), lang, skip, take, asc, desc, where, extra);

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
        public IHttpActionResult GetAppTaskLanguageWithID([FromUri]int AppTaskLanguageID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), lang, 0, 1, "", "", extra);

                if (appTaskLanguageService.Query.Extra == "A")
                {
                    AppTaskLanguageExtraA appTaskLanguageExtraA = new AppTaskLanguageExtraA();
                    appTaskLanguageExtraA = appTaskLanguageService.GetAppTaskLanguageExtraAWithAppTaskLanguageID(AppTaskLanguageID);

                    if (appTaskLanguageExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(appTaskLanguageExtraA);
                }
                else if (appTaskLanguageService.Query.Extra == "B")
                {
                    AppTaskLanguageExtraB appTaskLanguageExtraB = new AppTaskLanguageExtraB();
                    appTaskLanguageExtraB = appTaskLanguageService.GetAppTaskLanguageExtraBWithAppTaskLanguageID(AppTaskLanguageID);

                    if (appTaskLanguageExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(appTaskLanguageExtraB);
                }
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
