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
    public partial class TVItemUserAuthorizationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVItemUserAuthorization_Controller_GetTVItemUserAuthorizationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationFirst = new TVItemUserAuthorization();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationFirst = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                        count = (from c in db.TVItemUserAuthorizations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItemUserAuthorization info
                    IActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvItemUserAuthorizationFirst.TVItemUserAuthorizationID, ((List<TVItemUserAuthorization>)ret.Value)[0].TVItemUserAuthorizationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemUserAuthorization>)ret.Value).Count);

                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations select c).OrderBy(c => c.TVItemUserAuthorizationID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItemUserAuthorizations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItemUserAuthorization info
                        jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvItemUserAuthorizationList[0].TVItemUserAuthorizationID, ((List<TVItemUserAuthorization>)ret.Value)[0].TVItemUserAuthorizationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemUserAuthorization>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemUserAuthorization info
                           IActionResult jsonRet2 = tvItemUserAuthorizationController.GetTVItemUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvItemUserAuthorizationList[1].TVItemUserAuthorizationID, ((List<TVItemUserAuthorization>)ret2.Value)[0].TVItemUserAuthorizationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemUserAuthorization>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVItemUserAuthorization_Controller_GetTVItemUserAuthorizationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationFirst = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query(), db, ContactID);
                        tvItemUserAuthorizationFirst = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationFirst.TVItemUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvItemUserAuthorizationFirst.TVItemUserAuthorizationID, ((TVItemUserAuthorization)ret.Value).TVItemUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvItemUserAuthorizationRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvItemUserAuthorizationRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVItemUserAuthorization_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationLast = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationLast = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationLast.TVItemUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = (TVItemUserAuthorization)ret.Value;
                    Assert.Equal(tvItemUserAuthorizationLast.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVItemUserAuthorizationID exist
                    IActionResult jsonRet2 = tvItemUserAuthorizationController.Post(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemUserAuthorization
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvItemUserAuthorizationController.Post(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationRet, LanguageRequest.ToString());
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
        public void TVItemUserAuthorization_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationLast = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationLast = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationLast.TVItemUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = (TVItemUserAuthorization)Ret.Value;
                    Assert.Equal(tvItemUserAuthorizationLast.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvItemUserAuthorizationController.Put(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvItemUserAuthorizationRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvItemUserAuthorizationRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVItemUserAuthorizationID of 0 does not exist
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvItemUserAuthorizationController.Put(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvItemUserAuthorizationRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvItemUserAuthorizationRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVItemUserAuthorization_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationLast = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationLast = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationLast.TVItemUserAuthorizationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = (TVItemUserAuthorization)Ret.Value;
                    Assert.Equal(tvItemUserAuthorizationLast.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVItemUserAuthorization
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvItemUserAuthorizationController.Post(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVItemUserAuthorization tvItemUserAuthorization = (TVItemUserAuthorization)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVItemUserAuthorizationID of 0 does not exist
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    IActionResult jsonRet4 = tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationRet, LanguageRequest.ToString());
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
