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
        [TestMethod]
        public void AppTask_Controller_GetAppTaskList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

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
                    IHttpActionResult jsonRet = appTaskController.GetAppTaskList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<AppTask>> ret = jsonRet as OkNegotiatedContentResult<List<AppTask>>;
                    Assert.AreEqual(appTaskFirst.AppTaskID, ret.Content[0].AppTaskID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<AppTask>>;
                        Assert.AreEqual(appTaskList[0].AppTaskID, ret.Content[0].AppTaskID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppTask info
                           IHttpActionResult jsonRet2 = appTaskController.GetAppTaskList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<AppTask>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<AppTask>>;
                           Assert.AreEqual(appTaskList[1].AppTaskID, ret2.Content[0].AppTaskID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void AppTask_Controller_GetAppTaskWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskFirst = new AppTask();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query(), db, ContactID);
                        appTaskFirst = (from c in db.AppTasks select c).FirstOrDefault();
                    }

                    // ok with AppTask info
                    IHttpActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskFirst.AppTaskID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTask> Ret = jsonRet as OkNegotiatedContentResult<AppTask>;
                    AppTask appTaskRet = Ret.Content;
                    Assert.AreEqual(appTaskFirst.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = appTaskController.GetAppTaskWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTask> appTaskRet2 = jsonRet2 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNull(appTaskRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void AppTask_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

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
                    IHttpActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskLast.AppTaskID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTask> Ret = jsonRet as OkNegotiatedContentResult<AppTask>;
                    AppTask appTaskRet = Ret.Content;
                    Assert.AreEqual(appTaskLast.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because AppTaskID exist
                    IHttpActionResult jsonRet2 = appTaskController.Post(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTask> appTaskRet2 = jsonRet2 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNull(appTaskRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added AppTask
                    appTaskRet.AppTaskID = 0;
                    appTaskController.Request = new System.Net.Http.HttpRequestMessage();
                    appTaskController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appTask");
                    IHttpActionResult jsonRet3 = appTaskController.Post(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppTask> appTaskRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppTask>;
                    Assert.IsNotNull(appTaskRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = appTaskController.Delete(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<AppTask> appTaskRet4 = jsonRet4 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNotNull(appTaskRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void AppTask_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

                    AppTask appTaskLast = new AppTask();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AppTaskService appTaskService = new AppTaskService(query, db, ContactID);
                        appTaskLast = (from c in db.AppTasks select c).FirstOrDefault();
                    }

                    // ok with AppTask info
                    IHttpActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskLast.AppTaskID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTask> Ret = jsonRet as OkNegotiatedContentResult<AppTask>;
                    AppTask appTaskRet = Ret.Content;
                    Assert.AreEqual(appTaskLast.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = appTaskController.Put(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTask> appTaskRet2 = jsonRet2 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNotNull(appTaskRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because AppTaskID of 0 does not exist
                    appTaskRet.AppTaskID = 0;
                    IHttpActionResult jsonRet3 = appTaskController.Put(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<AppTask> appTaskRet3 = jsonRet3 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNull(appTaskRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void AppTask_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskController appTaskController = new AppTaskController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskController.DatabaseType);

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
                    IHttpActionResult jsonRet = appTaskController.GetAppTaskWithID(appTaskLast.AppTaskID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTask> Ret = jsonRet as OkNegotiatedContentResult<AppTask>;
                    AppTask appTaskRet = Ret.Content;
                    Assert.AreEqual(appTaskLast.AppTaskID, appTaskRet.AppTaskID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added AppTask
                    appTaskRet.AppTaskID = 0;
                    appTaskController.Request = new System.Net.Http.HttpRequestMessage();
                    appTaskController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appTask");
                    IHttpActionResult jsonRet3 = appTaskController.Post(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppTask> appTaskRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppTask>;
                    Assert.IsNotNull(appTaskRet3);
                    AppTask appTask = appTaskRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = appTaskController.Delete(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTask> appTaskRet2 = jsonRet2 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNotNull(appTaskRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because AppTaskID of 0 does not exist
                    appTaskRet.AppTaskID = 0;
                    IHttpActionResult jsonRet4 = appTaskController.Delete(appTaskRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<AppTask> appTaskRet4 = jsonRet4 as OkNegotiatedContentResult<AppTask>;
                    Assert.IsNull(appTaskRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
