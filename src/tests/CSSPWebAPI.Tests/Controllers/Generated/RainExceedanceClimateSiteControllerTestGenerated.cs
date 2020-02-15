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
    public partial class RainExceedanceClimateSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_GetRainExceedanceClimateSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                        count = (from c in db.RainExceedanceClimateSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RainExceedanceClimateSite info
                    IActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, ((List<RainExceedanceClimateSite>)ret.Value)[0].RainExceedanceClimateSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<RainExceedanceClimateSite>)ret.Value).Count);

                    List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = new List<RainExceedanceClimateSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteList = (from c in db.RainExceedanceClimateSites select c).OrderBy(c => c.RainExceedanceClimateSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.RainExceedanceClimateSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RainExceedanceClimateSite info
                        jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID, ((List<RainExceedanceClimateSite>)ret.Value)[0].RainExceedanceClimateSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<RainExceedanceClimateSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RainExceedanceClimateSite info
                           IActionResult jsonRet2 = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(rainExceedanceClimateSiteList[1].RainExceedanceClimateSiteID, ((List<RainExceedanceClimateSite>)ret2.Value)[0].RainExceedanceClimateSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<RainExceedanceClimateSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_GetRainExceedanceClimateSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query(), db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, ((RainExceedanceClimateSite)ret.Value).RainExceedanceClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult rainExceedanceClimateSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(rainExceedanceClimateSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = (RainExceedanceClimateSite)ret.Value;
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because RainExceedanceClimateSiteID exist
                    IActionResult jsonRet2 = rainExceedanceClimateSiteController.Post(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RainExceedanceClimateSite
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    IActionResult jsonRet3 = rainExceedanceClimateSiteController.Post(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
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
        public void RainExceedanceClimateSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = (RainExceedanceClimateSite)Ret.Value;
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = rainExceedanceClimateSiteController.Put(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult rainExceedanceClimateSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(rainExceedanceClimateSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because RainExceedanceClimateSiteID of 0 does not exist
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    IActionResult jsonRet3 = rainExceedanceClimateSiteController.Put(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult rainExceedanceClimateSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(rainExceedanceClimateSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = (RainExceedanceClimateSite)Ret.Value;
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added RainExceedanceClimateSite
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    IActionResult jsonRet3 = rainExceedanceClimateSiteController.Post(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    RainExceedanceClimateSite rainExceedanceClimateSite = (RainExceedanceClimateSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because RainExceedanceClimateSiteID of 0 does not exist
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    IActionResult jsonRet4 = rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
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
