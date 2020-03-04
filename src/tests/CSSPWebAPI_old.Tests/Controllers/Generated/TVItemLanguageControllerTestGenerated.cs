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
    public partial class TVItemLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVItemLanguage_Controller_GetTVItemLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                        count = (from c in db.TVItemLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItemLanguage info
                    IActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, ((List<TVItemLanguage>)ret.Value)[0].TVItemLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemLanguage>)ret.Value).Count);

                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageList = (from c in db.TVItemLanguages select c).OrderBy(c => c.TVItemLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItemLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItemLanguage info
                        jsonRet = tvItemLanguageController.GetTVItemLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvItemLanguageList[0].TVItemLanguageID, ((List<TVItemLanguage>)ret.Value)[0].TVItemLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemLanguage info
                           IActionResult jsonRet2 = tvItemLanguageController.GetTVItemLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvItemLanguageList[1].TVItemLanguageID, ((List<TVItemLanguage>)ret2.Value)[0].TVItemLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVItemLanguage_Controller_GetTVItemLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query(), db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageFirst.TVItemLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, ((TVItemLanguage)ret.Value).TVItemLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvItemLanguageController.GetTVItemLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvItemLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvItemLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVItemLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageFirst.TVItemLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVItemLanguage tvItemLanguageRet = (TVItemLanguage)ret.Value;
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVItemLanguageID exist
                    IActionResult jsonRet2 = tvItemLanguageController.Post(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemLanguage
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    IActionResult jsonRet3 = tvItemLanguageController.Post(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvItemLanguageController.Delete(tvItemLanguageRet, LanguageRequest.ToString());
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
        public void TVItemLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageFirst.TVItemLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemLanguage tvItemLanguageRet = (TVItemLanguage)Ret.Value;
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvItemLanguageController.Put(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvItemLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvItemLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVItemLanguageID of 0 does not exist
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    IActionResult jsonRet3 = tvItemLanguageController.Put(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvItemLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvItemLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVItemLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageFirst.TVItemLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemLanguage tvItemLanguageRet = (TVItemLanguage)Ret.Value;
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVItemLanguage
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    IActionResult jsonRet3 = tvItemLanguageController.Post(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVItemLanguage tvItemLanguage = (TVItemLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvItemLanguageController.Delete(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVItemLanguageID of 0 does not exist
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    IActionResult jsonRet4 = tvItemLanguageController.Delete(tvItemLanguageRet, LanguageRequest.ToString());
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
