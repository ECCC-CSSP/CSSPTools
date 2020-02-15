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
                    IActionResult jsonRet = contactController.GetContactList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(contactFirst.ContactID, ((List<Contact>)ret.Value)[0].ContactID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Contact>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(contactList[0].ContactID, ((List<Contact>)ret.Value)[0].ContactID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Contact>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Contact info
                           IActionResult jsonRet2 = contactController.GetContactList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(contactList[1].ContactID, ((List<Contact>)ret2.Value)[0].ContactID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Contact>)ret2.Value).Count);
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
                    IActionResult jsonRet = contactController.GetContactWithID(contactFirst.ContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(contactFirst.ContactID, ((Contact)ret.Value).ContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = contactController.GetContactWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult contactRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(contactRet2);
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

                    Contact contactFirst = new Contact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactFirst = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IActionResult jsonRet = contactController.GetContactWithID(contactFirst.ContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Contact contactRet = (Contact)ret.Value;
                    Assert.Equal(contactFirst.ContactID, contactRet.ContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ContactID exist
                    IActionResult jsonRet2 = contactController.Post(contactRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Contact
                    contactRet.ContactID = 0;
                    IActionResult jsonRet3 = contactController.Post(contactRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = contactController.Delete(contactRet, LanguageRequest.ToString());
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
        public void Contact_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactFirst = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IActionResult jsonRet = contactController.GetContactWithID(contactFirst.ContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Contact contactRet = (Contact)Ret.Value;
                    Assert.Equal(contactFirst.ContactID, contactRet.ContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = contactController.Put(contactRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult contactRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(contactRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ContactID of 0 does not exist
                    contactRet.ContactID = 0;
                    IActionResult jsonRet3 = contactController.Put(contactRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult contactRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(contactRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    Contact contactFirst = new Contact();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ContactService contactService = new ContactService(query, db, ContactID);
                        contactFirst = (from c in db.Contacts select c).FirstOrDefault();
                    }

                    // ok with Contact info
                    IActionResult jsonRet = contactController.GetContactWithID(contactFirst.ContactID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Contact contactRet = (Contact)Ret.Value;
                    Assert.Equal(contactFirst.ContactID, contactRet.ContactID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Contact
                    contactRet.ContactID = 0;
                    IActionResult jsonRet3 = contactController.Post(contactRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Contact contact = (Contact)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = contactController.Delete(contactRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ContactID of 0 does not exist
                    contactRet.ContactID = 0;
                    IActionResult jsonRet4 = contactController.Delete(contactRet, LanguageRequest.ToString());
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
