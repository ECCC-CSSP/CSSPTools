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
    public partial class TVFileLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVFileLanguage_Controller_GetTVFileLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageFirst = new TVFileLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageFirst = (from c in db.TVFileLanguages select c).FirstOrDefault();
                        count = (from c in db.TVFileLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVFileLanguage info
                    IActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvFileLanguageFirst.TVFileLanguageID, ((List<TVFileLanguage>)ret.Value)[0].TVFileLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVFileLanguage>)ret.Value).Count);

                    List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageList = (from c in db.TVFileLanguages select c).OrderBy(c => c.TVFileLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVFileLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVFileLanguage info
                        jsonRet = tvFileLanguageController.GetTVFileLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvFileLanguageList[0].TVFileLanguageID, ((List<TVFileLanguage>)ret.Value)[0].TVFileLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVFileLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVFileLanguage info
                           IActionResult jsonRet2 = tvFileLanguageController.GetTVFileLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvFileLanguageList[1].TVFileLanguageID, ((List<TVFileLanguage>)ret2.Value)[0].TVFileLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVFileLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVFileLanguage_Controller_GetTVFileLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageFirst = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query(), db, ContactID);
                        tvFileLanguageFirst = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageFirst.TVFileLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvFileLanguageFirst.TVFileLanguageID, ((TVFileLanguage)ret.Value).TVFileLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvFileLanguageController.GetTVFileLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvFileLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvFileLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVFileLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageLast = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageLast = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageLast.TVFileLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVFileLanguage tvFileLanguageRet = (TVFileLanguage)ret.Value;
                    Assert.Equal(tvFileLanguageLast.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVFileLanguageID exist
                    IActionResult jsonRet2 = tvFileLanguageController.Post(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVFileLanguage
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    IActionResult jsonRet3 = tvFileLanguageController.Post(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvFileLanguageController.Delete(tvFileLanguageRet, LanguageRequest.ToString());
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
        public void TVFileLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageLast = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageLast = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageLast.TVFileLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVFileLanguage tvFileLanguageRet = (TVFileLanguage)Ret.Value;
                    Assert.Equal(tvFileLanguageLast.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvFileLanguageController.Put(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvFileLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvFileLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVFileLanguageID of 0 does not exist
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    IActionResult jsonRet3 = tvFileLanguageController.Put(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvFileLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvFileLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVFileLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageLast = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageLast = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageLast.TVFileLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVFileLanguage tvFileLanguageRet = (TVFileLanguage)Ret.Value;
                    Assert.Equal(tvFileLanguageLast.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVFileLanguage
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    IActionResult jsonRet3 = tvFileLanguageController.Post(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVFileLanguage tvFileLanguage = (TVFileLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvFileLanguageController.Delete(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVFileLanguageID of 0 does not exist
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    IActionResult jsonRet4 = tvFileLanguageController.Delete(tvFileLanguageRet, LanguageRequest.ToString());
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
