/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class AppTaskController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/appTask
        [HttpGet]
        public IActionResult GetAppTaskList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{AppTaskID}")]
        public IActionResult GetAppTaskWithID(int AppTaskID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(AppTask appTask, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Lang = lang }, db, ContactID);

                if (!appTaskService.Add(appTask))
                {
                    return BadRequest(String.Join("|||", appTask.ValidationResults));
                }
                else
                {
                    appTask.ValidationResults = null;
                    return Created("/api/appTask/" + appTask.AppTaskID, appTask);
                }
            }
        }
        // PUT api/appTask
        [HttpPut]
        public IActionResult Put(AppTask appTask, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(AppTask appTask, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Lang = lang }, db, ContactID);

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