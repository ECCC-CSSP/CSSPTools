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
        [Fact]
        public void Email_Controller_GetEmailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

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
                    IActionResult jsonRet = emailController.GetEmailList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<Email>> ret = jsonRet as OkNegotiatedContentResult<List<Email>>;
                    Assert.Equal(emailFirst.EmailID, ret.Content[0].EmailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Email>>;
                        Assert.Equal(emailList[0].EmailID, ret.Content[0].EmailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Email info
                           IActionResult jsonRet2 = emailController.GetEmailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Email>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Email>>;
                           Assert.Equal(emailList[1].EmailID, ret2.Content[0].EmailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Email_Controller_GetEmailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailFirst = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailService emailService = new EmailService(new Query(), db, ContactID);
                        emailFirst = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IActionResult jsonRet = emailController.GetEmailWithID(emailFirst.EmailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.Equal(emailFirst.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailController.GetEmailWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.Null(emailRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Email_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

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
                    IActionResult jsonRet = emailController.GetEmailWithID(emailLast.EmailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.Equal(emailLast.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailID exist
                    IActionResult jsonRet2 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.Null(emailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Email
                    emailRet.EmailID = 0;
                    emailController.Request = new System.Net.Http.HttpRequestMessage();
                    emailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/email");
                    IActionResult jsonRet3 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Email> emailRet3 = jsonRet3 as CreatedNegotiatedContentResult<Email>;
                    Assert.NotNull(emailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Email> emailRet4 = jsonRet4 as OkNegotiatedContentResult<Email>;
                    Assert.NotNull(emailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void Email_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

                    Email emailLast = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailLast = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IActionResult jsonRet = emailController.GetEmailWithID(emailLast.EmailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.Equal(emailLast.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailController.Put(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.NotNull(emailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailID of 0 does not exist
                    emailRet.EmailID = 0;
                    IActionResult jsonRet3 = emailController.Put(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<Email> emailRet3 = jsonRet3 as OkNegotiatedContentResult<Email>;
                    Assert.Null(emailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Email_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailController emailController = new EmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailController.DatabaseType);

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
                    IActionResult jsonRet = emailController.GetEmailWithID(emailLast.EmailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Email> Ret = jsonRet as OkNegotiatedContentResult<Email>;
                    Email emailRet = Ret.Content;
                    Assert.Equal(emailLast.EmailID, emailRet.EmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Email
                    emailRet.EmailID = 0;
                    emailController.Request = new System.Net.Http.HttpRequestMessage();
                    emailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/email");
                    IActionResult jsonRet3 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Email> emailRet3 = jsonRet3 as CreatedNegotiatedContentResult<Email>;
                    Assert.NotNull(emailRet3);
                    Email email = emailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Email> emailRet2 = jsonRet2 as OkNegotiatedContentResult<Email>;
                    Assert.NotNull(emailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailID of 0 does not exist
                    emailRet.EmailID = 0;
                    IActionResult jsonRet4 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Email> emailRet4 = jsonRet4 as OkNegotiatedContentResult<Email>;
                    Assert.Null(emailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
