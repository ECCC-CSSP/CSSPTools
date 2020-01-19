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
                    IHttpActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<EmailDistributionListContactLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionListContactLanguage>>;
                    Assert.Equal(emailDistributionListContactLanguageFirst.EmailDistributionListContactLanguageID, ret.Content[0].EmailDistributionListContactLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<EmailDistributionListContactLanguage>>;
                        Assert.Equal(emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID, ret.Content[0].EmailDistributionListContactLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with EmailDistributionListContactLanguage info
                           IHttpActionResult jsonRet2 = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<EmailDistributionListContactLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<EmailDistributionListContactLanguage>>;
                           Assert.Equal(emailDistributionListContactLanguageList[1].EmailDistributionListContactLanguageID, ret2.Content[0].EmailDistributionListContactLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    IHttpActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageFirst.EmailDistributionListContactLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLanguageFirst.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.IsNull(emailDistributionListContactLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
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
                    IHttpActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because EmailDistributionListContactLanguageID exist
                    IHttpActionResult jsonRet2 = emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.IsNull(emailDistributionListContactLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added EmailDistributionListContactLanguage
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    emailDistributionListContactLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListContactLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionListContactLanguage");
                    IHttpActionResult jsonRet3 = emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.NotNull(emailDistributionListContactLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.NotNull(emailDistributionListContactLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
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
                    IHttpActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = emailDistributionListContactLanguageController.Put(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.NotNull(emailDistributionListContactLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because EmailDistributionListContactLanguageID of 0 does not exist
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    IHttpActionResult jsonRet3 = emailDistributionListContactLanguageController.Put(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.IsNull(emailDistributionListContactLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    IHttpActionResult jsonRet = emailDistributionListContactLanguageController.GetEmailDistributionListContactLanguageWithID(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> Ret = jsonRet as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = Ret.Content;
                    Assert.Equal(emailDistributionListContactLanguageLast.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added EmailDistributionListContactLanguage
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    emailDistributionListContactLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    emailDistributionListContactLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/emailDistributionListContactLanguage");
                    IHttpActionResult jsonRet3 = emailDistributionListContactLanguageController.Post(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.NotNull(emailDistributionListContactLanguageRet3);
                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = emailDistributionListContactLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.NotNull(emailDistributionListContactLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because EmailDistributionListContactLanguageID of 0 does not exist
                    emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID = 0;
                    IHttpActionResult jsonRet4 = emailDistributionListContactLanguageController.Delete(emailDistributionListContactLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<EmailDistributionListContactLanguage> emailDistributionListContactLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<EmailDistributionListContactLanguage>;
                    Assert.IsNull(emailDistributionListContactLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
