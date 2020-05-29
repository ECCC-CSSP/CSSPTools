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
    public partial class EmailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void Email_Controller_GetEmailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailFirst = new Email();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailFirst = (from c in db.Emails select c).FirstOrDefault();
                        count = (from c in db.Emails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Email info
                    IHttpActionResult jsonRet = emailController.GetEmailList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<Email>> ret = jsonRet as OkNegotiatedContentResult<List<Email>>;
                    Assert.AreEqual(emailFirst.EmailID, ret.Content[0].EmailID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Email> emailList = new List<Email>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailList = (from c in db.Emails select c).OrderBy(c => c.EmailID).Skip(0).Take(2).ToList();
                        count = (from c in db.Emails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Email info
                        jsonRet = emailController.GetEmailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Email>>;
                        Assert.AreEqual(emailList[0].EmailID, ret.Content[0].EmailID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Email info
                           IHttpActionResult jsonRet2 = emailController.GetEmailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Email>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Email>>;
                           Assert.AreEqual(emailList[1].EmailID, ret2.Content[0].EmailID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void Email_Controller_GetEmailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailFirst = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailService emailService = new EmailService(new Query(), db, ContactID);
                        emailFirst = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IHttpActionResult jsonRet = emailController.GetEmailWithID(emailFirst.EmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.AreEqual(emailFirst.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = emailController.GetEmailWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.IsNull(emailRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void Email_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailLast = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailLast = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IHttpActionResult jsonRet = emailController.GetEmailWithID(emailLast.EmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.AreEqual(emailLast.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because EmailID exist
                    IHttpActionResult jsonRet2 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.IsNull(emailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added Email
                    emailRet.EmailID = 0;
                    emailController.Request = new System.Net.Http.HttpRequestMessage();
                    emailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/email");
                    IHttpActionResult jsonRet3 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Email> emailRet3 = jsonRet3 as CreatedNegotiatedContentResult<Email>;
                    Assert.IsNotNull(emailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Email> emailRet4 = jsonRet4 as OkNegotiatedContentResult<Email>;
                    Assert.IsNotNull(emailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void Email_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailLast = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailLast = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IHttpActionResult jsonRet = emailController.GetEmailWithID(emailLast.EmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.AreEqual(emailLast.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = emailController.Put(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.IsNotNull(emailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because EmailID of 0 does not exist
                    emailRet.EmailID = 0;
                    IHttpActionResult jsonRet3 = emailController.Put(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<Email> emailRet3 = jsonRet3 as OkNegotiatedContentResult<Email>;
                    Assert.IsNull(emailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void Email_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(emailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailLast = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailLast = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IHttpActionResult jsonRet = emailController.GetEmailWithID(emailLast.EmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.AreEqual(emailLast.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Email
                    emailRet.EmailID = 0;
                    emailController.Request = new System.Net.Http.HttpRequestMessage();
                    emailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/email");
                    IHttpActionResult jsonRet3 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Email> emailRet3 = jsonRet3 as CreatedNegotiatedContentResult<Email>;
                    Assert.IsNotNull(emailRet3);
                    Email email = emailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.IsNotNull(emailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because EmailID of 0 does not exist
                    emailRet.EmailID = 0;
                    IHttpActionResult jsonRet4 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Email> emailRet4 = jsonRet4 as OkNegotiatedContentResult<Email>;
                    Assert.IsNull(emailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
