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
    public partial class UseOfSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public UseOfSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void UseOfSite_Controller_GetUseOfSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                        count = (from c in db.UseOfSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, ((List<UseOfSite>)ret.Value)[0].UseOfSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<UseOfSite>)ret.Value).Count);

                    List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteList = (from c in db.UseOfSites select c).OrderBy(c => c.UseOfSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.UseOfSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with UseOfSite info
                        jsonRet = useOfSiteController.GetUseOfSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(useOfSiteList[0].UseOfSiteID, ((List<UseOfSite>)ret.Value)[0].UseOfSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<UseOfSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with UseOfSite info
                           IActionResult jsonRet2 = useOfSiteController.GetUseOfSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(useOfSiteList[1].UseOfSiteID, ((List<UseOfSite>)ret2.Value)[0].UseOfSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<UseOfSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void UseOfSite_Controller_GetUseOfSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query(), db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteFirst.UseOfSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, ((UseOfSite)ret.Value).UseOfSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = useOfSiteController.GetUseOfSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult useOfSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(useOfSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void UseOfSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteFirst.UseOfSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    UseOfSite useOfSiteRet = (UseOfSite)ret.Value;
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because UseOfSiteID exist
                    IActionResult jsonRet2 = useOfSiteController.Post(useOfSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added UseOfSite
                    useOfSiteRet.UseOfSiteID = 0;
                    IActionResult jsonRet3 = useOfSiteController.Post(useOfSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = useOfSiteController.Delete(useOfSiteRet, LanguageRequest.ToString());
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
        public void UseOfSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteFirst.UseOfSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    UseOfSite useOfSiteRet = (UseOfSite)Ret.Value;
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = useOfSiteController.Put(useOfSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult useOfSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(useOfSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because UseOfSiteID of 0 does not exist
                    useOfSiteRet.UseOfSiteID = 0;
                    IActionResult jsonRet3 = useOfSiteController.Put(useOfSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult useOfSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(useOfSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void UseOfSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteFirst.UseOfSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    UseOfSite useOfSiteRet = (UseOfSite)Ret.Value;
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added UseOfSite
                    useOfSiteRet.UseOfSiteID = 0;
                    IActionResult jsonRet3 = useOfSiteController.Post(useOfSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    UseOfSite useOfSite = (UseOfSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = useOfSiteController.Delete(useOfSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because UseOfSiteID of 0 does not exist
                    useOfSiteRet.UseOfSiteID = 0;
                    IActionResult jsonRet4 = useOfSiteController.Delete(useOfSiteRet, LanguageRequest.ToString());
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
