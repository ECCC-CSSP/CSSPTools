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
    public partial class MWQMAnalysisReportParameterControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MWQMAnalysisReportParameter_Controller_GetMWQMAnalysisReportParameterList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmAnalysisReportParameterController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                        count = (from c in db.MWQMAnalysisReportParameters select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IHttpActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>>;
                    Assert.AreEqual(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, ret.Content[0].MWQMAnalysisReportParameterID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterList = (from c in db.MWQMAnalysisReportParameters select c).OrderBy(c => c.MWQMAnalysisReportParameterID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMAnalysisReportParameters select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMAnalysisReportParameter info
                        jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>>;
                        Assert.AreEqual(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID, ret.Content[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMAnalysisReportParameter info
                           IHttpActionResult jsonRet2 = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>>;
                           Assert.AreEqual(mwqmAnalysisReportParameterList[1].MWQMAnalysisReportParameterID, ret2.Content[0].MWQMAnalysisReportParameterID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMAnalysisReportParameter_Controller_GetMWQMAnalysisReportParameterWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmAnalysisReportParameterController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query(), db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IHttpActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.AreEqual(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNull(mwqmAnalysisReportParameterRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMAnalysisReportParameter_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmAnalysisReportParameterController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterLast = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterLast = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IHttpActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.AreEqual(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMAnalysisReportParameterID exist
                    IHttpActionResult jsonRet2 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNull(mwqmAnalysisReportParameterRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMAnalysisReportParameter
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    mwqmAnalysisReportParameterController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmAnalysisReportParameterController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmAnalysisReportParameter");
                    IHttpActionResult jsonRet3 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMAnalysisReportParameter_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmAnalysisReportParameterController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterLast = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterLast = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IHttpActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.AreEqual(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMAnalysisReportParameterID of 0 does not exist
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IHttpActionResult jsonRet3 = mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNull(mwqmAnalysisReportParameterRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMAnalysisReportParameter_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmAnalysisReportParameterController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterLast = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterLast = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IHttpActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.AreEqual(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMAnalysisReportParameter
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    mwqmAnalysisReportParameterController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmAnalysisReportParameterController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmAnalysisReportParameter");
                    IHttpActionResult jsonRet3 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet3);
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = mwqmAnalysisReportParameterRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMAnalysisReportParameterID of 0 does not exist
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IHttpActionResult jsonRet4 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.IsNull(mwqmAnalysisReportParameterRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
