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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<EmailDistributionListContact>> ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionListContact>>;
                    Assert.Equal(emailDistributionListContactFirst.EmailDistributionListContactID, ret.Content[0].EmailDistributionListContactID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionListContact>>;
                        Assert.Equal(emailDistributionListContactList[0].EmailDistributionListContactID, ret.Content[0].EmailDistributionListContactID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionListContact info
                           IActionResult jsonRet2 = emailDistributionListContactController.GetEmailDistributionListContactList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<EmailDistributionListContact>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<EmailDistributionListContact>>;
                           Assert.Equal(emailDistributionListContactList[1].EmailDistributionListContactID, ret2.Content[0].EmailDistributionListContactID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContact> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContact>;
                    EmailDistributionListContact emailDistributionListContactRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactFirst.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = emailDistributionListContactController.GetEmailDistributionListContactWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.Null(emailDistributionListContactRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContact> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContact>;
                    EmailDistributionListContact emailDistributionListContactRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLast.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because EmailDistributionListContactID exist
                    IActionResult jsonRet2 = emailDistributionListContactController.Post(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.Null(emailDistributionListContactRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionListContact
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    emailDistributionListContactController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListContactController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionListContact");
                    IActionResult jsonRet3 = emailDistributionListContactController.Post(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.NotNull(emailDistributionListContactRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = emailDistributionListContactController.Delete(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.NotNull(emailDistributionListContactRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContact> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContact>;
                    EmailDistributionListContact emailDistributionListContactRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLast.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = emailDistributionListContactController.Put(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.NotNull(emailDistributionListContactRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because EmailDistributionListContactID of 0 does not exist
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    IActionResult jsonRet3 = emailDistributionListContactController.Put(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet3 = jsonRet3 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.Null(emailDistributionListContactRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContact> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContact>;
                    EmailDistributionListContact emailDistributionListContactRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLast.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added EmailDistributionListContact
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    emailDistributionListContactController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListContactController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionListContact");
                    IActionResult jsonRet3 = emailDistributionListContactController.Post(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.NotNull(emailDistributionListContactRet3);
                    EmailDistributionListContact emailDistributionListContact = emailDistributionListContactRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = emailDistributionListContactController.Delete(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.NotNull(emailDistributionListContactRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListContactID of 0 does not exist
                    emailDistributionListContactRet.EmailDistributionListContactID = 0;
                    IActionResult jsonRet4 = emailDistributionListContactController.Delete(emailDistributionListContactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionListContact> emailDistributionListContactRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionListContact>;
                    Assert.Null(emailDistributionListContactRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
