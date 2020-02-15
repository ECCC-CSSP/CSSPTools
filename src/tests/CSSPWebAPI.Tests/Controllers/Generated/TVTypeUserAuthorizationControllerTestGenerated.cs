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
    public partial class TVTypeUserAuthorizationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_GetTVTypeUserAuthorizationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                        count = (from c in db.TVTypeUserAuthorizations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, ((List<TVTypeUserAuthorization>)ret.Value)[0].TVTypeUserAuthorizationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVTypeUserAuthorization>)ret.Value).Count);

                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations select c).OrderBy(c => c.TVTypeUserAuthorizationID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVTypeUserAuthorizations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVTypeUserAuthorization info
                        jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID, ((List<TVTypeUserAuthorization>)ret.Value)[0].TVTypeUserAuthorizationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVTypeUserAuthorization>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVTypeUserAuthorization info
                           IActionResult jsonRet2 = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvTypeUserAuthorizationList[1].TVTypeUserAuthorizationID, ((List<TVTypeUserAuthorization>)ret2.Value)[0].TVTypeUserAuthorizationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVTypeUserAuthorization>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_GetTVTypeUserAuthorizationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query(), db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, ((TVTypeUserAuthorization)ret.Value).TVTypeUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvTypeUserAuthorizationRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvTypeUserAuthorizationRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = (TVTypeUserAuthorization)ret.Value;
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVTypeUserAuthorizationID exist
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVTypeUserAuthorization
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
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
        public void TVTypeUserAuthorization_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = (TVTypeUserAuthorization)Ret.Value;
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvTypeUserAuthorizationRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvTypeUserAuthorizationRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVTypeUserAuthorizationID of 0 does not exist
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvTypeUserAuthorizationRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvTypeUserAuthorizationRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = (TVTypeUserAuthorization)Ret.Value;
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVTypeUserAuthorization
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVTypeUserAuthorization tvTypeUserAuthorization = (TVTypeUserAuthorization)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVTypeUserAuthorizationID of 0 does not exist
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IActionResult jsonRet4 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
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
