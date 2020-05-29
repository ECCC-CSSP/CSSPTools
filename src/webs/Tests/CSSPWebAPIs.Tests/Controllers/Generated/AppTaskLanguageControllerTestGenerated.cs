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
    public partial class AppTaskLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void AppTaskLanguage_Controller_GetAppTaskLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                        count = (from c in db.AppTaskLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with AppTaskLanguage info
                    IHttpActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<AppTaskLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<AppTaskLanguage>>;
                    Assert.AreEqual(appTaskLanguageFirst.AppTaskLanguageID, ret.Content[0].AppTaskLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageList = (from c in db.AppTaskLanguages select c).OrderBy(c => c.AppTaskLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.AppTaskLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with AppTaskLanguage info
                        jsonRet = appTaskLanguageController.GetAppTaskLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<AppTaskLanguage>>;
                        Assert.AreEqual(appTaskLanguageList[0].AppTaskLanguageID, ret.Content[0].AppTaskLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppTaskLanguage info
                           IHttpActionResult jsonRet2 = appTaskLanguageController.GetAppTaskLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<AppTaskLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<AppTaskLanguage>>;
                           Assert.AreEqual(appTaskLanguageList[1].AppTaskLanguageID, ret2.Content[0].AppTaskLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void AppTaskLanguage_Controller_GetAppTaskLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query(), db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IHttpActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageFirst.AppTaskLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTaskLanguage> Ret = jsonRet as OkNegotiatedContentResult<AppTaskLanguage>;
                    AppTaskLanguage appTaskLanguageRet = Ret.Content;
                    Assert.AreEqual(appTaskLanguageFirst.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = appTaskLanguageController.GetAppTaskLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNull(appTaskLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void AppTaskLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageLast = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageLast = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IHttpActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageLast.AppTaskLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTaskLanguage> Ret = jsonRet as OkNegotiatedContentResult<AppTaskLanguage>;
                    AppTaskLanguage appTaskLanguageRet = Ret.Content;
                    Assert.AreEqual(appTaskLanguageLast.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because AppTaskLanguageID exist
                    IHttpActionResult jsonRet2 = appTaskLanguageController.Post(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNull(appTaskLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added AppTaskLanguage
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    appTaskLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    appTaskLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appTaskLanguage");
                    IHttpActionResult jsonRet3 = appTaskLanguageController.Post(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNotNull(appTaskLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = appTaskLanguageController.Delete(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNotNull(appTaskLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void AppTaskLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageLast = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageLast = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IHttpActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageLast.AppTaskLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTaskLanguage> Ret = jsonRet as OkNegotiatedContentResult<AppTaskLanguage>;
                    AppTaskLanguage appTaskLanguageRet = Ret.Content;
                    Assert.AreEqual(appTaskLanguageLast.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = appTaskLanguageController.Put(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNotNull(appTaskLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because AppTaskLanguageID of 0 does not exist
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    IHttpActionResult jsonRet3 = appTaskLanguageController.Put(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNull(appTaskLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void AppTaskLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(appTaskLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageLast = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageLast = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IHttpActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageLast.AppTaskLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<AppTaskLanguage> Ret = jsonRet as OkNegotiatedContentResult<AppTaskLanguage>;
                    AppTaskLanguage appTaskLanguageRet = Ret.Content;
                    Assert.AreEqual(appTaskLanguageLast.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added AppTaskLanguage
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    appTaskLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    appTaskLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/appTaskLanguage");
                    IHttpActionResult jsonRet3 = appTaskLanguageController.Post(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNotNull(appTaskLanguageRet3);
                    AppTaskLanguage appTaskLanguage = appTaskLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = appTaskLanguageController.Delete(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNotNull(appTaskLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because AppTaskLanguageID of 0 does not exist
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    IHttpActionResult jsonRet4 = appTaskLanguageController.Delete(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<AppTaskLanguage> appTaskLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<AppTaskLanguage>;
                    Assert.IsNull(appTaskLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
