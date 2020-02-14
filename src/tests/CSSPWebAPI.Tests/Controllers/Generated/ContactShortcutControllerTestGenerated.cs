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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(contactShortcutFirst.ContactShortcutID, ((List<ContactShortcut>)ret.Value)[0].ContactShortcutID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ContactShortcut>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(contactShortcutList[0].ContactShortcutID, ((List<ContactShortcut>)ret.Value)[0].ContactShortcutID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ContactShortcut>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ContactShortcut info
                           IActionResult jsonRet2 = contactShortcutController.GetContactShortcutList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(contactShortcutList[1].ContactShortcutID, ((List<ContactShortcut>)ret2.Value)[0].ContactShortcutID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ContactShortcut>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(contactShortcutFirst.ContactShortcutID, ((ContactShortcut)ret.Value).ContactShortcutID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = contactShortcutController.GetContactShortcutWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult contactShortcutRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(contactShortcutRet2);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ContactShortcut contactShortcutRet = (ContactShortcut)ret.Value;
                    Assert.Equal(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ContactShortcutID exist
                    IActionResult jsonRet2 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ContactShortcut
                    contactShortcutRet.ContactShortcutID = 0;
                    IActionResult jsonRet3 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ContactShortcut contactShortcutRet = (ContactShortcut)Ret.Value;
                    Assert.Equal(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = contactShortcutController.Put(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult contactShortcutRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(contactShortcutRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ContactShortcutID of 0 does not exist
                    contactShortcutRet.ContactShortcutID = 0;
                    IActionResult jsonRet3 = contactShortcutController.Put(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult contactShortcutRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(contactShortcutRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ContactShortcut contactShortcutRet = (ContactShortcut)Ret.Value;
                    Assert.Equal(contactShortcutLast.ContactShortcutID, contactShortcutRet.ContactShortcutID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ContactShortcut
                    contactShortcutRet.ContactShortcutID = 0;
                    IActionResult jsonRet3 = contactShortcutController.Post(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ContactShortcut contactShortcut = (ContactShortcut)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ContactShortcutID of 0 does not exist
                    contactShortcutRet.ContactShortcutID = 0;
                    IActionResult jsonRet4 = contactShortcutController.Delete(contactShortcutRet, LanguageRequest.ToString());
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
