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
    public partial class MikeScenarioResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MikeScenarioResult_Controller_GetMikeScenarioResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeScenarioResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultFirst = new MikeScenarioResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultFirst = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                        count = (from c in db.MikeScenarioResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeScenarioResult info
                    IHttpActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeScenarioResult>> ret = jsonRet as OkNegotiatedContentResult<List<MikeScenarioResult>>;
                    Assert.AreEqual(mikeScenarioResultFirst.MikeScenarioResultID, ret.Content[0].MikeScenarioResultID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultList = (from c in db.MikeScenarioResults select c).OrderBy(c => c.MikeScenarioResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeScenarioResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeScenarioResult info
                        jsonRet = mikeScenarioResultController.GetMikeScenarioResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeScenarioResult>>;
                        Assert.AreEqual(mikeScenarioResultList[0].MikeScenarioResultID, ret.Content[0].MikeScenarioResultID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeScenarioResult info
                           IHttpActionResult jsonRet2 = mikeScenarioResultController.GetMikeScenarioResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeScenarioResult>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeScenarioResult>>;
                           Assert.AreEqual(mikeScenarioResultList[1].MikeScenarioResultID, ret2.Content[0].MikeScenarioResultID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MikeScenarioResult_Controller_GetMikeScenarioResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeScenarioResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultFirst = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query(), db, ContactID);
                        mikeScenarioResultFirst = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IHttpActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultFirst.MikeScenarioResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenarioResult> Ret = jsonRet as OkNegotiatedContentResult<MikeScenarioResult>;
                    MikeScenarioResult mikeScenarioResultRet = Ret.Content;
                    Assert.AreEqual(mikeScenarioResultFirst.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mikeScenarioResultController.GetMikeScenarioResultWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNull(mikeScenarioResultRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MikeScenarioResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeScenarioResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultLast = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultLast = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IHttpActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultLast.MikeScenarioResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenarioResult> Ret = jsonRet as OkNegotiatedContentResult<MikeScenarioResult>;
                    MikeScenarioResult mikeScenarioResultRet = Ret.Content;
                    Assert.AreEqual(mikeScenarioResultLast.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MikeScenarioResultID exist
                    IHttpActionResult jsonRet2 = mikeScenarioResultController.Post(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNull(mikeScenarioResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MikeScenarioResult
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    mikeScenarioResultController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeScenarioResultController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeScenarioResult");
                    IHttpActionResult jsonRet3 = mikeScenarioResultController.Post(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNotNull(mikeScenarioResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mikeScenarioResultController.Delete(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet4 = jsonRet4 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNotNull(mikeScenarioResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MikeScenarioResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeScenarioResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultLast = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultLast = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IHttpActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultLast.MikeScenarioResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenarioResult> Ret = jsonRet as OkNegotiatedContentResult<MikeScenarioResult>;
                    MikeScenarioResult mikeScenarioResultRet = Ret.Content;
                    Assert.AreEqual(mikeScenarioResultLast.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mikeScenarioResultController.Put(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNotNull(mikeScenarioResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MikeScenarioResultID of 0 does not exist
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    IHttpActionResult jsonRet3 = mikeScenarioResultController.Put(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet3 = jsonRet3 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNull(mikeScenarioResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MikeScenarioResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeScenarioResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultLast = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultLast = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IHttpActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultLast.MikeScenarioResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenarioResult> Ret = jsonRet as OkNegotiatedContentResult<MikeScenarioResult>;
                    MikeScenarioResult mikeScenarioResultRet = Ret.Content;
                    Assert.AreEqual(mikeScenarioResultLast.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MikeScenarioResult
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    mikeScenarioResultController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeScenarioResultController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeScenarioResult");
                    IHttpActionResult jsonRet3 = mikeScenarioResultController.Post(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNotNull(mikeScenarioResultRet3);
                    MikeScenarioResult mikeScenarioResult = mikeScenarioResultRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mikeScenarioResultController.Delete(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNotNull(mikeScenarioResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MikeScenarioResultID of 0 does not exist
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    IHttpActionResult jsonRet4 = mikeScenarioResultController.Delete(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeScenarioResult> mikeScenarioResultRet4 = jsonRet4 as OkNegotiatedContentResult<MikeScenarioResult>;
                    Assert.IsNull(mikeScenarioResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
