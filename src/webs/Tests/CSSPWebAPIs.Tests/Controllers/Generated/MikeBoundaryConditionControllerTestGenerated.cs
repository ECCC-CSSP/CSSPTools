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
    public partial class MikeBoundaryConditionControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MikeBoundaryCondition_Controller_GetMikeBoundaryConditionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeBoundaryConditionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionFirst = new MikeBoundaryCondition();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionFirst = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                        count = (from c in db.MikeBoundaryConditions select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeBoundaryCondition info
                    IHttpActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeBoundaryCondition>> ret = jsonRet as OkNegotiatedContentResult<List<MikeBoundaryCondition>>;
                    Assert.AreEqual(mikeBoundaryConditionFirst.MikeBoundaryConditionID, ret.Content[0].MikeBoundaryConditionID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionList = (from c in db.MikeBoundaryConditions select c).OrderBy(c => c.MikeBoundaryConditionID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeBoundaryConditions select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeBoundaryCondition info
                        jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeBoundaryCondition>>;
                        Assert.AreEqual(mikeBoundaryConditionList[0].MikeBoundaryConditionID, ret.Content[0].MikeBoundaryConditionID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeBoundaryCondition info
                           IHttpActionResult jsonRet2 = mikeBoundaryConditionController.GetMikeBoundaryConditionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeBoundaryCondition>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeBoundaryCondition>>;
                           Assert.AreEqual(mikeBoundaryConditionList[1].MikeBoundaryConditionID, ret2.Content[0].MikeBoundaryConditionID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MikeBoundaryCondition_Controller_GetMikeBoundaryConditionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeBoundaryConditionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionFirst = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query(), db, ContactID);
                        mikeBoundaryConditionFirst = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IHttpActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionFirst.MikeBoundaryConditionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.AreEqual(mikeBoundaryConditionFirst.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNull(mikeBoundaryConditionRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MikeBoundaryCondition_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeBoundaryConditionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionLast = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionLast = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IHttpActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionLast.MikeBoundaryConditionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.AreEqual(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MikeBoundaryConditionID exist
                    IHttpActionResult jsonRet2 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNull(mikeBoundaryConditionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MikeBoundaryCondition
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    mikeBoundaryConditionController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeBoundaryConditionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeBoundaryCondition");
                    IHttpActionResult jsonRet3 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNotNull(mikeBoundaryConditionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet4 = jsonRet4 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNotNull(mikeBoundaryConditionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MikeBoundaryCondition_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeBoundaryConditionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionLast = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionLast = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IHttpActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionLast.MikeBoundaryConditionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.AreEqual(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mikeBoundaryConditionController.Put(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNotNull(mikeBoundaryConditionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MikeBoundaryConditionID of 0 does not exist
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IHttpActionResult jsonRet3 = mikeBoundaryConditionController.Put(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet3 = jsonRet3 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNull(mikeBoundaryConditionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MikeBoundaryCondition_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeBoundaryConditionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionLast = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionLast = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IHttpActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionLast.MikeBoundaryConditionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.AreEqual(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MikeBoundaryCondition
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    mikeBoundaryConditionController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeBoundaryConditionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeBoundaryCondition");
                    IHttpActionResult jsonRet3 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNotNull(mikeBoundaryConditionRet3);
                    MikeBoundaryCondition mikeBoundaryCondition = mikeBoundaryConditionRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNotNull(mikeBoundaryConditionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MikeBoundaryConditionID of 0 does not exist
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IHttpActionResult jsonRet4 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet4 = jsonRet4 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.IsNull(mikeBoundaryConditionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
