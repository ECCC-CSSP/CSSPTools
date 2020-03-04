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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(emailFirst.EmailID, ((List<Email>)ret.Value)[0].EmailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Email>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(emailList[0].EmailID, ((List<Email>)ret.Value)[0].EmailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Email>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Email info
                           IActionResult jsonRet2 = emailController.GetEmailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(emailList[1].EmailID, ((List<Email>)ret2.Value)[0].EmailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Email>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(emailFirst.EmailID, ((Email)ret.Value).EmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailController.GetEmailWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult emailRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(emailRet2);
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

                    Email emailFirst = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailFirst = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IActionResult jsonRet = emailController.GetEmailWithID(emailFirst.EmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Email emailRet = (Email)ret.Value;
                    Assert.Equal(emailFirst.EmailID, emailRet.EmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailID exist
                    IActionResult jsonRet2 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Email
                    emailRet.EmailID = 0;
                    IActionResult jsonRet3 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailController.Delete(emailRet, LanguageRequest.ToString());
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
        public void Email_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailFirst = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IActionResult jsonRet = emailController.GetEmailWithID(emailFirst.EmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Email emailRet = (Email)Ret.Value;
                    Assert.Equal(emailFirst.EmailID, emailRet.EmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailController.Put(emailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult emailRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(emailRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailID of 0 does not exist
                    emailRet.EmailID = 0;
                    IActionResult jsonRet3 = emailController.Put(emailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult emailRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(emailRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    Email emailFirst = new Email();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailService emailService = new EmailService(query, db, ContactID);
                        emailFirst = (from c in db.Emails select c).FirstOrDefault();
                    }

                    // ok with Email info
                    IActionResult jsonRet = emailController.GetEmailWithID(emailFirst.EmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Email emailRet = (Email)Ret.Value;
                    Assert.Equal(emailFirst.EmailID, emailRet.EmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Email
                    emailRet.EmailID = 0;
                    IActionResult jsonRet3 = emailController.Post(emailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Email email = (Email)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailController.Delete(emailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailID of 0 does not exist
                    emailRet.EmailID = 0;
                    IActionResult jsonRet4 = emailController.Delete(emailRet, LanguageRequest.ToString());
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
