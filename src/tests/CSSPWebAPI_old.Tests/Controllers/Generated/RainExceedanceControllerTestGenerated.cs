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
    public partial class RainExceedanceControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void RainExceedance_Controller_GetRainExceedanceList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                        count = (from c in db.RainExceedances select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RainExceedance info
                    IActionResult jsonRet = rainExceedanceController.GetRainExceedanceList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(rainExceedanceFirst.RainExceedanceID, ((List<RainExceedance>)ret.Value)[0].RainExceedanceID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<RainExceedance>)ret.Value).Count);

                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceList = (from c in db.RainExceedances select c).OrderBy(c => c.RainExceedanceID).Skip(0).Take(2).ToList();
                        count = (from c in db.RainExceedances select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RainExceedance info
                        jsonRet = rainExceedanceController.GetRainExceedanceList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(rainExceedanceList[0].RainExceedanceID, ((List<RainExceedance>)ret.Value)[0].RainExceedanceID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<RainExceedance>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RainExceedance info
                           IActionResult jsonRet2 = rainExceedanceController.GetRainExceedanceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(rainExceedanceList[1].RainExceedanceID, ((List<RainExceedance>)ret2.Value)[0].RainExceedanceID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<RainExceedance>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void RainExceedance_Controller_GetRainExceedanceWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query(), db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceFirst.RainExceedanceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(rainExceedanceFirst.RainExceedanceID, ((RainExceedance)ret.Value).RainExceedanceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = rainExceedanceController.GetRainExceedanceWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult rainExceedanceRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(rainExceedanceRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void RainExceedance_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceFirst.RainExceedanceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    RainExceedance rainExceedanceRet = (RainExceedance)ret.Value;
                    Assert.Equal(rainExceedanceFirst.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because RainExceedanceID exist
                    IActionResult jsonRet2 = rainExceedanceController.Post(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RainExceedance
                    rainExceedanceRet.RainExceedanceID = 0;
                    IActionResult jsonRet3 = rainExceedanceController.Post(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = rainExceedanceController.Delete(rainExceedanceRet, LanguageRequest.ToString());
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
        public void RainExceedance_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceFirst.RainExceedanceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RainExceedance rainExceedanceRet = (RainExceedance)Ret.Value;
                    Assert.Equal(rainExceedanceFirst.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = rainExceedanceController.Put(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult rainExceedanceRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(rainExceedanceRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because RainExceedanceID of 0 does not exist
                    rainExceedanceRet.RainExceedanceID = 0;
                    IActionResult jsonRet3 = rainExceedanceController.Put(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult rainExceedanceRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(rainExceedanceRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void RainExceedance_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceFirst.RainExceedanceID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RainExceedance rainExceedanceRet = (RainExceedance)Ret.Value;
                    Assert.Equal(rainExceedanceFirst.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added RainExceedance
                    rainExceedanceRet.RainExceedanceID = 0;
                    IActionResult jsonRet3 = rainExceedanceController.Post(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    RainExceedance rainExceedance = (RainExceedance)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = rainExceedanceController.Delete(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because RainExceedanceID of 0 does not exist
                    rainExceedanceRet.RainExceedanceID = 0;
                    IActionResult jsonRet4 = rainExceedanceController.Delete(rainExceedanceRet, LanguageRequest.ToString());
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
