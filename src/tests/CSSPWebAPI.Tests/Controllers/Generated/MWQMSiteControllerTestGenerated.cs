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
    public partial class MWQMSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSite_Controller_GetMWQMSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteFirst = new MWQMSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteFirst = (from c in db.MWQMSites select c).FirstOrDefault();
                        count = (from c in db.MWQMSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSite info
                    IActionResult jsonRet = mwqmSiteController.GetMWQMSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmSiteFirst.MWQMSiteID, ((List<MWQMSite>)ret.Value)[0].MWQMSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSite>)ret.Value).Count);

                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteList = (from c in db.MWQMSites select c).OrderBy(c => c.MWQMSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSite info
                        jsonRet = mwqmSiteController.GetMWQMSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmSiteList[0].MWQMSiteID, ((List<MWQMSite>)ret.Value)[0].MWQMSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSite info
                           IActionResult jsonRet2 = mwqmSiteController.GetMWQMSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmSiteList[1].MWQMSiteID, ((List<MWQMSite>)ret2.Value)[0].MWQMSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSite_Controller_GetMWQMSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteFirst = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query(), db, ContactID);
                        mwqmSiteFirst = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteFirst.MWQMSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmSiteFirst.MWQMSiteID, ((MWQMSite)ret.Value).MWQMSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSiteController.GetMWQMSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteLast = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteLast = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteLast.MWQMSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMSite mwqmSiteRet = (MWQMSite)ret.Value;
                    Assert.Equal(mwqmSiteLast.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSiteID exist
                    IActionResult jsonRet2 = mwqmSiteController.Post(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSite
                    mwqmSiteRet.MWQMSiteID = 0;
                    IActionResult jsonRet3 = mwqmSiteController.Post(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSiteController.Delete(mwqmSiteRet, LanguageRequest.ToString());
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
        public void MWQMSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteLast = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteLast = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteLast.MWQMSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSite mwqmSiteRet = (MWQMSite)Ret.Value;
                    Assert.Equal(mwqmSiteLast.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSiteController.Put(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSiteID of 0 does not exist
                    mwqmSiteRet.MWQMSiteID = 0;
                    IActionResult jsonRet3 = mwqmSiteController.Put(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteLast = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteLast = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteLast.MWQMSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSite mwqmSiteRet = (MWQMSite)Ret.Value;
                    Assert.Equal(mwqmSiteLast.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSite
                    mwqmSiteRet.MWQMSiteID = 0;
                    IActionResult jsonRet3 = mwqmSiteController.Post(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMSite mwqmSite = (MWQMSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSiteController.Delete(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSiteID of 0 does not exist
                    mwqmSiteRet.MWQMSiteID = 0;
                    IActionResult jsonRet4 = mwqmSiteController.Delete(mwqmSiteRet, LanguageRequest.ToString());
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
