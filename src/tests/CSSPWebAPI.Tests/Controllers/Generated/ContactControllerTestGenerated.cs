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
    public partial class ContactControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Contact_Controller_GetContactList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactController contactController = new ContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactController.DatabaseType);

                    Contact contactFirst = new Contact();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactFirst = (from c in db.Contacts select c).FirstOrDefault();
                        count = (from c in db.Contacts select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Contact info
                    IHttpActionResult jsonRet = contactController.GetContactList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<Contact>> ret = jsonRet as OkNegotiatedContentResult<List<Contact>>;
                    Assert.Equal(contactFirst.ContactID, ret.Content[0].ContactID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Contact> contactList = new List<Contact>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactList = (from c in db.Contacts select c).OrderBy(c => c.ContactID).Skip(0).Take(2).ToList();
                        count = (from c in db.Contacts select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Contact info
                        jsonRet = contactController.GetContactList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Contact>>;
                        Assert.Equal(contactList[0].ContactID, ret.Content[0].ContactID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Contact info
                           IHttpActionResult jsonRet2 = contactController.GetContactList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Contact>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Contact>>;
                           Assert.Equal(contactList[1].ContactID, ret2.Content[0].ContactID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Contact_Controller_GetContactWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactController contactController = new ContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactController.DatabaseType);

                    Contact contactFirst = new Contact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactService contactService = new ContactService(new Query(), db, ContactID);
                        contactFirst = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IHttpActionResult jsonRet = contactController.GetContactWithID(contactFirst.ContactID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Contact> Ret = jsonRet as OkNegotiatedContentResult<Contact>;
                    Contact contactRet = Ret.Content;
                    Assert.Equal(contactFirst.ContactID, contactRet.ContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = contactController.GetContactWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Contact> contactRet2 = jsonRet2 as OkNegotiatedContentResult<Contact>;
                    Assert.IsNull(contactRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Contact_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactController contactController = new ContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactController.DatabaseType);

                    Contact contactLast = new Contact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactLast = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IHttpActionResult jsonRet = contactController.GetContactWithID(contactLast.ContactID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Contact> Ret = jsonRet as OkNegotiatedContentResult<Contact>;
                    Contact contactRet = Ret.Content;
                    Assert.Equal(contactLast.ContactID, contactRet.ContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ContactID exist
                    IHttpActionResult jsonRet2 = contactController.Post(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Contact> contactRet2 = jsonRet2 as OkNegotiatedContentResult<Contact>;
                    Assert.IsNull(contactRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Contact
                    contactRet.ContactID = 0;
                    contactController.Request = new System.Net.Http.HttpRequestMessage();
                    contactController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contact");
                    IHttpActionResult jsonRet3 = contactController.Post(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Contact> contactRet3 = jsonRet3 as CreatedNegotiatedContentResult<Contact>;
                    Assert.NotNull(contactRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = contactController.Delete(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Contact> contactRet4 = jsonRet4 as OkNegotiatedContentResult<Contact>;
                    Assert.NotNull(contactRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void Contact_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactController contactController = new ContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactController.DatabaseType);

                    Contact contactLast = new Contact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactLast = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IHttpActionResult jsonRet = contactController.GetContactWithID(contactLast.ContactID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Contact> Ret = jsonRet as OkNegotiatedContentResult<Contact>;
                    Contact contactRet = Ret.Content;
                    Assert.Equal(contactLast.ContactID, contactRet.ContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = contactController.Put(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Contact> contactRet2 = jsonRet2 as OkNegotiatedContentResult<Contact>;
                    Assert.NotNull(contactRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ContactID of 0 does not exist
                    contactRet.ContactID = 0;
                    IHttpActionResult jsonRet3 = contactController.Put(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<Contact> contactRet3 = jsonRet3 as OkNegotiatedContentResult<Contact>;
                    Assert.IsNull(contactRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Contact_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactController contactController = new ContactController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactController.DatabaseType);

                    Contact contactLast = new Contact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactLast = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IHttpActionResult jsonRet = contactController.GetContactWithID(contactLast.ContactID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Contact> Ret = jsonRet as OkNegotiatedContentResult<Contact>;
                    Contact contactRet = Ret.Content;
                    Assert.Equal(contactLast.ContactID, contactRet.ContactID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Contact
                    contactRet.ContactID = 0;
                    contactController.Request = new System.Net.Http.HttpRequestMessage();
                    contactController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contact");
                    IHttpActionResult jsonRet3 = contactController.Post(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Contact> contactRet3 = jsonRet3 as CreatedNegotiatedContentResult<Contact>;
                    Assert.NotNull(contactRet3);
                    Contact contact = contactRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = contactController.Delete(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Contact> contactRet2 = jsonRet2 as OkNegotiatedContentResult<Contact>;
                    Assert.NotNull(contactRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ContactID of 0 does not exist
                    contactRet.ContactID = 0;
                    IHttpActionResult jsonRet4 = contactController.Delete(contactRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Contact> contactRet4 = jsonRet4 as OkNegotiatedContentResult<Contact>;
                    Assert.IsNull(contactRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
