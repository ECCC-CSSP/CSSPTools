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
    public partial class SamplingPlanSubsectorSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SamplingPlanSubsectorSite_Controller_GetSamplingPlanSubsectorSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteFirst = new SamplingPlanSubsectorSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(query, db, ContactID);
                        samplingPlanSubsectorSiteFirst = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                        count = (from c in db.SamplingPlanSubsectorSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID, ((List<SamplingPlanSubsectorSite>)ret.Value)[0].SamplingPlanSubsectorSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanSubsectorSite>)ret.Value).Count);

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(query, db, ContactID);
                        samplingPlanSubsectorSiteList = (from c in db.SamplingPlanSubsectorSites select c).OrderBy(c => c.SamplingPlanSubsectorSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.SamplingPlanSubsectorSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SamplingPlanSubsectorSite info
                        jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID, ((List<SamplingPlanSubsectorSite>)ret.Value)[0].SamplingPlanSubsectorSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanSubsectorSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanSubsectorSite info
                           IActionResult jsonRet2 = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(samplingPlanSubsectorSiteList[1].SamplingPlanSubsectorSiteID, ((List<SamplingPlanSubsectorSite>)ret2.Value)[0].SamplingPlanSubsectorSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanSubsectorSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SamplingPlanSubsectorSite_Controller_GetSamplingPlanSubsectorSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteFirst = new SamplingPlanSubsectorSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query(), db, ContactID);
                        samplingPlanSubsectorSiteFirst = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID, ((SamplingPlanSubsectorSite)ret.Value).SamplingPlanSubsectorSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult samplingPlanSubsectorSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(samplingPlanSubsectorSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SamplingPlanSubsectorSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteLast = new SamplingPlanSubsectorSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(query, db, ContactID);
                        samplingPlanSubsectorSiteLast = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = (SamplingPlanSubsectorSite)ret.Value;
                    Assert.Equal(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SamplingPlanSubsectorSiteID exist
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlanSubsectorSite
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
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
        public void SamplingPlanSubsectorSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteLast = new SamplingPlanSubsectorSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(query, db, ContactID);
                        samplingPlanSubsectorSiteLast = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = (SamplingPlanSubsectorSite)Ret.Value;
                    Assert.Equal(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult samplingPlanSubsectorSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(samplingPlanSubsectorSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SamplingPlanSubsectorSiteID of 0 does not exist
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult samplingPlanSubsectorSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(samplingPlanSubsectorSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SamplingPlanSubsectorSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteLast = new SamplingPlanSubsectorSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(query, db, ContactID);
                        samplingPlanSubsectorSiteLast = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = (SamplingPlanSubsectorSite)Ret.Value;
                    Assert.Equal(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SamplingPlanSubsectorSite
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (SamplingPlanSubsectorSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SamplingPlanSubsectorSiteID of 0 does not exist
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet4 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
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
