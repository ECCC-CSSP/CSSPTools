using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class AppTaskControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void AppTask_Controller_GetAppTaskList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskFirst = new AppTask();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppTaskService appTaskService = new AppTaskService(query, db, ContactID);
                        appTaskFirst = (from c in db.AppTasks select c).FirstOrDefault();
                        count = (from c in db.AppTasks select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with AppTask info
                    IActionResult jsonRet = appTaskController.GetAppTaskList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(appTaskFirst.AppTaskID, ((List<AppTask>)ret.Value)[0].AppTaskID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<AppTask>)ret.Value).Count);

                    List<AppTask> appTaskList = new List<AppTask>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppTaskService appTaskService = new AppTaskService(query, db, ContactID);
                        appTaskList = (from c in db.AppTasks select c).OrderBy(c => c.AppTaskID).Skip(0).Take(2).ToList();
                        count = (from c in db.AppTasks select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with AppTask info
                        jsonRet = appTaskController.GetAppTaskList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(appTaskList[0].AppTaskID, ((List<AppTask>)ret.Value)[0].AppTaskID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<AppTask>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppTask info
                           IActionResult jsonRet2 = appTaskController.GetAppTaskList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(appTaskList[1].AppTaskID, ((List<AppTask>)ret2.Value)[0].AppTaskID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<AppTask>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void AppTask_Controller_GetAppTaskWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskFirst = new AppTask();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query(), db, ContactID);
                        appTaskFirst = (from c in db.AppTasks select c).FirstOrDefault();
                    }

                    // ok with AppTask info
                    IActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskFirst.AppTaskID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(appTaskFirst.AppTaskID, ((AppTask)ret.Value).AppTaskID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = appTaskController.GetAppTaskWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult appTaskRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(appTaskRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void AppTask_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskLast = new AppTask();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppTaskService appTaskService = new AppTaskService(query, db, ContactID);
                        appTaskLast = (from c in db.AppTasks select c).FirstOrDefault();
                    }

                    // ok with AppTask info
                    IActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskLast.AppTaskID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    AppTask appTaskRet = (AppTask)ret.Value;
                    Assert.Equal(appTaskLast.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because AppTaskID exist
                    IActionResult jsonRet2 = appTaskController.Post(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added AppTask
                    appTaskRet.AppTaskID = 0;
                    IActionResult jsonRet3 = appTaskController.Post(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = appTaskController.Delete(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.NotNull(ret4);

                    BadRequestResult badRequest4 = jsonRet4 as BadRequestResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void AppTask_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskLast = new AppTask();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AppTaskService appTaskService = new AppTaskService(query, db, ContactID);
                        appTaskLast = (from c in db.AppTasks select c).FirstOrDefault();
                    }

                    // ok with AppTask info
                    IActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskLast.AppTaskID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    AppTask appTaskRet = (AppTask)Ret.Value;
                    Assert.Equal(appTaskLast.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = appTaskController.Put(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult appTaskRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(appTaskRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because AppTaskID of 0 does not exist
                    appTaskRet.AppTaskID = 0;
                    IActionResult jsonRet3 = appTaskController.Put(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult appTaskRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(appTaskRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void AppTask_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskLast = new AppTask();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppTaskService appTaskService = new AppTaskService(query, db, ContactID);
                        appTaskLast = (from c in db.AppTasks select c).FirstOrDefault();
                    }

                    // ok with AppTask info
                    IActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskLast.AppTaskID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    AppTask appTaskRet = (AppTask)Ret.Value;
                    Assert.Equal(appTaskLast.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added AppTask
                    appTaskRet.AppTaskID = 0;
                    IActionResult jsonRet3 = appTaskController.Post(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    AppTask appTask = (AppTask)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = appTaskController.Delete(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because AppTaskID of 0 does not exist
                    appTaskRet.AppTaskID = 0;
                    IActionResult jsonRet4 = appTaskController.Delete(appTaskRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.Null(ret4);

                    BadRequestObjectResult badRequest4 = jsonRet4 as BadRequestObjectResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
