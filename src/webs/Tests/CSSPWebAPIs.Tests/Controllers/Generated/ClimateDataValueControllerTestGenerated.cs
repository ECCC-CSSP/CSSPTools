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
    public partial class ClimateDataValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateDataValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void ClimateDataValue_Controller_GetClimateDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueFirst = new ClimateDataValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueFirst = (from c in db.ClimateDataValues select c).FirstOrDefault();
                        count = (from c in db.ClimateDataValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ClimateDataValue info
                    IHttpActionResult jsonRet = climateDataValueController.GetClimateDataValueList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ClimateDataValue>> ret = jsonRet as OkNegotiatedContentResult<List<ClimateDataValue>>;
                    Assert.AreEqual(climateDataValueFirst.ClimateDataValueID, ret.Content[0].ClimateDataValueID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueList = (from c in db.ClimateDataValues select c).OrderBy(c => c.ClimateDataValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.ClimateDataValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ClimateDataValue info
                        jsonRet = climateDataValueController.GetClimateDataValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ClimateDataValue>>;
                        Assert.AreEqual(climateDataValueList[0].ClimateDataValueID, ret.Content[0].ClimateDataValueID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ClimateDataValue info
                           IHttpActionResult jsonRet2 = climateDataValueController.GetClimateDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ClimateDataValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ClimateDataValue>>;
                           Assert.AreEqual(climateDataValueList[1].ClimateDataValueID, ret2.Content[0].ClimateDataValueID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ClimateDataValue_Controller_GetClimateDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueFirst = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query(), db, ContactID);
                        climateDataValueFirst = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IHttpActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueFirst.ClimateDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.AreEqual(climateDataValueFirst.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = climateDataValueController.GetClimateDataValueWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNull(climateDataValueRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ClimateDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueLast = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueLast = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IHttpActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueLast.ClimateDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.AreEqual(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ClimateDataValueID exist
                    IHttpActionResult jsonRet2 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNull(climateDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ClimateDataValue
                    climateDataValueRet.ClimateDataValueID = 0;
                    climateDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    climateDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/climateDataValue");
                    IHttpActionResult jsonRet3 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ClimateDataValue> climateDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNotNull(climateDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNotNull(climateDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ClimateDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueLast = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueLast = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IHttpActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueLast.ClimateDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.AreEqual(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = climateDataValueController.Put(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNotNull(climateDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ClimateDataValueID of 0 does not exist
                    climateDataValueRet.ClimateDataValueID = 0;
                    IHttpActionResult jsonRet3 = climateDataValueController.Put(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet3 = jsonRet3 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNull(climateDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ClimateDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueLast = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueLast = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IHttpActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueLast.ClimateDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.AreEqual(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ClimateDataValue
                    climateDataValueRet.ClimateDataValueID = 0;
                    climateDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    climateDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/climateDataValue");
                    IHttpActionResult jsonRet3 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ClimateDataValue> climateDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNotNull(climateDataValueRet3);
                    ClimateDataValue climateDataValue = climateDataValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNotNull(climateDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ClimateDataValueID of 0 does not exist
                    climateDataValueRet.ClimateDataValueID = 0;
                    IHttpActionResult jsonRet4 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.IsNull(climateDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
