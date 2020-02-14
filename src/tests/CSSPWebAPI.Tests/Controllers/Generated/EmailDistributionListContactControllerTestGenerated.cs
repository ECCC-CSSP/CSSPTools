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
    public partial class EmailDistributionListContactControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void EmailDistributionListContact_Controller_GetEmailDistributionListContactList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactController emailDistributionListContactController = new EmailDistributionListContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactController.DatabaseType);

                    EmailDistributionListContact emailDistributionListContactFirst = new EmailDistributionListContact();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(query, db, ContactID);
                        emailDistributionListContactFirst = (from c in db.EmailDistributionListContacts select c).FirstOrDefault();
                        count = (from c in db.EmailDistributionListContacts select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with EmailDistributionListContact info
                    IActionResult jsonRet = emailDistributionListContactController.GetEmailDistributionListContactList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(emailDistributionListContactFirst.EmailDistributionListContactID, ((List<EmailDistributionListContact>)ret.Value)[0].EmailDistributionListContactID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListContact>)ret.Value).Count);

                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(query, db, ContactID);
                        emailDistributionListContactList = (from c in db.EmailDistributionListContacts select c).OrderBy(c => c.EmailDistributionListContactID).Skip(0).Take(2).ToList();
                        count = (from c in db.EmailDistributionListContacts select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with EmailDistributionListContact info
                        jsonRet = emailDistributionListContactController.GetEmailDistributionListContactList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(emailDistributionListContactList[0].EmailDistributionListContactID, ((List<EmailDistributionListContact>)ret.Value)[0].EmailDistributionListContactID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListContact>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionListContact info
                           IActionResult jsonRet2 = emailDistributionListContactController.GetEmailDistributionListContactList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(emailDistributionListContactList[1].EmailDistributionListContactID, ((List<EmailDistributionListContact>)ret2.Value)[0].EmailDistributionListContactID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionListContact>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void EmailDistributionListContact_Controller_GetEmailDistributionListContactWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactController emailDistributionListContactController = new EmailDistributionListContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactController.DatabaseType);

                    EmailDistributionListContact emailDistributionListContactFirst = new EmailDistributionListContact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query(), db, ContactID);
                        emailDistributionListContactFirst = (from c in db.EmailDistributionListContacts select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContact info
                    IActionResult jsonRet = emailDistributionListContactController.GetEmailDistributionListContactWithID(emailDistributionListContactFirst.EmailDistributionListContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(emailDistributionListContactFirst.EmailDistributionListContactID, ((EmailDistributionListContact)ret.Value).EmailDistributionListContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailDistributionListContactController.GetEmailDistributionListContactWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult emailDistributionListContactRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(emailDistributionListContactRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void EmailDistributionListContact_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactController emailDistributionListContactController = new EmailDistributionListContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactController.DatabaseType);

                    EmailDistributionListContact emailDistributionListContactLast = new EmailDistributionListContact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(query, db, ContactID);
                        emailDistributionListContactLast = (from c in db.EmailDistributionListContacts select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContact info
                    IActionResult jsonRet = emailDistributionListContactController.GetEmailDistributionListContactWithID(emailDistributionListContactLast.EmailDistributionListContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    EmailDistributionListContact emailDistributionListContactRet = (EmailDistributionListContact)ret.Value;
                    Assert.Equal(emailDistributionListContactLast.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailDistributionListContactID exist
                    IActionResult jsonRet2 = emailDistributionListContactController.Post(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionListContact
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactController.Post(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailDistributionListContactController.Delete(emailDistributionListContactRet, LanguageRequest.ToString());
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
        public void EmailDistributionListContact_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactController emailDistributionListContactController = new EmailDistributionListContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactController.DatabaseType);

                    EmailDistributionListContact emailDistributionListContactLast = new EmailDistributionListContact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(query, db, ContactID);
                        emailDistributionListContactLast = (from c in db.EmailDistributionListContacts select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContact info
                    IActionResult jsonRet = emailDistributionListContactController.GetEmailDistributionListContactWithID(emailDistributionListContactLast.EmailDistributionListContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionListContact emailDistributionListContactRet = (EmailDistributionListContact)Ret.Value;
                    Assert.Equal(emailDistributionListContactLast.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailDistributionListContactController.Put(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult emailDistributionListContactRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(emailDistributionListContactRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailDistributionListContactID of 0 does not exist
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactController.Put(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult emailDistributionListContactRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(emailDistributionListContactRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void EmailDistributionListContact_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListContactController emailDistributionListContactController = new EmailDistributionListContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListContactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListContactController.DatabaseType);

                    EmailDistributionListContact emailDistributionListContactLast = new EmailDistributionListContact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(query, db, ContactID);
                        emailDistributionListContactLast = (from c in db.EmailDistributionListContacts select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionListContact info
                    IActionResult jsonRet = emailDistributionListContactController.GetEmailDistributionListContactWithID(emailDistributionListContactLast.EmailDistributionListContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionListContact emailDistributionListContactRet = (EmailDistributionListContact)Ret.Value;
                    Assert.Equal(emailDistributionListContactLast.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added EmailDistributionListContact
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactController.Post(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    EmailDistributionListContact emailDistributionListContact = (EmailDistributionListContact)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailDistributionListContactController.Delete(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListContactID of 0 does not exist
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    IActionResult jsonRet4 = emailDistributionListContactController.Delete(emailDistributionListContactRet, LanguageRequest.ToString());
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
