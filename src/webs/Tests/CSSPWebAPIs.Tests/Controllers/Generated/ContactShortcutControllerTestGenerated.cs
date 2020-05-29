using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void ContactShortcut_Controller_GetContactShortcutList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactShortcutController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

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
                    IHttpActionResult jsonRet = contactShortcutController.GetContactShortcutList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ContactShortcut>> ret = jsonRet as OkNegotiatedContentResult<List<ContactShortcut>>;
                    Assert.AreEqual(contactShortcutFirst.ContactShortcutID, ret.Content[0].ContactShortcutID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ContactShortcut>>;
                        Assert.AreEqual(contactShortcutList[0].ContactShortcutID, ret.Content[0].ContactShortcutID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ContactShortcut info
                           IHttpActionResult jsonRet2 = contactShortcutController.GetContactShortcutList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ContactShortcut>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ContactShortcut>>;
                           Assert.AreEqual(contactShortcutList[1].ContactShortcutID, ret2.Content[0].ContactShortcutID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ContactShortcut_Controller_GetContactShortcutWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactShortcutController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutFirst = new ContactShortcut();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query(), db, ContactID);
                        contactShortcutFirst = (from c in db.ContactShortcuts select c).FirstOrDefault();
                    }

                    // ok with ContactShortcut info
                    IHttpActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutFirst.ContactShortcutID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.AreEqual(contactShortcutFirst.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = contactShortcutController.GetContactShortcutWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNull(contactShortcutRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ContactShortcut_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactShortcutController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

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
                    IHttpActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutLast.ContactShortcutID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.AreEqual(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ContactShortcutID exist
                    IHttpActionResult jsonRet2 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNull(contactShortcutRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ContactShortcut
                    contactShortcutRet.ContactShortcutID = 0;
                    contactShortcutController.Request = new System.Net.Http.HttpRequestMessage();
                    contactShortcutController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contactShortcut");
                    IHttpActionResult jsonRet3 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ContactShortcut> contactShortcutRet3 = jsonRet3 as CreatedNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNotNull(contactShortcutRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet4 = jsonRet4 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNotNull(contactShortcutRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ContactShortcut_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactShortcutController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

                    ContactShortcut contactShortcutLast = new ContactShortcut();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ContactShortcutService contactShortcutService = new ContactShortcutService(query, db, ContactID);
                        contactShortcutLast = (from c in db.ContactShortcuts select c).FirstOrDefault();
                    }

                    // ok with ContactShortcut info
                    IHttpActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutLast.ContactShortcutID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.AreEqual(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = contactShortcutController.Put(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNotNull(contactShortcutRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ContactShortcutID of 0 does not exist
                    contactShortcutRet.ContactShortcutID = 0;
                    IHttpActionResult jsonRet3 = contactShortcutController.Put(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet3 = jsonRet3 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNull(contactShortcutRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ContactShortcut_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactShortcutController contactShortcutController = new ContactShortcutController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactShortcutController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactShortcutController.DatabaseType);

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
                    IHttpActionResult jsonRet = contactShortcutController.GetContactShortcutWithID(contactShortcutLast.ContactShortcutID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactShortcut> Ret = jsonRet as OkNegotiatedContentResult<ContactShortcut>;
                    ContactShortcut contactShortcutRet = Ret.Content;
                    Assert.AreEqual(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ContactShortcut
                    contactShortcutRet.ContactShortcutID = 0;
                    contactShortcutController.Request = new System.Net.Http.HttpRequestMessage();
                    contactShortcutController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contactShortcut");
                    IHttpActionResult jsonRet3 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ContactShortcut> contactShortcutRet3 = jsonRet3 as CreatedNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNotNull(contactShortcutRet3);
                    ContactShortcut contactShortcut = contactShortcutRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet2 = jsonRet2 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNotNull(contactShortcutRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ContactShortcutID of 0 does not exist
                    contactShortcutRet.ContactShortcutID = 0;
                    IHttpActionResult jsonRet4 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ContactShortcut> contactShortcutRet4 = jsonRet4 as OkNegotiatedContentResult<ContactShortcut>;
                    Assert.IsNull(contactShortcutRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
