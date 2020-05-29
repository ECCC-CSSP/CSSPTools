using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/appErrLog")]
    public partial class AppErrLogController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppErrLogController() : base()
        {
        }
        public AppErrLogController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/appErrLog
        [Route("")]
        public IHttpActionResult GetAppErrLogList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = lang }, db, ContactID);

                else // QueryString has no parameter [extra] or extra is empty
                {
                   appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), lang, skip, take, asc, desc, where, extra);

                    if (appErrLogService.Query.HasErrors)
                    {
                        return Ok(new List<AppErrLog>()
                        {
                            new AppErrLog()
                            {
                                HasErrors = appErrLogService.Query.HasErrors,
                                ValidationResults = appErrLogService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(appErrLogService.GetAppErrLogList().ToList());
                    }
                }
            }
        }
        // GET api/appErrLog/1
        [Route("{AppErrLogID:int}")]
        public IHttpActionResult GetAppErrLogWithID([FromUri]int AppErrLogID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), lang, 0, 1, "", "", extra);

                else
                {
                    AppErrLog appErrLog = new AppErrLog();
                    appErrLog = appErrLogService.GetAppErrLogWithAppErrLogID(AppErrLogID);

                    if (appErrLog == null)
                    {
                        return NotFound();
                    }

                    return Ok(appErrLog);
                }
            }
        }
        // POST api/appErrLog
        [Route("")]
        public IHttpActionResult Post([FromBody]AppErrLog appErrLog, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appErrLogService.Add(appErrLog))
                {
                    return BadRequest(String.Join("|||", appErrLog.ValidationResults));
                }
                else
                {
                    appErrLog.ValidationResults = null;
                    return Created<AppErrLog>(new Uri(Request.RequestUri, appErrLog.AppErrLogID.ToString()), appErrLog);
                }
            }
        }
        // PUT api/appErrLog
        [Route("")]
        public IHttpActionResult Put([FromBody]AppErrLog appErrLog, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appErrLogService.Update(appErrLog))
                {
                    return BadRequest(String.Join("|||", appErrLog.ValidationResults));
                }
                else
                {
                    appErrLog.ValidationResults = null;
                    return Ok(appErrLog);
                }
            }
        }
        // DELETE api/appErrLog
        [Route("")]
        public IHttpActionResult Delete([FromBody]AppErrLog appErrLog, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appErrLogService.Delete(appErrLog))
                {
                    return BadRequest(String.Join("|||", appErrLog.ValidationResults));
                }
                else
                {
                    appErrLog.ValidationResults = null;
                    return Ok(appErrLog);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
