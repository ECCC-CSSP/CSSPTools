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
    public partial class ContactShortcutControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactShortcutControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ContactShortcut_Controller_GetContactShortcutList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactShortcutController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutFirst = new ContactShortcut();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(query, db, ContactID);
                        contactShortcutFirst = (from c in db.ContactShortcuts select c).FirstOrDefault();
                        count = (from c in db.ContactShortcuts select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ContactShortcut info
                    IActionResult jsonRet = contactShortcutController.GetContactShortcutList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<ContactShortcut>> ret = jsonRet as OkNegotiatedContentResult<List<ContactShortcut>>;
                    Assert.Equal(contactShortcutFirst.ContactShortcutID, ret.Content[0].ContactShortcutID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(query, db, ContactID);
                        contactShortcutList = (from c in db.ContactShortcuts select c).OrderBy(c => c.ContactShortcutID).Skip(0).Take(2).ToList();
                        count = (from c in db.ContactShortcuts select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ContactShortcut info
                        jsonRet = contactShortcutController.GetContactShortcutList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ContactShortcut>>;
                        Assert.Equal(contactShortcutList[0].ContactShortcutID, ret.Content[0].ContactShortcutID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ContactShortcut info
                           IActionResult jsonRet2 = contactShortcutController.GetContactShortcutList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ContactShortcut>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ContactShortcut>>;
                           Assert.Equal(contactShortcutList[1].ContactShortcutID, ret2.Content[0].ContactShortcutID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ContactShortcut_Controller_GetContactShortcutWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactShortcutController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutFirst = new ContactShortcut();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query(), db, ContactID);
                        contactShortcutFirst = (from c in db.ContactShortcuts select c).FirstOrDefault();
                    }

                    // ok with ContactShortcut info
                    IActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutFirst.ContactShortcutID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.Equal(contactShortcutFirst.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = contactShortcutController.GetContactShortcutWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.Null(contactShortcutRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ContactShortcut_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactShortcutController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutLast = new ContactShortcut();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactShortcutService contactShortcutService = new ContactShortcutService(query, db, ContactID);
                        contactShortcutLast = (from c in db.ContactShortcuts select c).FirstOrDefault();
                    }

                    // ok with ContactShortcut info
                    IActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutLast.ContactShortcutID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.Equal(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ContactShortcutID exist
                    IActionResult jsonRet2 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.Null(contactShortcutRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ContactShortcut
                    contactShortcutRet.ContactShortcutID = 0;
                    contactShortcutController.Request = new System.Net.Http.HttpRequestMessage();
                    contactShortcutController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contactShortcut");
                    IActionResult jsonRet3 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ContactShortcut> contactShortcutRet3 = jsonRet3 as CreatedNegotiatedContentResult<ContactShortcut>;
                    Assert.NotNull(contactShortcutRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet4 = jsonRet4 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.NotNull(contactShortcutRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void ContactShortcut_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactShortcutController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutLast = new ContactShortcut();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ContactShortcutService contactShortcutService = new ContactShortcutService(query, db, ContactID);
                        contactShortcutLast = (from c in db.ContactShortcuts select c).FirstOrDefault();
                    }

                    // ok with ContactShortcut info
                    IActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutLast.ContactShortcutID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.Equal(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = contactShortcutController.Put(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.NotNull(contactShortcutRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ContactShortcutID of 0 does not exist
                    contactShortcutRet.ContactShortcutID = 0;
                    IActionResult jsonRet3 = contactShortcutController.Put(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet3 = jsonRet3 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.Null(contactShortcutRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ContactShortcut_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactShortcutController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutLast = new ContactShortcut();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactShortcutService contactShortcutService = new ContactShortcutService(query, db, ContactID);
                        contactShortcutLast = (from c in db.ContactShortcuts select c).FirstOrDefault();
                    }

                    // ok with ContactShortcut info
                    IActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutLast.ContactShortcutID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.Equal(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ContactShortcut
                    contactShortcutRet.ContactShortcutID = 0;
                    contactShortcutController.Request = new System.Net.Http.HttpRequestMessage();
                    contactShortcutController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contactShortcut");
                    IActionResult jsonRet3 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ContactShortcut> contactShortcutRet3 = jsonRet3 as CreatedNegotiatedContentResult<ContactShortcut>;
                    Assert.NotNull(contactShortcutRet3);
                    ContactShortcut contactShortcut = contactShortcutRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.NotNull(contactShortcutRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ContactShortcutID of 0 does not exist
                    contactShortcutRet.ContactShortcutID = 0;
                    IActionResult jsonRet4 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet4 = jsonRet4 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.Null(contactShortcutRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
