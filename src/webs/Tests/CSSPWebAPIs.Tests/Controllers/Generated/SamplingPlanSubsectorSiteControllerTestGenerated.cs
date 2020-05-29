using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void SamplingPlanSubsectorSite_Controller_GetSamplingPlanSubsectorSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

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
                    IHttpActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>>;
                    Assert.AreEqual(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID, ret.Content[0].SamplingPlanSubsectorSiteID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>>;
                        Assert.AreEqual(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID, ret.Content[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanSubsectorSite info
                           IHttpActionResult jsonRet2 = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlanSubsectorSite>>;
                           Assert.AreEqual(samplingPlanSubsectorSiteList[1].SamplingPlanSubsectorSiteID, ret2.Content[0].SamplingPlanSubsectorSiteID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void SamplingPlanSubsectorSite_Controller_GetSamplingPlanSubsectorSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteFirst = new SamplingPlanSubsectorSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query(), db, ContactID);
                        samplingPlanSubsectorSiteFirst = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IHttpActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorSiteFirst.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNull(samplingPlanSubsectorSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void SamplingPlanSubsectorSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

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
                    IHttpActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because SamplingPlanSubsectorSiteID exist
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNull(samplingPlanSubsectorSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added SamplingPlanSubsectorSite
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    samplingPlanSubsectorSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanSubsectorSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanSubsectorSite");
                    IHttpActionResult jsonRet3 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNotNull(samplingPlanSubsectorSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNotNull(samplingPlanSubsectorSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void SamplingPlanSubsectorSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteLast = new SamplingPlanSubsectorSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(query, db, ContactID);
                        samplingPlanSubsectorSiteLast = (from c in db.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsectorSite info
                    IHttpActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNotNull(samplingPlanSubsectorSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because SamplingPlanSubsectorSiteID of 0 does not exist
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IHttpActionResult jsonRet3 = samplingPlanSubsectorSiteController.Put(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNull(samplingPlanSubsectorSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void SamplingPlanSubsectorSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorSiteController samplingPlanSubsectorSiteController = new SamplingPlanSubsectorSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorSiteController.DatabaseType);

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
                    IHttpActionResult jsonRet = samplingPlanSubsectorSiteController.GetSamplingPlanSubsectorSiteWithID(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorSiteLast.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added SamplingPlanSubsectorSite
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    samplingPlanSubsectorSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanSubsectorSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanSubsectorSite");
                    IHttpActionResult jsonRet3 = samplingPlanSubsectorSiteController.Post(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNotNull(samplingPlanSubsectorSiteRet3);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = samplingPlanSubsectorSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNotNull(samplingPlanSubsectorSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because SamplingPlanSubsectorSiteID of 0 does not exist
                    samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID = 0;
                    IHttpActionResult jsonRet4 = samplingPlanSubsectorSiteController.Delete(samplingPlanSubsectorSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsectorSite>;
                    Assert.IsNull(samplingPlanSubsectorSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
