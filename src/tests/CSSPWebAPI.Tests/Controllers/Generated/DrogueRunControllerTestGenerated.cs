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
                    IHttpActionResult jsonRet = drogueRunController.GetDrogueRunList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<DrogueRun>> ret = jsonRet as OkNegotiatedContentResult<List<DrogueRun>>;
                    Assert.Equal(drogueRunFirst.DrogueRunID, ret.Content[0].DrogueRunID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<DrogueRun>>;
                        Assert.Equal(drogueRunList[0].DrogueRunID, ret.Content[0].DrogueRunID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DrogueRun info
                           IHttpActionResult jsonRet2 = drogueRunController.GetDrogueRunList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<DrogueRun>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<DrogueRun>>;
                           Assert.Equal(drogueRunList[1].DrogueRunID, ret2.Content[0].DrogueRunID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    IHttpActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunFirst.DrogueRunID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRun> Ret = jsonRet as OkNegotiatedContentResult<DrogueRun>;
                    DrogueRun drogueRunRet = Ret.Content;
                    Assert.Equal(drogueRunFirst.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = drogueRunController.GetDrogueRunWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.IsNull(drogueRunRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
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
                    IHttpActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunLast.DrogueRunID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRun> Ret = jsonRet as OkNegotiatedContentResult<DrogueRun>;
                    DrogueRun drogueRunRet = Ret.Content;
                    Assert.Equal(drogueRunLast.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because DrogueRunID exist
                    IHttpActionResult jsonRet2 = drogueRunController.Post(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.IsNull(drogueRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added DrogueRun
                    drogueRunRet.DrogueRunID = 0;
                    drogueRunController.Request = new System.Net.Http.HttpRequestMessage();
                    drogueRunController.Request.RequestUri = new System.Uri("http://localhost:5000/api/drogueRun");
                    IHttpActionResult jsonRet3 = drogueRunController.Post(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DrogueRun> drogueRunRet3 = jsonRet3 as CreatedNegotiatedContentResult<DrogueRun>;
                    Assert.NotNull(drogueRunRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = drogueRunController.Delete(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet4 = jsonRet4 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.NotNull(drogueRunRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
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
                    IHttpActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunLast.DrogueRunID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRun> Ret = jsonRet as OkNegotiatedContentResult<DrogueRun>;
                    DrogueRun drogueRunRet = Ret.Content;
                    Assert.Equal(drogueRunLast.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = drogueRunController.Put(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.NotNull(drogueRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because DrogueRunID of 0 does not exist
                    drogueRunRet.DrogueRunID = 0;
                    IHttpActionResult jsonRet3 = drogueRunController.Put(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet3 = jsonRet3 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.IsNull(drogueRunRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    IHttpActionResult jsonRet = drogueRunController.GetDrogueRunWithID(drogueRunLast.DrogueRunID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRun> Ret = jsonRet as OkNegotiatedContentResult<DrogueRun>;
                    DrogueRun drogueRunRet = Ret.Content;
                    Assert.Equal(drogueRunLast.DrogueRunID, drogueRunRet.DrogueRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added DrogueRun
                    drogueRunRet.DrogueRunID = 0;
                    drogueRunController.Request = new System.Net.Http.HttpRequestMessage();
                    drogueRunController.Request.RequestUri = new System.Uri("http://localhost:5000/api/drogueRun");
                    IHttpActionResult jsonRet3 = drogueRunController.Post(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DrogueRun> drogueRunRet3 = jsonRet3 as CreatedNegotiatedContentResult<DrogueRun>;
                    Assert.NotNull(drogueRunRet3);
                    DrogueRun drogueRun = drogueRunRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = drogueRunController.Delete(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.NotNull(drogueRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because DrogueRunID of 0 does not exist
                    drogueRunRet.DrogueRunID = 0;
                    IHttpActionResult jsonRet4 = drogueRunController.Delete(drogueRunRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<DrogueRun> drogueRunRet4 = jsonRet4 as OkNegotiatedContentResult<DrogueRun>;
                    Assert.IsNull(drogueRunRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
