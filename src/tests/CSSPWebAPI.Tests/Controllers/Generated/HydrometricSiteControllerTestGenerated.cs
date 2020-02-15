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
    public partial class HydrometricSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void HydrometricSite_Controller_GetHydrometricSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                        count = (from c in db.HydrometricSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with HydrometricSite info
                    IActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(hydrometricSiteFirst.HydrometricSiteID, ((List<HydrometricSite>)ret.Value)[0].HydrometricSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<HydrometricSite>)ret.Value).Count);

                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteList = (from c in db.HydrometricSites select c).OrderBy(c => c.HydrometricSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.HydrometricSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with HydrometricSite info
                        jsonRet = hydrometricSiteController.GetHydrometricSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(hydrometricSiteList[0].HydrometricSiteID, ((List<HydrometricSite>)ret.Value)[0].HydrometricSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<HydrometricSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with HydrometricSite info
                           IActionResult jsonRet2 = hydrometricSiteController.GetHydrometricSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(hydrometricSiteList[1].HydrometricSiteID, ((List<HydrometricSite>)ret2.Value)[0].HydrometricSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<HydrometricSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void HydrometricSite_Controller_GetHydrometricSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query(), db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteFirst.HydrometricSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(hydrometricSiteFirst.HydrometricSiteID, ((HydrometricSite)ret.Value).HydrometricSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = hydrometricSiteController.GetHydrometricSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult hydrometricSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(hydrometricSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void HydrometricSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteFirst.HydrometricSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    HydrometricSite hydrometricSiteRet = (HydrometricSite)ret.Value;
                    Assert.Equal(hydrometricSiteFirst.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because HydrometricSiteID exist
                    IActionResult jsonRet2 = hydrometricSiteController.Post(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added HydrometricSite
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    IActionResult jsonRet3 = hydrometricSiteController.Post(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = hydrometricSiteController.Delete(hydrometricSiteRet, LanguageRequest.ToString());
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
        public void HydrometricSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteFirst.HydrometricSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    HydrometricSite hydrometricSiteRet = (HydrometricSite)Ret.Value;
                    Assert.Equal(hydrometricSiteFirst.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = hydrometricSiteController.Put(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult hydrometricSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(hydrometricSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because HydrometricSiteID of 0 does not exist
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    IActionResult jsonRet3 = hydrometricSiteController.Put(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult hydrometricSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(hydrometricSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void HydrometricSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricSiteController hydrometricSiteController = new HydrometricSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricSiteController.DatabaseType);

                    HydrometricSite hydrometricSiteFirst = new HydrometricSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(query, db, ContactID);
                        hydrometricSiteFirst = (from c in db.HydrometricSites select c).FirstOrDefault();
                    }

                    // ok with HydrometricSite info
                    IActionResult jsonRet = hydrometricSiteController.GetHydrometricSiteWithID(hydrometricSiteFirst.HydrometricSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    HydrometricSite hydrometricSiteRet = (HydrometricSite)Ret.Value;
                    Assert.Equal(hydrometricSiteFirst.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added HydrometricSite
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    IActionResult jsonRet3 = hydrometricSiteController.Post(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    HydrometricSite hydrometricSite = (HydrometricSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = hydrometricSiteController.Delete(hydrometricSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because HydrometricSiteID of 0 does not exist
                    hydrometricSiteRet.HydrometricSiteID = 0;
                    IActionResult jsonRet4 = hydrometricSiteController.Delete(hydrometricSiteRet, LanguageRequest.ToString());
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
