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
        [TestMethod]
        public void MWQMRun_Controller_GetMWQMRunList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

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
                    IHttpActionResult jsonRet = mwqmRunController.GetMWQMRunList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMRun>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMRun>>;
                    Assert.AreEqual(mwqmRunFirst.MWQMRunID, ret.Content[0].MWQMRunID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMRun>>;
                        Assert.AreEqual(mwqmRunList[0].MWQMRunID, ret.Content[0].MWQMRunID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMRun info
                           IHttpActionResult jsonRet2 = mwqmRunController.GetMWQMRunList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMRun>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMRun>>;
                           Assert.AreEqual(mwqmRunList[1].MWQMRunID, ret2.Content[0].MWQMRunID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMRun_Controller_GetMWQMRunWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunFirst = new MWQMRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query(), db, ContactID);
                        mwqmRunFirst = (from c in db.MWQMRuns select c).FirstOrDefault();
                    }

                    // ok with MWQMRun info
                    IHttpActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunFirst.MWQMRunID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.AreEqual(mwqmRunFirst.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmRunController.GetMWQMRunWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNull(mwqmRunRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMRun_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

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
                    IHttpActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunLast.MWQMRunID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMRunID exist
                    IHttpActionResult jsonRet2 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNull(mwqmRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMRun
                    mwqmRunRet.MWQMRunID = 0;
                    mwqmRunController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmRunController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmRun");
                    IHttpActionResult jsonRet3 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMRun> mwqmRunRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMRun>;
                    Assert.IsNotNull(mwqmRunRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNotNull(mwqmRunRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMRun_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

                    MWQMRun mwqmRunLast = new MWQMRun();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMRunService mwqmRunService = new MWQMRunService(query, db, ContactID);
                        mwqmRunLast = (from c in db.MWQMRuns select c).FirstOrDefault();
                    }

                    // ok with MWQMRun info
                    IHttpActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunLast.MWQMRunID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmRunController.Put(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNotNull(mwqmRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMRunID of 0 does not exist
                    mwqmRunRet.MWQMRunID = 0;
                    IHttpActionResult jsonRet3 = mwqmRunController.Put(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNull(mwqmRunRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMRun_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunController mwqmRunController = new MWQMRunController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmRunController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmRunController.DatabaseType);

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
                    IHttpActionResult jsonRet = mwqmRunController.GetMWQMRunWithID(mwqmRunLast.MWQMRunID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMRun> Ret = jsonRet as OkNegotiatedContentResult<MWQMRun>;
                    MWQMRun mwqmRunRet = Ret.Content;
                    Assert.AreEqual(mwqmRunLast.MWQMRunID, mwqmRunRet.MWQMRunID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMRun
                    mwqmRunRet.MWQMRunID = 0;
                    mwqmRunController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmRunController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmRun");
                    IHttpActionResult jsonRet3 = mwqmRunController.Post(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMRun> mwqmRunRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMRun>;
                    Assert.IsNotNull(mwqmRunRet3);
                    MWQMRun mwqmRun = mwqmRunRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNotNull(mwqmRunRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMRunID of 0 does not exist
                    mwqmRunRet.MWQMRunID = 0;
                    IHttpActionResult jsonRet4 = mwqmRunController.Delete(mwqmRunRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMRun> mwqmRunRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMRun>;
                    Assert.IsNull(mwqmRunRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
