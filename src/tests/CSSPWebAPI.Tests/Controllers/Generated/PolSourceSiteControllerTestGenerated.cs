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
    public partial class PolSourceSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void PolSourceSite_Controller_GetPolSourceSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteFirst = new PolSourceSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteFirst = (from c in db.PolSourceSites select c).FirstOrDefault();
                        count = (from c in db.PolSourceSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceSite info
                    IActionResult jsonRet = polSourceSiteController.GetPolSourceSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(polSourceSiteFirst.PolSourceSiteID, ((List<PolSourceSite>)ret.Value)[0].PolSourceSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSite>)ret.Value).Count);

                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteList = (from c in db.PolSourceSites select c).OrderBy(c => c.PolSourceSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceSite info
                        jsonRet = polSourceSiteController.GetPolSourceSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(polSourceSiteList[0].PolSourceSiteID, ((List<PolSourceSite>)ret.Value)[0].PolSourceSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceSite info
                           IActionResult jsonRet2 = polSourceSiteController.GetPolSourceSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(polSourceSiteList[1].PolSourceSiteID, ((List<PolSourceSite>)ret2.Value)[0].PolSourceSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void PolSourceSite_Controller_GetPolSourceSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteFirst = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query(), db, ContactID);
                        polSourceSiteFirst = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteFirst.PolSourceSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(polSourceSiteFirst.PolSourceSiteID, ((PolSourceSite)ret.Value).PolSourceSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = polSourceSiteController.GetPolSourceSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult polSourceSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(polSourceSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void PolSourceSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteLast = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteLast = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteLast.PolSourceSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    PolSourceSite polSourceSiteRet = (PolSourceSite)ret.Value;
                    Assert.Equal(polSourceSiteLast.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because PolSourceSiteID exist
                    IActionResult jsonRet2 = polSourceSiteController.Post(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceSite
                    polSourceSiteRet.PolSourceSiteID = 0;
                    IActionResult jsonRet3 = polSourceSiteController.Post(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = polSourceSiteController.Delete(polSourceSiteRet, LanguageRequest.ToString());
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
        public void PolSourceSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteLast = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteLast = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteLast.PolSourceSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceSite polSourceSiteRet = (PolSourceSite)Ret.Value;
                    Assert.Equal(polSourceSiteLast.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = polSourceSiteController.Put(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult polSourceSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(polSourceSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because PolSourceSiteID of 0 does not exist
                    polSourceSiteRet.PolSourceSiteID = 0;
                    IActionResult jsonRet3 = polSourceSiteController.Put(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult polSourceSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(polSourceSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void PolSourceSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteController polSourceSiteController = new PolSourceSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteController.DatabaseType);

                    PolSourceSite polSourceSiteLast = new PolSourceSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(query, db, ContactID);
                        polSourceSiteLast = (from c in db.PolSourceSites select c).FirstOrDefault();
                    }

                    // ok with PolSourceSite info
                    IActionResult jsonRet = polSourceSiteController.GetPolSourceSiteWithID(polSourceSiteLast.PolSourceSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceSite polSourceSiteRet = (PolSourceSite)Ret.Value;
                    Assert.Equal(polSourceSiteLast.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added PolSourceSite
                    polSourceSiteRet.PolSourceSiteID = 0;
                    IActionResult jsonRet3 = polSourceSiteController.Post(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    PolSourceSite polSourceSite = (PolSourceSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = polSourceSiteController.Delete(polSourceSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because PolSourceSiteID of 0 does not exist
                    polSourceSiteRet.PolSourceSiteID = 0;
                    IActionResult jsonRet4 = polSourceSiteController.Delete(polSourceSiteRet, LanguageRequest.ToString());
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
