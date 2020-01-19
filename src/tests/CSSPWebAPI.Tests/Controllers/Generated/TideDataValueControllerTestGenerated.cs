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
        [Fact]
        public void TideDataValue_Controller_GetTideDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TideDataValue>> ret = jsonRet as OkNegotiatedContentResult<List<TideDataValue>>;
                    Assert.Equal(tideDataValueFirst.TideDataValueID, ret.Content[0].TideDataValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TideDataValue>>;
                        Assert.Equal(tideDataValueList[0].TideDataValueID, ret.Content[0].TideDataValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideDataValue info
                           IHttpActionResult jsonRet2 = tideDataValueController.GetTideDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TideDataValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TideDataValue>>;
                           Assert.Equal(tideDataValueList[1].TideDataValueID, ret2.Content[0].TideDataValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TideDataValue_Controller_GetTideDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query(), db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IHttpActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueFirst.TideDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.Equal(tideDataValueFirst.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tideDataValueController.GetTideDataValueWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TideDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.Equal(tideDataValueLast.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TideDataValueID exist
                    IHttpActionResult jsonRet2 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TideDataValue
                    tideDataValueRet.TideDataValueID = 0;
                    tideDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    tideDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideDataValue");
                    IHttpActionResult jsonRet3 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideDataValue> tideDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideDataValue>;
                    Assert.NotNull(tideDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.NotNull(tideDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TideDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.Equal(tideDataValueLast.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tideDataValueController.Put(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.NotNull(tideDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TideDataValueID of 0 does not exist
                    tideDataValueRet.TideDataValueID = 0;
                    IHttpActionResult jsonRet3 = tideDataValueController.Put(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet3 = jsonRet3 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TideDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideDataValue> Ret = jsonRet as OkNegotiatedContentResult<TideDataValue>;
                    TideDataValue tideDataValueRet = Ret.Content;
                    Assert.Equal(tideDataValueLast.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TideDataValue
                    tideDataValueRet.TideDataValueID = 0;
                    tideDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    tideDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideDataValue");
                    IHttpActionResult jsonRet3 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideDataValue> tideDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideDataValue>;
                    Assert.NotNull(tideDataValueRet3);
                    TideDataValue tideDataValue = tideDataValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.NotNull(tideDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TideDataValueID of 0 does not exist
                    tideDataValueRet.TideDataValueID = 0;
                    IHttpActionResult jsonRet4 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TideDataValue> tideDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<TideDataValue>;
                    Assert.IsNull(tideDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
