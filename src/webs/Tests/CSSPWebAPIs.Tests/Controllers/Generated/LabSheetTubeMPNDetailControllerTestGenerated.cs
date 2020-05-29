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
    public partial class LabSheetTubeMPNDetailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void LabSheetTubeMPNDetail_Controller_GetLabSheetTubeMPNDetailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetTubeMPNDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailFirst = new LabSheetTubeMPNDetail();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailFirst = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                        count = (from c in db.LabSheetTubeMPNDetails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IHttpActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>> ret = jsonRet as OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>>;
                    Assert.AreEqual(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID, ret.Content[0].LabSheetTubeMPNDetailID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailList = (from c in db.LabSheetTubeMPNDetails select c).OrderBy(c => c.LabSheetTubeMPNDetailID).Skip(0).Take(2).ToList();
                        count = (from c in db.LabSheetTubeMPNDetails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with LabSheetTubeMPNDetail info
                        jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>>;
                        Assert.AreEqual(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID, ret.Content[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheetTubeMPNDetail info
                           IHttpActionResult jsonRet2 = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>>;
                           Assert.AreEqual(labSheetTubeMPNDetailList[1].LabSheetTubeMPNDetailID, ret2.Content[0].LabSheetTubeMPNDetailID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void LabSheetTubeMPNDetail_Controller_GetLabSheetTubeMPNDetailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetTubeMPNDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailFirst = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query(), db, ContactID);
                        labSheetTubeMPNDetailFirst = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IHttpActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNull(labSheetTubeMPNDetailRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void LabSheetTubeMPNDetail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetTubeMPNDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailLast = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailLast = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IHttpActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because LabSheetTubeMPNDetailID exist
                    IHttpActionResult jsonRet2 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNull(labSheetTubeMPNDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added LabSheetTubeMPNDetail
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    labSheetTubeMPNDetailController.Request = new System.Net.Http.HttpRequestMessage();
                    labSheetTubeMPNDetailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/labSheetTubeMPNDetail");
                    IHttpActionResult jsonRet3 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNotNull(labSheetTubeMPNDetailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNotNull(labSheetTubeMPNDetailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void LabSheetTubeMPNDetail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetTubeMPNDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailLast = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailLast = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IHttpActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNotNull(labSheetTubeMPNDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because LabSheetTubeMPNDetailID of 0 does not exist
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IHttpActionResult jsonRet3 = labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet3 = jsonRet3 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNull(labSheetTubeMPNDetailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void LabSheetTubeMPNDetail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(labSheetTubeMPNDetailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailLast = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailLast = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IHttpActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.AreEqual(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added LabSheetTubeMPNDetail
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    labSheetTubeMPNDetailController.Request = new System.Net.Http.HttpRequestMessage();
                    labSheetTubeMPNDetailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/labSheetTubeMPNDetail");
                    IHttpActionResult jsonRet3 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNotNull(labSheetTubeMPNDetailRet3);
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = labSheetTubeMPNDetailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNotNull(labSheetTubeMPNDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because LabSheetTubeMPNDetailID of 0 does not exist
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IHttpActionResult jsonRet4 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.IsNull(labSheetTubeMPNDetailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
