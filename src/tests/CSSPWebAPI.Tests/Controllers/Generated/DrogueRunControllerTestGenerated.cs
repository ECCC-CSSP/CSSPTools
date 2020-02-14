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
    public partial class DrogueRunControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void DrogueRun_Controller_GetDrogueRunList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunController drogueRunController = new DrogueRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunController.DatabaseType);

                    DrogueRun drogueRunFirst = new DrogueRun();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunService drogueRunService = new DrogueRunService(query, db, ContactID);
                        drogueRunFirst = (from c in db.DrogueRuns select c).FirstOrDefault();
                        count = (from c in db.DrogueRuns select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with DrogueRun info
                    IActionResult jsonRet = drogueRunController.GetDrogueRunList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(drogueRunFirst.DrogueRunID, ((List<DrogueRun>)ret.Value)[0].DrogueRunID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<DrogueRun>)ret.Value).Count);

                    List<DrogueRun> drogueRunList = new List<DrogueRun>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunService drogueRunService = new DrogueRunService(query, db, ContactID);
                        drogueRunList = (from c in db.DrogueRuns select c).OrderBy(c => c.DrogueRunID).Skip(0).Take(2).ToList();
                        count = (from c in db.DrogueRuns select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with DrogueRun info
                        jsonRet = drogueRunController.GetDrogueRunList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(drogueRunList[0].DrogueRunID, ((List<DrogueRun>)ret.Value)[0].DrogueRunID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<DrogueRun>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DrogueRun info
                           IActionResult jsonRet2 = drogueRunController.GetDrogueRunList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(drogueRunList[1].DrogueRunID, ((List<DrogueRun>)ret2.Value)[0].DrogueRunID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<DrogueRun>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void DrogueRun_Controller_GetDrogueRunWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunController drogueRunController = new DrogueRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunController.DatabaseType);

                    DrogueRun drogueRunFirst = new DrogueRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        DrogueRunService drogueRunService = new DrogueRunService(new Query(), db, ContactID);
                        drogueRunFirst = (from c in db.DrogueRuns select c).FirstOrDefault();
                    }

                    // ok with DrogueRun info
                    IActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunFirst.DrogueRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(drogueRunFirst.DrogueRunID, ((DrogueRun)ret.Value).DrogueRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = drogueRunController.GetDrogueRunWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult drogueRunRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(drogueRunRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void DrogueRun_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunController drogueRunController = new DrogueRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunController.DatabaseType);

                    DrogueRun drogueRunLast = new DrogueRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunService drogueRunService = new DrogueRunService(query, db, ContactID);
                        drogueRunLast = (from c in db.DrogueRuns select c).FirstOrDefault();
                    }

                    // ok with DrogueRun info
                    IActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunLast.DrogueRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    DrogueRun drogueRunRet = (DrogueRun)ret.Value;
                    Assert.Equal(drogueRunLast.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because DrogueRunID exist
                    IActionResult jsonRet2 = drogueRunController.Post(drogueRunRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added DrogueRun
                    drogueRunRet.DrogueRunID = 0;
                    IActionResult jsonRet3 = drogueRunController.Post(drogueRunRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = drogueRunController.Delete(drogueRunRet, LanguageRequest.ToString());
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
        public void DrogueRun_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunController drogueRunController = new DrogueRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunController.DatabaseType);

                    DrogueRun drogueRunLast = new DrogueRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DrogueRunService drogueRunService = new DrogueRunService(query, db, ContactID);
                        drogueRunLast = (from c in db.DrogueRuns select c).FirstOrDefault();
                    }

                    // ok with DrogueRun info
                    IActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunLast.DrogueRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    DrogueRun drogueRunRet = (DrogueRun)Ret.Value;
                    Assert.Equal(drogueRunLast.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = drogueRunController.Put(drogueRunRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult drogueRunRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(drogueRunRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because DrogueRunID of 0 does not exist
                    drogueRunRet.DrogueRunID = 0;
                    IActionResult jsonRet3 = drogueRunController.Put(drogueRunRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult drogueRunRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(drogueRunRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void DrogueRun_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunController drogueRunController = new DrogueRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunController.DatabaseType);

                    DrogueRun drogueRunLast = new DrogueRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunService drogueRunService = new DrogueRunService(query, db, ContactID);
                        drogueRunLast = (from c in db.DrogueRuns select c).FirstOrDefault();
                    }

                    // ok with DrogueRun info
                    IActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunLast.DrogueRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    DrogueRun drogueRunRet = (DrogueRun)Ret.Value;
                    Assert.Equal(drogueRunLast.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added DrogueRun
                    drogueRunRet.DrogueRunID = 0;
                    IActionResult jsonRet3 = drogueRunController.Post(drogueRunRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    DrogueRun drogueRun = (DrogueRun)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = drogueRunController.Delete(drogueRunRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because DrogueRunID of 0 does not exist
                    drogueRunRet.DrogueRunID = 0;
                    IActionResult jsonRet4 = drogueRunController.Delete(drogueRunRet, LanguageRequest.ToString());
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
