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
        [Fact]
        public void Log_Controller_GetLogList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(logController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

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
                    IActionResult jsonRet = logController.GetLogList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(logFirst.LogID, ((List<Log>)ret.Value)[0].LogID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Log>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(logList[0].LogID, ((List<Log>)ret.Value)[0].LogID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Log>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Log info
                           IActionResult jsonRet2 = logController.GetLogList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(logList[1].LogID, ((List<Log>)ret2.Value)[0].LogID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Log>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Log_Controller_GetLogWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(logController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logFirst = new Log();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LogService logService = new LogService(new Query(), db, ContactID);
                        logFirst = (from c in db.Logs select c).FirstOrDefault();
                    }

                    // ok with Log info
                    IActionResult jsonRet = logController.GetLogWithID(logFirst.LogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(logFirst.LogID, ((Log)ret.Value).LogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = logController.GetLogWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult logRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(logRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Log_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(logController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

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
                    IActionResult jsonRet = logController.GetLogWithID(logLast.LogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Log logRet = (Log)ret.Value;
                    Assert.Equal(logLast.LogID, logRet.LogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because LogID exist
                    IActionResult jsonRet2 = logController.Post(logRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Log
                    logRet.LogID = 0;
                    IActionResult jsonRet3 = logController.Post(logRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = logController.Delete(logRet, LanguageRequest.ToString());
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
        public void Log_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(logController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

                    Log logLast = new Log();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LogService logService = new LogService(query, db, ContactID);
                        logLast = (from c in db.Logs select c).FirstOrDefault();
                    }

                    // ok with Log info
                    IActionResult jsonRet = logController.GetLogWithID(logLast.LogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Log logRet = (Log)Ret.Value;
                    Assert.Equal(logLast.LogID, logRet.LogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = logController.Put(logRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult logRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(logRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because LogID of 0 does not exist
                    logRet.LogID = 0;
                    IActionResult jsonRet3 = logController.Put(logRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult logRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(logRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Log_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LogController logController = new LogController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(logController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, logController.DatabaseType);

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
                    IActionResult jsonRet = logController.GetLogWithID(logLast.LogID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Log logRet = (Log)Ret.Value;
                    Assert.Equal(logLast.LogID, logRet.LogID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Log
                    logRet.LogID = 0;
                    IActionResult jsonRet3 = logController.Post(logRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Log log = (Log)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = logController.Delete(logRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because LogID of 0 does not exist
                    logRet.LogID = 0;
                    IActionResult jsonRet4 = logController.Delete(logRet, LanguageRequest.ToString());
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
