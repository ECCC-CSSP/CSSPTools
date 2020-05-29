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
    public partial class VPResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void VPResult_Controller_GetVPResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultFirst = new VPResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultFirst = (from c in db.VPResults select c).FirstOrDefault();
                        count = (from c in db.VPResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPResult info
                    IHttpActionResult jsonRet = vpResultController.GetVPResultList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<VPResult>> ret = jsonRet as OkNegotiatedContentResult<List<VPResult>>;
                    Assert.AreEqual(vpResultFirst.VPResultID, ret.Content[0].VPResultID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<VPResult> vpResultList = new List<VPResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultList = (from c in db.VPResults select c).OrderBy(c => c.VPResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPResult info
                        jsonRet = vpResultController.GetVPResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<VPResult>>;
                        Assert.AreEqual(vpResultList[0].VPResultID, ret.Content[0].VPResultID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPResult info
                           IHttpActionResult jsonRet2 = vpResultController.GetVPResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<VPResult>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<VPResult>>;
                           Assert.AreEqual(vpResultList[1].VPResultID, ret2.Content[0].VPResultID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void VPResult_Controller_GetVPResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultFirst = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPResultService vpResultService = new VPResultService(new Query(), db, ContactID);
                        vpResultFirst = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IHttpActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultFirst.VPResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.AreEqual(vpResultFirst.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = vpResultController.GetVPResultWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNull(vpResultRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void VPResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IHttpActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.AreEqual(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because VPResultID exist
                    IHttpActionResult jsonRet2 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNull(vpResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added VPResult
                    vpResultRet.VPResultID = 0;
                    vpResultController.Request = new System.Net.Http.HttpRequestMessage();
                    vpResultController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpResult");
                    IHttpActionResult jsonRet3 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPResult> vpResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPResult>;
                    Assert.IsNotNull(vpResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<VPResult> vpResultRet4 = jsonRet4 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNotNull(vpResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void VPResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IHttpActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.AreEqual(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = vpResultController.Put(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNotNull(vpResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because VPResultID of 0 does not exist
                    vpResultRet.VPResultID = 0;
                    IHttpActionResult jsonRet3 = vpResultController.Put(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<VPResult> vpResultRet3 = jsonRet3 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNull(vpResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void VPResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpResultController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IHttpActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.AreEqual(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added VPResult
                    vpResultRet.VPResultID = 0;
                    vpResultController.Request = new System.Net.Http.HttpRequestMessage();
                    vpResultController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpResult");
                    IHttpActionResult jsonRet3 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPResult> vpResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPResult>;
                    Assert.IsNotNull(vpResultRet3);
                    VPResult vpResult = vpResultRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNotNull(vpResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because VPResultID of 0 does not exist
                    vpResultRet.VPResultID = 0;
                    IHttpActionResult jsonRet4 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<VPResult> vpResultRet4 = jsonRet4 as OkNegotiatedContentResult<VPResult>;
                    Assert.IsNull(vpResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
