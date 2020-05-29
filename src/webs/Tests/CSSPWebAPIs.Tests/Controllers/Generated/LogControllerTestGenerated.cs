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
    public partial class LogControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LogControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void Log_Controller_GetLogList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(logController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logFirst = new Log();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LogService logService = new LogService(query, db, ContactID);
                        logFirst = (from c in db.Logs select c).FirstOrDefault();
                        count = (from c in db.Logs select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Log info
                    IHttpActionResult jsonRet = logController.GetLogList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<Log>> ret = jsonRet as OkNegotiatedContentResult<List<Log>>;
                    Assert.AreEqual(logFirst.LogID, ret.Content[0].LogID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Log> logList = new List<Log>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LogService logService = new LogService(query, db, ContactID);
                        logList = (from c in db.Logs select c).OrderBy(c => c.LogID).Skip(0).Take(2).ToList();
                        count = (from c in db.Logs select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Log info
                        jsonRet = logController.GetLogList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Log>>;
                        Assert.AreEqual(logList[0].LogID, ret.Content[0].LogID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Log info
                           IHttpActionResult jsonRet2 = logController.GetLogList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Log>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Log>>;
                           Assert.AreEqual(logList[1].LogID, ret2.Content[0].LogID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void Log_Controller_GetLogWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(logController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logFirst = new Log();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LogService logService = new LogService(new Query(), db, ContactID);
                        logFirst = (from c in db.Logs select c).FirstOrDefault();
                    }

                    // ok with Log info
                    IHttpActionResult jsonRet = logController.GetLogWithID(logFirst.LogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Log> Ret = jsonRet as OkNegotiatedContentResult<Log>;
                    Log logRet = Ret.Content;
                    Assert.AreEqual(logFirst.LogID, logRet.LogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = logController.GetLogWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Log> logRet2 = jsonRet2 as OkNegotiatedContentResult<Log>;
                    Assert.IsNull(logRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void Log_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(logController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logLast = new Log();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LogService logService = new LogService(query, db, ContactID);
                        logLast = (from c in db.Logs select c).FirstOrDefault();
                    }

                    // ok with Log info
                    IHttpActionResult jsonRet = logController.GetLogWithID(logLast.LogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Log> Ret = jsonRet as OkNegotiatedContentResult<Log>;
                    Log logRet = Ret.Content;
                    Assert.AreEqual(logLast.LogID, logRet.LogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because LogID exist
                    IHttpActionResult jsonRet2 = logController.Post(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Log> logRet2 = jsonRet2 as OkNegotiatedContentResult<Log>;
                    Assert.IsNull(logRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added Log
                    logRet.LogID = 0;
                    logController.Request = new System.Net.Http.HttpRequestMessage();
                    logController.Request.RequestUri = new System.Uri("http://localhost:5000/api/log");
                    IHttpActionResult jsonRet3 = logController.Post(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Log> logRet3 = jsonRet3 as CreatedNegotiatedContentResult<Log>;
                    Assert.IsNotNull(logRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = logController.Delete(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Log> logRet4 = jsonRet4 as OkNegotiatedContentResult<Log>;
                    Assert.IsNotNull(logRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void Log_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(logController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logLast = new Log();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LogService logService = new LogService(query, db, ContactID);
                        logLast = (from c in db.Logs select c).FirstOrDefault();
                    }

                    // ok with Log info
                    IHttpActionResult jsonRet = logController.GetLogWithID(logLast.LogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Log> Ret = jsonRet as OkNegotiatedContentResult<Log>;
                    Log logRet = Ret.Content;
                    Assert.AreEqual(logLast.LogID, logRet.LogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = logController.Put(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Log> logRet2 = jsonRet2 as OkNegotiatedContentResult<Log>;
                    Assert.IsNotNull(logRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because LogID of 0 does not exist
                    logRet.LogID = 0;
                    IHttpActionResult jsonRet3 = logController.Put(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<Log> logRet3 = jsonRet3 as OkNegotiatedContentResult<Log>;
                    Assert.IsNull(logRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void Log_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(logController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logLast = new Log();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LogService logService = new LogService(query, db, ContactID);
                        logLast = (from c in db.Logs select c).FirstOrDefault();
                    }

                    // ok with Log info
                    IHttpActionResult jsonRet = logController.GetLogWithID(logLast.LogID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Log> Ret = jsonRet as OkNegotiatedContentResult<Log>;
                    Log logRet = Ret.Content;
                    Assert.AreEqual(logLast.LogID, logRet.LogID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Log
                    logRet.LogID = 0;
                    logController.Request = new System.Net.Http.HttpRequestMessage();
                    logController.Request.RequestUri = new System.Uri("http://localhost:5000/api/log");
                    IHttpActionResult jsonRet3 = logController.Post(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Log> logRet3 = jsonRet3 as CreatedNegotiatedContentResult<Log>;
                    Assert.IsNotNull(logRet3);
                    Log log = logRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = logController.Delete(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Log> logRet2 = jsonRet2 as OkNegotiatedContentResult<Log>;
                    Assert.IsNotNull(logRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because LogID of 0 does not exist
                    logRet.LogID = 0;
                    IHttpActionResult jsonRet4 = logController.Delete(logRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Log> logRet4 = jsonRet4 as OkNegotiatedContentResult<Log>;
                    Assert.IsNull(logRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
