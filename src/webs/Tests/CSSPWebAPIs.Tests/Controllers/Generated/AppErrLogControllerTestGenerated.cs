using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void AppErrLog_Controller_GetAppErrLogList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appErrLogController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

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
                    IHttpActionResult jsonRet = appErrLogController.GetAppErrLogList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<AppErrLog>> ret = jsonRet as OkNegotiatedContentResult<List<AppErrLog>>;
                    Assert.AreEqual(appErrLogFirst.AppErrLogID, ret.Content[0].AppErrLogID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<AppErrLog>>;
                        Assert.AreEqual(appErrLogList[0].AppErrLogID, ret.Content[0].AppErrLogID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppErrLog info
                           IHttpActionResult jsonRet2 = appErrLogController.GetAppErrLogList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<AppErrLog>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<AppErrLog>>;
                           Assert.AreEqual(appErrLogList[1].AppErrLogID, ret2.Content[0].AppErrLogID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void AppErrLog_Controller_GetAppErrLogWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appErrLogController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogFirst = new AppErrLog();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query(), db, ContactID);
                        appErrLogFirst = (from c in db.AppErrLogs select c).FirstOrDefault();
                    }

                    // ok with AppErrLog info
                    IHttpActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogFirst.AppErrLogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.AreEqual(appErrLogFirst.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = appErrLogController.GetAppErrLogWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNull(appErrLogRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void AppErrLog_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appErrLogController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

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
                    IHttpActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogLast.AppErrLogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.AreEqual(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because AppErrLogID exist
                    IHttpActionResult jsonRet2 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNull(appErrLogRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added AppErrLog
                    appErrLogRet.AppErrLogID = 0;
                    appErrLogController.Request = new System.Net.Http.HttpRequestMessage();
                    appErrLogController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appErrLog");
                    IHttpActionResult jsonRet3 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppErrLog> appErrLogRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppErrLog>;
                    Assert.IsNotNull(appErrLogRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet4 = jsonRet4 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNotNull(appErrLogRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void AppErrLog_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appErrLogController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

                    AppErrLog appErrLogLast = new AppErrLog();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AppErrLogService appErrLogService = new AppErrLogService(query, db, ContactID);
                        appErrLogLast = (from c in db.AppErrLogs select c).FirstOrDefault();
                    }

                    // ok with AppErrLog info
                    IHttpActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogLast.AppErrLogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.AreEqual(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = appErrLogController.Put(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNotNull(appErrLogRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because AppErrLogID of 0 does not exist
                    appErrLogRet.AppErrLogID = 0;
                    IHttpActionResult jsonRet3 = appErrLogController.Put(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet3 = jsonRet3 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNull(appErrLogRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void AppErrLog_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppErrLogController appErrLogController = new AppErrLogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appErrLogController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appErrLogController.DatabaseType);

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
                    IHttpActionResult jsonRet = appErrLogController.GetAppErrLogWithID(appErrLogLast.AppErrLogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppErrLog> Ret = jsonRet as OkNegotiatedContentResult<AppErrLog>;
                    AppErrLog appErrLogRet = Ret.Content;
                    Assert.AreEqual(appErrLogLast.AppErrLogID, appErrLogRet.AppErrLogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added AppErrLog
                    appErrLogRet.AppErrLogID = 0;
                    appErrLogController.Request = new System.Net.Http.HttpRequestMessage();
                    appErrLogController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appErrLog");
                    IHttpActionResult jsonRet3 = appErrLogController.Post(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppErrLog> appErrLogRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppErrLog>;
                    Assert.IsNotNull(appErrLogRet3);
                    AppErrLog appErrLog = appErrLogRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet2 = jsonRet2 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNotNull(appErrLogRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because AppErrLogID of 0 does not exist
                    appErrLogRet.AppErrLogID = 0;
                    IHttpActionResult jsonRet4 = appErrLogController.Delete(appErrLogRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<AppErrLog> appErrLogRet4 = jsonRet4 as OkNegotiatedContentResult<AppErrLog>;
                    Assert.IsNull(appErrLogRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
