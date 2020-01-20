using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/appTask")]
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
        public IHttpActionResult GetAppTaskList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   appTaskService.Query = appTaskService.FillQuery(typeof(AppTaskExtraA), lang, skip, take, asc, desc, where, extra);

                    if (appTaskService.Query.HasErrors)
                    {
                        return Ok(new List<AppTaskExtraA>()
                        {
                            new AppTaskExtraA()
                            {
                                HasErrors = appTaskService.Query.HasErrors,
                                ValidationResults = appTaskService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(appTaskService.GetAppTaskExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   appTaskService.Query = appTaskService.FillQuery(typeof(AppTaskExtraB), lang, skip, take, asc, desc, where, extra);

                    if (appTaskService.Query.HasErrors)
                    {
                        return Ok(new List<AppTaskExtraB>()
                        {
                            new AppTaskExtraB()
                            {
                                HasErrors = appTaskService.Query.HasErrors,
                                ValidationResults = appTaskService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(appTaskService.GetAppTaskExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/appTask/1
        [Route("{AppTaskID:int}")]
        public IHttpActionResult GetAppTaskWithID([FromUri]int AppTaskID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AppTaskService appTaskService = new AppTaskService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), lang, 0, 1, "", "", extra);

                if (appTaskService.Query.Extra == "A")
                {
                    AppTaskExtraA appTaskExtraA = new AppTaskExtraA();
                    appTaskExtraA = appTaskService.GetAppTaskExtraAWithAppTaskID(AppTaskID);

                    if (appTaskExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(appTaskExtraA);
                }
                else if (appTaskService.Query.Extra == "B")
                {
                    AppTaskExtraB appTaskExtraB = new AppTaskExtraB();
                    appTaskExtraB = appTaskService.GetAppTaskExtraBWithAppTaskID(AppTaskID);

                    if (appTaskExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(appTaskExtraB);
                }
                else
                {
                    AppTask appTask = new AppTask();
                    appTask = appTaskService.GetAppTaskWithAppTaskID(AppTaskID);

                    if (appTask == null)
                    {
                        return NotFound();
                    }

                    return Ok(appTask);
                }
            }
        }
        // POST api/appTask
        [Route("")]
        public IHttpActionResult Post([FromBody]AppTask appTask, [FromUri]string lang = "en")
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
                    return Created<AppTask>(new Uri(Request.RequestUri, appTask.AppTaskID.ToString()), appTask);
                }
            }
        }
        // PUT api/appTask
        [Route("")]
        public IHttpActionResult Put([FromBody]AppTask appTask, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]AppTask appTask, [FromUri]string lang = "en")
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
