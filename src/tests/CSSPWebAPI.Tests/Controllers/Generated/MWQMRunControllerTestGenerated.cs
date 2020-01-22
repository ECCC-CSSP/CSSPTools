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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMRun>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMRun>>;
                    Assert.Equal(mwqmRunFirst.MWQMRunID, ret.Content[0].MWQMRunID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMRun>>;
                        Assert.Equal(mwqmRunList[0].MWQMRunID, ret.Content[0].MWQMRunID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMRun info
                           IActionResult jsonRet2 = mwqmRunController.GetMWQMRunList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMRun>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMRun>>;
                           Assert.Equal(mwqmRunList[1].MWQMRunID, ret2.Content[0].MWQMRunID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.Equal(mwqmRunFirst.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmRunController.GetMWQMRunWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.Null(mwqmRunRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.Equal(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMRunID exist
                    IActionResult jsonRet2 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.Null(mwqmRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMRun
                    mwqmRunRet.MWQMRunID = 0;
                    mwqmRunController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmRunController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmRun");
                    IActionResult jsonRet3 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMRun> mwqmRunRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMRun>;
                    Assert.NotNull(mwqmRunRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.NotNull(mwqmRunRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.Equal(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmRunController.Put(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.NotNull(mwqmRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMRunID of 0 does not exist
                    mwqmRunRet.MWQMRunID = 0;
                    IActionResult jsonRet3 = mwqmRunController.Put(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.Null(mwqmRunRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.Equal(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMRun
                    mwqmRunRet.MWQMRunID = 0;
                    mwqmRunController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmRunController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmRun");
                    IActionResult jsonRet3 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMRun> mwqmRunRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMRun>;
                    Assert.NotNull(mwqmRunRet3);
                    MWQMRun mwqmRun = mwqmRunRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.NotNull(mwqmRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMRunID of 0 does not exist
                    mwqmRunRet.MWQMRunID = 0;
                    IActionResult jsonRet4 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.Null(mwqmRunRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
