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
    public partial class SamplingPlanEmailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SamplingPlanEmail_Controller_GetSamplingPlanEmailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                        count = (from c in db.SamplingPlanEmails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SamplingPlanEmail info
                    IActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, ((List<SamplingPlanEmail>)ret.Value)[0].SamplingPlanEmailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanEmail>)ret.Value).Count);

                    List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailList = (from c in db.SamplingPlanEmails select c).OrderBy(c => c.SamplingPlanEmailID).Skip(0).Take(2).ToList();
                        count = (from c in db.SamplingPlanEmails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SamplingPlanEmail info
                        jsonRet = samplingPlanEmailController.GetSamplingPlanEmailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(samplingPlanEmailList[0].SamplingPlanEmailID, ((List<SamplingPlanEmail>)ret.Value)[0].SamplingPlanEmailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanEmail>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanEmail info
                           IActionResult jsonRet2 = samplingPlanEmailController.GetSamplingPlanEmailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(samplingPlanEmailList[1].SamplingPlanEmailID, ((List<SamplingPlanEmail>)ret2.Value)[0].SamplingPlanEmailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<SamplingPlanEmail>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SamplingPlanEmail_Controller_GetSamplingPlanEmailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query(), db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailFirst.SamplingPlanEmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, ((SamplingPlanEmail)ret.Value).SamplingPlanEmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = samplingPlanEmailController.GetSamplingPlanEmailWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult samplingPlanEmailRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(samplingPlanEmailRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SamplingPlanEmail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailFirst.SamplingPlanEmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    SamplingPlanEmail samplingPlanEmailRet = (SamplingPlanEmail)ret.Value;
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SamplingPlanEmailID exist
                    IActionResult jsonRet2 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlanEmail
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IActionResult jsonRet3 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
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
        public void SamplingPlanEmail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailFirst.SamplingPlanEmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlanEmail samplingPlanEmailRet = (SamplingPlanEmail)Ret.Value;
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = samplingPlanEmailController.Put(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult samplingPlanEmailRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(samplingPlanEmailRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SamplingPlanEmailID of 0 does not exist
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IActionResult jsonRet3 = samplingPlanEmailController.Put(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult samplingPlanEmailRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(samplingPlanEmailRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SamplingPlanEmail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailFirst.SamplingPlanEmailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SamplingPlanEmail samplingPlanEmailRet = (SamplingPlanEmail)Ret.Value;
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SamplingPlanEmail
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IActionResult jsonRet3 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    SamplingPlanEmail samplingPlanEmail = (SamplingPlanEmail)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SamplingPlanEmailID of 0 does not exist
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IActionResult jsonRet4 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
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
