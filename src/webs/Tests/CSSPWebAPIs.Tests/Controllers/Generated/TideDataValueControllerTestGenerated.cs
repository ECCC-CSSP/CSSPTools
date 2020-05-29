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
    public partial class TideDataValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideDataValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void TideDataValue_Controller_GetTideDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                        count = (from c in db.TideDataValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TideDataValue info
                    IHttpActionResult jsonRet = tideDataValueController.GetTideDataValueList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<TideDataValue>> ret = jsonRet as OkNegotiatedContentResult<List<TideDataValue>>;
                    Assert.AreEqual(tideDataValueFirst.TideDataValueID, ret.Content[0].TideDataValueID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueList = (from c in db.TideDataValues select c).OrderBy(c => c.TideDataValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.TideDataValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TideDataValue info
                        jsonRet = tideDataValueController.GetTideDataValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TideDataValue>>;
                        Assert.AreEqual(tideDataValueList[0].TideDataValueID, ret.Content[0].TideDataValueID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideDataValue info
                           IHttpActionResult jsonRet2 = tideDataValueController.GetTideDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TideDataValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TideDataValue>>;
                           Assert.AreEqual(tideDataValueList[1].TideDataValueID, ret2.Content[0].TideDataValueID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void TideDataValue_Controller_GetTideDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query(), db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IHttpActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueFirst.TideDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.AreEqual(tideDataValueFirst.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tideDataValueController.GetTideDataValueWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void TideDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueLast = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueLast = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IHttpActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueLast.TideDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.AreEqual(tideDataValueLast.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TideDataValueID exist
                    IHttpActionResult jsonRet2 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added TideDataValue
                    tideDataValueRet.TideDataValueID = 0;
                    tideDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    tideDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideDataValue");
                    IHttpActionResult jsonRet3 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideDataValue> tideDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideDataValue>;
                    Assert.IsNotNull(tideDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNotNull(tideDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void TideDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueLast = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueLast = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IHttpActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueLast.TideDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.AreEqual(tideDataValueLast.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tideDataValueController.Put(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNotNull(tideDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TideDataValueID of 0 does not exist
                    tideDataValueRet.TideDataValueID = 0;
                    IHttpActionResult jsonRet3 = tideDataValueController.Put(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet3 = jsonRet3 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void TideDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideDataValueController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueLast = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueLast = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IHttpActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueLast.TideDataValueID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.AreEqual(tideDataValueLast.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TideDataValue
                    tideDataValueRet.TideDataValueID = 0;
                    tideDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    tideDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideDataValue");
                    IHttpActionResult jsonRet3 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideDataValue> tideDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideDataValue>;
                    Assert.IsNotNull(tideDataValueRet3);
                    TideDataValue tideDataValue = tideDataValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNotNull(tideDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TideDataValueID of 0 does not exist
                    tideDataValueRet.TideDataValueID = 0;
                    IHttpActionResult jsonRet4 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
