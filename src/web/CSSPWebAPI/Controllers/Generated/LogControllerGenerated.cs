using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;;

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
        public IHttpActionResult GetLogList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Lang = lang }, db, ContactID);

                else
                {
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
        }
        // GET api/log/1
        [Route("{LogID:int}")]
        public IHttpActionResult GetLogWithID([FromUri]int LogID, [FromUri]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                LogService logService = new LogService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                logService.Query = logService.FillQuery(typeof(Log), lang, 0, 1, "", "");

                else
                {
                    Log log = new Log();
                    log = logService.GetLogWithLogID(LogID);

                    if (log == null)
                    {
                        return NotFound();
                    }

                    return Ok(log);
                }
            }
        }
        // POST api/log
        [Route("")]
        public IHttpActionResult Post([FromBody]Log log, [FromUri]string lang = "en")
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
        public IHttpActionResult Put([FromBody]Log log, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]Log log, [FromUri]string lang = "en")
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
