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
    public partial class EmailDistributionListLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void EmailDistributionListLanguage_Controller_GetEmailDistributionListLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailDistributionListLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageFirst = new EmailDistributionListLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(query, db, ContactID);
                        emailDistributionListLanguageFirst = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                        count = (from c in db.EmailDistributionListLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with EmailDistributionListLanguage info
                    IHttpActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<EmailDistributionListLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionListLanguage>>;
                    Assert.AreEqual(emailDistributionListLanguageFirst.EmailDistributionListLanguageID, ret.Content[0].EmailDistributionListLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(query, db, ContactID);
                        emailDistributionListLanguageList = (from c in db.EmailDistributionListLanguages select c).OrderBy(c => c.EmailDistributionListLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.EmailDistributionListLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with EmailDistributionListLanguage info
                        jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionListLanguage>>;
                        Assert.AreEqual(emailDistributionListLanguageList[0].EmailDistributionListLanguageID, ret.Content[0].EmailDistributionListLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionListLanguage info
                           IHttpActionResult jsonRet2 = emailDistributionListLanguageController.GetEmailDistributionListLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<EmailDistributionListLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<EmailDistributionListLanguage>>;
                           Assert.AreEqual(emailDistributionListLanguageList[1].EmailDistributionListLanguageID, ret2.Content[0].EmailDistributionListLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void EmailDistributionListLanguage_Controller_GetEmailDistributionListLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailDistributionListLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageFirst = new EmailDistributionListLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query(), db, ContactID);
                        emailDistributionListLanguageFirst = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListLanguage info
                    IHttpActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageFirst.EmailDistributionListLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = Ret.Content;
                    Assert.AreEqual(emailDistributionListLanguageFirst.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNull(emailDistributionListLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void EmailDistributionListLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailDistributionListLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageLast = new EmailDistributionListLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(query, db, ContactID);
                        emailDistributionListLanguageLast = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListLanguage info
                    IHttpActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageLast.EmailDistributionListLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = Ret.Content;
                    Assert.AreEqual(emailDistributionListLanguageLast.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because EmailDistributionListLanguageID exist
                    IHttpActionResult jsonRet2 = emailDistributionListLanguageController.Post(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNull(emailDistributionListLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added EmailDistributionListLanguage
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    emailDistributionListLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionListLanguage");
                    IHttpActionResult jsonRet3 = emailDistributionListLanguageController.Post(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNotNull(emailDistributionListLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = emailDistributionListLanguageController.Delete(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNotNull(emailDistributionListLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void EmailDistributionListLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailDistributionListLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageLast = new EmailDistributionListLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(query, db, ContactID);
                        emailDistributionListLanguageLast = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListLanguage info
                    IHttpActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageLast.EmailDistributionListLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = Ret.Content;
                    Assert.AreEqual(emailDistributionListLanguageLast.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = emailDistributionListLanguageController.Put(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNotNull(emailDistributionListLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because EmailDistributionListLanguageID of 0 does not exist
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    IHttpActionResult jsonRet3 = emailDistributionListLanguageController.Put(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNull(emailDistributionListLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void EmailDistributionListLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailDistributionListLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageLast = new EmailDistributionListLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(query, db, ContactID);
                        emailDistributionListLanguageLast = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListLanguage info
                    IHttpActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageLast.EmailDistributionListLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = Ret.Content;
                    Assert.AreEqual(emailDistributionListLanguageLast.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added EmailDistributionListLanguage
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    emailDistributionListLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionListLanguage");
                    IHttpActionResult jsonRet3 = emailDistributionListLanguageController.Post(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNotNull(emailDistributionListLanguageRet3);
                    EmailDistributionListLanguage emailDistributionListLanguage = emailDistributionListLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = emailDistributionListLanguageController.Delete(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNotNull(emailDistributionListLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListLanguageID of 0 does not exist
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    IHttpActionResult jsonRet4 = emailDistributionListLanguageController.Delete(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionListLanguage> emailDistributionListLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionListLanguage>;
                    Assert.IsNull(emailDistributionListLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
