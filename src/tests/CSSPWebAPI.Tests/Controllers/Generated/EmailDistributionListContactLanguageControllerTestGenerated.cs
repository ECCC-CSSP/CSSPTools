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
    public partial class EmailDistributionListContactLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void EmailDistributionListContactLanguage_Controller_GetEmailDistributionListContactLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactLanguageController emailDistributionListContactLanguageController = new EmailDistributionListContactLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactLanguageController.DatabaseType);

                    EmailDistributionListContactLanguage emailDistributionListContactLanguageFirst = new EmailDistributionListContactLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(query, db, ContactID);
                        emailDistributionListContactLanguageFirst = (from c in db.EmailDistributionListContactLanguages select c).FirstOrDefault();
                        count = (from c in db.EmailDistributionListContactLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with EmailDistributionListContactLanguage info
                    IActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(emailDistributionListContactLanguageFirst.EmailDistributionListContactLanguageID, ((List<EmailDistributionListContactLanguage>)ret.Value)[0].EmailDistributionListContactLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListContactLanguage>)ret.Value).Count);

                    List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(query, db, ContactID);
                        emailDistributionListContactLanguageList = (from c in db.EmailDistributionListContactLanguages select c).OrderBy(c => c.EmailDistributionListContactLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.EmailDistributionListContactLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with EmailDistributionListContactLanguage info
                        jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID, ((List<EmailDistributionListContactLanguage>)ret.Value)[0].EmailDistributionListContactLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListContactLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionListContactLanguage info
                           IActionResult jsonRet2 = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(emailDistributionListContactLanguageList[1].EmailDistributionListContactLanguageID, ((List<EmailDistributionListContactLanguage>)ret2.Value)[0].EmailDistributionListContactLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListContactLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void EmailDistributionListContactLanguage_Controller_GetEmailDistributionListContactLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactLanguageController emailDistributionListContactLanguageController = new EmailDistributionListContactLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactLanguageController.DatabaseType);

                    EmailDistributionListContactLanguage emailDistributionListContactLanguageFirst = new EmailDistributionListContactLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query(), db, ContactID);
                        emailDistributionListContactLanguageFirst = (from c in db.EmailDistributionListContactLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContactLanguage info
                    IActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageFirst.EmailDistributionListContactLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(emailDistributionListContactLanguageFirst.EmailDistributionListContactLanguageID, ((EmailDistributionListContactLanguage)ret.Value).EmailDistributionListContactLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult emailDistributionListContactLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(emailDistributionListContactLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void EmailDistributionListContactLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactLanguageController emailDistributionListContactLanguageController = new EmailDistributionListContactLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactLanguageController.DatabaseType);

                    EmailDistributionListContactLanguage emailDistributionListContactLanguageLast = new EmailDistributionListContactLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(query, db, ContactID);
                        emailDistributionListContactLanguageLast = (from c in db.EmailDistributionListContactLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContactLanguage info
                    IActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = (EmailDistributionListContactLanguage)ret.Value;
                    Assert.Equal(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailDistributionListContactLanguageID exist
                    IActionResult jsonRet2 = emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionListContactLanguage
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
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
        public void EmailDistributionListContactLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactLanguageController emailDistributionListContactLanguageController = new EmailDistributionListContactLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactLanguageController.DatabaseType);

                    EmailDistributionListContactLanguage emailDistributionListContactLanguageLast = new EmailDistributionListContactLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(query, db, ContactID);
                        emailDistributionListContactLanguageLast = (from c in db.EmailDistributionListContactLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContactLanguage info
                    IActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = (EmailDistributionListContactLanguage)Ret.Value;
                    Assert.Equal(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailDistributionListContactLanguageController.Put(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult emailDistributionListContactLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(emailDistributionListContactLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailDistributionListContactLanguageID of 0 does not exist
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactLanguageController.Put(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult emailDistributionListContactLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(emailDistributionListContactLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void EmailDistributionListContactLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactLanguageController emailDistributionListContactLanguageController = new EmailDistributionListContactLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactLanguageController.DatabaseType);

                    EmailDistributionListContactLanguage emailDistributionListContactLanguageLast = new EmailDistributionListContactLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(query, db, ContactID);
                        emailDistributionListContactLanguageLast = (from c in db.EmailDistributionListContactLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContactLanguage info
                    IActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = (EmailDistributionListContactLanguage)Ret.Value;
                    Assert.Equal(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added EmailDistributionListContactLanguage
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = (EmailDistributionListContactLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListContactLanguageID of 0 does not exist
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    IActionResult jsonRet4 = emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
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
