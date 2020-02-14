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
        [Fact]
        public void ContactPreference_Controller_GetContactPreferenceList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactPreferenceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

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
                    IActionResult jsonRet = contactPreferenceController.GetContactPreferenceList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(contactPreferenceFirst.ContactPreferenceID, ((List<ContactPreference>)ret.Value)[0].ContactPreferenceID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ContactPreference>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(contactPreferenceList[0].ContactPreferenceID, ((List<ContactPreference>)ret.Value)[0].ContactPreferenceID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ContactPreference>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ContactPreference info
                           IActionResult jsonRet2 = contactPreferenceController.GetContactPreferenceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(contactPreferenceList[1].ContactPreferenceID, ((List<ContactPreference>)ret2.Value)[0].ContactPreferenceID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ContactPreference>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ContactPreference_Controller_GetContactPreferenceWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactPreferenceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceFirst = new ContactPreference();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query(), db, ContactID);
                        contactPreferenceFirst = (from c in db.ContactPreferences select c).FirstOrDefault();
                    }

                    // ok with ContactPreference info
                    IActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceFirst.ContactPreferenceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(contactPreferenceFirst.ContactPreferenceID, ((ContactPreference)ret.Value).ContactPreferenceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = contactPreferenceController.GetContactPreferenceWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult contactPreferenceRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(contactPreferenceRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ContactPreference_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactPreferenceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

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
                    IActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceLast.ContactPreferenceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ContactPreference contactPreferenceRet = (ContactPreference)ret.Value;
                    Assert.Equal(contactPreferenceLast.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ContactPreferenceID exist
                    IActionResult jsonRet2 = contactPreferenceController.Post(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ContactPreference
                    contactPreferenceRet.ContactPreferenceID = 0;
                    IActionResult jsonRet3 = contactPreferenceController.Post(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = contactPreferenceController.Delete(contactPreferenceRet, LanguageRequest.ToString());
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
        public void ContactPreference_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactPreferenceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

                    ContactPreference contactPreferenceLast = new ContactPreference();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(query, db, ContactID);
                        contactPreferenceLast = (from c in db.ContactPreferences select c).FirstOrDefault();
                    }

                    // ok with ContactPreference info
                    IActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceLast.ContactPreferenceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ContactPreference contactPreferenceRet = (ContactPreference)Ret.Value;
                    Assert.Equal(contactPreferenceLast.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = contactPreferenceController.Put(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult contactPreferenceRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(contactPreferenceRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ContactPreferenceID of 0 does not exist
                    contactPreferenceRet.ContactPreferenceID = 0;
                    IActionResult jsonRet3 = contactPreferenceController.Put(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult contactPreferenceRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(contactPreferenceRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ContactPreference_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ContactPreferenceController contactPreferenceController = new ContactPreferenceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(contactPreferenceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, contactPreferenceController.DatabaseType);

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
                    IActionResult jsonRet = contactPreferenceController.GetContactPreferenceWithID(contactPreferenceLast.ContactPreferenceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ContactPreference contactPreferenceRet = (ContactPreference)Ret.Value;
                    Assert.Equal(contactPreferenceLast.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ContactPreference
                    contactPreferenceRet.ContactPreferenceID = 0;
                    IActionResult jsonRet3 = contactPreferenceController.Post(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ContactPreference contactPreference = (ContactPreference)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = contactPreferenceController.Delete(contactPreferenceRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ContactPreferenceID of 0 does not exist
                    contactPreferenceRet.ContactPreferenceID = 0;
                    IActionResult jsonRet4 = contactPreferenceController.Delete(contactPreferenceRet, LanguageRequest.ToString());
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
