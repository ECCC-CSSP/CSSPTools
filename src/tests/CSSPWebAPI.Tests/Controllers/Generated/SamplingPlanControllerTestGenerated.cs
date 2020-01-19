using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class SamplingPlanControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SamplingPlan_Controller_GetSamplingPlanList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanController samplingPlanController = new SamplingPlanController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanController.DatabaseType);

                    SamplingPlan samplingPlanFirst = new SamplingPlan();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(query, db, ContactID);
                        samplingPlanFirst = (from c in db.SamplingPlans select c).FirstOrDefault();
                        count = (from c in db.SamplingPlans select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SamplingPlan info
                    IHttpActionResult jsonRet = samplingPlanController.GetSamplingPlanList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlan>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlan>>;
                    Assert.Equal(samplingPlanFirst.SamplingPlanID, ret.Content[0].SamplingPlanID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(query, db, ContactID);
                        samplingPlanList = (from c in db.SamplingPlans select c).OrderBy(c => c.SamplingPlanID).Skip(0).Take(2).ToList();
                        count = (from c in db.SamplingPlans select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SamplingPlan info
                        jsonRet = samplingPlanController.GetSamplingPlanList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlan>>;
                        Assert.Equal(samplingPlanList[0].SamplingPlanID, ret.Content[0].SamplingPlanID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlan info
                           IHttpActionResult jsonRet2 = samplingPlanController.GetSamplingPlanList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlan>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlan>>;
                           Assert.Equal(samplingPlanList[1].SamplingPlanID, ret2.Content[0].SamplingPlanID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SamplingPlan_Controller_GetSamplingPlanWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanController samplingPlanController = new SamplingPlanController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanController.DatabaseType);

                    SamplingPlan samplingPlanFirst = new SamplingPlan();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query(), db, ContactID);
                        samplingPlanFirst = (from c in db.SamplingPlans select c).FirstOrDefault();
                    }

                    // ok with SamplingPlan info
                    IHttpActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanFirst.SamplingPlanID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlan> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlan>;
                    SamplingPlan samplingPlanRet = Ret.Content;
                    Assert.Equal(samplingPlanFirst.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = samplingPlanController.GetSamplingPlanWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.IsNull(samplingPlanRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SamplingPlan_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanController samplingPlanController = new SamplingPlanController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanController.DatabaseType);

                    SamplingPlan samplingPlanLast = new SamplingPlan();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanService samplingPlanService = new SamplingPlanService(query, db, ContactID);
                        samplingPlanLast = (from c in db.SamplingPlans select c).FirstOrDefault();
                    }

                    // ok with SamplingPlan info
                    IHttpActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanLast.SamplingPlanID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlan> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlan>;
                    SamplingPlan samplingPlanRet = Ret.Content;
                    Assert.Equal(samplingPlanLast.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because SamplingPlanID exist
                    IHttpActionResult jsonRet2 = samplingPlanController.Post(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.IsNull(samplingPlanRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlan
                    samplingPlanRet.SamplingPlanID = 0;
                    samplingPlanRet.SamplingPlanName = samplingPlanRet.SamplingPlanName.Replace(".txt", "_a.txt");
                    samplingPlanController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlan");
                    IHttpActionResult jsonRet3 = samplingPlanController.Post(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlan> samplingPlanRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlan>;
                    Assert.NotNull(samplingPlanRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = samplingPlanController.Delete(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.NotNull(samplingPlanRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void SamplingPlan_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanController samplingPlanController = new SamplingPlanController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanController.DatabaseType);

                    SamplingPlan samplingPlanLast = new SamplingPlan();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanService samplingPlanService = new SamplingPlanService(query, db, ContactID);
                        samplingPlanLast = (from c in db.SamplingPlans select c).FirstOrDefault();
                    }

                    // ok with SamplingPlan info
                    IHttpActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanLast.SamplingPlanID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlan> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlan>;
                    SamplingPlan samplingPlanRet = Ret.Content;
                    Assert.Equal(samplingPlanLast.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = samplingPlanController.Put(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.NotNull(samplingPlanRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because SamplingPlanID of 0 does not exist
                    samplingPlanRet.SamplingPlanID = 0;
                    IHttpActionResult jsonRet3 = samplingPlanController.Put(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.IsNull(samplingPlanRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SamplingPlan_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanController samplingPlanController = new SamplingPlanController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanController.DatabaseType);

                    SamplingPlan samplingPlanLast = new SamplingPlan();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanService samplingPlanService = new SamplingPlanService(query, db, ContactID);
                        samplingPlanLast = (from c in db.SamplingPlans select c).FirstOrDefault();
                    }

                    // ok with SamplingPlan info
                    IHttpActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanLast.SamplingPlanID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlan> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlan>;
                    SamplingPlan samplingPlanRet = Ret.Content;
                    Assert.Equal(samplingPlanLast.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added SamplingPlan
                    samplingPlanRet.SamplingPlanID = 0;
                    samplingPlanRet.SamplingPlanName = samplingPlanRet.SamplingPlanName.Replace(".txt", "_a.txt");
                    samplingPlanController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlan");
                    IHttpActionResult jsonRet3 = samplingPlanController.Post(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlan> samplingPlanRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlan>;
                    Assert.NotNull(samplingPlanRet3);
                    SamplingPlan samplingPlan = samplingPlanRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = samplingPlanController.Delete(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.NotNull(samplingPlanRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because SamplingPlanID of 0 does not exist
                    samplingPlanRet.SamplingPlanID = 0;
                    IHttpActionResult jsonRet4 = samplingPlanController.Delete(samplingPlanRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlan> samplingPlanRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlan>;
                    Assert.IsNull(samplingPlanRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
