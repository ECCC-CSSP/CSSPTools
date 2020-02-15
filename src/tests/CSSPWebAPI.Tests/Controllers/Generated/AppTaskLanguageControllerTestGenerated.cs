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
    public partial class AppTaskLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void AppTaskLanguage_Controller_GetAppTaskLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                        count = (from c in db.AppTaskLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with AppTaskLanguage info
                    IActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(appTaskLanguageFirst.AppTaskLanguageID, ((List<AppTaskLanguage>)ret.Value)[0].AppTaskLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<AppTaskLanguage>)ret.Value).Count);

                    List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageList = (from c in db.AppTaskLanguages select c).OrderBy(c => c.AppTaskLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.AppTaskLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with AppTaskLanguage info
                        jsonRet = appTaskLanguageController.GetAppTaskLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(appTaskLanguageList[0].AppTaskLanguageID, ((List<AppTaskLanguage>)ret.Value)[0].AppTaskLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<AppTaskLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with AppTaskLanguage info
                           IActionResult jsonRet2 = appTaskLanguageController.GetAppTaskLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(appTaskLanguageList[1].AppTaskLanguageID, ((List<AppTaskLanguage>)ret2.Value)[0].AppTaskLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<AppTaskLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void AppTaskLanguage_Controller_GetAppTaskLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query(), db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageFirst.AppTaskLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(appTaskLanguageFirst.AppTaskLanguageID, ((AppTaskLanguage)ret.Value).AppTaskLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = appTaskLanguageController.GetAppTaskLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult appTaskLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(appTaskLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void AppTaskLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageFirst.AppTaskLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    AppTaskLanguage appTaskLanguageRet = (AppTaskLanguage)ret.Value;
                    Assert.Equal(appTaskLanguageFirst.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because AppTaskLanguageID exist
                    IActionResult jsonRet2 = appTaskLanguageController.Post(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added AppTaskLanguage
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    IActionResult jsonRet3 = appTaskLanguageController.Post(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = appTaskLanguageController.Delete(appTaskLanguageRet, LanguageRequest.ToString());
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
        public void AppTaskLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageFirst.AppTaskLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    AppTaskLanguage appTaskLanguageRet = (AppTaskLanguage)Ret.Value;
                    Assert.Equal(appTaskLanguageFirst.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = appTaskLanguageController.Put(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult appTaskLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(appTaskLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because AppTaskLanguageID of 0 does not exist
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    IActionResult jsonRet3 = appTaskLanguageController.Put(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult appTaskLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(appTaskLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void AppTaskLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AppTaskLanguageController appTaskLanguageController = new AppTaskLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(appTaskLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, appTaskLanguageController.DatabaseType);

                    AppTaskLanguage appTaskLanguageFirst = new AppTaskLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(query, db, ContactID);
                        appTaskLanguageFirst = (from c in db.AppTaskLanguages select c).FirstOrDefault();
                    }

                    // ok with AppTaskLanguage info
                    IActionResult jsonRet = appTaskLanguageController.GetAppTaskLanguageWithID(appTaskLanguageFirst.AppTaskLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    AppTaskLanguage appTaskLanguageRet = (AppTaskLanguage)Ret.Value;
                    Assert.Equal(appTaskLanguageFirst.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added AppTaskLanguage
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    IActionResult jsonRet3 = appTaskLanguageController.Post(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    AppTaskLanguage appTaskLanguage = (AppTaskLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = appTaskLanguageController.Delete(appTaskLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because AppTaskLanguageID of 0 does not exist
                    appTaskLanguageRet.AppTaskLanguageID = 0;
                    IActionResult jsonRet4 = appTaskLanguageController.Delete(appTaskLanguageRet, LanguageRequest.ToString());
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
