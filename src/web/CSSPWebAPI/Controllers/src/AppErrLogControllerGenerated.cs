using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/appErrLog")]
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
        public IActionResult GetAppErrLogList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = lang }, db, ContactID);

                appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), lang, skip, take, asc, desc, where);

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
        // GET api/appErrLog/1
        [Route("{AppErrLogID:int}")]
        public IActionResult GetAppErrLogWithID([FromQuery]int AppErrLogID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppErrLogService appErrLogService = new AppErrLogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), lang, 0, 1, "", "");

                AppErrLog appErrLog = new AppErrLog();
                appErrLog = appErrLogService.GetAppErrLogWithAppErrLogID(AppErrLogID);

                if (appErrLog == null)
                {
                    return NotFound();
                }

                return Ok(appErrLog);
            }
        }
        // POST api/appErrLog
        [Route("")]
        public IActionResult Post([FromBody]AppErrLog appErrLog, [FromQuery]string lang = "en")
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
        public IActionResult Put([FromBody]AppErrLog appErrLog, [FromQuery]string lang = "en")
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
        public IActionResult Delete([FromBody]AppErrLog appErrLog, [FromQuery]string lang = "en")
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
