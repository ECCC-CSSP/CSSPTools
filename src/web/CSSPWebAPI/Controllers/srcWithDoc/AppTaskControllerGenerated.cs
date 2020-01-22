using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/appTask")]
    public partial class AppTaskController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskController() : base()
        {
        }
        public AppTaskController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/appTask
        [Route("")]
        public IActionResult GetAppTaskList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Lang = lang }, db, ContactID);

                appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), lang, skip, take, asc, desc, where);

                 if (appTaskService.Query.HasErrors)
                 {
                     return Ok(new List<AppTask>()
                     {
                         new AppTask()
                         {
                             HasErrors = appTaskService.Query.HasErrors,
                             ValidationResults = appTaskService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(appTaskService.GetAppTaskList().ToList());
                 }
            }
        }
        // GET api/appTask/1
        [Route("{AppTaskID:int}")]
        public IActionResult GetAppTaskWithID([FromQuery]int AppTaskID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), lang, 0, 1, "", "");

                AppTask appTask = new AppTask();
                appTask = appTaskService.GetAppTaskWithAppTaskID(AppTaskID);

                if (appTask == null)
                {
                    return NotFound();
                }

                return Ok(appTask);
            }
        }
        // POST api/appTask
        [Route("")]
        public IActionResult Post([FromBody]AppTask appTask, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskService.Add(appTask))
                {
                    return BadRequest(String.Join("|||", appTask.ValidationResults));
                }
                else
                {
                    appTask.ValidationResults = null;
                    return Created(Url.ToString(), appTask);
                }
            }
        }
        // PUT api/appTask
        [Route("")]
        public IActionResult Put([FromBody]AppTask appTask, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskService.Update(appTask))
                {
                    return BadRequest(String.Join("|||", appTask.ValidationResults));
                }
                else
                {
                    appTask.ValidationResults = null;
                    return Ok(appTask);
                }
            }
        }
        // DELETE api/appTask
        [Route("")]
        public IActionResult Delete([FromBody]AppTask appTask, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!appTaskService.Delete(appTask))
                {
                    return BadRequest(String.Join("|||", appTask.ValidationResults));
                }
                else
                {
                    appTask.ValidationResults = null;
                    return Ok(appTask);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
