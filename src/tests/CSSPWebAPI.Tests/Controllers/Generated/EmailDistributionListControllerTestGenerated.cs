using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

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
                    IHttpActionResult jsonRet = emailDistributionListController.GetEmailDistributionListList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<EmailDistributionList>> ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionList>>;
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, ret.Content[0].EmailDistributionListID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionList>>;
                        Assert.Equal(emailDistributionListList[0].EmailDistributionListID, ret.Content[0].EmailDistributionListID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionList info
                           IHttpActionResult jsonRet2 = emailDistributionListController.GetEmailDistributionListList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<EmailDistributionList>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<EmailDistributionList>>;
                           Assert.Equal(emailDistributionListList[1].EmailDistributionListID, ret2.Content[0].EmailDistributionListID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    IHttpActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListFirst.EmailDistributionListID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionList> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionList>;
                    EmailDistributionList emailDistributionListRet = Ret.Content;
                    Assert.Equal(emailDistributionListFirst.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = emailDistributionListController.GetEmailDistributionListWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.IsNull(emailDistributionListRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
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

                    EmailDistributionList emailDistributionListLast = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListLast = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IHttpActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListLast.EmailDistributionListID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionList> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionList>;
                    EmailDistributionList emailDistributionListRet = Ret.Content;
                    Assert.Equal(emailDistributionListLast.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because EmailDistributionListID exist
                    IHttpActionResult jsonRet2 = emailDistributionListController.Post(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.IsNull(emailDistributionListRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionList
                    emailDistributionListRet.EmailDistributionListID = 0;
                    emailDistributionListController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionList");
                    IHttpActionResult jsonRet3 = emailDistributionListController.Post(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionList> emailDistributionListRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionList>;
                    Assert.NotNull(emailDistributionListRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = emailDistributionListController.Delete(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.NotNull(emailDistributionListRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
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

                    EmailDistributionList emailDistributionListLast = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListLast = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IHttpActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListLast.EmailDistributionListID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionList> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionList>;
                    EmailDistributionList emailDistributionListRet = Ret.Content;
                    Assert.Equal(emailDistributionListLast.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = emailDistributionListController.Put(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.NotNull(emailDistributionListRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because EmailDistributionListID of 0 does not exist
                    emailDistributionListRet.EmailDistributionListID = 0;
                    IHttpActionResult jsonRet3 = emailDistributionListController.Put(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet3 = jsonRet3 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.IsNull(emailDistributionListRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    EmailDistributionList emailDistributionListLast = new EmailDistributionList();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(query, db, ContactID);
                        emailDistributionListLast = (from c in db.EmailDistributionLists select c).FirstOrDefault();
                    }

                    // ok with EmailDistributionList info
                    IHttpActionResult jsonRet = emailDistributionListController.GetEmailDistributionListWithID(emailDistributionListLast.EmailDistributionListID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionList> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionList>;
                    EmailDistributionList emailDistributionListRet = Ret.Content;
                    Assert.Equal(emailDistributionListLast.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added EmailDistributionList
                    emailDistributionListRet.EmailDistributionListID = 0;
                    emailDistributionListController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionList");
                    IHttpActionResult jsonRet3 = emailDistributionListController.Post(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionList> emailDistributionListRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionList>;
                    Assert.NotNull(emailDistributionListRet3);
                    EmailDistributionList emailDistributionList = emailDistributionListRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = emailDistributionListController.Delete(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.NotNull(emailDistributionListRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListID of 0 does not exist
                    emailDistributionListRet.EmailDistributionListID = 0;
                    IHttpActionResult jsonRet4 = emailDistributionListController.Delete(emailDistributionListRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionList> emailDistributionListRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionList>;
                    Assert.IsNull(emailDistributionListRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
