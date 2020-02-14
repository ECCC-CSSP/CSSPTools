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
                    IActionResult jsonRet = samplingPlanController.GetSamplingPlanList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(samplingPlanFirst.SamplingPlanID, ((List<SamplingPlan>)ret.Value)[0].SamplingPlanID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlan>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(samplingPlanList[0].SamplingPlanID, ((List<SamplingPlan>)ret.Value)[0].SamplingPlanID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlan>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlan info
                           IActionResult jsonRet2 = samplingPlanController.GetSamplingPlanList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(samplingPlanList[1].SamplingPlanID, ((List<SamplingPlan>)ret2.Value)[0].SamplingPlanID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlan>)ret2.Value).Count);
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
                    IActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanFirst.SamplingPlanID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(samplingPlanFirst.SamplingPlanID, ((SamplingPlan)ret.Value).SamplingPlanID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = samplingPlanController.GetSamplingPlanWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult samplingPlanRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(samplingPlanRet2);
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
                    IActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanLast.SamplingPlanID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    SamplingPlan samplingPlanRet = (SamplingPlan)ret.Value;
                    Assert.Equal(samplingPlanLast.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SamplingPlanID exist
                    IActionResult jsonRet2 = samplingPlanController.Post(samplingPlanRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlan
                    samplingPlanRet.SamplingPlanID = 0;
                    samplingPlanRet.SamplingPlanName = samplingPlanRet.SamplingPlanName.Replace(".txt", "_a.txt");
                    IActionResult jsonRet3 = samplingPlanController.Post(samplingPlanRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = samplingPlanController.Delete(samplingPlanRet, LanguageRequest.ToString());
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
                    IActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanLast.SamplingPlanID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlan samplingPlanRet = (SamplingPlan)Ret.Value;
                    Assert.Equal(samplingPlanLast.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = samplingPlanController.Put(samplingPlanRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult samplingPlanRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(samplingPlanRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SamplingPlanID of 0 does not exist
                    samplingPlanRet.SamplingPlanID = 0;
                    IActionResult jsonRet3 = samplingPlanController.Put(samplingPlanRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult samplingPlanRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(samplingPlanRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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
                    IActionResult jsonRet = samplingPlanController.GetSamplingPlanWithID(samplingPlanLast.SamplingPlanID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlan samplingPlanRet = (SamplingPlan)Ret.Value;
                    Assert.Equal(samplingPlanLast.SamplingPlanID, samplingPlanRet.SamplingPlanID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SamplingPlan
                    samplingPlanRet.SamplingPlanID = 0;
                    samplingPlanRet.SamplingPlanName = samplingPlanRet.SamplingPlanName.Replace(".txt", "_a.txt");
                    IActionResult jsonRet3 = samplingPlanController.Post(samplingPlanRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    SamplingPlan samplingPlan = (SamplingPlan)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = samplingPlanController.Delete(samplingPlanRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SamplingPlanID of 0 does not exist
                    samplingPlanRet.SamplingPlanID = 0;
                    IActionResult jsonRet4 = samplingPlanController.Delete(samplingPlanRet, LanguageRequest.ToString());
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
