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
    public partial class TideSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TideSite_Controller_GetTideSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteFirst = new TideSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteFirst = (from c in db.TideSites select c).FirstOrDefault();
                        count = (from c in db.TideSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TideSite info
                    IActionResult jsonRet = tideSiteController.GetTideSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tideSiteFirst.TideSiteID, ((List<TideSite>)ret.Value)[0].TideSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TideSite>)ret.Value).Count);

                    List<TideSite> tideSiteList = new List<TideSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteList = (from c in db.TideSites select c).OrderBy(c => c.TideSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.TideSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TideSite info
                        jsonRet = tideSiteController.GetTideSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tideSiteList[0].TideSiteID, ((List<TideSite>)ret.Value)[0].TideSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TideSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideSite info
                           IActionResult jsonRet2 = tideSiteController.GetTideSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tideSiteList[1].TideSiteID, ((List<TideSite>)ret2.Value)[0].TideSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TideSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TideSite_Controller_GetTideSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteFirst = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query(), db, ContactID);
                        tideSiteFirst = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteFirst.TideSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tideSiteFirst.TideSiteID, ((TideSite)ret.Value).TideSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tideSiteController.GetTideSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tideSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tideSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TideSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteLast = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteLast = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteLast.TideSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TideSite tideSiteRet = (TideSite)ret.Value;
                    Assert.Equal(tideSiteLast.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TideSiteID exist
                    IActionResult jsonRet2 = tideSiteController.Post(tideSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TideSite
                    tideSiteRet.TideSiteID = 0;
                    IActionResult jsonRet3 = tideSiteController.Post(tideSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tideSiteController.Delete(tideSiteRet, LanguageRequest.ToString());
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
        public void TideSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteLast = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteLast = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteLast.TideSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TideSite tideSiteRet = (TideSite)Ret.Value;
                    Assert.Equal(tideSiteLast.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tideSiteController.Put(tideSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tideSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tideSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TideSiteID of 0 does not exist
                    tideSiteRet.TideSiteID = 0;
                    IActionResult jsonRet3 = tideSiteController.Put(tideSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tideSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tideSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TideSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteLast = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteLast = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteLast.TideSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TideSite tideSiteRet = (TideSite)Ret.Value;
                    Assert.Equal(tideSiteLast.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TideSite
                    tideSiteRet.TideSiteID = 0;
                    IActionResult jsonRet3 = tideSiteController.Post(tideSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TideSite tideSite = (TideSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tideSiteController.Delete(tideSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TideSiteID of 0 does not exist
                    tideSiteRet.TideSiteID = 0;
                    IActionResult jsonRet4 = tideSiteController.Delete(tideSiteRet, LanguageRequest.ToString());
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
