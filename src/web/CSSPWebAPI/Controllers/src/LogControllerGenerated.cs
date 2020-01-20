using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/log")]
    public partial class LogController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LogController() : base()
        {
        }
        public LogController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/log
        [Route("")]
        public IActionResult GetLogList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Lang = lang }, db, ContactID);

                logService.Query = logService.FillQuery(typeof(Log), lang, skip, take, asc, desc, where);

                 if (logService.Query.HasErrors)
                 {
                     return Ok(new List<Log>()
                     {
                         new Log()
                         {
                             HasErrors = logService.Query.HasErrors,
                             ValidationResults = logService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(logService.GetLogList().ToList());
                 }
            }
        }
        // GET api/log/1
        [Route("{LogID:int}")]
        public IActionResult GetLogWithID([FromQuery]int LogID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                logService.Query = logService.FillQuery(typeof(Log), lang, 0, 1, "", "");

                Log log = new Log();
                log = logService.GetLogWithLogID(LogID);

                if (log == null)
                {
                    return NotFound();
                }

                return Ok(log);
            }
        }
        // POST api/log
        [Route("")]
        public IActionResult Post([FromBody]Log log, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!logService.Add(log))
                {
                    return BadRequest(String.Join("|||", log.ValidationResults));
                }
                else
                {
                    log.ValidationResults = null;
                    return Created<Log>(new Uri(Request.RequestUri, log.LogID.ToString()), log);
                }
            }
        }
        // PUT api/log
        [Route("")]
        public IActionResult Put([FromBody]Log log, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!logService.Update(log))
                {
                    return BadRequest(String.Join("|||", log.ValidationResults));
                }
                else
                {
                    log.ValidationResults = null;
                    return Ok(log);
                }
            }
        }
        // DELETE api/log
        [Route("")]
        public IActionResult Delete([FromBody]Log log, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!logService.Delete(log))
                {
                    return BadRequest(String.Join("|||", log.ValidationResults));
                }
                else
                {
                    log.ValidationResults = null;
                    return Ok(log);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
