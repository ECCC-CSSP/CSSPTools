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
    public partial class PolSourceGroupingLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void PolSourceGroupingLanguage_Controller_GetPolSourceGroupingLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingLanguageController polSourceGroupingLanguageController = new PolSourceGroupingLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingLanguageController.DatabaseType);

                    PolSourceGroupingLanguage polSourceGroupingLanguageFirst = new PolSourceGroupingLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(query, db, ContactID);
                        polSourceGroupingLanguageFirst = (from c in db.PolSourceGroupingLanguages select c).FirstOrDefault();
                        count = (from c in db.PolSourceGroupingLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceGroupingLanguage info
                    IHttpActionResult jsonRet = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceGroupingLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceGroupingLanguage>>;
                    Assert.AreEqual(polSourceGroupingLanguageFirst.PolSourceGroupingLanguageID, ret.Content[0].PolSourceGroupingLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = new List<PolSourceGroupingLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(query, db, ContactID);
                        polSourceGroupingLanguageList = (from c in db.PolSourceGroupingLanguages select c).OrderBy(c => c.PolSourceGroupingLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceGroupingLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceGroupingLanguage info
                        jsonRet = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceGroupingLanguage>>;
                        Assert.AreEqual(polSourceGroupingLanguageList[0].PolSourceGroupingLanguageID, ret.Content[0].PolSourceGroupingLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceGroupingLanguage info
                           IHttpActionResult jsonRet2 = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceGroupingLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceGroupingLanguage>>;
                           Assert.AreEqual(polSourceGroupingLanguageList[1].PolSourceGroupingLanguageID, ret2.Content[0].PolSourceGroupingLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void PolSourceGroupingLanguage_Controller_GetPolSourceGroupingLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingLanguageController polSourceGroupingLanguageController = new PolSourceGroupingLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingLanguageController.DatabaseType);

                    PolSourceGroupingLanguage polSourceGroupingLanguageFirst = new PolSourceGroupingLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(new Query(), db, ContactID);
                        polSourceGroupingLanguageFirst = (from c in db.PolSourceGroupingLanguages select c).FirstOrDefault();
                    }

                    // ok with PolSourceGroupingLanguage info
                    IHttpActionResult jsonRet = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageWithID(polSourceGroupingLanguageFirst.PolSourceGroupingLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    PolSourceGroupingLanguage polSourceGroupingLanguageRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLanguageFirst.PolSourceGroupingLanguageID, polSourceGroupingLanguageRet.PolSourceGroupingLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNull(polSourceGroupingLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void PolSourceGroupingLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingLanguageController polSourceGroupingLanguageController = new PolSourceGroupingLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingLanguageController.DatabaseType);

                    PolSourceGroupingLanguage polSourceGroupingLanguageLast = new PolSourceGroupingLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(query, db, ContactID);
                        polSourceGroupingLanguageLast = (from c in db.PolSourceGroupingLanguages select c).FirstOrDefault();
                    }

                    // ok with PolSourceGroupingLanguage info
                    IHttpActionResult jsonRet = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageWithID(polSourceGroupingLanguageLast.PolSourceGroupingLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    PolSourceGroupingLanguage polSourceGroupingLanguageRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLanguageLast.PolSourceGroupingLanguageID, polSourceGroupingLanguageRet.PolSourceGroupingLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceGroupingLanguageID exist
                    IHttpActionResult jsonRet2 = polSourceGroupingLanguageController.Post(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNull(polSourceGroupingLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added PolSourceGroupingLanguage
                    polSourceGroupingLanguageRet.PolSourceGroupingLanguageID = 0;
                    polSourceGroupingLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceGroupingLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceGroupingLanguage");
                    IHttpActionResult jsonRet3 = polSourceGroupingLanguageController.Post(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNotNull(polSourceGroupingLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceGroupingLanguageController.Delete(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNotNull(polSourceGroupingLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void PolSourceGroupingLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingLanguageController polSourceGroupingLanguageController = new PolSourceGroupingLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingLanguageController.DatabaseType);

                    PolSourceGroupingLanguage polSourceGroupingLanguageLast = new PolSourceGroupingLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(query, db, ContactID);
                        polSourceGroupingLanguageLast = (from c in db.PolSourceGroupingLanguages select c).FirstOrDefault();
                    }

                    // ok with PolSourceGroupingLanguage info
                    IHttpActionResult jsonRet = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageWithID(polSourceGroupingLanguageLast.PolSourceGroupingLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    PolSourceGroupingLanguage polSourceGroupingLanguageRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLanguageLast.PolSourceGroupingLanguageID, polSourceGroupingLanguageRet.PolSourceGroupingLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceGroupingLanguageController.Put(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNotNull(polSourceGroupingLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceGroupingLanguageID of 0 does not exist
                    polSourceGroupingLanguageRet.PolSourceGroupingLanguageID = 0;
                    IHttpActionResult jsonRet3 = polSourceGroupingLanguageController.Put(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNull(polSourceGroupingLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void PolSourceGroupingLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingLanguageController polSourceGroupingLanguageController = new PolSourceGroupingLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingLanguageController.DatabaseType);

                    PolSourceGroupingLanguage polSourceGroupingLanguageLast = new PolSourceGroupingLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceGroupingLanguageService polSourceGroupingLanguageService = new PolSourceGroupingLanguageService(query, db, ContactID);
                        polSourceGroupingLanguageLast = (from c in db.PolSourceGroupingLanguages select c).FirstOrDefault();
                    }

                    // ok with PolSourceGroupingLanguage info
                    IHttpActionResult jsonRet = polSourceGroupingLanguageController.GetPolSourceGroupingLanguageWithID(polSourceGroupingLanguageLast.PolSourceGroupingLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    PolSourceGroupingLanguage polSourceGroupingLanguageRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLanguageLast.PolSourceGroupingLanguageID, polSourceGroupingLanguageRet.PolSourceGroupingLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceGroupingLanguage
                    polSourceGroupingLanguageRet.PolSourceGroupingLanguageID = 0;
                    polSourceGroupingLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceGroupingLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceGroupingLanguage");
                    IHttpActionResult jsonRet3 = polSourceGroupingLanguageController.Post(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNotNull(polSourceGroupingLanguageRet3);
                    PolSourceGroupingLanguage polSourceGroupingLanguage = polSourceGroupingLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceGroupingLanguageController.Delete(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNotNull(polSourceGroupingLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceGroupingLanguageID of 0 does not exist
                    polSourceGroupingLanguageRet.PolSourceGroupingLanguageID = 0;
                    IHttpActionResult jsonRet4 = polSourceGroupingLanguageController.Delete(polSourceGroupingLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceGroupingLanguage> polSourceGroupingLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceGroupingLanguage>;
                    Assert.IsNull(polSourceGroupingLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
