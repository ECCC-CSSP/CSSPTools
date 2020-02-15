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
    public partial class EmailDistributionListControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void EmailDistributionList_Controller_GetEmailDistributionListList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListController emailDistributionListController = new EmailDistributionListController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListController.DatabaseType);

                    EmailDistributionList emailDistributionListFirst = new EmailDistributionList();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListFirst = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                        count = (from c in db.EmailDistributionLists select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with EmailDistributionList info
                    IActionResult jsonRet = emailDistributionListController.GetEmailDistributionListList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, ((List<EmailDistributionList>)ret.Value)[0].EmailDistributionListID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionList>)ret.Value).Count);

                    List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListList = (from c in db.EmailDistributionLists select c).OrderBy(c => c.EmailDistributionListID).Skip(0).Take(2).ToList();
                        count = (from c in db.EmailDistributionLists select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with EmailDistributionList info
                        jsonRet = emailDistributionListController.GetEmailDistributionListList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(emailDistributionListList[0].EmailDistributionListID, ((List<EmailDistributionList>)ret.Value)[0].EmailDistributionListID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionList>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionList info
                           IActionResult jsonRet2 = emailDistributionListController.GetEmailDistributionListList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(emailDistributionListList[1].EmailDistributionListID, ((List<EmailDistributionList>)ret2.Value)[0].EmailDistributionListID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<EmailDistributionList>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void EmailDistributionList_Controller_GetEmailDistributionListWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListController emailDistributionListController = new EmailDistributionListController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListController.DatabaseType);

                    EmailDistributionList emailDistributionListFirst = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query(), db, ContactID);
                        emailDistributionListFirst = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListFirst.EmailDistributionListID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, ((EmailDistributionList)ret.Value).EmailDistributionListID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailDistributionListController.GetEmailDistributionListWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult emailDistributionListRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(emailDistributionListRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void EmailDistributionList_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListController emailDistributionListController = new EmailDistributionListController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListController.DatabaseType);

                    EmailDistributionList emailDistributionListFirst = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListFirst = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListFirst.EmailDistributionListID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    EmailDistributionList emailDistributionListRet = (EmailDistributionList)ret.Value;
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailDistributionListID exist
                    IActionResult jsonRet2 = emailDistributionListController.Post(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionList
                    emailDistributionListRet.EmailDistributionListID = 0;
                    IActionResult jsonRet3 = emailDistributionListController.Post(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailDistributionListController.Delete(emailDistributionListRet, LanguageRequest.ToString());
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
        public void EmailDistributionList_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListController emailDistributionListController = new EmailDistributionListController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListController.DatabaseType);

                    EmailDistributionList emailDistributionListFirst = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListFirst = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListFirst.EmailDistributionListID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionList emailDistributionListRet = (EmailDistributionList)Ret.Value;
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailDistributionListController.Put(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult emailDistributionListRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(emailDistributionListRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailDistributionListID of 0 does not exist
                    emailDistributionListRet.EmailDistributionListID = 0;
                    IActionResult jsonRet3 = emailDistributionListController.Put(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult emailDistributionListRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(emailDistributionListRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void EmailDistributionList_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    EmailDistributionListController emailDistributionListController = new EmailDistributionListController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(emailDistributionListController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, emailDistributionListController.DatabaseType);

                    EmailDistributionList emailDistributionListFirst = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListFirst = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListFirst.EmailDistributionListID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    EmailDistributionList emailDistributionListRet = (EmailDistributionList)Ret.Value;
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added EmailDistributionList
                    emailDistributionListRet.EmailDistributionListID = 0;
                    IActionResult jsonRet3 = emailDistributionListController.Post(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    EmailDistributionList emailDistributionList = (EmailDistributionList)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailDistributionListController.Delete(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListID of 0 does not exist
                    emailDistributionListRet.EmailDistributionListID = 0;
                    IActionResult jsonRet4 = emailDistributionListController.Delete(emailDistributionListRet, LanguageRequest.ToString());
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
