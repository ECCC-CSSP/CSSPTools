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
    public partial class MWQMRunControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMRun_Controller_GetMWQMRunList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunFirst = new MWQMRun();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(query, db, ContactID);
                        mwqmRunFirst = (from c in db.MWQMRuns select c).FirstOrDefault();
                        count = (from c in db.MWQMRuns select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMRun info
                    IActionResult jsonRet = mwqmRunController.GetMWQMRunList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmRunFirst.MWQMRunID, ((List<MWQMRun>)ret.Value)[0].MWQMRunID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMRun>)ret.Value).Count);

                    List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(query, db, ContactID);
                        mwqmRunList = (from c in db.MWQMRuns select c).OrderBy(c => c.MWQMRunID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMRuns select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMRun info
                        jsonRet = mwqmRunController.GetMWQMRunList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmRunList[0].MWQMRunID, ((List<MWQMRun>)ret.Value)[0].MWQMRunID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMRun>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMRun info
                           IActionResult jsonRet2 = mwqmRunController.GetMWQMRunList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmRunList[1].MWQMRunID, ((List<MWQMRun>)ret2.Value)[0].MWQMRunID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMRun>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMRun_Controller_GetMWQMRunWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunFirst = new MWQMRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query(), db, ContactID);
                        mwqmRunFirst = (from c in db.MWQMRuns select c).FirstOrDefault();
                    }

                    // ok with MWQMRun info
                    IActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunFirst.MWQMRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmRunFirst.MWQMRunID, ((MWQMRun)ret.Value).MWQMRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmRunController.GetMWQMRunWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmRunRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmRunRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMRun_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunLast = new MWQMRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMRunService mwqmRunService = new MWQMRunService(query, db, ContactID);
                        mwqmRunLast = (from c in db.MWQMRuns select c).FirstOrDefault();
                    }

                    // ok with MWQMRun info
                    IActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunLast.MWQMRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMRun mwqmRunRet = (MWQMRun)ret.Value;
                    Assert.Equal(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMRunID exist
                    IActionResult jsonRet2 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMRun
                    mwqmRunRet.MWQMRunID = 0;
                    IActionResult jsonRet3 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
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
        public void MWQMRun_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunLast = new MWQMRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMRunService mwqmRunService = new MWQMRunService(query, db, ContactID);
                        mwqmRunLast = (from c in db.MWQMRuns select c).FirstOrDefault();
                    }

                    // ok with MWQMRun info
                    IActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunLast.MWQMRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMRun mwqmRunRet = (MWQMRun)Ret.Value;
                    Assert.Equal(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmRunController.Put(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmRunRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmRunRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMRunID of 0 does not exist
                    mwqmRunRet.MWQMRunID = 0;
                    IActionResult jsonRet3 = mwqmRunController.Put(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmRunRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmRunRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMRun_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunLast = new MWQMRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMRunService mwqmRunService = new MWQMRunService(query, db, ContactID);
                        mwqmRunLast = (from c in db.MWQMRuns select c).FirstOrDefault();
                    }

                    // ok with MWQMRun info
                    IActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunLast.MWQMRunID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMRun mwqmRunRet = (MWQMRun)Ret.Value;
                    Assert.Equal(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMRun
                    mwqmRunRet.MWQMRunID = 0;
                    IActionResult jsonRet3 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMRun mwqmRun = (MWQMRun)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMRunID of 0 does not exist
                    mwqmRunRet.MWQMRunID = 0;
                    IActionResult jsonRet4 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
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
