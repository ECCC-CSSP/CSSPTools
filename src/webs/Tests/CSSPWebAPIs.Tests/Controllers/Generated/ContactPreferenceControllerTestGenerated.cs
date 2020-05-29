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
    public partial class ContactPreferenceControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactPreferenceControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void ContactPreference_Controller_GetContactPreferenceList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactPreferenceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceFirst = new ContactPreference();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(query, db, ContactID);
                        contactPreferenceFirst = (from c in db.ContactPreferences select c).FirstOrDefault();
                        count = (from c in db.ContactPreferences select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ContactPreference info
                    IHttpActionResult jsonRet = contactPreferenceController.GetContactPreferenceList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ContactPreference>> ret = jsonRet as OkNegotiatedContentResult<List<ContactPreference>>;
                    Assert.AreEqual(contactPreferenceFirst.ContactPreferenceID, ret.Content[0].ContactPreferenceID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(query, db, ContactID);
                        contactPreferenceList = (from c in db.ContactPreferences select c).OrderBy(c => c.ContactPreferenceID).Skip(0).Take(2).ToList();
                        count = (from c in db.ContactPreferences select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ContactPreference info
                        jsonRet = contactPreferenceController.GetContactPreferenceList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ContactPreference>>;
                        Assert.AreEqual(contactPreferenceList[0].ContactPreferenceID, ret.Content[0].ContactPreferenceID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ContactPreference info
                           IHttpActionResult jsonRet2 = contactPreferenceController.GetContactPreferenceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ContactPreference>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ContactPreference>>;
                           Assert.AreEqual(contactPreferenceList[1].ContactPreferenceID, ret2.Content[0].ContactPreferenceID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ContactPreference_Controller_GetContactPreferenceWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactPreferenceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceFirst = new ContactPreference();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query(), db, ContactID);
                        contactPreferenceFirst = (from c in db.ContactPreferences select c).FirstOrDefault();
                    }

                    // ok with ContactPreference info
                    IHttpActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceFirst.ContactPreferenceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactPreference> Ret = jsonRet as OkNegotiatedContentResult<ContactPreference>;
                    ContactPreference contactPreferenceRet = Ret.Content;
                    Assert.AreEqual(contactPreferenceFirst.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = contactPreferenceController.GetContactPreferenceWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet2 = jsonRet2 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNull(contactPreferenceRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ContactPreference_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactPreferenceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceLast = new ContactPreference();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(query, db, ContactID);
                        contactPreferenceLast = (from c in db.ContactPreferences select c).FirstOrDefault();
                    }

                    // ok with ContactPreference info
                    IHttpActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceLast.ContactPreferenceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactPreference> Ret = jsonRet as OkNegotiatedContentResult<ContactPreference>;
                    ContactPreference contactPreferenceRet = Ret.Content;
                    Assert.AreEqual(contactPreferenceLast.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ContactPreferenceID exist
                    IHttpActionResult jsonRet2 = contactPreferenceController.Post(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet2 = jsonRet2 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNull(contactPreferenceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ContactPreference
                    contactPreferenceRet.ContactPreferenceID = 0;
                    contactPreferenceController.Request = new System.Net.Http.HttpRequestMessage();
                    contactPreferenceController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contactPreference");
                    IHttpActionResult jsonRet3 = contactPreferenceController.Post(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ContactPreference> contactPreferenceRet3 = jsonRet3 as CreatedNegotiatedContentResult<ContactPreference>;
                    Assert.IsNotNull(contactPreferenceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = contactPreferenceController.Delete(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet4 = jsonRet4 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNotNull(contactPreferenceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ContactPreference_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactPreferenceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceLast = new ContactPreference();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(query, db, ContactID);
                        contactPreferenceLast = (from c in db.ContactPreferences select c).FirstOrDefault();
                    }

                    // ok with ContactPreference info
                    IHttpActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceLast.ContactPreferenceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactPreference> Ret = jsonRet as OkNegotiatedContentResult<ContactPreference>;
                    ContactPreference contactPreferenceRet = Ret.Content;
                    Assert.AreEqual(contactPreferenceLast.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = contactPreferenceController.Put(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet2 = jsonRet2 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNotNull(contactPreferenceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ContactPreferenceID of 0 does not exist
                    contactPreferenceRet.ContactPreferenceID = 0;
                    IHttpActionResult jsonRet3 = contactPreferenceController.Put(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet3 = jsonRet3 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNull(contactPreferenceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ContactPreference_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(contactPreferenceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceLast = new ContactPreference();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(query, db, ContactID);
                        contactPreferenceLast = (from c in db.ContactPreferences select c).FirstOrDefault();
                    }

                    // ok with ContactPreference info
                    IHttpActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceLast.ContactPreferenceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ContactPreference> Ret = jsonRet as OkNegotiatedContentResult<ContactPreference>;
                    ContactPreference contactPreferenceRet = Ret.Content;
                    Assert.AreEqual(contactPreferenceLast.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ContactPreference
                    contactPreferenceRet.ContactPreferenceID = 0;
                    contactPreferenceController.Request = new System.Net.Http.HttpRequestMessage();
                    contactPreferenceController.Request.RequestUri = new System.Uri("http://localhost:5000/api/contactPreference");
                    IHttpActionResult jsonRet3 = contactPreferenceController.Post(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ContactPreference> contactPreferenceRet3 = jsonRet3 as CreatedNegotiatedContentResult<ContactPreference>;
                    Assert.IsNotNull(contactPreferenceRet3);
                    ContactPreference contactPreference = contactPreferenceRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = contactPreferenceController.Delete(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet2 = jsonRet2 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNotNull(contactPreferenceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ContactPreferenceID of 0 does not exist
                    contactPreferenceRet.ContactPreferenceID = 0;
                    IHttpActionResult jsonRet4 = contactPreferenceController.Delete(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ContactPreference> contactPreferenceRet4 = jsonRet4 as OkNegotiatedContentResult<ContactPreference>;
                    Assert.IsNull(contactPreferenceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
