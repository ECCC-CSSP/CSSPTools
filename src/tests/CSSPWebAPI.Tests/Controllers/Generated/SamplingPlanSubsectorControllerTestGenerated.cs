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
    public partial class SamplingPlanSubsectorControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SamplingPlanSubsector_Controller_GetSamplingPlanSubsectorList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorFirst = new SamplingPlanSubsector();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorFirst = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                        count = (from c in db.SamplingPlanSubsectors select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(samplingPlanSubsectorFirst.SamplingPlanSubsectorID, ((List<SamplingPlanSubsector>)ret.Value)[0].SamplingPlanSubsectorID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanSubsector>)ret.Value).Count);

                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorList = (from c in db.SamplingPlanSubsectors select c).OrderBy(c => c.SamplingPlanSubsectorID).Skip(0).Take(2).ToList();
                        count = (from c in db.SamplingPlanSubsectors select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SamplingPlanSubsector info
                        jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(samplingPlanSubsectorList[0].SamplingPlanSubsectorID, ((List<SamplingPlanSubsector>)ret.Value)[0].SamplingPlanSubsectorID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanSubsector>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanSubsector info
                           IActionResult jsonRet2 = samplingPlanSubsectorController.GetSamplingPlanSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(samplingPlanSubsectorList[1].SamplingPlanSubsectorID, ((List<SamplingPlanSubsector>)ret2.Value)[0].SamplingPlanSubsectorID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanSubsector>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SamplingPlanSubsector_Controller_GetSamplingPlanSubsectorWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorFirst = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query(), db, ContactID);
                        samplingPlanSubsectorFirst = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorFirst.SamplingPlanSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(samplingPlanSubsectorFirst.SamplingPlanSubsectorID, ((SamplingPlanSubsector)ret.Value).SamplingPlanSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult samplingPlanSubsectorRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(samplingPlanSubsectorRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SamplingPlanSubsector_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    SamplingPlanSubsector samplingPlanSubsectorRet = (SamplingPlanSubsector)ret.Value;
                    Assert.Equal(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SamplingPlanSubsectorID exist
                    IActionResult jsonRet2 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlanSubsector
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
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
        public void SamplingPlanSubsector_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlanSubsector samplingPlanSubsectorRet = (SamplingPlanSubsector)Ret.Value;
                    Assert.Equal(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorController.Put(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult samplingPlanSubsectorRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(samplingPlanSubsectorRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SamplingPlanSubsectorID of 0 does not exist
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorController.Put(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult samplingPlanSubsectorRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(samplingPlanSubsectorRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SamplingPlanSubsector_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlanSubsector samplingPlanSubsectorRet = (SamplingPlanSubsector)Ret.Value;
                    Assert.Equal(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SamplingPlanSubsector
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    SamplingPlanSubsector samplingPlanSubsector = (SamplingPlanSubsector)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SamplingPlanSubsectorID of 0 does not exist
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet4 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
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
