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
    public partial class AppErrLogControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppErrLogControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void AppErrLog_Controller_GetAppErrLogList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appErrLogController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogFirst = new AppErrLog();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(query, db, ContactID);
                        appErrLogFirst = (from c in db.AppErrLogs select c).FirstOrDefault();
                        count = (from c in db.AppErrLogs select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with AppErrLog info
                    IActionResult jsonRet = appErrLogController.GetAppErrLogList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(appErrLogFirst.AppErrLogID, ((List<AppErrLog>)ret.Value)[0].AppErrLogID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<AppErrLog>)ret.Value).Count);

                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(query, db, ContactID);
                        appErrLogList = (from c in db.AppErrLogs select c).OrderBy(c => c.AppErrLogID).Skip(0).Take(2).ToList();
                        count = (from c in db.AppErrLogs select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with AppErrLog info
                        jsonRet = appErrLogController.GetAppErrLogList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(appErrLogList[0].AppErrLogID, ((List<AppErrLog>)ret.Value)[0].AppErrLogID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<AppErrLog>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppErrLog info
                           IActionResult jsonRet2 = appErrLogController.GetAppErrLogList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(appErrLogList[1].AppErrLogID, ((List<AppErrLog>)ret2.Value)[0].AppErrLogID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<AppErrLog>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void AppErrLog_Controller_GetAppErrLogWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appErrLogController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogFirst = new AppErrLog();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query(), db, ContactID);
                        appErrLogFirst = (from c in db.AppErrLogs select c).FirstOrDefault();
                    }

                    // ok with AppErrLog info
                    IActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogFirst.AppErrLogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(appErrLogFirst.AppErrLogID, ((AppErrLog)ret.Value).AppErrLogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = appErrLogController.GetAppErrLogWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult appErrLogRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(appErrLogRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void AppErrLog_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appErrLogController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogLast = new AppErrLog();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppErrLogService appErrLogService = new AppErrLogService(query, db, ContactID);
                        appErrLogLast = (from c in db.AppErrLogs select c).FirstOrDefault();
                    }

                    // ok with AppErrLog info
                    IActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogLast.AppErrLogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    AppErrLog appErrLogRet = (AppErrLog)ret.Value;
                    Assert.Equal(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because AppErrLogID exist
                    IActionResult jsonRet2 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added AppErrLog
                    appErrLogRet.AppErrLogID = 0;
                    IActionResult jsonRet3 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
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
        public void AppErrLog_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appErrLogController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogLast = new AppErrLog();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AppErrLogService appErrLogService = new AppErrLogService(query, db, ContactID);
                        appErrLogLast = (from c in db.AppErrLogs select c).FirstOrDefault();
                    }

                    // ok with AppErrLog info
                    IActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogLast.AppErrLogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    AppErrLog appErrLogRet = (AppErrLog)Ret.Value;
                    Assert.Equal(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = appErrLogController.Put(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult appErrLogRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(appErrLogRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because AppErrLogID of 0 does not exist
                    appErrLogRet.AppErrLogID = 0;
                    IActionResult jsonRet3 = appErrLogController.Put(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult appErrLogRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(appErrLogRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void AppErrLog_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appErrLogController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogLast = new AppErrLog();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppErrLogService appErrLogService = new AppErrLogService(query, db, ContactID);
                        appErrLogLast = (from c in db.AppErrLogs select c).FirstOrDefault();
                    }

                    // ok with AppErrLog info
                    IActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogLast.AppErrLogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    AppErrLog appErrLogRet = (AppErrLog)Ret.Value;
                    Assert.Equal(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added AppErrLog
                    appErrLogRet.AppErrLogID = 0;
                    IActionResult jsonRet3 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    AppErrLog appErrLog = (AppErrLog)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because AppErrLogID of 0 does not exist
                    appErrLogRet.AppErrLogID = 0;
                    IActionResult jsonRet4 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
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
