using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>>;
                    Assert.Equal(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID, ret.Content[0].SamplingPlanSubsectorSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>>;
                        Assert.Equal(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID, ret.Content[0].SamplingPlanSubsectorSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanSubsectorSite info
                           IActionResult jsonRet2 = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>>;
                           Assert.Equal(samplingPlanSubsectorSiteList[1].SamplingPlanSubsectorSiteID, ret2.Content[0].SamplingPlanSubsectorSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.Null(samplingPlanSubsectorSiteRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SamplingPlanSubsectorSiteID exist
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.Null(samplingPlanSubsectorSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlanSubsectorSite
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.NotNull(samplingPlanSubsectorSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.NotNull(samplingPlanSubsectorSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.NotNull(samplingPlanSubsectorSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SamplingPlanSubsectorSiteID of 0 does not exist
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.Null(samplingPlanSubsectorSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SamplingPlanSubsectorSite
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.NotNull(samplingPlanSubsectorSiteRet3);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = samplingPlanSubsectorSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.NotNull(samplingPlanSubsectorSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SamplingPlanSubsectorSiteID of 0 does not exist
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IActionResult jsonRet4 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.Null(samplingPlanSubsectorSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
