using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<AppErrLog>> ret = jsonRet as OkNegotiatedContentResult<List<AppErrLog>>;
                    Assert.Equal(appErrLogFirst.AppErrLogID, ret.Content[0].AppErrLogID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<AppErrLog>>;
                        Assert.Equal(appErrLogList[0].AppErrLogID, ret.Content[0].AppErrLogID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppErrLog info
                           IActionResult jsonRet2 = appErrLogController.GetAppErrLogList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<AppErrLog>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<AppErrLog>>;
                           Assert.Equal(appErrLogList[1].AppErrLogID, ret2.Content[0].AppErrLogID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.Equal(appErrLogFirst.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = appErrLogController.GetAppErrLogWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.Null(appErrLogRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.Equal(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because AppErrLogID exist
                    IActionResult jsonRet2 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.Null(appErrLogRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added AppErrLog
                    appErrLogRet.AppErrLogID = 0;
                    appErrLogController.Request = new System.Net.Http.HttpRequestMessage();
                    appErrLogController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appErrLog");
                    IActionResult jsonRet3 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppErrLog> appErrLogRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppErrLog>;
                    Assert.NotNull(appErrLogRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet4 = jsonRet4 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.NotNull(appErrLogRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.Equal(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = appErrLogController.Put(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.NotNull(appErrLogRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because AppErrLogID of 0 does not exist
                    appErrLogRet.AppErrLogID = 0;
                    IActionResult jsonRet3 = appErrLogController.Put(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet3 = jsonRet3 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.Null(appErrLogRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.Equal(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added AppErrLog
                    appErrLogRet.AppErrLogID = 0;
                    appErrLogController.Request = new System.Net.Http.HttpRequestMessage();
                    appErrLogController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appErrLog");
                    IActionResult jsonRet3 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppErrLog> appErrLogRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppErrLog>;
                    Assert.NotNull(appErrLogRet3);
                    AppErrLog appErrLog = appErrLogRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.NotNull(appErrLogRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because AppErrLogID of 0 does not exist
                    appErrLogRet.AppErrLogID = 0;
                    IActionResult jsonRet4 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet4 = jsonRet4 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.Null(appErrLogRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
