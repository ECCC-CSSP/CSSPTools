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
    public partial class TelControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TelControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Tel_Controller_GetTelList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TelService telService = new TelService(query, db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                        count = (from c in db.Tels select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(telFirst.TelID, ((List<Tel>)ret.Value)[0].TelID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Tel>)ret.Value).Count);

                    List<Tel> telList = new List<Tel>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TelService telService = new TelService(query, db, ContactID);
                        telList = (from c in db.Tels select c).OrderBy(c => c.TelID).Skip(0).Take(2).ToList();
                        count = (from c in db.Tels select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Tel info
                        jsonRet = telController.GetTelList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(telList[0].TelID, ((List<Tel>)ret.Value)[0].TelID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Tel>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Tel info
                           IActionResult jsonRet2 = telController.GetTelList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(telList[1].TelID, ((List<Tel>)ret2.Value)[0].TelID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Tel>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Tel_Controller_GetTelWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TelService telService = new TelService(new Query(), db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telFirst.TelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(telFirst.TelID, ((Tel)ret.Value).TelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = telController.GetTelWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult telRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(telRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Tel_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TelService telService = new TelService(query, db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telFirst.TelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Tel telRet = (Tel)ret.Value;
                    Assert.Equal(telFirst.TelID, telRet.TelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TelID exist
                    IActionResult jsonRet2 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Tel
                    telRet.TelID = 0;
                    IActionResult jsonRet3 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = telController.Delete(telRet, LanguageRequest.ToString());
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
        public void Tel_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TelService telService = new TelService(query, db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telFirst.TelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Tel telRet = (Tel)Ret.Value;
                    Assert.Equal(telFirst.TelID, telRet.TelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = telController.Put(telRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult telRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(telRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TelID of 0 does not exist
                    telRet.TelID = 0;
                    IActionResult jsonRet3 = telController.Put(telRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult telRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(telRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Tel_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TelService telService = new TelService(query, db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telFirst.TelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Tel telRet = (Tel)Ret.Value;
                    Assert.Equal(telFirst.TelID, telRet.TelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Tel
                    telRet.TelID = 0;
                    IActionResult jsonRet3 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Tel tel = (Tel)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TelID of 0 does not exist
                    telRet.TelID = 0;
                    IActionResult jsonRet4 = telController.Delete(telRet, LanguageRequest.ToString());
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
