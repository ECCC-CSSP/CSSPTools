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
    public partial class InfrastructureLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void InfrastructureLanguage_Controller_GetInfrastructureLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(infrastructureLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageFirst = new InfrastructureLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageFirst = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                        count = (from c in db.InfrastructureLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with InfrastructureLanguage info
                    IHttpActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<InfrastructureLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<InfrastructureLanguage>>;
                    Assert.AreEqual(infrastructureLanguageFirst.InfrastructureLanguageID, ret.Content[0].InfrastructureLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageList = (from c in db.InfrastructureLanguages select c).OrderBy(c => c.InfrastructureLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.InfrastructureLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with InfrastructureLanguage info
                        jsonRet = infrastructureLanguageController.GetInfrastructureLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<InfrastructureLanguage>>;
                        Assert.AreEqual(infrastructureLanguageList[0].InfrastructureLanguageID, ret.Content[0].InfrastructureLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with InfrastructureLanguage info
                           IHttpActionResult jsonRet2 = infrastructureLanguageController.GetInfrastructureLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<InfrastructureLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<InfrastructureLanguage>>;
                           Assert.AreEqual(infrastructureLanguageList[1].InfrastructureLanguageID, ret2.Content[0].InfrastructureLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void InfrastructureLanguage_Controller_GetInfrastructureLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(infrastructureLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageFirst = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query(), db, ContactID);
                        infrastructureLanguageFirst = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IHttpActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageFirst.InfrastructureLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.AreEqual(infrastructureLanguageFirst.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = infrastructureLanguageController.GetInfrastructureLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNull(infrastructureLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void InfrastructureLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(infrastructureLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IHttpActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.AreEqual(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because InfrastructureLanguageID exist
                    IHttpActionResult jsonRet2 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNull(infrastructureLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added InfrastructureLanguage
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    infrastructureLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    infrastructureLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/infrastructureLanguage");
                    IHttpActionResult jsonRet3 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNotNull(infrastructureLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNotNull(infrastructureLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void InfrastructureLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(infrastructureLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IHttpActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.AreEqual(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = infrastructureLanguageController.Put(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNotNull(infrastructureLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because InfrastructureLanguageID of 0 does not exist
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IHttpActionResult jsonRet3 = infrastructureLanguageController.Put(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNull(infrastructureLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void InfrastructureLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(infrastructureLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IHttpActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.AreEqual(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added InfrastructureLanguage
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    infrastructureLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    infrastructureLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/infrastructureLanguage");
                    IHttpActionResult jsonRet3 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNotNull(infrastructureLanguageRet3);
                    InfrastructureLanguage infrastructureLanguage = infrastructureLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNotNull(infrastructureLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because InfrastructureLanguageID of 0 does not exist
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IHttpActionResult jsonRet4 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.IsNull(infrastructureLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
