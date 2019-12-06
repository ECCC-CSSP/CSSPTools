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
    public partial class DrogueRunPositionControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunPositionControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void DrogueRunPosition_Controller_GetDrogueRunPositionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(drogueRunPositionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionFirst = new DrogueRunPosition();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionFirst = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                        count = (from c in db.DrogueRunPositions select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<DrogueRunPosition>> ret = jsonRet as OkNegotiatedContentResult<List<DrogueRunPosition>>;
                    Assert.AreEqual(drogueRunPositionFirst.DrogueRunPositionID, ret.Content[0].DrogueRunPositionID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<DrogueRunPosition> drogueRunPositionList = new List<DrogueRunPosition>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionList = (from c in db.DrogueRunPositions select c).OrderBy(c => c.DrogueRunPositionID).Skip(0).Take(2).ToList();
                        count = (from c in db.DrogueRunPositions select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with DrogueRunPosition info
                        jsonRet = drogueRunPositionController.GetDrogueRunPositionList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<DrogueRunPosition>>;
                        Assert.AreEqual(drogueRunPositionList[0].DrogueRunPositionID, ret.Content[0].DrogueRunPositionID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DrogueRunPosition info
                           IHttpActionResult jsonRet2 = drogueRunPositionController.GetDrogueRunPositionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<DrogueRunPosition>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<DrogueRunPosition>>;
                           Assert.AreEqual(drogueRunPositionList[1].DrogueRunPositionID, ret2.Content[0].DrogueRunPositionID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void DrogueRunPosition_Controller_GetDrogueRunPositionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(drogueRunPositionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionFirst = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query(), db, ContactID);
                        drogueRunPositionFirst = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionFirst.DrogueRunPositionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.AreEqual(drogueRunPositionFirst.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = drogueRunPositionController.GetDrogueRunPositionWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void DrogueRunPosition_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(drogueRunPositionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.AreEqual(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because DrogueRunPositionID exist
                    IHttpActionResult jsonRet2 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added DrogueRunPosition
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    drogueRunPositionController.Request = new System.Net.Http.HttpRequestMessage();
                    drogueRunPositionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/drogueRunPosition");
                    IHttpActionResult jsonRet3 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet3 = jsonRet3 as CreatedNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNotNull(drogueRunPositionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet4 = jsonRet4 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNotNull(drogueRunPositionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void DrogueRunPosition_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(drogueRunPositionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.AreEqual(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = drogueRunPositionController.Put(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNotNull(drogueRunPositionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because DrogueRunPositionID of 0 does not exist
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IHttpActionResult jsonRet3 = drogueRunPositionController.Put(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet3 = jsonRet3 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void DrogueRunPosition_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(drogueRunPositionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.AreEqual(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added DrogueRunPosition
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    drogueRunPositionController.Request = new System.Net.Http.HttpRequestMessage();
                    drogueRunPositionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/drogueRunPosition");
                    IHttpActionResult jsonRet3 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet3 = jsonRet3 as CreatedNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNotNull(drogueRunPositionRet3);
                    DrogueRunPosition drogueRunPosition = drogueRunPositionRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNotNull(drogueRunPositionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because DrogueRunPositionID of 0 does not exist
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IHttpActionResult jsonRet4 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet4 = jsonRet4 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
