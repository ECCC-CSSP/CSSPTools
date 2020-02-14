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
        [Fact]
        public void EmailDistributionListLanguage_Controller_GetEmailDistributionListLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

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
                    IActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(emailDistributionListLanguageFirst.EmailDistributionListLanguageID, ((List<EmailDistributionListLanguage>)ret.Value)[0].EmailDistributionListLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListLanguage>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(emailDistributionListLanguageList[0].EmailDistributionListLanguageID, ((List<EmailDistributionListLanguage>)ret.Value)[0].EmailDistributionListLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionListLanguage info
                           IActionResult jsonRet2 = emailDistributionListLanguageController.GetEmailDistributionListLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(emailDistributionListLanguageList[1].EmailDistributionListLanguageID, ((List<EmailDistributionListLanguage>)ret2.Value)[0].EmailDistributionListLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void EmailDistributionListLanguage_Controller_GetEmailDistributionListLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageFirst = new EmailDistributionListLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query(), db, ContactID);
                        emailDistributionListLanguageFirst = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListLanguage info
                    IActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageFirst.EmailDistributionListLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(emailDistributionListLanguageFirst.EmailDistributionListLanguageID, ((EmailDistributionListLanguage)ret.Value).EmailDistributionListLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult emailDistributionListLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(emailDistributionListLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void EmailDistributionListLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

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
                    IActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageLast.EmailDistributionListLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = (EmailDistributionListLanguage)ret.Value;
                    Assert.Equal(emailDistributionListLanguageLast.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailDistributionListLanguageID exist
                    IActionResult jsonRet2 = emailDistributionListLanguageController.Post(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionListLanguage
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    IActionResult jsonRet3 = emailDistributionListLanguageController.Post(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailDistributionListLanguageController.Delete(emailDistributionListLanguageRet, LanguageRequest.ToString());
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
        public void EmailDistributionListLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

                    EmailDistributionListLanguage emailDistributionListLanguageLast = new EmailDistributionListLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(query, db, ContactID);
                        emailDistributionListLanguageLast = (from c in db.EmailDistributionListLanguages select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListLanguage info
                    IActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageLast.EmailDistributionListLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = (EmailDistributionListLanguage)Ret.Value;
                    Assert.Equal(emailDistributionListLanguageLast.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailDistributionListLanguageController.Put(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult emailDistributionListLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(emailDistributionListLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailDistributionListLanguageID of 0 does not exist
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    IActionResult jsonRet3 = emailDistributionListLanguageController.Put(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult emailDistributionListLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(emailDistributionListLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void EmailDistributionListLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListLanguageController emailDistributionListLanguageController = new EmailDistributionListLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListLanguageController.DatabaseType);

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
                    IActionResult jsonRet = emailDistributionListLanguageController.GetEmailDistributionListLanguageWithID(emailDistributionListLanguageLast.EmailDistributionListLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionListLanguage emailDistributionListLanguageRet = (EmailDistributionListLanguage)Ret.Value;
                    Assert.Equal(emailDistributionListLanguageLast.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added EmailDistributionListLanguage
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    IActionResult jsonRet3 = emailDistributionListLanguageController.Post(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    EmailDistributionListLanguage emailDistributionListLanguage = (EmailDistributionListLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailDistributionListLanguageController.Delete(emailDistributionListLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListLanguageID of 0 does not exist
                    emailDistributionListLanguageRet.EmailDistributionListLanguageID = 0;
                    IActionResult jsonRet4 = emailDistributionListLanguageController.Delete(emailDistributionListLanguageRet, LanguageRequest.ToString());
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
